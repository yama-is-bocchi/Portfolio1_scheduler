namespace study_scheduler.Kakeibo_forms.child_forms
{
    partial class Zandaka_form
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
            zandaka_top_btn = new Button();
            expendi_top_btn = new Button();
            income_top_btn = new Button();
            zandaka_top_panel = new Panel();
            zandaka_top_panel.SuspendLayout();
            SuspendLayout();
            // 
            // zandaka_top_btn
            // 
            zandaka_top_btn.BackColor = Color.FromArgb(50, 50, 50);
            zandaka_top_btn.Cursor = Cursors.Hand;
            zandaka_top_btn.FlatStyle = FlatStyle.Flat;
            zandaka_top_btn.Font = new Font("MV Boli", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            zandaka_top_btn.ForeColor = Color.LimeGreen;
            zandaka_top_btn.Location = new Point(505, 505);
            zandaka_top_btn.Name = "zandaka_top_btn";
            zandaka_top_btn.Size = new Size(650, 140);
            zandaka_top_btn.TabIndex = 6;
            zandaka_top_btn.Text = "残高参照";
            zandaka_top_btn.UseVisualStyleBackColor = false;
            zandaka_top_btn.MouseClick += zandaka_top_btn_MouseClick;
            zandaka_top_btn.MouseEnter += zandaka_top_panel_MouseEnter;
            zandaka_top_btn.MouseLeave += zandaka_top_panel_MouseLeave;
            // 
            // expendi_top_btn
            // 
            expendi_top_btn.BackColor = Color.FromArgb(50, 50, 50);
            expendi_top_btn.Cursor = Cursors.Hand;
            expendi_top_btn.FlatStyle = FlatStyle.Flat;
            expendi_top_btn.Font = new Font("MV Boli", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            expendi_top_btn.ForeColor = Color.LimeGreen;
            expendi_top_btn.Location = new Point(913, 222);
            expendi_top_btn.Name = "expendi_top_btn";
            expendi_top_btn.Size = new Size(650, 140);
            expendi_top_btn.TabIndex = 5;
            expendi_top_btn.Text = "支出一覧,参照";
            expendi_top_btn.UseVisualStyleBackColor = false;
            expendi_top_btn.MouseClick += expendi_top_btn_MouseClick;
            expendi_top_btn.MouseEnter += zandaka_top_panel_MouseEnter;
            expendi_top_btn.MouseLeave += zandaka_top_panel_MouseLeave;
            // 
            // income_top_btn
            // 
            income_top_btn.BackColor = Color.FromArgb(50, 50, 50);
            income_top_btn.Cursor = Cursors.Hand;
            income_top_btn.FlatStyle = FlatStyle.Flat;
            income_top_btn.Font = new Font("MV Boli", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            income_top_btn.ForeColor = Color.LimeGreen;
            income_top_btn.Location = new Point(101, 222);
            income_top_btn.Name = "income_top_btn";
            income_top_btn.Size = new Size(650, 140);
            income_top_btn.TabIndex = 4;
            income_top_btn.Text = "収入一覧,編集";
            income_top_btn.UseVisualStyleBackColor = false;
            income_top_btn.MouseClick += income_top_btn_MouseClick;
            income_top_btn.MouseEnter += zandaka_top_panel_MouseEnter;
            income_top_btn.MouseLeave += zandaka_top_panel_MouseLeave;
            // 
            // zandaka_top_panel
            // 
            zandaka_top_panel.Controls.Add(income_top_btn);
            zandaka_top_panel.Controls.Add(expendi_top_btn);
            zandaka_top_panel.Controls.Add(zandaka_top_btn);
            zandaka_top_panel.Dock = DockStyle.Fill;
            zandaka_top_panel.Location = new Point(0, 0);
            zandaka_top_panel.Name = "zandaka_top_panel";
            zandaka_top_panel.Size = new Size(1660, 879);
            zandaka_top_panel.TabIndex = 7;
            // 
            // Zandaka_form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(70, 70, 70);
            ClientSize = new Size(1660, 879);
            Controls.Add(zandaka_top_panel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Zandaka_form";
            Text = "Zandaka_form";
            zandaka_top_panel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button zandaka_top_btn;
        private Button expendi_top_btn;
        private Button income_top_btn;
        private Panel zandaka_top_panel;
    }
}