namespace study_scheduler.Kakeibo_forms.child_forms
{
    partial class Zandka_view
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
            label1 = new Label();
            label3 = new Label();
            label2 = new Label();
            back_btn = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MV Boli", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LimeGreen;
            label1.Location = new Point(528, 9);
            label1.Name = "label1";
            label1.Size = new Size(90, 41);
            label1.TabIndex = 17;
            label1.Text = "日付";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("MV Boli", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.LimeGreen;
            label3.Location = new Point(1070, 9);
            label3.Name = "label3";
            label3.Size = new Size(90, 41);
            label3.TabIndex = 18;
            label3.Text = "金額";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("MV Boli", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.LimeGreen;
            label2.Location = new Point(154, 13);
            label2.Name = "label2";
            label2.Size = new Size(90, 41);
            label2.TabIndex = 19;
            label2.Text = "残高";
            // 
            // back_btn
            // 
            back_btn.BackColor = Color.FromArgb(50, 50, 50);
            back_btn.Cursor = Cursors.Hand;
            back_btn.FlatStyle = FlatStyle.Flat;
            back_btn.Font = new Font("MV Boli", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            back_btn.ForeColor = Color.LimeGreen;
            back_btn.Location = new Point(13, 12);
            back_btn.Margin = new Padding(4, 3, 4, 3);
            back_btn.Name = "back_btn";
            back_btn.Size = new Size(119, 51);
            back_btn.TabIndex = 24;
            back_btn.Text = "戻る";
            back_btn.UseVisualStyleBackColor = false;
            back_btn.MouseClick += back_btn_MouseClick;
            back_btn.MouseEnter += back_btn_MouseEnter;
            back_btn.MouseLeave += back_btn_MouseLeave;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(back_btn);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1644, 840);
            panel1.TabIndex = 25;
            // 
            // Zandka_view
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(70, 70, 70);
            ClientSize = new Size(1644, 840);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Zandka_view";
            Text = "Zandka_view";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label3;
        private Label label2;
        private Button back_btn;
        private Panel panel1;
    }
}