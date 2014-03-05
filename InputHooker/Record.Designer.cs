namespace InputHooker
{
    partial class RecordTC
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (eventMes != null && eventMes.IsAlive)
                eventMes.Abort();

            if (file != null)
                file.Close();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mouseKeyEventProvider1 = new MouseKeyboardActivityMonitor.Controls.MouseKeyEventProvider();
            this.MousePos = new System.Windows.Forms.TextBox();
            this.ClickCount = new System.Windows.Forms.TextBox();
            this.ScreenCoords = new System.Windows.Forms.TextBox();
            this.Record = new System.Windows.Forms.Button();
            this.StopRecord = new System.Windows.Forms.Button();
            this.FileOpen = new System.Windows.Forms.TextBox();
            this.SaveFile = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.MouseBut = new System.Windows.Forms.TextBox();
            this.EventLog = new System.Windows.Forms.TextBox();
            this.ChangeColor = new System.Windows.Forms.Button();
            this.Detents = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // mouseKeyEventProvider1
            // 
            this.mouseKeyEventProvider1.Enabled = false;
            this.mouseKeyEventProvider1.HookType = MouseKeyboardActivityMonitor.Controls.HookType.Global;
            this.mouseKeyEventProvider1.MouseDownExt += new System.EventHandler<MouseKeyboardActivityMonitor.MouseEventExtArgs>(this.mouseKeyEventProvider1_MouseDownExt);
            this.mouseKeyEventProvider1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mouseKeyEventProvider1_KeyUp);
            this.mouseKeyEventProvider1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mouseKeyEventProvider1_KeyDown);
            this.mouseKeyEventProvider1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseKeyEventProvider1_MouseUp);
            this.mouseKeyEventProvider1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mouseKeyEventProvider1_MouseDoubleClick);
            this.mouseKeyEventProvider1.MouseWheel += new System.EventHandler<System.Windows.Forms.MouseEventArgs>(this.mouseKeyEventProvider1_MouseWheel);
            this.mouseKeyEventProvider1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseKeyEventProvider1_MouseMove);
            // 
            // MousePos
            // 
            this.MousePos.Cursor = System.Windows.Forms.Cursors.Default;
            this.MousePos.Location = new System.Drawing.Point(12, 99);
            this.MousePos.Name = "MousePos";
            this.MousePos.Size = new System.Drawing.Size(100, 20);
            this.MousePos.TabIndex = 0;
            // 
            // ClickCount
            // 
            this.ClickCount.Cursor = System.Windows.Forms.Cursors.Default;
            this.ClickCount.Location = new System.Drawing.Point(12, 12);
            this.ClickCount.Name = "ClickCount";
            this.ClickCount.Size = new System.Drawing.Size(32, 20);
            this.ClickCount.TabIndex = 1;
            // 
            // ScreenCoords
            // 
            this.ScreenCoords.Cursor = System.Windows.Forms.Cursors.Default;
            this.ScreenCoords.Location = new System.Drawing.Point(12, 125);
            this.ScreenCoords.Name = "ScreenCoords";
            this.ScreenCoords.Size = new System.Drawing.Size(100, 20);
            this.ScreenCoords.TabIndex = 2;
            // 
            // Record
            // 
            this.Record.Location = new System.Drawing.Point(197, 93);
            this.Record.Name = "Record";
            this.Record.Size = new System.Drawing.Size(75, 23);
            this.Record.TabIndex = 3;
            this.Record.Text = "Record";
            this.Record.UseVisualStyleBackColor = true;
            this.Record.Click += new System.EventHandler(this.Record_Click);
            // 
            // StopRecord
            // 
            this.StopRecord.Location = new System.Drawing.Point(197, 122);
            this.StopRecord.Name = "StopRecord";
            this.StopRecord.Size = new System.Drawing.Size(75, 23);
            this.StopRecord.TabIndex = 4;
            this.StopRecord.Text = "Stop Record";
            this.StopRecord.UseVisualStyleBackColor = true;
            this.StopRecord.Click += new System.EventHandler(this.StopRecord_Click);
            // 
            // FileOpen
            // 
            this.FileOpen.Cursor = System.Windows.Forms.Cursors.Default;
            this.FileOpen.Location = new System.Drawing.Point(12, 54);
            this.FileOpen.Name = "FileOpen";
            this.FileOpen.Size = new System.Drawing.Size(228, 20);
            this.FileOpen.TabIndex = 5;
            // 
            // SaveFile
            // 
            this.SaveFile.Location = new System.Drawing.Point(246, 54);
            this.SaveFile.Name = "SaveFile";
            this.SaveFile.Size = new System.Drawing.Size(26, 20);
            this.SaveFile.TabIndex = 6;
            this.SaveFile.UseVisualStyleBackColor = true;
            this.SaveFile.Click += new System.EventHandler(this.SaveFile_Click);
            // 
            // MouseBut
            // 
            this.MouseBut.Cursor = System.Windows.Forms.Cursors.Default;
            this.MouseBut.Location = new System.Drawing.Point(237, 12);
            this.MouseBut.Name = "MouseBut";
            this.MouseBut.Size = new System.Drawing.Size(34, 20);
            this.MouseBut.TabIndex = 7;
            // 
            // EventLog
            // 
            this.EventLog.BackColor = System.Drawing.Color.White;
            this.EventLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EventLog.Cursor = System.Windows.Forms.Cursors.Default;
            this.EventLog.Location = new System.Drawing.Point(13, 151);
            this.EventLog.Name = "EventLog";
            this.EventLog.Size = new System.Drawing.Size(259, 13);
            this.EventLog.TabIndex = 8;
            // 
            // ChangeColor
            // 
            this.ChangeColor.Location = new System.Drawing.Point(1, -4);
            this.ChangeColor.Name = "ChangeColor";
            this.ChangeColor.Size = new System.Drawing.Size(277, 10);
            this.ChangeColor.TabIndex = 10;
            this.ChangeColor.Text = "Change Color";
            this.ChangeColor.UseVisualStyleBackColor = true;
            this.ChangeColor.Click += new System.EventHandler(this.ChangeColor_Click);
            // 
            // Detents
            // 
            this.Detents.Location = new System.Drawing.Point(197, 12);
            this.Detents.Name = "Detents";
            this.Detents.Size = new System.Drawing.Size(31, 20);
            this.Detents.TabIndex = 11;
            // 
            // RecordTC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(284, 167);
            this.Controls.Add(this.Detents);
            this.Controls.Add(this.ChangeColor);
            this.Controls.Add(this.EventLog);
            this.Controls.Add(this.MouseBut);
            this.Controls.Add(this.SaveFile);
            this.Controls.Add(this.FileOpen);
            this.Controls.Add(this.StopRecord);
            this.Controls.Add(this.Record);
            this.Controls.Add(this.ScreenCoords);
            this.Controls.Add(this.ClickCount);
            this.Controls.Add(this.MousePos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RecordTC";
            this.Text = "Record Test Case";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MouseKeyboardActivityMonitor.Controls.MouseKeyEventProvider mouseKeyEventProvider1;
        private System.Windows.Forms.TextBox MousePos;
        private System.Windows.Forms.TextBox ClickCount;
        private System.Windows.Forms.TextBox ScreenCoords;
        private System.Windows.Forms.Button Record;
        private System.Windows.Forms.Button StopRecord;
        private System.Windows.Forms.TextBox FileOpen;
        private System.Windows.Forms.Button SaveFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox MouseBut;
        private System.Windows.Forms.TextBox EventLog;
        private System.Windows.Forms.Button ChangeColor;
        private System.Windows.Forms.TextBox Detents;
    }
}

