namespace study_scheduler.childforms
{
    partial class Register_form
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
            register_panel = new Panel();
            ok_btn = new Button();
            end_time_label = new Label();
            end_label = new Label();
            label4 = new Label();
            st_time_label = new Label();
            start_label = new Label();
            back_btn = new Button();
            plum_panel = new Panel();
            lightsteelblue_panel = new Panel();
            limegreen_panel = new Panel();
            salmon_panel = new Panel();
            cur_color_panel = new Panel();
            dimgray_panel = new Panel();
            pink_panel = new Panel();
            magenta_panel = new Panel();
            blueviolet_panel = new Panel();
            midnightblue_panel = new Panel();
            steelblue_panel = new Panel();
            darkslategray_panel = new Panel();
            aquamarine_panel = new Panel();
            mediumseagreen_panel = new Panel();
            greenyellow_panel = new Panel();
            oliverdrab_panel = new Panel();
            olive_panel = new Panel();
            gold_panel = new Panel();
            orange_panel = new Panel();
            red_panel = new Panel();
            black_panel = new Panel();
            color_label = new Label();
            textBox1 = new TextBox();
            text_box_label = new Label();
            study_checkbox = new CheckBox();
            radio_panel = new Panel();
            which = new Label();
            button1 = new Button();
            minut_label = new Label();
            hour_label = new Label();
            minut_track = new TrackBar();
            hour_track = new TrackBar();
            highlight_timer = new System.Windows.Forms.Timer(components);
            register_panel.SuspendLayout();
            radio_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)minut_track).BeginInit();
            ((System.ComponentModel.ISupportInitialize)hour_track).BeginInit();
            SuspendLayout();
            // 
            // register_panel
            // 
            register_panel.BackColor = Color.Gainsboro;
            register_panel.BorderStyle = BorderStyle.Fixed3D;
            register_panel.Controls.Add(ok_btn);
            register_panel.Controls.Add(end_time_label);
            register_panel.Controls.Add(end_label);
            register_panel.Controls.Add(label4);
            register_panel.Controls.Add(st_time_label);
            register_panel.Controls.Add(start_label);
            register_panel.Controls.Add(back_btn);
            register_panel.Controls.Add(plum_panel);
            register_panel.Controls.Add(lightsteelblue_panel);
            register_panel.Controls.Add(limegreen_panel);
            register_panel.Controls.Add(salmon_panel);
            register_panel.Controls.Add(cur_color_panel);
            register_panel.Controls.Add(dimgray_panel);
            register_panel.Controls.Add(pink_panel);
            register_panel.Controls.Add(magenta_panel);
            register_panel.Controls.Add(blueviolet_panel);
            register_panel.Controls.Add(midnightblue_panel);
            register_panel.Controls.Add(steelblue_panel);
            register_panel.Controls.Add(darkslategray_panel);
            register_panel.Controls.Add(aquamarine_panel);
            register_panel.Controls.Add(mediumseagreen_panel);
            register_panel.Controls.Add(greenyellow_panel);
            register_panel.Controls.Add(oliverdrab_panel);
            register_panel.Controls.Add(olive_panel);
            register_panel.Controls.Add(gold_panel);
            register_panel.Controls.Add(orange_panel);
            register_panel.Controls.Add(red_panel);
            register_panel.Controls.Add(black_panel);
            register_panel.Controls.Add(color_label);
            register_panel.Controls.Add(textBox1);
            register_panel.Controls.Add(text_box_label);
            register_panel.Controls.Add(study_checkbox);
            register_panel.Location = new Point(584, 55);
            register_panel.Name = "register_panel";
            register_panel.Size = new Size(743, 801);
            register_panel.TabIndex = 0;
            // 
            // ok_btn
            // 
            ok_btn.Cursor = Cursors.Hand;
            ok_btn.Font = new Font("MV Boli", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ok_btn.Location = new Point(271, 657);
            ok_btn.Name = "ok_btn";
            ok_btn.Size = new Size(188, 65);
            ok_btn.TabIndex = 24;
            ok_btn.Text = "OK";
            ok_btn.UseVisualStyleBackColor = true;
            ok_btn.MouseClick += ok_btn_MouseClick;
            // 
            // end_time_label
            // 
            end_time_label.AutoSize = true;
            end_time_label.BorderStyle = BorderStyle.Fixed3D;
            end_time_label.Cursor = Cursors.Hand;
            end_time_label.Font = new Font("MV Boli", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            end_time_label.Location = new Point(478, 516);
            end_time_label.Name = "end_time_label";
            end_time_label.Size = new Size(141, 51);
            end_time_label.TabIndex = 23;
            end_time_label.Text = "00:00";
            end_time_label.MouseClick += change_time;
            // 
            // end_label
            // 
            end_label.AutoSize = true;
            end_label.BorderStyle = BorderStyle.Fixed3D;
            end_label.Cursor = Cursors.Hand;
            end_label.Font = new Font("MV Boli", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            end_label.Location = new Point(347, 534);
            end_label.Name = "end_label";
            end_label.Size = new Size(95, 27);
            end_label.TabIndex = 22;
            end_label.Text = "End time";
            end_label.MouseClick += change_time;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("游明朝 Light", 48F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label4.Location = new Point(509, 313);
            label4.Name = "label4";
            label4.Size = new Size(56, 83);
            label4.TabIndex = 21;
            label4.Text = "≀";
            // 
            // st_time_label
            // 
            st_time_label.AutoSize = true;
            st_time_label.BorderStyle = BorderStyle.Fixed3D;
            st_time_label.Cursor = Cursors.Hand;
            st_time_label.Font = new Font("MV Boli", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            st_time_label.Location = new Point(478, 126);
            st_time_label.Name = "st_time_label";
            st_time_label.Size = new Size(141, 51);
            st_time_label.TabIndex = 20;
            st_time_label.Text = "00:00";
            st_time_label.MouseClick += change_time;
            // 
            // start_label
            // 
            start_label.AutoSize = true;
            start_label.BorderStyle = BorderStyle.Fixed3D;
            start_label.Cursor = Cursors.Hand;
            start_label.Font = new Font("MV Boli", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            start_label.Location = new Point(347, 144);
            start_label.Name = "start_label";
            start_label.Size = new Size(112, 27);
            start_label.TabIndex = 19;
            start_label.Text = "Start time";
            start_label.MouseClick += change_time;
            // 
            // back_btn
            // 
            back_btn.Cursor = Cursors.Hand;
            back_btn.Font = new Font("MV Boli", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            back_btn.Location = new Point(32, 14);
            back_btn.Name = "back_btn";
            back_btn.Size = new Size(75, 37);
            back_btn.TabIndex = 18;
            back_btn.Text = "Back";
            back_btn.UseVisualStyleBackColor = true;
            back_btn.MouseClick += back_btn_MouseClick;
            // 
            // plum_panel
            // 
            plum_panel.BackColor = Color.Plum;
            plum_panel.BorderStyle = BorderStyle.FixedSingle;
            plum_panel.Cursor = Cursors.Hand;
            plum_panel.Location = new Point(166, 434);
            plum_panel.Name = "plum_panel";
            plum_panel.Size = new Size(25, 25);
            plum_panel.TabIndex = 17;
            plum_panel.MouseClick += select_color_click;
            // 
            // lightsteelblue_panel
            // 
            lightsteelblue_panel.BackColor = Color.LightSteelBlue;
            lightsteelblue_panel.BorderStyle = BorderStyle.FixedSingle;
            lightsteelblue_panel.Cursor = Cursors.Hand;
            lightsteelblue_panel.Location = new Point(207, 393);
            lightsteelblue_panel.Name = "lightsteelblue_panel";
            lightsteelblue_panel.Size = new Size(25, 25);
            lightsteelblue_panel.TabIndex = 13;
            lightsteelblue_panel.MouseClick += select_color_click;
            // 
            // limegreen_panel
            // 
            limegreen_panel.BackColor = Color.LimeGreen;
            limegreen_panel.BorderStyle = BorderStyle.FixedSingle;
            limegreen_panel.Cursor = Cursors.Hand;
            limegreen_panel.Location = new Point(207, 353);
            limegreen_panel.Name = "limegreen_panel";
            limegreen_panel.Size = new Size(25, 25);
            limegreen_panel.TabIndex = 12;
            limegreen_panel.MouseClick += select_color_click;
            // 
            // salmon_panel
            // 
            salmon_panel.BackColor = Color.Salmon;
            salmon_panel.BorderStyle = BorderStyle.FixedSingle;
            salmon_panel.Cursor = Cursors.Hand;
            salmon_panel.Location = new Point(207, 313);
            salmon_panel.Name = "salmon_panel";
            salmon_panel.Size = new Size(25, 25);
            salmon_panel.TabIndex = 8;
            salmon_panel.MouseClick += select_color_click;
            // 
            // cur_color_panel
            // 
            cur_color_panel.BackColor = Color.Gainsboro;
            cur_color_panel.BorderStyle = BorderStyle.FixedSingle;
            cur_color_panel.Location = new Point(172, 250);
            cur_color_panel.Name = "cur_color_panel";
            cur_color_panel.Size = new Size(25, 25);
            cur_color_panel.TabIndex = 8;
            // 
            // dimgray_panel
            // 
            dimgray_panel.BackColor = Color.DimGray;
            dimgray_panel.BorderStyle = BorderStyle.FixedSingle;
            dimgray_panel.Cursor = Cursors.Hand;
            dimgray_panel.Location = new Point(82, 313);
            dimgray_panel.Name = "dimgray_panel";
            dimgray_panel.Size = new Size(25, 25);
            dimgray_panel.TabIndex = 17;
            dimgray_panel.MouseClick += select_color_click;
            // 
            // pink_panel
            // 
            pink_panel.BackColor = Color.Pink;
            pink_panel.BorderStyle = BorderStyle.FixedSingle;
            pink_panel.Cursor = Cursors.Hand;
            pink_panel.Location = new Point(207, 434);
            pink_panel.Name = "pink_panel";
            pink_panel.Size = new Size(25, 25);
            pink_panel.TabIndex = 16;
            pink_panel.MouseClick += select_color_click;
            // 
            // magenta_panel
            // 
            magenta_panel.BackColor = Color.Magenta;
            magenta_panel.BorderStyle = BorderStyle.FixedSingle;
            magenta_panel.Cursor = Cursors.Hand;
            magenta_panel.Location = new Point(126, 434);
            magenta_panel.Name = "magenta_panel";
            magenta_panel.Size = new Size(25, 25);
            magenta_panel.TabIndex = 15;
            magenta_panel.MouseClick += select_color_click;
            // 
            // blueviolet_panel
            // 
            blueviolet_panel.BackColor = Color.BlueViolet;
            blueviolet_panel.BorderStyle = BorderStyle.FixedSingle;
            blueviolet_panel.Cursor = Cursors.Hand;
            blueviolet_panel.Location = new Point(82, 434);
            blueviolet_panel.Name = "blueviolet_panel";
            blueviolet_panel.Size = new Size(25, 25);
            blueviolet_panel.TabIndex = 14;
            blueviolet_panel.MouseClick += select_color_click;
            // 
            // midnightblue_panel
            // 
            midnightblue_panel.BackColor = Color.MidnightBlue;
            midnightblue_panel.BorderStyle = BorderStyle.FixedSingle;
            midnightblue_panel.Cursor = Cursors.Hand;
            midnightblue_panel.Location = new Point(40, 434);
            midnightblue_panel.Name = "midnightblue_panel";
            midnightblue_panel.Size = new Size(25, 25);
            midnightblue_panel.TabIndex = 13;
            midnightblue_panel.MouseClick += select_color_click;
            // 
            // steelblue_panel
            // 
            steelblue_panel.BackColor = Color.SteelBlue;
            steelblue_panel.BorderStyle = BorderStyle.FixedSingle;
            steelblue_panel.Cursor = Cursors.Hand;
            steelblue_panel.Location = new Point(166, 393);
            steelblue_panel.Name = "steelblue_panel";
            steelblue_panel.Size = new Size(25, 25);
            steelblue_panel.TabIndex = 13;
            steelblue_panel.MouseClick += select_color_click;
            // 
            // darkslategray_panel
            // 
            darkslategray_panel.BackColor = Color.DarkSlateGray;
            darkslategray_panel.BorderStyle = BorderStyle.FixedSingle;
            darkslategray_panel.Cursor = Cursors.Hand;
            darkslategray_panel.Location = new Point(126, 393);
            darkslategray_panel.Name = "darkslategray_panel";
            darkslategray_panel.Size = new Size(25, 25);
            darkslategray_panel.TabIndex = 13;
            darkslategray_panel.MouseClick += select_color_click;
            // 
            // aquamarine_panel
            // 
            aquamarine_panel.BackColor = Color.Aquamarine;
            aquamarine_panel.BorderStyle = BorderStyle.FixedSingle;
            aquamarine_panel.Cursor = Cursors.Hand;
            aquamarine_panel.Location = new Point(82, 393);
            aquamarine_panel.Name = "aquamarine_panel";
            aquamarine_panel.Size = new Size(25, 25);
            aquamarine_panel.TabIndex = 13;
            aquamarine_panel.MouseClick += select_color_click;
            // 
            // mediumseagreen_panel
            // 
            mediumseagreen_panel.BackColor = Color.MediumSeaGreen;
            mediumseagreen_panel.BorderStyle = BorderStyle.FixedSingle;
            mediumseagreen_panel.Cursor = Cursors.Hand;
            mediumseagreen_panel.Location = new Point(40, 393);
            mediumseagreen_panel.Name = "mediumseagreen_panel";
            mediumseagreen_panel.Size = new Size(25, 25);
            mediumseagreen_panel.TabIndex = 12;
            mediumseagreen_panel.MouseClick += select_color_click;
            // 
            // greenyellow_panel
            // 
            greenyellow_panel.BackColor = Color.GreenYellow;
            greenyellow_panel.BorderStyle = BorderStyle.FixedSingle;
            greenyellow_panel.Cursor = Cursors.Hand;
            greenyellow_panel.Location = new Point(166, 353);
            greenyellow_panel.Name = "greenyellow_panel";
            greenyellow_panel.Size = new Size(25, 25);
            greenyellow_panel.TabIndex = 11;
            greenyellow_panel.MouseClick += select_color_click;
            // 
            // oliverdrab_panel
            // 
            oliverdrab_panel.BackColor = Color.OliveDrab;
            oliverdrab_panel.BorderStyle = BorderStyle.FixedSingle;
            oliverdrab_panel.Cursor = Cursors.Hand;
            oliverdrab_panel.Location = new Point(126, 353);
            oliverdrab_panel.Name = "oliverdrab_panel";
            oliverdrab_panel.Size = new Size(25, 25);
            oliverdrab_panel.TabIndex = 10;
            oliverdrab_panel.MouseClick += select_color_click;
            // 
            // olive_panel
            // 
            olive_panel.BackColor = Color.Olive;
            olive_panel.BorderStyle = BorderStyle.FixedSingle;
            olive_panel.Cursor = Cursors.Hand;
            olive_panel.Location = new Point(82, 353);
            olive_panel.Name = "olive_panel";
            olive_panel.Size = new Size(25, 25);
            olive_panel.TabIndex = 9;
            olive_panel.MouseClick += select_color_click;
            // 
            // gold_panel
            // 
            gold_panel.BackColor = Color.Gold;
            gold_panel.BorderStyle = BorderStyle.FixedSingle;
            gold_panel.Cursor = Cursors.Hand;
            gold_panel.Location = new Point(40, 353);
            gold_panel.Name = "gold_panel";
            gold_panel.Size = new Size(25, 25);
            gold_panel.TabIndex = 8;
            gold_panel.MouseClick += select_color_click;
            // 
            // orange_panel
            // 
            orange_panel.BackColor = Color.Orange;
            orange_panel.BorderStyle = BorderStyle.FixedSingle;
            orange_panel.Cursor = Cursors.Hand;
            orange_panel.Location = new Point(166, 313);
            orange_panel.Name = "orange_panel";
            orange_panel.Size = new Size(25, 25);
            orange_panel.TabIndex = 7;
            orange_panel.MouseClick += select_color_click;
            // 
            // red_panel
            // 
            red_panel.BackColor = Color.Red;
            red_panel.BorderStyle = BorderStyle.FixedSingle;
            red_panel.Cursor = Cursors.Hand;
            red_panel.Location = new Point(126, 313);
            red_panel.Name = "red_panel";
            red_panel.Size = new Size(25, 25);
            red_panel.TabIndex = 6;
            red_panel.MouseClick += select_color_click;
            // 
            // black_panel
            // 
            black_panel.BackColor = Color.Black;
            black_panel.BorderStyle = BorderStyle.FixedSingle;
            black_panel.Cursor = Cursors.Hand;
            black_panel.Location = new Point(40, 313);
            black_panel.Name = "black_panel";
            black_panel.Size = new Size(25, 25);
            black_panel.TabIndex = 5;
            black_panel.MouseClick += select_color_click;
            // 
            // color_label
            // 
            color_label.AutoSize = true;
            color_label.Font = new Font("MV Boli", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            color_label.Location = new Point(32, 250);
            color_label.Name = "color_label";
            color_label.Size = new Size(115, 25);
            color_label.TabIndex = 4;
            color_label.Text = "Select color";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("MV Boli", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(32, 147);
            textBox1.MaxLength = 9;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(241, 51);
            textBox1.TabIndex = 3;
            textBox1.MouseClick += _MouseClick;
            // 
            // text_box_label
            // 
            text_box_label.AutoSize = true;
            text_box_label.Font = new Font("MV Boli", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            text_box_label.Location = new Point(32, 75);
            text_box_label.Name = "text_box_label";
            text_box_label.Size = new Size(182, 50);
            text_box_label.TabIndex = 2;
            text_box_label.Text = "Title\r\n(※maxlength is 8)";
            // 
            // study_checkbox
            // 
            study_checkbox.AutoSize = true;
            study_checkbox.CheckAlign = ContentAlignment.MiddleRight;
            study_checkbox.Cursor = Cursors.Hand;
            study_checkbox.Font = new Font("MV Boli", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            study_checkbox.Location = new Point(25, 534);
            study_checkbox.Name = "study_checkbox";
            study_checkbox.Size = new Size(248, 35);
            study_checkbox.TabIndex = 1;
            study_checkbox.Text = "Is this plan study?";
            study_checkbox.UseVisualStyleBackColor = true;
            study_checkbox.MouseClick += _MouseClick;
            // 
            // radio_panel
            // 
            radio_panel.BackColor = Color.Gainsboro;
            radio_panel.Controls.Add(which);
            radio_panel.Controls.Add(button1);
            radio_panel.Controls.Add(minut_label);
            radio_panel.Controls.Add(hour_label);
            radio_panel.Controls.Add(minut_track);
            radio_panel.Controls.Add(hour_track);
            radio_panel.Location = new Point(1377, 55);
            radio_panel.Name = "radio_panel";
            radio_panel.Size = new Size(515, 801);
            radio_panel.TabIndex = 25;
            radio_panel.Visible = false;
            // 
            // which
            // 
            which.AutoSize = true;
            which.Font = new Font("MV Boli", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            which.Location = new Point(12, 99);
            which.Name = "which";
            which.Size = new Size(74, 31);
            which.TabIndex = 25;
            which.Text = "which";
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("MV Boli", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(12, 31);
            button1.Name = "button1";
            button1.Size = new Size(84, 40);
            button1.TabIndex = 11;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            button1.MouseClick += radio_ok_btn;
            // 
            // minut_label
            // 
            minut_label.AutoSize = true;
            minut_label.Font = new Font("MV Boli", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            minut_label.Location = new Point(335, 336);
            minut_label.Name = "minut_label";
            minut_label.Size = new Size(95, 63);
            minut_label.TabIndex = 9;
            minut_label.Text = "00";
            // 
            // hour_label
            // 
            hour_label.AutoSize = true;
            hour_label.Font = new Font("MV Boli", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            hour_label.Location = new Point(89, 336);
            hour_label.Name = "hour_label";
            hour_label.Size = new Size(95, 63);
            hour_label.TabIndex = 8;
            hour_label.Text = "00";
            // 
            // minut_track
            // 
            minut_track.BackColor = Color.Silver;
            minut_track.Cursor = Cursors.Hand;
            minut_track.Location = new Point(458, 31);
            minut_track.Maximum = 59;
            minut_track.Name = "minut_track";
            minut_track.Orientation = Orientation.Vertical;
            minut_track.RightToLeft = RightToLeft.Yes;
            minut_track.Size = new Size(45, 738);
            minut_track.TabIndex = 7;
            minut_track.Value = 59;
            minut_track.ValueChanged += minut_track_Scroll;
            // 
            // hour_track
            // 
            hour_track.BackColor = Color.Silver;
            hour_track.Cursor = Cursors.Hand;
            hour_track.Location = new Point(213, 31);
            hour_track.Maximum = 23;
            hour_track.Name = "hour_track";
            hour_track.Orientation = Orientation.Vertical;
            hour_track.RightToLeft = RightToLeft.Yes;
            hour_track.Size = new Size(45, 738);
            hour_track.TabIndex = 6;
            hour_track.Value = 23;
            hour_track.ValueChanged += hour_track_Scroll;
            // 
            // highlight_timer
            // 
            highlight_timer.Interval = 200;
            highlight_timer.Tick += highlight_timer_Tick;
            // 
            // Register_form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1904, 1041);
            Controls.Add(radio_panel);
            Controls.Add(register_panel);
            Name = "Register_form";
            Text = "Register_form";
            register_panel.ResumeLayout(false);
            register_panel.PerformLayout();
            radio_panel.ResumeLayout(false);
            radio_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)minut_track).EndInit();
            ((System.ComponentModel.ISupportInitialize)hour_track).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel register_panel;
        private CheckBox study_checkbox;
        private Label text_box_label;
        private TextBox textBox1;
        private Panel red_panel;
        private Panel black_panel;
        private Label color_label;
        private Panel gold_panel;
        private Panel orange_panel;
        private Panel oliverdrab_panel;
        private Panel olive_panel;
        private Panel midnightblue_panel;
        private Panel blueviolet_panel;
        private Panel steelblue_panel;
        private Panel darkslategray_panel;
        private Panel aquamarine_panel;
        private Panel mediumseagreen_panel;
        private Panel greenyellow_panel;
        private Panel cur_color_panel;
        private Panel dimgray_panel;
        private Panel pink_panel;
        private Panel magenta_panel;
        private Panel limegreen_panel;
        private Panel salmon_panel;
        private Panel lightsteelblue_panel;
        private Button back_btn;
        private Panel plum_panel;
        private Label st_time_label;
        private Label start_label;
        private Label end_time_label;
        private Label end_label;
        private Label label4;
        private Button ok_btn;
        private Panel radio_panel;
        private Button button1;
        private Label minut_label;
        private Label hour_label;
        private TrackBar minut_track;
        private TrackBar hour_track;
        private Label which;
        private System.Windows.Forms.Timer highlight_timer;
    }
}