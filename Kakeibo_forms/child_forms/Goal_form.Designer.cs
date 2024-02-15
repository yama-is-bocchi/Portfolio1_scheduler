namespace study_scheduler.Kakeibo_forms.child_forms
{
    partial class Goal_form
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
            change_cur_info = new Label();
            label4 = new Label();
            add_btn = new Button();
            change_btn = new Button();
            goal_panel = new Panel();
            goal_panel.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MV Boli", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LimeGreen;
            label1.Location = new Point(119, 9);
            label1.Name = "label1";
            label1.Size = new Size(88, 41);
            label1.TabIndex = 13;
            label1.Text = "Title";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("MV Boli", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.LimeGreen;
            label2.Location = new Point(466, 9);
            label2.Name = "label2";
            label2.Size = new Size(210, 41);
            label2.TabIndex = 14;
            label2.Text = "Goal amount";
            // 
            // change_cur_info
            // 
            change_cur_info.AutoSize = true;
            change_cur_info.Font = new Font("MV Boli", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            change_cur_info.ForeColor = Color.LimeGreen;
            change_cur_info.Location = new Point(883, 9);
            change_cur_info.Name = "change_cur_info";
            change_cur_info.Size = new Size(195, 41);
            change_cur_info.TabIndex = 15;
            change_cur_info.Text = "Expenditure";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("MV Boli", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.LimeGreen;
            label4.Location = new Point(1297, 9);
            label4.Name = "label4";
            label4.Size = new Size(74, 41);
            label4.TabIndex = 16;
            label4.Text = "Diff";
            // 
            // add_btn
            // 
            add_btn.BackColor = Color.FromArgb(50, 50, 50);
            add_btn.Cursor = Cursors.Hand;
            add_btn.FlatStyle = FlatStyle.Flat;
            add_btn.Font = new Font("MV Boli", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            add_btn.ForeColor = Color.LimeGreen;
            add_btn.Location = new Point(1541, 4);
            add_btn.Margin = new Padding(4, 3, 4, 3);
            add_btn.Name = "add_btn";
            add_btn.Size = new Size(115, 53);
            add_btn.TabIndex = 21;
            add_btn.Text = "Add";
            add_btn.UseVisualStyleBackColor = false;
            add_btn.MouseClick += add_btn_MouseClick;
            add_btn.MouseEnter += add_btn_MouseEnter;
            add_btn.MouseLeave += add_btn_MouseLeave;
            // 
            // change_btn
            // 
            change_btn.BackColor = Color.FromArgb(50, 50, 50);
            change_btn.Cursor = Cursors.Hand;
            change_btn.FlatStyle = FlatStyle.Flat;
            change_btn.Font = new Font("MV Boli", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            change_btn.ForeColor = Color.LimeGreen;
            change_btn.Location = new Point(1406, 4);
            change_btn.Margin = new Padding(4, 3, 4, 3);
            change_btn.Name = "change_btn";
            change_btn.Size = new Size(127, 53);
            change_btn.TabIndex = 22;
            change_btn.Text = "Change";
            change_btn.UseVisualStyleBackColor = false;
            change_btn.MouseClick += change_btn_MouseClick;
            // 
            // goal_panel
            // 
            goal_panel.AutoScroll = true;
            goal_panel.Controls.Add(add_btn);
            goal_panel.Controls.Add(change_btn);
            goal_panel.Controls.Add(label1);
            goal_panel.Controls.Add(label2);
            goal_panel.Controls.Add(label4);
            goal_panel.Controls.Add(change_cur_info);
            goal_panel.Dock = DockStyle.Fill;
            goal_panel.Location = new Point(0, 0);
            goal_panel.Name = "goal_panel";
            goal_panel.Size = new Size(1660, 879);
            goal_panel.TabIndex = 23;
            // 
            // Goal_form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(70, 70, 70);
            ClientSize = new Size(1660, 879);
            Controls.Add(goal_panel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Goal_form";
            Text = "Goal_form";
            goal_panel.ResumeLayout(false);
            goal_panel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label change_cur_info;
        private Label label4;
        private Button add_btn;
        private Button change_btn;
        private Panel goal_panel;
    }
}