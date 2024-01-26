namespace study_scheduler
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            weather_pic_box = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)weather_pic_box).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(weather_pic_box);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1784, 172);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            panel1.Resize += panel1_Resize;
            // 
            // weather_pic_box
            // 
            weather_pic_box.Image = (Image)resources.GetObject("weather_pic_box.Image");
            weather_pic_box.Location = new Point(1358, 12);
            weather_pic_box.Name = "weather_pic_box";
            weather_pic_box.Size = new Size(82, 82);
            weather_pic_box.TabIndex = 0;
            weather_pic_box.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1784, 861);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)weather_pic_box).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox weather_pic_box;
    }
}
