namespace study_scheduler.childforms
{
    partial class Daysform
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
            test_btn = new Button();
            SuspendLayout();
            // 
            // test_btn
            // 
            test_btn.Location = new Point(750, 268);
            test_btn.Name = "test_btn";
            test_btn.Size = new Size(75, 88);
            test_btn.TabIndex = 0;
            test_btn.Text = "button1";
            test_btn.UseVisualStyleBackColor = true;
            test_btn.Click += test_btn_Click;
            // 
            // Daysform
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(test_btn);
            Name = "Daysform";
            Text = "Daysform";
            ResumeLayout(false);
        }

        #endregion

        private Button test_btn;
    }
}