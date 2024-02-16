namespace study_scheduler.Kakeibo_forms.child_forms
{
    partial class Edit_viewdata
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
            label2 = new Label();
            label3 = new Label();
            which_label = new Label();
            edit_panel = new Panel();
            select_remove_btn = new Button();
            back_btn = new Button();
            edit_panel.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MV Boli", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LimeGreen;
            label1.Location = new Point(360, 10);
            label1.Name = "label1";
            label1.Size = new Size(90, 41);
            label1.TabIndex = 14;
            label1.Text = "日付";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("MV Boli", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.LimeGreen;
            label2.Location = new Point(740, 10);
            label2.Name = "label2";
            label2.Size = new Size(123, 41);
            label2.TabIndex = 15;
            label2.Text = "タイトル";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("MV Boli", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.LimeGreen;
            label3.Location = new Point(1140, 9);
            label3.Name = "label3";
            label3.Size = new Size(90, 41);
            label3.TabIndex = 16;
            label3.Text = "金額";
            // 
            // which_label
            // 
            which_label.AutoSize = true;
            which_label.Font = new Font("MV Boli", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            which_label.ForeColor = Color.LimeGreen;
            which_label.Location = new Point(173, 9);
            which_label.Name = "which_label";
            which_label.Size = new Size(99, 41);
            which_label.TabIndex = 17;
            which_label.Text = "which";
            // 
            // edit_panel
            // 
            edit_panel.AutoScroll = true;
            edit_panel.Controls.Add(select_remove_btn);
            edit_panel.Controls.Add(back_btn);
            edit_panel.Controls.Add(which_label);
            edit_panel.Controls.Add(label1);
            edit_panel.Controls.Add(label3);
            edit_panel.Controls.Add(label2);
            edit_panel.Dock = DockStyle.Fill;
            edit_panel.Location = new Point(0, 0);
            edit_panel.Name = "edit_panel";
            edit_panel.Size = new Size(1660, 879);
            edit_panel.TabIndex = 18;
            // 
            // select_remove_btn
            // 
            select_remove_btn.BackColor = Color.FromArgb(50, 50, 50);
            select_remove_btn.Cursor = Cursors.Hand;
            select_remove_btn.FlatStyle = FlatStyle.Flat;
            select_remove_btn.Font = new Font("MV Boli", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            select_remove_btn.ForeColor = Color.LimeGreen;
            select_remove_btn.Location = new Point(13, 303);
            select_remove_btn.Margin = new Padding(4, 3, 4, 3);
            select_remove_btn.Name = "select_remove_btn";
            select_remove_btn.Size = new Size(238, 134);
            select_remove_btn.TabIndex = 24;
            select_remove_btn.Text = "選択削除";
            select_remove_btn.UseVisualStyleBackColor = false;
            select_remove_btn.MouseClick += select_remove_btn_MouseClick;
            select_remove_btn.MouseEnter += edit_panel_MouseEnter;
            select_remove_btn.MouseLeave += edit_panel_MouseLeave;
            // 
            // back_btn
            // 
            back_btn.BackColor = Color.FromArgb(50, 50, 50);
            back_btn.Cursor = Cursors.Hand;
            back_btn.FlatStyle = FlatStyle.Flat;
            back_btn.Font = new Font("MV Boli", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            back_btn.ForeColor = Color.LimeGreen;
            back_btn.Location = new Point(13, 9);
            back_btn.Margin = new Padding(4, 3, 4, 3);
            back_btn.Name = "back_btn";
            back_btn.Size = new Size(119, 51);
            back_btn.TabIndex = 23;
            back_btn.Text = "戻る";
            back_btn.UseVisualStyleBackColor = false;
            back_btn.MouseClick += back_btn_MouseClick;
            back_btn.MouseEnter += edit_panel_MouseEnter;
            back_btn.MouseLeave += edit_panel_MouseLeave;
            // 
            // Edit_viewdata
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(70, 70, 70);
            ClientSize = new Size(1660, 879);
            Controls.Add(edit_panel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Edit_viewdata";
            Text = "Edit_viewdata";
            edit_panel.ResumeLayout(false);
            edit_panel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label which_label;
        private Panel edit_panel;
        private Button back_btn;
        private Button select_remove_btn;
    }
}