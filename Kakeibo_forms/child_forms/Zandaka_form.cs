using System;
using System.Collections.Generic;
using study_scheduler.Methods;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace study_scheduler.Kakeibo_forms.child_forms
{
    public partial class Zandaka_form : Form
    {
        public Zandaka_form()
        {
            InitializeComponent();
        }
        Kakeibo_form_methods methods = new Kakeibo_form_methods();

        //残高メニューで選択された画面を開く
        private void Open_form(Form Cur_form)
        {
            Cur_form.TopLevel = false;
            Cur_form.FormBorderStyle = FormBorderStyle.None;
            Cur_form.Dock = DockStyle.Fill;
            zandaka_top_panel.Controls.Add(Cur_form);
            zandaka_top_panel.Tag = Cur_form;
            Cur_form.BringToFront();
            Cur_form.Show();
        }

        //オブジェクト内にマウスカーソルが入る
        private void zandaka_top_panel_MouseEnter(object sender, EventArgs e)
        {
            methods.Enter_mouse_btn(sender, e);
        }

        //オブジェクト内からマウスカーソルが出る
        private void zandaka_top_panel_MouseLeave(object sender, EventArgs e)
        {
            methods.Leave_mouse_btn(sender, e);
        }

        //収入メニュー選択
        private void income_top_btn_MouseClick(object sender, MouseEventArgs e)
        {
            kakeibo_static_info.cur_page_name = "収入";
            //オープンメソッド
            Open_form(new Edit_viewdata());
        }
        
        //支出メニュー選択
        private void expendi_top_btn_MouseClick(object sender, MouseEventArgs e)
        {
            kakeibo_static_info.cur_page_name = "支出";
            //オープンメソッド
            Open_form(new Edit_viewdata());
        }

        //残高メニュー選択
        private void zandaka_top_btn_MouseClick(object sender, MouseEventArgs e)
        {
            kakeibo_static_info.cur_page_name = "残高";
            //オープンメソッド
            Open_form(new Zandka_view());
        }
    }
}
