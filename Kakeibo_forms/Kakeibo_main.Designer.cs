namespace study_scheduler.Kakeibo_forms
{
    partial class Kakeibo_main
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
            kakeibo_bar_panel = new Panel();
            exit_btn = new Button();
            cur_month_str_label = new Label();
            cur_date_label = new Label();
            cur_page_label = new Label();
            kakeibo_main_panel = new Panel();
            back_to_top_btn = new Button();
            goal_top_btn = new Button();
            income_expen_remain_top_btn = new Button();
            expendi_top_btn = new Button();
            income_top_btn = new Button();
            panel1 = new Panel();
            Back_scheduler = new Button();
            Income_expendi_remain_ref_btn = new Button();
            goal_regi_btn = new Button();
            Expenditure_regi_btn = new Button();
            Income_regi_btn = new Button();
            Top_btn = new Button();
            kakeibo_bar_panel.SuspendLayout();
            kakeibo_main_panel.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // kakeibo_bar_panel
            // 
            kakeibo_bar_panel.BackColor = Color.DarkOrchid;
            kakeibo_bar_panel.BorderStyle = BorderStyle.FixedSingle;
            kakeibo_bar_panel.Controls.Add(Top_btn);
            kakeibo_bar_panel.Controls.Add(exit_btn);
            kakeibo_bar_panel.Controls.Add(cur_month_str_label);
            kakeibo_bar_panel.Controls.Add(cur_date_label);
            kakeibo_bar_panel.Controls.Add(cur_page_label);
            kakeibo_bar_panel.Dock = DockStyle.Top;
            kakeibo_bar_panel.Location = new Point(0, 0);
            kakeibo_bar_panel.Name = "kakeibo_bar_panel";
            kakeibo_bar_panel.Size = new Size(1920, 162);
            kakeibo_bar_panel.TabIndex = 0;
            kakeibo_bar_panel.Paint += kakeibo_bar_panel_Paint;
            kakeibo_bar_panel.Resize += kakeibo_bar_panel_Resize;
            // 
            // exit_btn
            // 
            exit_btn.BackColor = Color.Red;
            exit_btn.Cursor = Cursors.Hand;
            exit_btn.FlatStyle = FlatStyle.Flat;
            exit_btn.Location = new Point(1889, -1);
            exit_btn.Name = "exit_btn";
            exit_btn.Size = new Size(30, 25);
            exit_btn.TabIndex = 17;
            exit_btn.Text = "X";
            exit_btn.UseVisualStyleBackColor = false;
            exit_btn.MouseClick += exit_btn_MouseClick;
            // 
            // cur_month_str_label
            // 
            cur_month_str_label.AutoSize = true;
            cur_month_str_label.BackColor = Color.Fuchsia;
            cur_month_str_label.Font = new Font("Segoe Script", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cur_month_str_label.ForeColor = SystemColors.ActiveCaptionText;
            cur_month_str_label.Location = new Point(0, 57);
            cur_month_str_label.Name = "cur_month_str_label";
            cur_month_str_label.Size = new Size(99, 38);
            cur_month_str_label.TabIndex = 15;
            cur_month_str_label.Text = "month";
            // 
            // cur_date_label
            // 
            cur_date_label.AutoSize = true;
            cur_date_label.BackColor = Color.Fuchsia;
            cur_date_label.Font = new Font("MV Boli", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cur_date_label.ForeColor = SystemColors.ActiveCaptionText;
            cur_date_label.Location = new Point(0, 0);
            cur_date_label.Name = "cur_date_label";
            cur_date_label.Size = new Size(242, 41);
            cur_date_label.TabIndex = 14;
            cur_date_label.Text = "YYYY/MM/DD";
            // 
            // cur_page_label
            // 
            cur_page_label.AutoSize = true;
            cur_page_label.BackColor = Color.Fuchsia;
            cur_page_label.Font = new Font("MV Boli", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cur_page_label.Location = new Point(461, 57);
            cur_page_label.Name = "cur_page_label";
            cur_page_label.Size = new Size(409, 85);
            cur_page_label.TabIndex = 0;
            cur_page_label.Text = "PAGE_DATA";
            // 
            // kakeibo_main_panel
            // 
            kakeibo_main_panel.BackColor = Color.FromArgb(70, 70, 70);
            kakeibo_main_panel.BorderStyle = BorderStyle.FixedSingle;
            kakeibo_main_panel.Controls.Add(back_to_top_btn);
            kakeibo_main_panel.Controls.Add(goal_top_btn);
            kakeibo_main_panel.Controls.Add(income_expen_remain_top_btn);
            kakeibo_main_panel.Controls.Add(expendi_top_btn);
            kakeibo_main_panel.Controls.Add(income_top_btn);
            kakeibo_main_panel.Dock = DockStyle.Top;
            kakeibo_main_panel.Location = new Point(244, 162);
            kakeibo_main_panel.Name = "kakeibo_main_panel";
            kakeibo_main_panel.Size = new Size(1676, 918);
            kakeibo_main_panel.TabIndex = 1;
            // 
            // back_to_top_btn
            // 
            back_to_top_btn.BackColor = Color.FromArgb(50, 50, 50);
            back_to_top_btn.Cursor = Cursors.Hand;
            back_to_top_btn.FlatStyle = FlatStyle.Flat;
            back_to_top_btn.Font = new Font("MV Boli", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            back_to_top_btn.ForeColor = Color.LimeGreen;
            back_to_top_btn.Location = new Point(904, 519);
            back_to_top_btn.Name = "back_to_top_btn";
            back_to_top_btn.Size = new Size(650, 139);
            back_to_top_btn.TabIndex = 4;
            back_to_top_btn.Text = "スケジューラーに戻る";
            back_to_top_btn.UseVisualStyleBackColor = false;
            back_to_top_btn.MouseClick += Back_scheduler_MouseClick;
            back_to_top_btn.MouseEnter += Enter_mouse_btn;
            back_to_top_btn.MouseLeave += Leave_mouse_btn;
            // 
            // goal_top_btn
            // 
            goal_top_btn.BackColor = Color.FromArgb(50, 50, 50);
            goal_top_btn.Cursor = Cursors.Hand;
            goal_top_btn.FlatStyle = FlatStyle.Flat;
            goal_top_btn.Font = new Font("MV Boli", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            goal_top_btn.ForeColor = Color.LimeGreen;
            goal_top_btn.Location = new Point(127, 653);
            goal_top_btn.Name = "goal_top_btn";
            goal_top_btn.Size = new Size(650, 140);
            goal_top_btn.TabIndex = 3;
            goal_top_btn.Text = "目標登録.参照";
            goal_top_btn.UseVisualStyleBackColor = false;
            goal_top_btn.MouseClick += Button_click;
            goal_top_btn.MouseEnter += Enter_mouse_btn;
            goal_top_btn.MouseLeave += Leave_mouse_btn;
            // 
            // income_expen_remain_top_btn
            // 
            income_expen_remain_top_btn.BackColor = Color.FromArgb(50, 50, 50);
            income_expen_remain_top_btn.Cursor = Cursors.Hand;
            income_expen_remain_top_btn.FlatStyle = FlatStyle.Flat;
            income_expen_remain_top_btn.Font = new Font("MV Boli", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            income_expen_remain_top_btn.ForeColor = Color.LimeGreen;
            income_expen_remain_top_btn.Location = new Point(904, 224);
            income_expen_remain_top_btn.Name = "income_expen_remain_top_btn";
            income_expen_remain_top_btn.Size = new Size(650, 139);
            income_expen_remain_top_btn.TabIndex = 2;
            income_expen_remain_top_btn.Text = "収入,支出,残高参照";
            income_expen_remain_top_btn.UseVisualStyleBackColor = false;
            income_expen_remain_top_btn.MouseClick += Button_click;
            income_expen_remain_top_btn.MouseEnter += Enter_mouse_btn;
            income_expen_remain_top_btn.MouseLeave += Leave_mouse_btn;
            // 
            // expendi_top_btn
            // 
            expendi_top_btn.BackColor = Color.FromArgb(50, 50, 50);
            expendi_top_btn.Cursor = Cursors.Hand;
            expendi_top_btn.FlatStyle = FlatStyle.Flat;
            expendi_top_btn.Font = new Font("MV Boli", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            expendi_top_btn.ForeColor = Color.LimeGreen;
            expendi_top_btn.Location = new Point(127, 368);
            expendi_top_btn.Name = "expendi_top_btn";
            expendi_top_btn.Size = new Size(650, 140);
            expendi_top_btn.TabIndex = 1;
            expendi_top_btn.Text = "支出登録";
            expendi_top_btn.UseVisualStyleBackColor = false;
            expendi_top_btn.MouseClick += Button_click;
            expendi_top_btn.MouseEnter += Enter_mouse_btn;
            expendi_top_btn.MouseLeave += Leave_mouse_btn;
            // 
            // income_top_btn
            // 
            income_top_btn.BackColor = Color.FromArgb(50, 50, 50);
            income_top_btn.Cursor = Cursors.Hand;
            income_top_btn.FlatStyle = FlatStyle.Flat;
            income_top_btn.Font = new Font("MV Boli", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            income_top_btn.ForeColor = Color.LimeGreen;
            income_top_btn.Location = new Point(127, 82);
            income_top_btn.Name = "income_top_btn";
            income_top_btn.Size = new Size(650, 140);
            income_top_btn.TabIndex = 0;
            income_top_btn.Text = "収入登録";
            income_top_btn.UseVisualStyleBackColor = false;
            income_top_btn.MouseClick += Button_click;
            income_top_btn.MouseEnter += Enter_mouse_btn;
            income_top_btn.MouseLeave += Leave_mouse_btn;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(55, 55, 55);
            panel1.Controls.Add(Back_scheduler);
            panel1.Controls.Add(Income_expendi_remain_ref_btn);
            panel1.Controls.Add(goal_regi_btn);
            panel1.Controls.Add(Expenditure_regi_btn);
            panel1.Controls.Add(Income_regi_btn);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 162);
            panel1.Name = "panel1";
            panel1.Size = new Size(244, 918);
            panel1.TabIndex = 0;
            // 
            // Back_scheduler
            // 
            Back_scheduler.Cursor = Cursors.Hand;
            Back_scheduler.Dock = DockStyle.Top;
            Back_scheduler.FlatStyle = FlatStyle.Flat;
            Back_scheduler.Font = new Font("MV Boli", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Back_scheduler.ForeColor = Color.LimeGreen;
            Back_scheduler.Location = new Point(0, 540);
            Back_scheduler.Name = "Back_scheduler";
            Back_scheduler.Size = new Size(244, 135);
            Back_scheduler.TabIndex = 4;
            Back_scheduler.Text = "スケジューラに戻る";
            Back_scheduler.UseVisualStyleBackColor = true;
            Back_scheduler.MouseClick += Back_scheduler_MouseClick;
            Back_scheduler.MouseEnter += Enter_mouse_btn;
            Back_scheduler.MouseLeave += Leave_mouse_btn;
            // 
            // Income_expendi_remain_ref_btn
            // 
            Income_expendi_remain_ref_btn.Cursor = Cursors.Hand;
            Income_expendi_remain_ref_btn.Dock = DockStyle.Top;
            Income_expendi_remain_ref_btn.FlatStyle = FlatStyle.Flat;
            Income_expendi_remain_ref_btn.Font = new Font("MV Boli", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Income_expendi_remain_ref_btn.ForeColor = Color.LimeGreen;
            Income_expendi_remain_ref_btn.Location = new Point(0, 405);
            Income_expendi_remain_ref_btn.Name = "Income_expendi_remain_ref_btn";
            Income_expendi_remain_ref_btn.Size = new Size(244, 135);
            Income_expendi_remain_ref_btn.TabIndex = 3;
            Income_expendi_remain_ref_btn.Text = "収入,支出,残高参照";
            Income_expendi_remain_ref_btn.UseVisualStyleBackColor = true;
            Income_expendi_remain_ref_btn.MouseClick += Button_click;
            Income_expendi_remain_ref_btn.MouseEnter += Enter_mouse_btn;
            Income_expendi_remain_ref_btn.MouseLeave += Leave_mouse_btn;
            // 
            // goal_regi_btn
            // 
            goal_regi_btn.Cursor = Cursors.Hand;
            goal_regi_btn.Dock = DockStyle.Top;
            goal_regi_btn.FlatStyle = FlatStyle.Flat;
            goal_regi_btn.Font = new Font("MV Boli", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            goal_regi_btn.ForeColor = Color.LimeGreen;
            goal_regi_btn.Location = new Point(0, 270);
            goal_regi_btn.Name = "goal_regi_btn";
            goal_regi_btn.Size = new Size(244, 135);
            goal_regi_btn.TabIndex = 2;
            goal_regi_btn.Text = "目標登録,参照";
            goal_regi_btn.UseVisualStyleBackColor = true;
            goal_regi_btn.MouseClick += Button_click;
            goal_regi_btn.MouseEnter += Enter_mouse_btn;
            goal_regi_btn.MouseLeave += Leave_mouse_btn;
            // 
            // Expenditure_regi_btn
            // 
            Expenditure_regi_btn.Cursor = Cursors.Hand;
            Expenditure_regi_btn.Dock = DockStyle.Top;
            Expenditure_regi_btn.FlatStyle = FlatStyle.Flat;
            Expenditure_regi_btn.Font = new Font("MV Boli", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Expenditure_regi_btn.ForeColor = Color.LimeGreen;
            Expenditure_regi_btn.Location = new Point(0, 135);
            Expenditure_regi_btn.Name = "Expenditure_regi_btn";
            Expenditure_regi_btn.Size = new Size(244, 135);
            Expenditure_regi_btn.TabIndex = 1;
            Expenditure_regi_btn.Text = "支出登録";
            Expenditure_regi_btn.UseVisualStyleBackColor = true;
            Expenditure_regi_btn.MouseClick += Button_click;
            Expenditure_regi_btn.MouseEnter += Enter_mouse_btn;
            Expenditure_regi_btn.MouseLeave += Leave_mouse_btn;
            // 
            // Income_regi_btn
            // 
            Income_regi_btn.Cursor = Cursors.Hand;
            Income_regi_btn.Dock = DockStyle.Top;
            Income_regi_btn.FlatStyle = FlatStyle.Flat;
            Income_regi_btn.Font = new Font("MV Boli", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Income_regi_btn.ForeColor = Color.LimeGreen;
            Income_regi_btn.Location = new Point(0, 0);
            Income_regi_btn.Name = "Income_regi_btn";
            Income_regi_btn.Size = new Size(244, 135);
            Income_regi_btn.TabIndex = 0;
            Income_regi_btn.Text = "収入登録";
            Income_regi_btn.UseVisualStyleBackColor = true;
            Income_regi_btn.MouseClick += Button_click;
            Income_regi_btn.MouseEnter += Enter_mouse_btn;
            Income_regi_btn.MouseLeave += Leave_mouse_btn;
            // 
            // Top_btn
            // 
            Top_btn.BackColor = Color.Fuchsia;
            Top_btn.Cursor = Cursors.Hand;
            Top_btn.FlatStyle = FlatStyle.Flat;
            Top_btn.Font = new Font("MV Boli", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Top_btn.ForeColor = Color.Black;
            Top_btn.Location = new Point(3, 100);
            Top_btn.Name = "Top_btn";
            Top_btn.Size = new Size(231, 57);
            Top_btn.TabIndex = 5;
            Top_btn.Text = "トップページ";
            Top_btn.UseVisualStyleBackColor = false;
            Top_btn.MouseClick += Top_btn_MouseClick;
            // 
            // Kakeibo_main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1920, 1080);
            Controls.Add(kakeibo_main_panel);
            Controls.Add(panel1);
            Controls.Add(kakeibo_bar_panel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Kakeibo_main";
            Text = "Kakeibo_main";
            kakeibo_bar_panel.ResumeLayout(false);
            kakeibo_bar_panel.PerformLayout();
            kakeibo_main_panel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel kakeibo_bar_panel;
        private Panel kakeibo_main_panel;
        private Label cur_page_label;
        private Label cur_month_str_label;
        private Label cur_date_label;
        private Button exit_btn;
        private Panel panel1;
        private Button Income_regi_btn;
        private Button Back_scheduler;
        private Button Income_expendi_remain_ref_btn;
        private Button goal_regi_btn;
        private Button Expenditure_regi_btn;
        private Button income_top_btn;
        private Button back_to_top_btn;
        private Button goal_top_btn;
        private Button income_expen_remain_top_btn;
        private Button expendi_top_btn;
        private Button Top_btn;
    }
}