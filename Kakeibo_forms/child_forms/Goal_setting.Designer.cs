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
            components = new System.ComponentModel.Container();
            amount_label = new Label();
            title_label = new Label();
            amountbox = new TextBox();
            Title_list_view = new Panel();
            tree_btn = new Label();
            cur_view_title = new Label();
            which_label = new Label();
            label3 = new Label();
            ok_btn = new Button();
            cancel_btn = new Button();
            high_timer = new System.Windows.Forms.Timer(components);
            Title_list_view.SuspendLayout();
            SuspendLayout();
            // 
            // amount_label
            // 
            amount_label.AutoSize = true;
            amount_label.Font = new Font("MV Boli", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            amount_label.ForeColor = Color.LimeGreen;
            amount_label.Location = new Point(182, 71);
            amount_label.Name = "amount_label";
            amount_label.Size = new Size(162, 41);
            amount_label.TabIndex = 15;
            amount_label.Text = "目標金額";
            // 
            // title_label
            // 
            title_label.AutoSize = true;
            title_label.Font = new Font("MV Boli", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            title_label.ForeColor = Color.LimeGreen;
            title_label.Location = new Point(824, 71);
            title_label.Name = "title_label";
            title_label.Size = new Size(123, 41);
            title_label.TabIndex = 16;
            title_label.Text = "タイトル";
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
            amountbox.TextChanged += amountbox_TextChanged;
            // 
            // Title_list_view
            // 
            Title_list_view.AutoScroll = true;
            Title_list_view.BackColor = Color.FromArgb(50, 50, 50);
            Title_list_view.BorderStyle = BorderStyle.FixedSingle;
            Title_list_view.Controls.Add(tree_btn);
            Title_list_view.Controls.Add(cur_view_title);
            Title_list_view.Cursor = Cursors.Hand;
            Title_list_view.Location = new Point(824, 115);
            Title_list_view.Name = "Title_list_view";
            Title_list_view.Size = new Size(366, 57);
            Title_list_view.TabIndex = 18;
            Title_list_view.MouseClick += List_mouse_click;
            // 
            // tree_btn
            // 
            tree_btn.AutoSize = true;
            tree_btn.Font = new Font("MV Boli", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tree_btn.ForeColor = Color.LimeGreen;
            tree_btn.Location = new Point(306, 6);
            tree_btn.Name = "tree_btn";
            tree_btn.Size = new Size(36, 41);
            tree_btn.TabIndex = 20;
            tree_btn.Text = "⇩";
            tree_btn.MouseClick += List_mouse_click;
            // 
            // cur_view_title
            // 
            cur_view_title.AutoSize = true;
            cur_view_title.Font = new Font("MV Boli", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cur_view_title.ForeColor = Color.LimeGreen;
            cur_view_title.Location = new Point(14, 15);
            cur_view_title.Name = "cur_view_title";
            cur_view_title.Size = new Size(0, 25);
            cur_view_title.TabIndex = 19;
            cur_view_title.MouseClick += List_mouse_click;
            // 
            // which_label
            // 
            which_label.AutoSize = true;
            which_label.Font = new Font("MV Boli", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            which_label.ForeColor = Color.LimeGreen;
            which_label.Location = new Point(25, 9);
            which_label.Name = "which_label";
            which_label.Size = new Size(210, 41);
            which_label.TabIndex = 19;
            which_label.Text = "Goal amount";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("MV Boli", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.LimeGreen;
            label3.Location = new Point(350, 82);
            label3.Name = "label3";
            label3.Size = new Size(138, 28);
            label3.TabIndex = 20;
            label3.Text = "(※17桁以内)";
            // 
            // ok_btn
            // 
            ok_btn.BackColor = Color.FromArgb(50, 50, 50);
            ok_btn.Cursor = Cursors.Hand;
            ok_btn.FlatStyle = FlatStyle.Flat;
            ok_btn.Font = new Font("MV Boli", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ok_btn.ForeColor = Color.LimeGreen;
            ok_btn.Location = new Point(794, 478);
            ok_btn.Margin = new Padding(4, 3, 4, 3);
            ok_btn.Name = "ok_btn";
            ok_btn.Size = new Size(201, 67);
            ok_btn.TabIndex = 21;
            ok_btn.Text = "OK";
            ok_btn.UseVisualStyleBackColor = false;
            ok_btn.MouseClick += ok_btn_MouseClick;
            ok_btn.MouseEnter += ok_btn_MouseEnter;
            ok_btn.MouseLeave += ok_btn_MouseLeave;
            // 
            // cancel_btn
            // 
            cancel_btn.BackColor = Color.FromArgb(50, 50, 50);
            cancel_btn.Cursor = Cursors.Hand;
            cancel_btn.FlatStyle = FlatStyle.Flat;
            cancel_btn.Font = new Font("MV Boli", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cancel_btn.ForeColor = Color.LimeGreen;
            cancel_btn.Location = new Point(509, 478);
            cancel_btn.Margin = new Padding(4, 3, 4, 3);
            cancel_btn.Name = "cancel_btn";
            cancel_btn.Size = new Size(201, 67);
            cancel_btn.TabIndex = 22;
            cancel_btn.Text = "Cancel";
            cancel_btn.UseVisualStyleBackColor = false;
            cancel_btn.MouseClick += cancel_btn_MouseClick;
            cancel_btn.MouseEnter += ok_btn_MouseEnter;
            cancel_btn.MouseLeave += ok_btn_MouseLeave;
            // 
            // high_timer
            // 
            high_timer.Interval = 200;
            high_timer.Tick += high_timer_Tick;
            // 
            // Goal_setting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(70, 70, 70);
            ClientSize = new Size(1644, 840);
            Controls.Add(cancel_btn);
            Controls.Add(ok_btn);
            Controls.Add(label3);
            Controls.Add(which_label);
            Controls.Add(Title_list_view);
            Controls.Add(amountbox);
            Controls.Add(title_label);
            Controls.Add(amount_label);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Name = "Goal_setting";
            Text = "Goal_setting";
            KeyDown += Goal_setting_KeyDown;
            Title_list_view.ResumeLayout(false);
            Title_list_view.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label amount_label;
        private Label title_label;
        private TextBox amountbox;
        private Panel Title_list_view;
        private Label cur_view_title;
        private Label tree_btn;
        private Label which_label;
        private Label label3;
        private Button ok_btn;
        private Button cancel_btn;
        private System.Windows.Forms.Timer high_timer;
    }
}