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
            minut_track = new TrackBar();
            hour_label = new Label();
            minut_label = new Label();
            cancel_btn = new Button();
            ok_btn = new Button();
            ((System.ComponentModel.ISupportInitialize)hour_track).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minut_track).BeginInit();
            SuspendLayout();
            // 
            // hour_track
            // 
            hour_track.BackColor = Color.Silver;
            hour_track.Cursor = Cursors.Hand;
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
            // minut_track
            // 
            minut_track.BackColor = Color.Silver;
            minut_track.Cursor = Cursors.Hand;
            minut_track.Location = new Point(557, 12);
            minut_track.Maximum = 59;
            minut_track.Name = "minut_track";
            minut_track.Orientation = Orientation.Vertical;
            minut_track.RightToLeft = RightToLeft.Yes;
            minut_track.Size = new Size(45, 738);
            minut_track.TabIndex = 1;
            minut_track.Value = 59;
            minut_track.Scroll += minut_track_Scroll;
            // 
            // hour_label
            // 
            hour_label.AutoSize = true;
            hour_label.Font = new Font("MV Boli", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            hour_label.Location = new Point(188, 317);
            hour_label.Name = "hour_label";
            hour_label.Size = new Size(95, 63);
            hour_label.TabIndex = 2;
            hour_label.Text = "00";
            // 
            // minut_label
            // 
            minut_label.AutoSize = true;
            minut_label.Font = new Font("MV Boli", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            minut_label.Location = new Point(434, 317);
            minut_label.Name = "minut_label";
            minut_label.Size = new Size(95, 63);
            minut_label.TabIndex = 3;
            minut_label.Text = "00";
            // 
            // cancel_btn
            // 
            cancel_btn.Cursor = Cursors.Hand;
            cancel_btn.Font = new Font("MV Boli", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cancel_btn.Location = new Point(102, 12);
            cancel_btn.Name = "cancel_btn";
            cancel_btn.Size = new Size(84, 40);
            cancel_btn.TabIndex = 4;
            cancel_btn.Text = "cancel";
            cancel_btn.UseVisualStyleBackColor = true;
            cancel_btn.MouseClick += cancel_btn_MouseClick;
            // 
            // ok_btn
            // 
            ok_btn.Cursor = Cursors.Hand;
            ok_btn.Font = new Font("MV Boli", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ok_btn.Location = new Point(12, 12);
            ok_btn.Name = "ok_btn";
            ok_btn.Size = new Size(84, 40);
            ok_btn.TabIndex = 5;
            ok_btn.Text = "OK";
            ok_btn.UseVisualStyleBackColor = true;
            ok_btn.MouseClick += ok_btn_MouseClick;
            // 
            // Edit_time
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(727, 762);
            Controls.Add(ok_btn);
            Controls.Add(cancel_btn);
            Controls.Add(minut_label);
            Controls.Add(hour_label);
            Controls.Add(minut_track);
            Controls.Add(hour_track);
            Name = "Edit_time";
            Text = "Edit_time";
            ((System.ComponentModel.ISupportInitialize)hour_track).EndInit();
            ((System.ComponentModel.ISupportInitialize)minut_track).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar hour_track;
        private TrackBar minut_track;
        private Label hour_label;
        private Label minut_label;
        private Button cancel_btn;
        private Button ok_btn;
    }
}