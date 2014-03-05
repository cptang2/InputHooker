using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;

using MouseKeyboardActivityMonitor;
// Assembly from http://globalmousekeyhook.codeplex.com/


namespace InputHooker
{
    public partial class RecordTC : Form
    {
        private delegate void setMessage();
        private delegate void clearMessage();
        private setMessage setMDelegate;
        private clearMessage clearMDelegate;

        private bool blockInput = false;
        private bool pause = false;
        private int mouseDownCount = 0;
        private int detents = 0;
        private Thread eventMes;
        string filePath;
        string directoryPath;
        string message;
        string currentDir;
        StreamWriter file;
        
        private Rectangle bounds = Screen.GetBounds(Point.Empty);
        
        public RecordTC()
        {
            InitializeComponent();
            this.BackColor = randomColor();
            ChangeColor.BackColor = this.BackColor;
            ChangeColor.FlatStyle = FlatStyle.Flat;
            ChangeColor.FlatAppearance.BorderSize = 0;

            setMDelegate = new setMessage(setMess);
            clearMDelegate = new clearMessage(clearMess);

            MousePos.ReadOnly = true;
            MousePos.BackColor = Color.Lavender;
            ScreenCoords.ReadOnly = true;
            ScreenCoords.BackColor = Color.Lavender;

            ClickCount.ReadOnly = true;
            ClickCount.BackColor = Color.MintCream;
            MouseBut.ReadOnly = true;
            MouseBut.BackColor = Color.MintCream;
            FileOpen.ReadOnly = true;
            FileOpen.BackColor = Color.MintCream;

            EventLog.ReadOnly = true;
            EventLog.BackColor = this.BackColor;

            mouseKeyEventProvider1.Enabled = true;
            ScreenCoords.Text = "(" + bounds.Left + "," + bounds.Top + "," + bounds.Right + "," + bounds.Bottom + ")";

            saveFileDialog1.Filter = "CSV File |*.csv";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.Title = "Save a CSV File";

            currentDir = Environment.CurrentDirectory;
        }

        //Start event messages on another thread:
        private void eventMessage()
        {
            EventLog.Invoke(setMDelegate);
            Thread.Sleep(10000);

            EventLog.Invoke(clearMDelegate);
        }

        private void setMess()
        {
            EventLog.Text = message;
        }

        private void clearMess()
        {
            EventLog.Clear();
        }

        //Start recording if a valid file was selected:
        private void Record_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(directoryPath))
            {
                EventLog.Text = "Recording";
                blockInput = true;
                file = new StreamWriter(filePath);
            }
            else
            {
                message = "No test case selected";
                eventMes = new Thread(new ThreadStart(eventMessage));
                eventMes.Start();

                while (!eventMes.IsAlive) ;
            }
        }


        //Stop recording and clean up:
        private void StopRecord_Click(object sender, EventArgs e)
        {
            if (blockInput)
            {
                EventLog.Clear();
                blockInput = false;
                mouseDownCount = 0;
                file.Close();
                SaveFile.Enabled = true;
            }
        }


        //Display current mouse position in text box:
        private void mouseKeyEventProvider1_MouseMove(object sender, MouseEventArgs e)
        {
            MousePos.Text = e.X + "," + e.Y;
        }

        //Take a snapshot before handling mousedown event:
        private void mouseKeyEventProvider1_MouseDownExt(object sender, MouseEventExtArgs e)
        {
            MouseBut.Text = "Down";
            detents = 0;
            Detents.Text = detents.ToString();
            if (blockInput)
            {
                e.Handled = true;

                mouseDownCount++;
                ClickCount.Text = mouseDownCount.ToString();
                //downInstance = true;
                saveStep(directoryPath);

                e.Handled = false;

                file.WriteLine(e.Timestamp);
                file.WriteLine("{0},{1},{2}", e.Button.ToString(), e.X, e.Y);
            }
        }

        //Record mouse up event:
        private void mouseKeyEventProvider1_MouseUp(object sender, MouseEventArgs e)
        {
            MouseBut.Text = "Up";

            if (blockInput)
                file.WriteLine("up{0},{1},{2}", e.Button, e.X, e.Y);
        }

        //Record doubleclick event:
        private void mouseKeyEventProvider1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (blockInput)
                file.WriteLine("doubleclick{0},{1},{2}", e.Button, e.X, e.Y);
        }

        //Save current screen:
        private void saveStep(string path)
        {
            //Save the full screen:
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }

                int post = 0;
                while (File.Exists(Path.Combine(path, post + ".png")))
                {
                    post++;
                }

                bitmap.Save(Path.Combine(path, post + ".png"));
                file.WriteLine("image,{0}", post + ".png");
            }
        }

        //Open the save file dialog:
        private void SaveFile_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();

            filePath = saveFileDialog1.FileName;

            if (filePath.Length > 0)
            {
                directoryPath = Path.Combine(Path.GetDirectoryName(filePath),
                                Path.GetFileNameWithoutExtension(saveFileDialog1.FileName));

                if (!File.Exists(filePath) && !Directory.Exists(directoryPath))
                {
                    //File.Create(saveFileDialog1.FileName);
                    Directory.CreateDirectory(directoryPath);
                    ClickCount.Text = "0";
                    File.Copy(Path.Combine(currentDir, "blankConfig.xml"),
                                Path.Combine(directoryPath, "config.xml"));
                    FileOpen.Text = Path.GetFileName(saveFileDialog1.FileName);
                    SaveFile.Enabled = false;
                }
            }
        }

        //Record Key up:
        private void mouseKeyEventProvider1_KeyUp(object sender, KeyEventArgs e)
        {
            if (blockInput)
                file.WriteLine("keyup,{0}", (int)e.KeyCode);
        }

        //Change GUI color randomly:
        private Color randomColor()
        {
            Random random = new Random();
            return Color.FromArgb(255, random.Next(1, 255), random.Next(1, 255), random.Next(1, 255));
        }

        private void ChangeColor_Click(object sender, EventArgs e)
        {
            this.BackColor = randomColor();
            EventLog.BackColor = this.BackColor;
            ChangeColor.BackColor = this.BackColor;
        }

        private void mouseKeyEventProvider1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == 44)
                e.Handled = true;

            if (blockInput && (int)e.KeyCode == 44)
            {
                EventLog.Text = "Paused";
                pause = true;
                blockInput = false;
                Record.Enabled = false;
                StopRecord.Enabled = false;
            }
            else if (pause && !blockInput && (int)e.KeyCode == 44)
            {
                EventLog.Text = "Recording";
                blockInput = true;
                pause = false;
                Record.Enabled = true;
                StopRecord.Enabled = true;
            }

            if (blockInput)
                file.WriteLine("keydown,{0}", (int)e.KeyCode);
        }

        private void mouseKeyEventProvider1_MouseWheel(object sender, MouseEventArgs e)
        {
            detents += e.Delta;
            Detents.Text = detents.ToString();
            if (blockInput)
            {
                file.WriteLine("detent,{0},{1},{2}", e.X, e.Y, e.Delta);
            }
        }
    }
}