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
            components = new System.ComponentModel.Container();
            cur_panel = new Panel();
            cur_month_num_label = new Label();
            cur_month_str_label = new Label();
            cur_year_label = new Label();
            label6 = new Label();
            temp_min_label = new Label();
            label5 = new Label();
            label4 = new Label();
            temp_max_label = new Label();
            now_time_label = new Label();
            today_date_label = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            next_btn = new Button();
            previous_btn = new Button();
            weather_pic_box = new PictureBox();
            change_second_timer = new System.Windows.Forms.Timer(components);
            form_panel = new Panel();
            cur_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)weather_pic_box).BeginInit();
            SuspendLayout();
            // 
            // cur_panel
            // 
            cur_panel.Controls.Add(cur_month_num_label);
            cur_panel.Controls.Add(cur_month_str_label);
            cur_panel.Controls.Add(cur_year_label);
            cur_panel.Controls.Add(label6);
            cur_panel.Controls.Add(temp_min_label);
            cur_panel.Controls.Add(label5);
            cur_panel.Controls.Add(label4);
            cur_panel.Controls.Add(temp_max_label);
            cur_panel.Controls.Add(now_time_label);
            cur_panel.Controls.Add(today_date_label);
            cur_panel.Controls.Add(label3);
            cur_panel.Controls.Add(label2);
            cur_panel.Controls.Add(label1);
            cur_panel.Controls.Add(next_btn);
            cur_panel.Controls.Add(previous_btn);
            cur_panel.Controls.Add(weather_pic_box);
            cur_panel.Dock = DockStyle.Top;
            cur_panel.Location = new Point(0, 0);
            cur_panel.Name = "cur_panel";
            cur_panel.Size = new Size(1904, 160);
            cur_panel.TabIndex = 0;
            cur_panel.Paint += panel1_Paint;
            cur_panel.Resize += panel1_Resize;
            // 
            // cur_month_num_label
            // 
            cur_month_num_label.AutoSize = true;
            cur_month_num_label.BackColor = Color.Cyan;
            cur_month_num_label.Font = new Font("游明朝 Light", 72F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cur_month_num_label.ForeColor = SystemColors.ActiveCaptionText;
            cur_month_num_label.Location = new Point(939, 29);
            cur_month_num_label.Name = "cur_month_num_label";
            cur_month_num_label.Size = new Size(100, 124);
            cur_month_num_label.TabIndex = 14;
            cur_month_num_label.Text = "1";
            // 
            // cur_month_str_label
            // 
            cur_month_str_label.AutoSize = true;
            cur_month_str_label.BackColor = Color.SpringGreen;
            cur_month_str_label.Font = new Font("MV Boli", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cur_month_str_label.ForeColor = SystemColors.ActiveCaptionText;
            cur_month_str_label.Location = new Point(25, 43);
            cur_month_str_label.Name = "cur_month_str_label";
            cur_month_str_label.Size = new Size(115, 41);
            cur_month_str_label.TabIndex = 13;
            cur_month_str_label.Text = "month";
            // 
            // cur_year_label
            // 
            cur_year_label.AutoSize = true;
            cur_year_label.BackColor = Color.SpringGreen;
            cur_year_label.Font = new Font("MV Boli", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cur_year_label.ForeColor = SystemColors.ActiveCaptionText;
            cur_year_label.Location = new Point(25, 2);
            cur_year_label.Name = "cur_year_label";
            cur_year_label.Size = new Size(81, 41);
            cur_year_label.TabIndex = 12;
            cur_year_label.Text = "year";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Cyan;
            label6.Font = new Font("游ゴシック Light", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ActiveCaptionText;
            label6.Location = new Point(1577, 103);
            label6.Name = "label6";
            label6.Size = new Size(29, 17);
            label6.TabIndex = 11;
            label6.Text = "min";
            // 
            // temp_min_label
            // 
            temp_min_label.AutoSize = true;
            temp_min_label.BackColor = Color.Cyan;
            temp_min_label.Font = new Font("Arial", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            temp_min_label.ForeColor = SystemColors.ActiveCaptionText;
            temp_min_label.Location = new Point(1577, 120);
            temp_min_label.Name = "temp_min_label";
            temp_min_label.Size = new Size(47, 33);
            temp_min_label.TabIndex = 10;
            temp_min_label.Text = "00";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Cyan;
            label5.Font = new Font("メイリオ", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(1549, 125);
            label5.Name = "label5";
            label5.Size = new Size(31, 28);
            label5.TabIndex = 9;
            label5.Text = "〜";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Cyan;
            label4.Font = new Font("游ゴシック Light", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(1475, 103);
            label4.Name = "label4";
            label4.Size = new Size(32, 17);
            label4.TabIndex = 8;
            label4.Text = "max";
            // 
            // temp_max_label
            // 
            temp_max_label.AutoSize = true;
            temp_max_label.BackColor = Color.Cyan;
            temp_max_label.Font = new Font("Arial", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            temp_max_label.ForeColor = SystemColors.ActiveCaptionText;
            temp_max_label.Location = new Point(1475, 120);
            temp_max_label.Name = "temp_max_label";
            temp_max_label.Size = new Size(47, 33);
            temp_max_label.TabIndex = 7;
            temp_max_label.Text = "00";
            // 
            // now_time_label
            // 
            now_time_label.AutoSize = true;
            now_time_label.BackColor = Color.Cyan;
            now_time_label.Font = new Font("Arial", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            now_time_label.ForeColor = SystemColors.ActiveCaptionText;
            now_time_label.Location = new Point(1475, 64);
            now_time_label.Name = "now_time_label";
            now_time_label.Size = new Size(71, 33);
            now_time_label.TabIndex = 6;
            now_time_label.Text = "time";
            // 
            // today_date_label
            // 
            today_date_label.AutoSize = true;
            today_date_label.BackColor = Color.Cyan;
            today_date_label.Font = new Font("Arial", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            today_date_label.ForeColor = SystemColors.ActiveCaptionText;
            today_date_label.Location = new Point(1475, 9);
            today_date_label.Name = "today_date_label";
            today_date_label.Size = new Size(71, 33);
            today_date_label.TabIndex = 5;
            today_date_label.Text = "date";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Cyan;
            label3.Font = new Font("MV Boli", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(1362, 114);
            label3.Name = "label3";
            label3.Size = new Size(112, 39);
            label3.TabIndex = 4;
            label3.Text = "Nagoya";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Cyan;
            label2.Font = new Font("MV Boli", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(1362, 64);
            label2.Name = "label2";
            label2.Size = new Size(82, 39);
            label2.TabIndex = 3;
            label2.Text = "Time";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Cyan;
            label1.Font = new Font("MV Boli", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(1362, 9);
            label1.Name = "label1";
            label1.Size = new Size(96, 39);
            label1.TabIndex = 1;
            label1.Text = "Today";
            // 
            // next_btn
            // 
            next_btn.FlatStyle = FlatStyle.Flat;
            next_btn.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            next_btn.Location = new Point(1831, 87);
            next_btn.Name = "next_btn";
            next_btn.Size = new Size(70, 70);
            next_btn.TabIndex = 2;
            next_btn.Text = ">";
            next_btn.UseVisualStyleBackColor = true;
            next_btn.MouseClick += next_btn_MouseClick;
            // 
            // previous_btn
            // 
            previous_btn.FlatStyle = FlatStyle.Flat;
            previous_btn.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            previous_btn.Location = new Point(12, 87);
            previous_btn.Name = "previous_btn";
            previous_btn.Size = new Size(70, 70);
            previous_btn.TabIndex = 1;
            previous_btn.Text = "<";
            previous_btn.UseVisualStyleBackColor = true;
            previous_btn.MouseClick += previous_btn_MouseClick;
            // 
            // weather_pic_box
            // 
            weather_pic_box.BackColor = Color.Cyan;
            weather_pic_box.Location = new Point(1687, 12);
            weather_pic_box.Name = "weather_pic_box";
            weather_pic_box.Size = new Size(82, 82);
            weather_pic_box.TabIndex = 0;
            weather_pic_box.TabStop = false;
            // 
            // change_second_timer
            // 
            change_second_timer.Interval = 1000;
            change_second_timer.Tick += change_second_timer_Tick;
            // 
            // form_panel
            // 
            form_panel.Dock = DockStyle.Fill;
            form_panel.Location = new Point(0, 0);
            form_panel.Name = "form_panel";
            form_panel.Size = new Size(1904, 1041);
            form_panel.TabIndex = 15;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(cur_panel);
            Controls.Add(form_panel);
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            cur_panel.ResumeLayout(false);
            cur_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)weather_pic_box).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel cur_panel;
        private PictureBox weather_pic_box;
        private Button previous_btn;
        private Button next_btn;
        private Label label1;
        private Label label3;
        private Label label2;
        private Label label6;
        private Label temp_min_label;
        private Label label5;
        private Label label4;
        private Label temp_max_label;
        private Label now_time_label;
        private Label today_date_label;
        private Label cur_year_label;
        private Label cur_month_str_label;
        private Label cur_month_num_label;
        private System.Windows.Forms.Timer change_second_timer;
        private Panel form_panel;
    }
}
