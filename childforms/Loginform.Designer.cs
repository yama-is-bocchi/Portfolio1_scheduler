namespace study_scheduler.childforms
{
    partial class Loginform
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
            components = new System.ComponentModel.Container();
            ok_btn = new Button();
            up_or_in_btn = new Button();
            which_label = new Label();
            Password_textbox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            Title_textbox = new TextBox();
            exit_btn = new Button();
            show_pass_check = new CheckBox();
            fault_label = new Label();
            fault_timer = new System.Windows.Forms.Timer(components);
            login_timer = new System.Windows.Forms.Timer(components);
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // ok_btn
            // 
            ok_btn.Cursor = Cursors.Hand;
            ok_btn.FlatStyle = FlatStyle.Flat;
            ok_btn.Font = new Font("MV Boli", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ok_btn.Location = new Point(769, 826);
            ok_btn.Name = "ok_btn";
            ok_btn.Size = new Size(323, 89);
            ok_btn.TabIndex = 0;
            ok_btn.Text = "OK";
            ok_btn.UseVisualStyleBackColor = true;
            ok_btn.MouseClick += ok_btn_MouseClick;
            // 
            // up_or_in_btn
            // 
            up_or_in_btn.Cursor = Cursors.Hand;
            up_or_in_btn.FlatStyle = FlatStyle.Flat;
            up_or_in_btn.Font = new Font("MV Boli", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            up_or_in_btn.Location = new Point(1567, 940);
            up_or_in_btn.Name = "up_or_in_btn";
            up_or_in_btn.Size = new Size(323, 89);
            up_or_in_btn.TabIndex = 1;
            up_or_in_btn.Text = "サインアップ";
            up_or_in_btn.UseVisualStyleBackColor = true;
            up_or_in_btn.MouseClick += up_or_in_btn_MouseClick;
            // 
            // which_label
            // 
            which_label.AutoSize = true;
            which_label.Font = new Font("MV Boli", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            which_label.Location = new Point(12, 9);
            which_label.Name = "which_label";
            which_label.Size = new Size(255, 85);
            which_label.TabIndex = 2;
            which_label.Text = "ログイン";
            // 
            // Password_textbox
            // 
            Password_textbox.BorderStyle = BorderStyle.FixedSingle;
            Password_textbox.Cursor = Cursors.Hand;
            Password_textbox.Font = new Font("Yu Gothic UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 128);
            Password_textbox.Location = new Point(603, 603);
            Password_textbox.MaxLength = 20;
            Password_textbox.Multiline = true;
            Password_textbox.Name = "Password_textbox";
            Password_textbox.Size = new Size(632, 70);
            Password_textbox.TabIndex = 3;
            Password_textbox.TextChanged += Passward_textbox_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("MV Boli", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(603, 551);
            label2.Name = "label2";
            label2.Size = new Size(185, 49);
            label2.TabIndex = 4;
            label2.Text = "パスワード";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("MV Boli", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(603, 238);
            label3.Name = "label3";
            label3.Size = new Size(145, 49);
            label3.TabIndex = 6;
            label3.Text = "タイトル";
            // 
            // Title_textbox
            // 
            Title_textbox.BorderStyle = BorderStyle.FixedSingle;
            Title_textbox.Cursor = Cursors.Hand;
            Title_textbox.Font = new Font("Yu Gothic UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 128);
            Title_textbox.Location = new Point(603, 300);
            Title_textbox.MaxLength = 20;
            Title_textbox.Multiline = true;
            Title_textbox.Name = "Title_textbox";
            Title_textbox.Size = new Size(632, 70);
            Title_textbox.TabIndex = 5;
            Title_textbox.TextChanged += Title_textbox_TextChanged;
            // 
            // exit_btn
            // 
            exit_btn.BackColor = Color.Red;
            exit_btn.Cursor = Cursors.Hand;
            exit_btn.FlatStyle = FlatStyle.Flat;
            exit_btn.Location = new Point(1891, -1);
            exit_btn.Name = "exit_btn";
            exit_btn.Size = new Size(30, 25);
            exit_btn.TabIndex = 28;
            exit_btn.Text = "X";
            exit_btn.UseVisualStyleBackColor = false;
            exit_btn.MouseClick += exit_btn_MouseClick;
            // 
            // show_pass_check
            // 
            show_pass_check.AutoSize = true;
            show_pass_check.Cursor = Cursors.Hand;
            show_pass_check.Font = new Font("MV Boli", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            show_pass_check.Location = new Point(794, 579);
            show_pass_check.Name = "show_pass_check";
            show_pass_check.RightToLeft = RightToLeft.Yes;
            show_pass_check.Size = new Size(130, 21);
            show_pass_check.TabIndex = 29;
            show_pass_check.Text = "パスワードを見せる";
            show_pass_check.UseVisualStyleBackColor = true;
            show_pass_check.CheckedChanged += show_pass_check_CheckedChanged;
            // 
            // fault_label
            // 
            fault_label.AutoSize = true;
            fault_label.Font = new Font("MV Boli", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fault_label.Location = new Point(603, 18);
            fault_label.Name = "fault_label";
            fault_label.Size = new Size(0, 63);
            fault_label.TabIndex = 30;
            // 
            // fault_timer
            // 
            fault_timer.Interval = 200;
            fault_timer.Tick += fault_timer_Tick;
            // 
            // login_timer
            // 
            login_timer.Interval = 2000;
            login_timer.Tick += login_timer_Tick;
            // 
            // panel1
            // 
            panel1.Controls.Add(which_label);
            panel1.Controls.Add(show_pass_check);
            panel1.Controls.Add(up_or_in_btn);
            panel1.Controls.Add(Title_textbox);
            panel1.Controls.Add(ok_btn);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(Password_textbox);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1920, 1080);
            panel1.TabIndex = 31;
            // 
            // Loginform
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1920, 1080);
            Controls.Add(fault_label);
            Controls.Add(exit_btn);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Name = "Loginform";
            Text = "Loginform";
            KeyDown += Loginform_KeyDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ok_btn;
        private Button up_or_in_btn;
        private Label which_label;
        private TextBox Password_textbox;
        private Label label2;
        private Label label3;
        private TextBox Title_textbox;
        private Button exit_btn;
        private CheckBox show_pass_check;
        private Label fault_label;
        private System.Windows.Forms.Timer fault_timer;
        private System.Windows.Forms.Timer login_timer;
        private Panel panel1;
    }
}