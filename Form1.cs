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
using System.Resources;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using AngleSharp;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace study_scheduler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            change_today_information();
        }

        private DateTime cur_date;


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // ブロック（{}）を抜けたら自動的に Dispose するC#構文
            using (
                // グラデーションブラシ作成
                var gb = new LinearGradientBrush(
                // グラデーション範囲（表示クリッピング領域）
                e.Graphics.VisibleClipBounds,
                // グラデーション開始色（紺色）
                Color.SpringGreen,

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
            cur_panel.Invalidate();
        }


        private void change_today_information()
        {
            DateTime today = DateTime.Today;

            cur_date = today;

            cur_label_change();

            change_per_second_information(ref today);

            change_second_timer.Start();

            scraping_tokyo_temp();

        }

        private void scraping_tokyo_temp()
        {
            // 取得対象の設定
            var htmlUrl = $"https://weather.yahoo.co.jp/weather/jp/23/5110.html";
            var querySelector = $"#main > div.forecastCity > table > tbody > tr > td:nth-child(1) > div > p.pict";
            // HTMLドキュメントの取得
            var document = BrowsingContext.New(Configuration.Default.WithDefaultLoader()).OpenAsync(htmlUrl).Result;
            // クエリセレクタでデータの取得
            var element = document.QuerySelector(querySelector);
            /// 天気の文字列を種痘
            /// 
            if (element == null)
            {
                return;
            }

            if (element.TextContent.Contains("晴"))
            {
                Image img = Image.FromFile(@"Resources\sunny.png");

                weather_pic_box.Image = img;

            }
            else if (element.TextContent.Contains("曇"))
            {
                Image img = Image.FromFile(@"Resources\cloudy.png");

                weather_pic_box.Image = img;

            }
            else if (element.TextContent.Contains("雨"))
            {
                Image img = Image.FromFile(@"Resources\rainy.png");

                weather_pic_box.Image = img;
            }
            else if (element.TextContent.Contains("雪"))
            {
                Image img = Image.FromFile(@"Resources\snow.png");

                weather_pic_box.Image = img;
            }
            else
            {
                weather_pic_box.Visible = false;
            }

            querySelector = $"#main > div.forecastCity > table > tbody > tr > td:nth-child(1) > div > ul > li.high > em";
            // HTMLドキュメントの取得
            document = BrowsingContext.New(Configuration.Default.WithDefaultLoader()).OpenAsync(htmlUrl).Result;
            // クエリセレクタでデータの取得
            element = document.QuerySelector(querySelector);
            /// 天気の文字列を種痘
            /// 
            if (element == null)
            {
                return;
            }


            temp_max_label.Text = element.TextContent + "℃";

            querySelector = $"#main > div.forecastCity > table > tbody > tr > td:nth-child(1) > div > ul > li.low > em";
            // HTMLドキュメントの取得
            document = BrowsingContext.New(Configuration.Default.WithDefaultLoader()).OpenAsync(htmlUrl).Result;
            // クエリセレクタでデータの取得
            element = document.QuerySelector(querySelector);

            if (element == null)
            {
                return;
            }

            temp_min_label.Text = element.TextContent + "℃";
        }


        //現在の日付時間更新
        private void change_per_second_information(ref DateTime date)
        {
            today_date_label.Text = date.ToString("yyyy/MM/dd");

            date = DateTime.Now;

            now_time_label.Text = date.ToString("hh:mm:ss");

          
        }


        //現在の日付時間更新タイマー 
        private void change_second_timer_Tick(object sender, EventArgs e)
        {

            change_second_timer.Stop();

            DateTime today = DateTime.Today;

            change_per_second_information(ref today);

            change_second_timer.Start();

        }

        private void cur_label_change()
        {
            cur_month_num_label.Text = cur_date.Month.ToString();

            cur_month_str_label.Text = month_string_class.readOnlymonth[Convert.ToInt16(cur_date.Month) - 1];

            cur_year_label.Text = cur_date.Year.ToString();
        }

        //先月に移動
        private void previous_btn_MouseClick(object sender, MouseEventArgs e)
        {
            cur_date=cur_date.AddMonths(-1);
            
            cur_label_change();
        }


        //来月に移動
        private void next_btn_MouseClick(object sender, MouseEventArgs e)
        {
            cur_date = cur_date.AddMonths(1);

            cur_label_change();

        }
    }
}
