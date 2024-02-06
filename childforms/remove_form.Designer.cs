namespace study_scheduler.childforms
{
    partial class remove_form
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
            remove_kind_label = new Label();
            ok_btn = new Button();
            cancel_btn = new Button();
            label1 = new Label();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // remove_kind_label
            // 
            remove_kind_label.AutoSize = true;
            remove_kind_label.Font = new Font("MV Boli", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            remove_kind_label.Location = new Point(69, 90);
            remove_kind_label.Name = "remove_kind_label";
            remove_kind_label.Size = new Size(96, 41);
            remove_kind_label.TabIndex = 0;
            remove_kind_label.Text = "label1";
            // 
            // ok_btn
            // 
            ok_btn.Cursor = Cursors.Hand;
            ok_btn.Font = new Font("MV Boli", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ok_btn.Location = new Point(226, 169);
            ok_btn.Name = "ok_btn";
            ok_btn.Size = new Size(101, 46);
            ok_btn.TabIndex = 1;
            ok_btn.Text = "OK";
            ok_btn.UseVisualStyleBackColor = true;
            ok_btn.MouseClick += ok_btn_MouseClick;
            // 
            // cancel_btn
            // 
            cancel_btn.Cursor = Cursors.Hand;
            cancel_btn.Font = new Font("MV Boli", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cancel_btn.Location = new Point(105, 169);
            cancel_btn.Name = "cancel_btn";
            cancel_btn.Size = new Size(101, 46);
            cancel_btn.TabIndex = 2;
            cancel_btn.Text = "Cancel";
            cancel_btn.UseVisualStyleBackColor = true;
            cancel_btn.MouseClick += cancel_btn_MouseClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MV Boli", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(69, 35);
            label1.Name = "label1";
            label1.Size = new Size(181, 41);
            label1.TabIndex = 3;
            label1.Text = "Remove at";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(remove_kind_label);
            panel1.Controls.Add(cancel_btn);
            panel1.Controls.Add(ok_btn);
            panel1.Location = new Point(777, 327);
            panel1.Name = "panel1";
            panel1.Size = new Size(423, 258);
            panel1.TabIndex = 4;
            // 
            // remove_form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(panel1);
            Name = "remove_form";
            Text = "remove_form";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label remove_kind_label;
        private Button ok_btn;
        private Button cancel_btn;
        private Label label1;
        private Panel panel1;
    }
}