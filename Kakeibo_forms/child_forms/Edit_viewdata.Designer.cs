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
            date_btn = new Label();
            title_btn = new Label();
            money_btn = new Label();
            which_label = new Label();
            edit_panel = new Panel();
            label1 = new Label();
            total_money = new Label();
            select_remove_btn = new Button();
            back_btn = new Button();
            edit_panel.SuspendLayout();
            SuspendLayout();
            // 
            // date_btn
            // 
            date_btn.AutoSize = true;
            date_btn.BorderStyle = BorderStyle.Fixed3D;
            date_btn.Cursor = Cursors.Hand;
            date_btn.Font = new Font("MV Boli", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            date_btn.ForeColor = Color.LimeGreen;
            date_btn.Location = new Point(360, 10);
            date_btn.Name = "date_btn";
            date_btn.Size = new Size(92, 43);
            date_btn.TabIndex = 14;
            date_btn.Text = "日付";
            date_btn.MouseClick += date_btn_MouseClick;
            date_btn.MouseEnter += date_btn_MouseEnter;
            date_btn.MouseLeave += date_btn_MouseLeave;
            // 
            // title_btn
            // 
            title_btn.AutoSize = true;
            title_btn.BorderStyle = BorderStyle.Fixed3D;
            title_btn.Cursor = Cursors.Hand;
            title_btn.Font = new Font("MV Boli", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            title_btn.ForeColor = Color.LimeGreen;
            title_btn.Location = new Point(740, 10);
            title_btn.Name = "title_btn";
            title_btn.Size = new Size(125, 43);
            title_btn.TabIndex = 15;
            title_btn.Text = "タイトル";
            title_btn.MouseClick += title_btn_MouseClick;
            title_btn.MouseEnter += date_btn_MouseEnter;
            title_btn.MouseLeave += date_btn_MouseLeave;
            // 
            // money_btn
            // 
            money_btn.AutoSize = true;
            money_btn.BorderStyle = BorderStyle.Fixed3D;
            money_btn.Cursor = Cursors.Hand;
            money_btn.Font = new Font("MV Boli", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            money_btn.ForeColor = Color.LimeGreen;
            money_btn.Location = new Point(1140, 9);
            money_btn.Name = "money_btn";
            money_btn.Size = new Size(92, 43);
            money_btn.TabIndex = 16;
            money_btn.Text = "金額";
            money_btn.MouseClick += money_btn_MouseClick;
            money_btn.MouseEnter += date_btn_MouseEnter;
            money_btn.MouseLeave += date_btn_MouseLeave;
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
            edit_panel.Controls.Add(label1);
            edit_panel.Controls.Add(total_money);
            edit_panel.Controls.Add(select_remove_btn);
            edit_panel.Controls.Add(back_btn);
            edit_panel.Controls.Add(which_label);
            edit_panel.Controls.Add(date_btn);
            edit_panel.Controls.Add(money_btn);
            edit_panel.Controls.Add(title_btn);
            edit_panel.Dock = DockStyle.Fill;
            edit_panel.Location = new Point(0, 0);
            edit_panel.Name = "edit_panel";
            edit_panel.Size = new Size(1660, 879);
            edit_panel.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MV Boli", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LimeGreen;
            label1.Location = new Point(13, 130);
            label1.Name = "label1";
            label1.Size = new Size(73, 31);
            label1.TabIndex = 26;
            label1.Text = "Total";
            // 
            // total_money
            // 
            total_money.AutoSize = true;
            total_money.Font = new Font("MV Boli", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            total_money.ForeColor = Color.LimeGreen;
            total_money.Location = new Point(13, 161);
            total_money.Name = "total_money";
            total_money.Size = new Size(83, 34);
            total_money.TabIndex = 25;
            total_money.Text = "which";
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

        private Label date_btn;
        private Label title_btn;
        private Label money_btn;
        private Label which_label;
        private Panel edit_panel;
        private Button back_btn;
        private Button select_remove_btn;
        private Label total_money;
        private Label label1;
    }
}