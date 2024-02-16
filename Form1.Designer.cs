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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            cur_panel = new Panel();
            exit_btn = new Button();
            Change_db_btn = new Button();
            Kakeibo_btn = new Button();
            all_remove_btn = new Button();
            label14 = new Label();
            total_time_label = new Label();
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
            main_panel = new Panel();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            button36 = new Button();
            button37 = new Button();
            button29 = new Button();
            button30 = new Button();
            button31 = new Button();
            button32 = new Button();
            button33 = new Button();
            button34 = new Button();
            button35 = new Button();
            button22 = new Button();
            button23 = new Button();
            button24 = new Button();
            button25 = new Button();
            button26 = new Button();
            button27 = new Button();
            button28 = new Button();
            button15 = new Button();
            button16 = new Button();
            button17 = new Button();
            button18 = new Button();
            button19 = new Button();
            button20 = new Button();
            button21 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            button12 = new Button();
            button13 = new Button();
            button14 = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            cur_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)weather_pic_box).BeginInit();
            main_panel.SuspendLayout();
            SuspendLayout();
            // 
            // cur_panel
            // 
            cur_panel.BorderStyle = BorderStyle.FixedSingle;
            cur_panel.Controls.Add(exit_btn);
            cur_panel.Controls.Add(Change_db_btn);
            cur_panel.Controls.Add(Kakeibo_btn);
            cur_panel.Controls.Add(all_remove_btn);
            cur_panel.Controls.Add(label14);
            cur_panel.Controls.Add(total_time_label);
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
            cur_panel.Size = new Size(1904, 162);
            cur_panel.TabIndex = 0;
            cur_panel.Paint += panel1_Paint;
            cur_panel.Resize += panel1_Resize;
            // 
            // exit_btn
            // 
            exit_btn.BackColor = Color.Red;
            exit_btn.Cursor = Cursors.Hand;
            exit_btn.FlatStyle = FlatStyle.Flat;
            exit_btn.Location = new Point(1890, 0);
            exit_btn.Name = "exit_btn";
            exit_btn.Size = new Size(30, 25);
            exit_btn.TabIndex = 16;
            exit_btn.Text = "X";
            exit_btn.UseVisualStyleBackColor = false;
            exit_btn.MouseClick += exit_btn_MouseClick;
            // 
            // Change_db_btn
            // 
            Change_db_btn.BackColor = Color.MediumSeaGreen;
            Change_db_btn.Cursor = Cursors.Hand;
            Change_db_btn.FlatStyle = FlatStyle.Flat;
            Change_db_btn.Font = new Font("MV Boli", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Change_db_btn.Location = new Point(102, 111);
            Change_db_btn.Name = "Change_db_btn";
            Change_db_btn.Size = new Size(70, 44);
            Change_db_btn.TabIndex = 61;
            Change_db_btn.Text = "ログアウト";
            Change_db_btn.TextAlign = ContentAlignment.TopLeft;
            Change_db_btn.UseVisualStyleBackColor = false;
            Change_db_btn.MouseClick += Change_db_btn_MouseClick;
            // 
            // Kakeibo_btn
            // 
            Kakeibo_btn.BackColor = Color.MediumSeaGreen;
            Kakeibo_btn.Cursor = Cursors.Hand;
            Kakeibo_btn.FlatStyle = FlatStyle.Flat;
            Kakeibo_btn.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            Kakeibo_btn.Image = (Image)resources.GetObject("Kakeibo_btn.Image");
            Kakeibo_btn.Location = new Point(228, 6);
            Kakeibo_btn.Name = "Kakeibo_btn";
            Kakeibo_btn.Size = new Size(61, 72);
            Kakeibo_btn.TabIndex = 60;
            Kakeibo_btn.TextAlign = ContentAlignment.TopLeft;
            Kakeibo_btn.UseVisualStyleBackColor = false;
            Kakeibo_btn.MouseClick += Kakeibo_btn_MouseClick;
            // 
            // all_remove_btn
            // 
            all_remove_btn.BackColor = Color.MediumSeaGreen;
            all_remove_btn.Cursor = Cursors.Hand;
            all_remove_btn.FlatStyle = FlatStyle.Flat;
            all_remove_btn.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            all_remove_btn.Image = Properties.Resources._9392;
            all_remove_btn.Location = new Point(161, 6);
            all_remove_btn.Name = "all_remove_btn";
            all_remove_btn.Size = new Size(61, 72);
            all_remove_btn.TabIndex = 59;
            all_remove_btn.TextAlign = ContentAlignment.TopLeft;
            all_remove_btn.UseVisualStyleBackColor = false;
            all_remove_btn.MouseClick += all_remove_btn_MouseClick;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.MediumSeaGreen;
            label14.Font = new Font("MV Boli", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.ForeColor = SystemColors.ActiveCaptionText;
            label14.Location = new Point(84, 81);
            label14.Name = "label14";
            label14.Size = new Size(200, 28);
            label14.TabIndex = 16;
            label14.Text = "月別総合勉強時間=";
            // 
            // total_time_label
            // 
            total_time_label.AutoSize = true;
            total_time_label.BackColor = Color.SpringGreen;
            total_time_label.Font = new Font("MV Boli", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            total_time_label.ForeColor = SystemColors.ActiveCaptionText;
            total_time_label.Location = new Point(290, 81);
            total_time_label.Name = "total_time_label";
            total_time_label.Size = new Size(80, 28);
            total_time_label.TabIndex = 15;
            total_time_label.Text = "00:00";
            // 
            // cur_month_num_label
            // 
            cur_month_num_label.AutoSize = true;
            cur_month_num_label.BackColor = Color.Cyan;
            cur_month_num_label.Font = new Font("游明朝 Light", 72F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cur_month_num_label.ForeColor = SystemColors.ActiveCaptionText;
            cur_month_num_label.Location = new Point(902, 20);
            cur_month_num_label.Name = "cur_month_num_label";
            cur_month_num_label.Size = new Size(100, 124);
            cur_month_num_label.TabIndex = 14;
            cur_month_num_label.Text = "1";
            // 
            // cur_month_str_label
            // 
            cur_month_str_label.AutoSize = true;
            cur_month_str_label.BackColor = Color.MediumSeaGreen;
            cur_month_str_label.Font = new Font("Segoe Script", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cur_month_str_label.ForeColor = SystemColors.ActiveCaptionText;
            cur_month_str_label.Location = new Point(-1, 43);
            cur_month_str_label.Name = "cur_month_str_label";
            cur_month_str_label.Size = new Size(99, 38);
            cur_month_str_label.TabIndex = 13;
            cur_month_str_label.Text = "month";
            // 
            // cur_year_label
            // 
            cur_year_label.AutoSize = true;
            cur_year_label.BackColor = Color.MediumSeaGreen;
            cur_year_label.Font = new Font("MV Boli", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cur_year_label.ForeColor = SystemColors.ActiveCaptionText;
            cur_year_label.Location = new Point(-1, -1);
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
            temp_min_label.Font = new Font("MV Boli", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            temp_min_label.ForeColor = SystemColors.ActiveCaptionText;
            temp_min_label.Location = new Point(1577, 118);
            temp_min_label.Name = "temp_min_label";
            temp_min_label.Size = new Size(57, 39);
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
            temp_max_label.Font = new Font("MV Boli", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            temp_max_label.ForeColor = SystemColors.ActiveCaptionText;
            temp_max_label.Location = new Point(1475, 118);
            temp_max_label.Name = "temp_max_label";
            temp_max_label.Size = new Size(57, 39);
            temp_max_label.TabIndex = 7;
            temp_max_label.Text = "00";
            // 
            // now_time_label
            // 
            now_time_label.AutoSize = true;
            now_time_label.BackColor = Color.Cyan;
            now_time_label.Font = new Font("MV Boli", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            now_time_label.ForeColor = SystemColors.ActiveCaptionText;
            now_time_label.Location = new Point(1475, 64);
            now_time_label.Name = "now_time_label";
            now_time_label.Size = new Size(78, 39);
            now_time_label.TabIndex = 6;
            now_time_label.Text = "time";
            // 
            // today_date_label
            // 
            today_date_label.AutoSize = true;
            today_date_label.BackColor = Color.Cyan;
            today_date_label.Font = new Font("MV Boli", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            today_date_label.ForeColor = SystemColors.ActiveCaptionText;
            today_date_label.Location = new Point(1475, 9);
            today_date_label.Name = "today_date_label";
            today_date_label.Size = new Size(76, 39);
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
            label3.Size = new Size(119, 39);
            label3.TabIndex = 4;
            label3.Text = "名古屋";
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
            next_btn.Cursor = Cursors.Hand;
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
            previous_btn.Cursor = Cursors.Hand;
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
            // main_panel
            // 
            main_panel.BackColor = Color.White;
            main_panel.Controls.Add(label13);
            main_panel.Controls.Add(label12);
            main_panel.Controls.Add(label11);
            main_panel.Controls.Add(label10);
            main_panel.Controls.Add(label9);
            main_panel.Controls.Add(label8);
            main_panel.Controls.Add(label7);
            main_panel.Controls.Add(button36);
            main_panel.Controls.Add(button37);
            main_panel.Controls.Add(button29);
            main_panel.Controls.Add(button30);
            main_panel.Controls.Add(button31);
            main_panel.Controls.Add(button32);
            main_panel.Controls.Add(button33);
            main_panel.Controls.Add(button34);
            main_panel.Controls.Add(button35);
            main_panel.Controls.Add(button22);
            main_panel.Controls.Add(button23);
            main_panel.Controls.Add(button24);
            main_panel.Controls.Add(button25);
            main_panel.Controls.Add(button26);
            main_panel.Controls.Add(button27);
            main_panel.Controls.Add(button28);
            main_panel.Controls.Add(button15);
            main_panel.Controls.Add(button16);
            main_panel.Controls.Add(button17);
            main_panel.Controls.Add(button18);
            main_panel.Controls.Add(button19);
            main_panel.Controls.Add(button20);
            main_panel.Controls.Add(button21);
            main_panel.Controls.Add(button8);
            main_panel.Controls.Add(button9);
            main_panel.Controls.Add(button10);
            main_panel.Controls.Add(button11);
            main_panel.Controls.Add(button12);
            main_panel.Controls.Add(button13);
            main_panel.Controls.Add(button14);
            main_panel.Controls.Add(button1);
            main_panel.Controls.Add(button2);
            main_panel.Controls.Add(button3);
            main_panel.Controls.Add(button4);
            main_panel.Controls.Add(button5);
            main_panel.Controls.Add(button6);
            main_panel.Controls.Add(button7);
            main_panel.Dock = DockStyle.Fill;
            main_panel.Location = new Point(0, 0);
            main_panel.Name = "main_panel";
            main_panel.Size = new Size(1904, 1041);
            main_panel.TabIndex = 15;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("MV Boli", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.ForeColor = SystemColors.ActiveCaptionText;
            label13.Location = new Point(1647, 163);
            label13.Name = "label13";
            label13.Size = new Size(137, 39);
            label13.TabIndex = 58;
            label13.Text = "Saturday";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("MV Boli", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = SystemColors.ActiveCaptionText;
            label12.Location = new Point(1395, 163);
            label12.Name = "label12";
            label12.Size = new Size(97, 39);
            label12.TabIndex = 57;
            label12.Text = "Friday";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("MV Boli", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ForeColor = SystemColors.ActiveCaptionText;
            label11.Location = new Point(1130, 163);
            label11.Name = "label11";
            label11.Size = new Size(137, 39);
            label11.TabIndex = 56;
            label11.Text = "Thursday";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("MV Boli", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = SystemColors.ActiveCaptionText;
            label10.Location = new Point(878, 163);
            label10.Name = "label10";
            label10.Size = new Size(161, 39);
            label10.TabIndex = 55;
            label10.Text = "Wednesday";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("MV Boli", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ActiveCaptionText;
            label9.Location = new Point(643, 163);
            label9.Name = "label9";
            label9.Size = new Size(123, 39);
            label9.TabIndex = 54;
            label9.Text = "Tuesday";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("MV Boli", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ActiveCaptionText;
            label8.Location = new Point(392, 163);
            label8.Name = "label8";
            label8.Size = new Size(120, 39);
            label8.TabIndex = 53;
            label8.Text = "Monday";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("MV Boli", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ActiveCaptionText;
            label7.Location = new Point(133, 163);
            label7.Name = "label7";
            label7.Size = new Size(112, 39);
            label7.TabIndex = 15;
            label7.Text = "Sunday";
            // 
            // button36
            // 
            button36.Cursor = Cursors.Hand;
            button36.FlatStyle = FlatStyle.Flat;
            button36.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button36.Location = new Point(85, 875);
            button36.Name = "button36";
            button36.Size = new Size(220, 118);
            button36.TabIndex = 52;
            button36.Text = "1";
            button36.TextAlign = ContentAlignment.TopLeft;
            button36.UseVisualStyleBackColor = true;
            button36.Visible = false;
            button36.MouseClick += select_day_btn;
            // 
            // button37
            // 
            button37.Cursor = Cursors.Hand;
            button37.FlatStyle = FlatStyle.Flat;
            button37.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button37.Location = new Point(339, 875);
            button37.Name = "button37";
            button37.Size = new Size(220, 118);
            button37.TabIndex = 51;
            button37.Text = "1";
            button37.TextAlign = ContentAlignment.TopLeft;
            button37.UseVisualStyleBackColor = true;
            button37.Visible = false;
            button37.MouseClick += select_day_btn;
            // 
            // button29
            // 
            button29.Cursor = Cursors.Hand;
            button29.FlatStyle = FlatStyle.Flat;
            button29.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button29.Location = new Point(85, 740);
            button29.Name = "button29";
            button29.Size = new Size(220, 118);
            button29.TabIndex = 49;
            button29.Text = "1";
            button29.TextAlign = ContentAlignment.TopLeft;
            button29.UseVisualStyleBackColor = true;
            button29.Visible = false;
            button29.MouseClick += select_day_btn;
            // 
            // button30
            // 
            button30.Cursor = Cursors.Hand;
            button30.FlatStyle = FlatStyle.Flat;
            button30.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button30.Location = new Point(339, 740);
            button30.Name = "button30";
            button30.Size = new Size(220, 118);
            button30.TabIndex = 48;
            button30.Text = "1";
            button30.TextAlign = ContentAlignment.TopLeft;
            button30.UseVisualStyleBackColor = true;
            button30.Visible = false;
            button30.MouseClick += select_day_btn;
            // 
            // button31
            // 
            button31.Cursor = Cursors.Hand;
            button31.FlatStyle = FlatStyle.Flat;
            button31.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button31.Location = new Point(590, 740);
            button31.Name = "button31";
            button31.Size = new Size(220, 118);
            button31.TabIndex = 47;
            button31.Text = "1";
            button31.TextAlign = ContentAlignment.TopLeft;
            button31.UseVisualStyleBackColor = true;
            button31.Visible = false;
            button31.MouseClick += select_day_btn;
            // 
            // button32
            // 
            button32.Cursor = Cursors.Hand;
            button32.FlatStyle = FlatStyle.Flat;
            button32.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button32.Location = new Point(840, 740);
            button32.Name = "button32";
            button32.Size = new Size(220, 118);
            button32.TabIndex = 46;
            button32.Text = "1";
            button32.TextAlign = ContentAlignment.TopLeft;
            button32.UseVisualStyleBackColor = true;
            button32.Visible = false;
            button32.MouseClick += select_day_btn;
            // 
            // button33
            // 
            button33.Cursor = Cursors.Hand;
            button33.FlatStyle = FlatStyle.Flat;
            button33.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button33.Location = new Point(1089, 740);
            button33.Name = "button33";
            button33.Size = new Size(220, 118);
            button33.TabIndex = 45;
            button33.Text = "1";
            button33.TextAlign = ContentAlignment.TopLeft;
            button33.UseVisualStyleBackColor = true;
            button33.Visible = false;
            button33.MouseClick += select_day_btn;
            // 
            // button34
            // 
            button34.Cursor = Cursors.Hand;
            button34.FlatStyle = FlatStyle.Flat;
            button34.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button34.Location = new Point(1339, 740);
            button34.Name = "button34";
            button34.Size = new Size(220, 118);
            button34.TabIndex = 44;
            button34.Text = "1";
            button34.TextAlign = ContentAlignment.TopLeft;
            button34.UseVisualStyleBackColor = true;
            button34.Visible = false;
            button34.MouseClick += select_day_btn;
            // 
            // button35
            // 
            button35.Cursor = Cursors.Hand;
            button35.FlatStyle = FlatStyle.Flat;
            button35.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button35.Location = new Point(1592, 740);
            button35.Name = "button35";
            button35.Size = new Size(220, 118);
            button35.TabIndex = 43;
            button35.Text = "1";
            button35.TextAlign = ContentAlignment.TopLeft;
            button35.UseVisualStyleBackColor = true;
            button35.Visible = false;
            button35.MouseClick += select_day_btn;
            // 
            // button22
            // 
            button22.Cursor = Cursors.Hand;
            button22.FlatStyle = FlatStyle.Flat;
            button22.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button22.Location = new Point(85, 607);
            button22.Name = "button22";
            button22.Size = new Size(220, 118);
            button22.TabIndex = 42;
            button22.Text = "1";
            button22.TextAlign = ContentAlignment.TopLeft;
            button22.UseVisualStyleBackColor = true;
            button22.Visible = false;
            button22.MouseClick += select_day_btn;
            // 
            // button23
            // 
            button23.Cursor = Cursors.Hand;
            button23.FlatStyle = FlatStyle.Flat;
            button23.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button23.Location = new Point(339, 607);
            button23.Name = "button23";
            button23.Size = new Size(220, 118);
            button23.TabIndex = 41;
            button23.Text = "1";
            button23.TextAlign = ContentAlignment.TopLeft;
            button23.UseVisualStyleBackColor = true;
            button23.Visible = false;
            button23.MouseClick += select_day_btn;
            // 
            // button24
            // 
            button24.Cursor = Cursors.Hand;
            button24.FlatStyle = FlatStyle.Flat;
            button24.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button24.Location = new Point(590, 607);
            button24.Name = "button24";
            button24.Size = new Size(220, 118);
            button24.TabIndex = 40;
            button24.Text = "1";
            button24.TextAlign = ContentAlignment.TopLeft;
            button24.UseVisualStyleBackColor = true;
            button24.Visible = false;
            button24.MouseClick += select_day_btn;
            // 
            // button25
            // 
            button25.Cursor = Cursors.Hand;
            button25.FlatStyle = FlatStyle.Flat;
            button25.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button25.Location = new Point(840, 607);
            button25.Name = "button25";
            button25.Size = new Size(220, 118);
            button25.TabIndex = 39;
            button25.Text = "1";
            button25.TextAlign = ContentAlignment.TopLeft;
            button25.UseVisualStyleBackColor = true;
            button25.Visible = false;
            button25.MouseClick += select_day_btn;
            // 
            // button26
            // 
            button26.Cursor = Cursors.Hand;
            button26.FlatStyle = FlatStyle.Flat;
            button26.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button26.Location = new Point(1089, 607);
            button26.Name = "button26";
            button26.Size = new Size(220, 118);
            button26.TabIndex = 38;
            button26.Text = "1";
            button26.TextAlign = ContentAlignment.TopLeft;
            button26.UseVisualStyleBackColor = true;
            button26.Visible = false;
            button26.MouseClick += select_day_btn;
            // 
            // button27
            // 
            button27.Cursor = Cursors.Hand;
            button27.FlatStyle = FlatStyle.Flat;
            button27.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button27.Location = new Point(1339, 607);
            button27.Name = "button27";
            button27.Size = new Size(220, 118);
            button27.TabIndex = 37;
            button27.Text = "1";
            button27.TextAlign = ContentAlignment.TopLeft;
            button27.UseVisualStyleBackColor = true;
            button27.Visible = false;
            button27.MouseClick += select_day_btn;
            // 
            // button28
            // 
            button28.Cursor = Cursors.Hand;
            button28.FlatStyle = FlatStyle.Flat;
            button28.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button28.Location = new Point(1592, 607);
            button28.Name = "button28";
            button28.Size = new Size(220, 118);
            button28.TabIndex = 36;
            button28.Text = "1";
            button28.TextAlign = ContentAlignment.TopLeft;
            button28.UseVisualStyleBackColor = true;
            button28.MouseClick += select_day_btn;
            // 
            // button15
            // 
            button15.Cursor = Cursors.Hand;
            button15.FlatStyle = FlatStyle.Flat;
            button15.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button15.Location = new Point(85, 471);
            button15.Name = "button15";
            button15.Size = new Size(220, 118);
            button15.TabIndex = 35;
            button15.Text = "1";
            button15.TextAlign = ContentAlignment.TopLeft;
            button15.UseVisualStyleBackColor = true;
            button15.Visible = false;
            button15.MouseClick += select_day_btn;
            // 
            // button16
            // 
            button16.Cursor = Cursors.Hand;
            button16.FlatStyle = FlatStyle.Flat;
            button16.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button16.Location = new Point(339, 471);
            button16.Name = "button16";
            button16.Size = new Size(220, 118);
            button16.TabIndex = 34;
            button16.Text = "1";
            button16.TextAlign = ContentAlignment.TopLeft;
            button16.UseVisualStyleBackColor = true;
            button16.Visible = false;
            button16.MouseClick += select_day_btn;
            // 
            // button17
            // 
            button17.Cursor = Cursors.Hand;
            button17.FlatStyle = FlatStyle.Flat;
            button17.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button17.Location = new Point(590, 471);
            button17.Name = "button17";
            button17.Size = new Size(220, 118);
            button17.TabIndex = 33;
            button17.Text = "1";
            button17.TextAlign = ContentAlignment.TopLeft;
            button17.UseVisualStyleBackColor = true;
            button17.Visible = false;
            button17.MouseClick += select_day_btn;
            // 
            // button18
            // 
            button18.Cursor = Cursors.Hand;
            button18.FlatStyle = FlatStyle.Flat;
            button18.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button18.Location = new Point(840, 471);
            button18.Name = "button18";
            button18.Size = new Size(220, 118);
            button18.TabIndex = 32;
            button18.Text = "1";
            button18.TextAlign = ContentAlignment.TopLeft;
            button18.UseVisualStyleBackColor = true;
            button18.Visible = false;
            button18.MouseClick += select_day_btn;
            // 
            // button19
            // 
            button19.Cursor = Cursors.Hand;
            button19.FlatStyle = FlatStyle.Flat;
            button19.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button19.Location = new Point(1089, 471);
            button19.Name = "button19";
            button19.Size = new Size(220, 118);
            button19.TabIndex = 31;
            button19.Text = "1";
            button19.TextAlign = ContentAlignment.TopLeft;
            button19.UseVisualStyleBackColor = true;
            button19.Visible = false;
            button19.MouseClick += select_day_btn;
            // 
            // button20
            // 
            button20.Cursor = Cursors.Hand;
            button20.FlatStyle = FlatStyle.Flat;
            button20.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button20.Location = new Point(1339, 471);
            button20.Name = "button20";
            button20.Size = new Size(220, 118);
            button20.TabIndex = 30;
            button20.Text = "1";
            button20.TextAlign = ContentAlignment.TopLeft;
            button20.UseVisualStyleBackColor = true;
            button20.Visible = false;
            button20.MouseClick += select_day_btn;
            // 
            // button21
            // 
            button21.Cursor = Cursors.Hand;
            button21.FlatStyle = FlatStyle.Flat;
            button21.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button21.Location = new Point(1592, 471);
            button21.Name = "button21";
            button21.Size = new Size(220, 118);
            button21.TabIndex = 29;
            button21.Text = "1";
            button21.TextAlign = ContentAlignment.TopLeft;
            button21.UseVisualStyleBackColor = true;
            button21.MouseClick += select_day_btn;
            // 
            // button8
            // 
            button8.Cursor = Cursors.Hand;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button8.Location = new Point(85, 338);
            button8.Name = "button8";
            button8.Size = new Size(220, 118);
            button8.TabIndex = 28;
            button8.Text = "1";
            button8.TextAlign = ContentAlignment.TopLeft;
            button8.UseVisualStyleBackColor = true;
            button8.Visible = false;
            button8.MouseClick += select_day_btn;
            // 
            // button9
            // 
            button9.Cursor = Cursors.Hand;
            button9.FlatStyle = FlatStyle.Flat;
            button9.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button9.Location = new Point(339, 338);
            button9.Name = "button9";
            button9.Size = new Size(220, 118);
            button9.TabIndex = 27;
            button9.Text = "1";
            button9.TextAlign = ContentAlignment.TopLeft;
            button9.UseVisualStyleBackColor = true;
            button9.Visible = false;
            button9.MouseClick += select_day_btn;
            // 
            // button10
            // 
            button10.Cursor = Cursors.Hand;
            button10.FlatStyle = FlatStyle.Flat;
            button10.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button10.Location = new Point(590, 338);
            button10.Name = "button10";
            button10.Size = new Size(220, 118);
            button10.TabIndex = 26;
            button10.Text = "1";
            button10.TextAlign = ContentAlignment.TopLeft;
            button10.UseVisualStyleBackColor = true;
            button10.Visible = false;
            button10.MouseClick += select_day_btn;
            // 
            // button11
            // 
            button11.Cursor = Cursors.Hand;
            button11.FlatStyle = FlatStyle.Flat;
            button11.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button11.Location = new Point(840, 338);
            button11.Name = "button11";
            button11.Size = new Size(220, 118);
            button11.TabIndex = 25;
            button11.Text = "1";
            button11.TextAlign = ContentAlignment.TopLeft;
            button11.UseVisualStyleBackColor = true;
            button11.Visible = false;
            button11.MouseClick += select_day_btn;
            // 
            // button12
            // 
            button12.Cursor = Cursors.Hand;
            button12.FlatStyle = FlatStyle.Flat;
            button12.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button12.Location = new Point(1089, 338);
            button12.Name = "button12";
            button12.Size = new Size(220, 118);
            button12.TabIndex = 24;
            button12.Text = "1";
            button12.TextAlign = ContentAlignment.TopLeft;
            button12.UseVisualStyleBackColor = true;
            button12.Visible = false;
            button12.MouseClick += select_day_btn;
            // 
            // button13
            // 
            button13.Cursor = Cursors.Hand;
            button13.FlatStyle = FlatStyle.Flat;
            button13.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button13.Location = new Point(1339, 338);
            button13.Name = "button13";
            button13.Size = new Size(220, 118);
            button13.TabIndex = 23;
            button13.Text = "1";
            button13.TextAlign = ContentAlignment.TopLeft;
            button13.UseVisualStyleBackColor = true;
            button13.Visible = false;
            button13.MouseClick += select_day_btn;
            // 
            // button14
            // 
            button14.Cursor = Cursors.Hand;
            button14.FlatStyle = FlatStyle.Flat;
            button14.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button14.Location = new Point(1592, 338);
            button14.Name = "button14";
            button14.Size = new Size(220, 118);
            button14.TabIndex = 22;
            button14.Text = "1";
            button14.TextAlign = ContentAlignment.TopLeft;
            button14.UseVisualStyleBackColor = true;
            button14.MouseClick += select_day_btn;
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button1.Location = new Point(85, 205);
            button1.Name = "button1";
            button1.Size = new Size(220, 118);
            button1.TabIndex = 21;
            button1.Text = "1";
            button1.TextAlign = ContentAlignment.TopLeft;
            button1.UseVisualStyleBackColor = true;
            button1.Visible = false;
            button1.MouseClick += select_day_btn;
            // 
            // button2
            // 
            button2.Cursor = Cursors.Hand;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button2.Location = new Point(339, 205);
            button2.Name = "button2";
            button2.Size = new Size(220, 118);
            button2.TabIndex = 20;
            button2.Text = "1";
            button2.TextAlign = ContentAlignment.TopLeft;
            button2.UseVisualStyleBackColor = true;
            button2.Visible = false;
            button2.MouseClick += select_day_btn;
            // 
            // button3
            // 
            button3.Cursor = Cursors.Hand;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button3.Location = new Point(590, 205);
            button3.Name = "button3";
            button3.Size = new Size(220, 118);
            button3.TabIndex = 19;
            button3.Text = "1";
            button3.TextAlign = ContentAlignment.TopLeft;
            button3.UseVisualStyleBackColor = true;
            button3.Visible = false;
            button3.MouseClick += select_day_btn;
            // 
            // button4
            // 
            button4.Cursor = Cursors.Hand;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button4.Location = new Point(840, 205);
            button4.Name = "button4";
            button4.Size = new Size(220, 118);
            button4.TabIndex = 18;
            button4.Text = "1";
            button4.TextAlign = ContentAlignment.TopLeft;
            button4.UseVisualStyleBackColor = true;
            button4.Visible = false;
            button4.MouseClick += select_day_btn;
            // 
            // button5
            // 
            button5.Cursor = Cursors.Hand;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button5.Location = new Point(1089, 205);
            button5.Name = "button5";
            button5.Size = new Size(220, 118);
            button5.TabIndex = 17;
            button5.Text = "1";
            button5.TextAlign = ContentAlignment.TopLeft;
            button5.UseVisualStyleBackColor = true;
            button5.Visible = false;
            button5.MouseClick += select_day_btn;
            // 
            // button6
            // 
            button6.Cursor = Cursors.Hand;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button6.Location = new Point(1339, 205);
            button6.Name = "button6";
            button6.Size = new Size(220, 118);
            button6.TabIndex = 16;
            button6.Text = "1";
            button6.TextAlign = ContentAlignment.TopLeft;
            button6.UseVisualStyleBackColor = true;
            button6.Visible = false;
            button6.MouseClick += select_day_btn;
            // 
            // button7
            // 
            button7.Cursor = Cursors.Hand;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Yu Gothic UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button7.Location = new Point(1592, 205);
            button7.Name = "button7";
            button7.Size = new Size(220, 118);
            button7.TabIndex = 15;
            button7.Text = "1";
            button7.TextAlign = ContentAlignment.TopLeft;
            button7.UseVisualStyleBackColor = true;
            button7.MouseClick += select_day_btn;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(cur_panel);
            Controls.Add(main_panel);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Name = "Form1";
            Text = "Scheduler";
            WindowState = FormWindowState.Maximized;
            cur_panel.ResumeLayout(false);
            cur_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)weather_pic_box).EndInit();
            main_panel.ResumeLayout(false);
            main_panel.PerformLayout();
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
        private Panel main_panel;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button29;
        private Button button30;
        private Button button31;
        private Button button32;
        private Button button33;
        private Button button34;
        private Button button35;
        private Button button22;
        private Button button23;
        private Button button24;
        private Button button25;
        private Button button26;
        private Button button27;
        private Button button28;
        private Button button15;
        private Button button16;
        private Button button17;
        private Button button18;
        private Button button19;
        private Button button20;
        private Button button21;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button13;
        private Button button14;
        private Button button1;
        private Button button2;
        private Button button36;
        private Button button37;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label14;
        private Label total_time_label;
        private Button all_remove_btn;
        private Button Kakeibo_btn;
        private Button Change_db_btn;
        private Button exit_btn;
    }
}
