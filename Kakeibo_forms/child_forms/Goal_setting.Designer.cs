namespace study_scheduler.Kakeibo_forms.child_forms
{
    partial class Goal_setting
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
            label2 = new Label();
            label1 = new Label();
            amountbox = new TextBox();
            treeView1 = new TreeView();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("MV Boli", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.LimeGreen;
            label2.Location = new Point(182, 71);
            label2.Name = "label2";
            label2.Size = new Size(210, 41);
            label2.TabIndex = 15;
            label2.Text = "Goal amount";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MV Boli", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LimeGreen;
            label1.Location = new Point(880, 71);
            label1.Name = "label1";
            label1.Size = new Size(210, 41);
            label1.TabIndex = 16;
            label1.Text = "Goal amount";
            // 
            // amountbox
            // 
            amountbox.BackColor = Color.FromArgb(50, 50, 50);
            amountbox.BorderStyle = BorderStyle.FixedSingle;
            amountbox.Cursor = Cursors.Hand;
            amountbox.Font = new Font("MV Boli", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            amountbox.ForeColor = Color.LimeGreen;
            amountbox.Location = new Point(182, 115);
            amountbox.Margin = new Padding(4, 3, 4, 3);
            amountbox.MaxLength = 17;
            amountbox.Multiline = true;
            amountbox.Name = "amountbox";
            amountbox.Size = new Size(499, 57);
            amountbox.TabIndex = 17;
            // 
            // treeView1
            // 
            treeView1.Location = new Point(880, 198);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(184, 57);
            treeView1.TabIndex = 18;
            // 
            // Goal_setting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(70, 70, 70);
            ClientSize = new Size(1644, 840);
            Controls.Add(treeView1);
            Controls.Add(amountbox);
            Controls.Add(label1);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Goal_setting";
            Text = "Goal_setting";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label1;
        private TextBox amountbox;
        private TreeView treeView1;
    }
}