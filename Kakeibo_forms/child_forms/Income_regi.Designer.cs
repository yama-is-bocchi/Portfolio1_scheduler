namespace study_scheduler.Kakeibo_forms.child_forms
{
    partial class Income_regi
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
            titlebox = new TextBox();
            show_calender_btn = new Button();
            label1 = new Label();
            title_label = new Label();
            amount_label = new Label();
            amountbox = new TextBox();
            text_box_label = new Label();
            label4 = new Label();
            label5 = new Label();
            calender_panel = new Panel();
            datebox = new Label();
            enter_timer = new System.Windows.Forms.Timer(components);
            high_timer = new System.Windows.Forms.Timer(components);
            Inserted_label = new Label();
            insert_timer = new System.Windows.Forms.Timer(components);
            back_btn = new Button();
            calc_panel = new Panel();
            show_calc_btn = new Button();
            calender_panel.SuspendLayout();
            calc_panel.SuspendLayout();
            SuspendLayout();
            // 
            // ok_btn
            // 
            ok_btn.BackColor = Color.FromArgb(50, 50, 50);
            ok_btn.Cursor = Cursors.Hand;
            ok_btn.FlatStyle = FlatStyle.Flat;
            ok_btn.Font = new Font("MV Boli", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ok_btn.ForeColor = Color.LimeGreen;
            ok_btn.Location = new Point(1075, 591);
            ok_btn.Margin = new Padding(4, 3, 4, 3);
            ok_btn.Name = "ok_btn";
            ok_btn.Size = new Size(262, 100);
            ok_btn.TabIndex = 5;
            ok_btn.Text = "OK";
            ok_btn.UseVisualStyleBackColor = false;
            ok_btn.Enter += ok_btn_Enter;
            ok_btn.MouseClick += ok_btn_MouseClick;
            ok_btn.MouseEnter += Enter_mouse_btn;
            ok_btn.MouseLeave += Leave_mouse_btn;
            // 
            // titlebox
            // 
            titlebox.BackColor = Color.FromArgb(50, 50, 50);
            titlebox.BorderStyle = BorderStyle.FixedSingle;
            titlebox.Cursor = Cursors.Hand;
            titlebox.Font = new Font("MV Boli", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            titlebox.ForeColor = Color.LimeGreen;
            titlebox.Location = new Point(230, 512);
            titlebox.Margin = new Padding(4, 3, 4, 3);
            titlebox.MaxLength = 13;
            titlebox.Multiline = true;
            titlebox.Name = "titlebox";
            titlebox.Size = new Size(430, 57);
            titlebox.TabIndex = 10;
            titlebox.TextChanged += titlebox_TextChanged;
            titlebox.Enter += titlebox_Enter;
            // 
            // show_calender_btn
            // 
            show_calender_btn.BackColor = Color.FromArgb(50, 50, 50);
            show_calender_btn.Cursor = Cursors.Hand;
            show_calender_btn.FlatStyle = FlatStyle.Flat;
            show_calender_btn.Font = new Font("MV Boli", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            show_calender_btn.ForeColor = Color.LimeGreen;
            show_calender_btn.Location = new Point(0, 0);
            show_calender_btn.Margin = new Padding(4, 3, 4, 3);
            show_calender_btn.Name = "show_calender_btn";
            show_calender_btn.Size = new Size(101, 57);
            show_calender_btn.TabIndex = 11;
            show_calender_btn.Text = "show calender";
            show_calender_btn.UseVisualStyleBackColor = false;
            show_calender_btn.MouseClick += show_calender_btn_MouseClick;
            show_calender_btn.MouseEnter += Enter_mouse_btn;
            show_calender_btn.MouseLeave += Leave_mouse_btn;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MV Boli", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LimeGreen;
            label1.Location = new Point(230, 116);
            label1.Name = "label1";
            label1.Size = new Size(90, 41);
            label1.TabIndex = 12;
            label1.Text = "日付";
            // 
            // title_label
            // 
            title_label.AutoSize = true;
            title_label.Font = new Font("MV Boli", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            title_label.ForeColor = Color.LimeGreen;
            title_label.Location = new Point(230, 468);
            title_label.Name = "title_label";
            title_label.Size = new Size(123, 41);
            title_label.TabIndex = 13;
            title_label.Text = "タイトル";
            // 
            // amount_label
            // 
            amount_label.AutoSize = true;
            amount_label.Font = new Font("MV Boli", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            amount_label.ForeColor = Color.LimeGreen;
            amount_label.Location = new Point(838, 116);
            amount_label.Name = "amount_label";
            amount_label.Size = new Size(90, 41);
            amount_label.TabIndex = 15;
            amount_label.Text = "金額";
            // 
            // amountbox
            // 
            amountbox.BackColor = Color.FromArgb(50, 50, 50);
            amountbox.BorderStyle = BorderStyle.FixedSingle;
            amountbox.Cursor = Cursors.Hand;
            amountbox.Font = new Font("MV Boli", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            amountbox.ForeColor = Color.LimeGreen;
            amountbox.Location = new Point(838, 160);
            amountbox.Margin = new Padding(4, 3, 4, 3);
            amountbox.MaxLength = 17;
            amountbox.Multiline = true;
            amountbox.Name = "amountbox";
            amountbox.Size = new Size(499, 57);
            amountbox.TabIndex = 14;
            amountbox.TextChanged += amountbox_TextChanged;
            amountbox.Enter += amountbox_Enter;
            // 
            // text_box_label
            // 
            text_box_label.AutoSize = true;
            text_box_label.Font = new Font("MV Boli", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            text_box_label.Location = new Point(308, 135);
            text_box_label.Name = "text_box_label";
            text_box_label.Size = new Size(185, 25);
            text_box_label.TabIndex = 16;
            text_box_label.Text = "(※YYYY/MM/DD)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("MV Boli", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(343, 481);
            label4.Name = "label4";
            label4.Size = new Size(152, 25);
            label4.TabIndex = 17;
            label4.Text = "(※13文字以内)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("MV Boli", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(934, 129);
            label5.Name = "label5";
            label5.Size = new Size(130, 25);
            label5.TabIndex = 18;
            label5.Text = "(※17桁以内)";
            // 
            // calender_panel
            // 
            calender_panel.Controls.Add(show_calender_btn);
            calender_panel.Location = new Point(501, 169);
            calender_panel.Name = "calender_panel";
            calender_panel.Size = new Size(330, 340);
            calender_panel.TabIndex = 19;
            // 
            // datebox
            // 
            datebox.AutoSize = true;
            datebox.BackColor = Color.FromArgb(50, 50, 50);
            datebox.BorderStyle = BorderStyle.FixedSingle;
            datebox.Font = new Font("MV Boli", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            datebox.ForeColor = Color.LimeGreen;
            datebox.Location = new Point(230, 169);
            datebox.Name = "datebox";
            datebox.Size = new Size(2, 51);
            datebox.TabIndex = 20;
            // 
            // enter_timer
            // 
            enter_timer.Tick += enter_timer_Tick;
            // 
            // high_timer
            // 
            high_timer.Interval = 200;
            high_timer.Tick += high_timer_Tick;
            // 
            // Inserted_label
            // 
            Inserted_label.AutoSize = true;
            Inserted_label.Font = new Font("MV Boli", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Inserted_label.ForeColor = Color.LimeGreen;
            Inserted_label.Location = new Point(441, 30);
            Inserted_label.Name = "Inserted_label";
            Inserted_label.Size = new Size(0, 41);
            Inserted_label.TabIndex = 21;
            Inserted_label.Visible = false;
            // 
            // insert_timer
            // 
            insert_timer.Interval = 5000;
            insert_timer.Tick += insert_timer_Tick;
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
            back_btn.Size = new Size(110, 59);
            back_btn.TabIndex = 22;
            back_btn.Text = "戻る";
            back_btn.UseVisualStyleBackColor = false;
            back_btn.Visible = false;
            back_btn.MouseClick += back_btn_MouseClick;
            // 
            // calc_panel
            // 
            calc_panel.Controls.Add(show_calc_btn);
            calc_panel.Location = new Point(838, 223);
            calc_panel.Name = "calc_panel";
            calc_panel.Size = new Size(410, 360);
            calc_panel.TabIndex = 20;
            // 
            // show_calc_btn
            // 
            show_calc_btn.BackColor = Color.FromArgb(50, 50, 50);
            show_calc_btn.Cursor = Cursors.Hand;
            show_calc_btn.FlatStyle = FlatStyle.Flat;
            show_calc_btn.Font = new Font("MV Boli", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            show_calc_btn.ForeColor = Color.LimeGreen;
            show_calc_btn.Location = new Point(0, 0);
            show_calc_btn.Margin = new Padding(4, 3, 4, 3);
            show_calc_btn.Name = "show_calc_btn";
            show_calc_btn.Size = new Size(101, 57);
            show_calc_btn.TabIndex = 11;
            show_calc_btn.Text = "show calc";
            show_calc_btn.UseVisualStyleBackColor = false;
            show_calc_btn.MouseClick += show_calc_btn_MouseClick;
            show_calc_btn.MouseEnter += Enter_mouse_btn;
            show_calc_btn.MouseLeave += Leave_mouse_btn;
            // 
            // Income_regi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(70, 70, 70);
            ClientSize = new Size(1660, 879);
            Controls.Add(calc_panel);
            Controls.Add(back_btn);
            Controls.Add(Inserted_label);
            Controls.Add(datebox);
            Controls.Add(calender_panel);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(text_box_label);
            Controls.Add(amount_label);
            Controls.Add(amountbox);
            Controls.Add(title_label);
            Controls.Add(label1);
            Controls.Add(titlebox);
            Controls.Add(ok_btn);
            ForeColor = Color.LimeGreen;
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Margin = new Padding(4, 3, 4, 3);
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "Income_regi";
            Text = "Income_regi";
            KeyDown += Income_regi_KeyDown;
            calender_panel.ResumeLayout(false);
            calc_panel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ok_btn;
        private TextBox titlebox;
        private Button show_calender_btn;
        private Label label1;
        private Label title_label;
        private Label amount_label;
        private TextBox amountbox;
        private Label text_box_label;
        private Label label4;
        private Label label5;
        private Panel calender_panel;
        private Label datebox;
        private System.Windows.Forms.Timer enter_timer;
        private System.Windows.Forms.Timer high_timer;
        private Label Inserted_label;
        private System.Windows.Forms.Timer insert_timer;
        private Button back_btn;
        private Panel calc_panel;
        private Button show_calc_btn;
    }
}