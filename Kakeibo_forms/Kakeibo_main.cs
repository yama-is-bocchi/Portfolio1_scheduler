using study_scheduler.Methods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace study_scheduler.Kakeibo_forms
{
    public partial class Kakeibo_main : Form
    {
        public Kakeibo_main()
        {
            InitializeComponent();
            Init_form_data();
            
        }
        private Form? Cur_form;
        private Button? Cur_active_btn;
        Kakeibo_form_methods methods = new Kakeibo_form_methods();

        private void Init_form_data()
        {
            Kakeibo_const.kakeibo_date = DateTime.Now;
            cur_date_label.Text = Kakeibo_const.kakeibo_date.ToString("yyyy/MM/dd");
            cur_month_str_label.Text = Kakeibo_const.kakeibo_date.ToString("MMMM", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
            cur_page_label.Text = "トップページ";
        }

        
        private void kakeibo_bar_panel_Paint(object sender, PaintEventArgs e)
        {
            using (
                // グラデーションブラシ作成
                var gb = new LinearGradientBrush(
                e.Graphics.VisibleClipBounds,
                Color.Fuchsia,
                Color.DarkOrchid,
                LinearGradientMode.Horizontal))
            {
                // 四角形の内部を塗りつぶす（表示クリッピング領域）
                e.Graphics.FillRectangle(gb, e.Graphics.VisibleClipBounds);
            }
        }
        //cur_panelの背景を変更
        private void kakeibo_bar_panel_Resize(object sender, EventArgs e)
        {
            // パネルの表面全体を無効化してパネルを再描画する
            kakeibo_bar_panel.Invalidate();
        }

        private void Enter_mouse_btn(object? sender, EventArgs e)
        {
            methods.Enter_mouse_btn(sender,e);

        }

        private void Leave_mouse_btn(object? sender, EventArgs e)
        {
            methods.Leave_mouse_btn(sender, e);

        }

        private void exit_btn_MouseClick(object sender, MouseEventArgs e)
        {
            cur_form_information.exit_btn_flag = true;
            Close();
        }

        private void Back_scheduler_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void Button_click(object sender, MouseEventArgs e)
        {

            if (sender is Button button && button != Cur_active_btn)
            {
                if (Cur_active_btn != null)
                {
                    Cur_active_btn.BackColor = Color.FromArgb(50, 50, 50);
                    Cur_active_btn.ForeColor = Color.LimeGreen;
                    Cur_active_btn.MouseLeave += Leave_mouse_btn;
                }
                Jud_menu_control(sender);
                if (Cur_active_btn == null || Cur_form==null) return;
                Cur_active_btn.MouseLeave -= Leave_mouse_btn;
                Cur_active_btn.BackColor = Color.LimeGreen;
                Cur_active_btn.ForeColor = Color.FromArgb(50, 50, 50);
                Cur_form.TopLevel = false;
                Cur_form.FormBorderStyle = FormBorderStyle.None;
                Cur_form.Dock = DockStyle.Fill;
                kakeibo_main_panel.Controls.Add(Cur_form);
                kakeibo_main_panel.Tag = Cur_form;
                Cur_form.BringToFront();
                Cur_form.Show();
            }
        }

        private void Jud_menu_control(object sender)
        {
            Cur_form?.Close();

            if (((Button)sender).Text.Contains("収入登録"))
            {
                Cur_active_btn = Income_regi_btn;
                cur_page_label.Text = "収入登録";
                kakeibo_static_info.cur_page_name = "収入";
                Cur_form = new child_forms.Income_regi();
            }
            else if (((Button)sender).Text.Contains("支出登録"))
            {
                Cur_active_btn = Expenditure_regi_btn;
                cur_page_label.Text = "支出登録";
                kakeibo_static_info.cur_page_name = "支出";
                Cur_form = new child_forms.Income_regi();
            }
            else if (((Button)sender).Text.Contains("目標登録"))
            {
                Cur_active_btn = goal_regi_btn;
                cur_page_label.Text = "目標登録,参照";
                kakeibo_static_info.cur_page_name = "目標";
                Cur_form = new child_forms.Goal_form();

            }
            else if (((Button)sender).Text.Contains("残高参照"))
            {
                Cur_active_btn = Income_expendi_remain_ref_btn;
                cur_page_label.Text = "収入,支出,残高参照";
                kakeibo_static_info.cur_page_name = "サブトップ";
                Cur_form = new child_forms.Zandaka_form();
            }
           
        }
    }
}
