namespace study_scheduler.childforms
{
    partial class Edit_time
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
            hour_track = new TrackBar();
            trackBar1 = new TrackBar();
            hour_label = new Label();
            ((System.ComponentModel.ISupportInitialize)hour_track).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // hour_track
            // 
            hour_track.BackColor = Color.Silver;
            hour_track.Location = new Point(312, 12);
            hour_track.Maximum = 23;
            hour_track.Name = "hour_track";
            hour_track.Orientation = Orientation.Vertical;
            hour_track.RightToLeft = RightToLeft.Yes;
            hour_track.Size = new Size(45, 738);
            hour_track.TabIndex = 0;
            hour_track.Value = 23;
            hour_track.Scroll += hour_track_Scroll;
            // 
            // trackBar1
            // 
            trackBar1.BackColor = Color.Silver;
            trackBar1.Location = new Point(557, 12);
            trackBar1.Maximum = 60;
            trackBar1.Name = "trackBar1";
            trackBar1.Orientation = Orientation.Vertical;
            trackBar1.RightToLeft = RightToLeft.Yes;
            trackBar1.Size = new Size(45, 738);
            trackBar1.TabIndex = 1;
            // 
            // hour_label
            // 
            hour_label.AutoSize = true;
            hour_label.Font = new Font("MV Boli", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            hour_label.Location = new Point(226, 307);
            hour_label.Name = "hour_label";
            hour_label.Size = new Size(53, 34);
            hour_label.TabIndex = 2;
            hour_label.Text = "00";
            // 
            // Edit_time
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(727, 762);
            Controls.Add(hour_label);
            Controls.Add(trackBar1);
            Controls.Add(hour_track);
            Name = "Edit_time";
            Text = "Edit_time";
            ((System.ComponentModel.ISupportInitialize)hour_track).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar hour_track;
        private TrackBar trackBar1;
        private Label hour_label;
    }
}