using System.Diagnostics;
using System.Drawing.Drawing2D;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace study_scheduler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // ブロック（{}）を抜けたら自動的に Dispose するC#構文
            using (
                // グラデーションブラシ作成
                var gb = new LinearGradientBrush(
                // グラデーション範囲（表示クリッピング領域）
                e.Graphics.VisibleClipBounds,
                // グラデーション開始色（紺色）
                Color.Lime,

                // グラデーション終了色（赤紫）
                Color.Cyan,
                // グラデーション方向（縦）
                LinearGradientMode.Horizontal))
            {
                // 四角形の内部を塗りつぶす（表示クリッピング領域）
                e.Graphics.FillRectangle(gb, e.Graphics.VisibleClipBounds);
            }
            // using構文を使用したため Dispose を書く必要はない
            //リソースを解放する
            //gb.Dispose();
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            // パネルの表面全体を無効化してパネルを再描画する
            panel1.Invalidate();
        }


        private void pic()
        {
            Image img =Image.FromFile(@"resor");

            weather_pic_box.Image = img;
        }






    }
}
