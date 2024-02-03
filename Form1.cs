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
using System.Xml.Serialization;
using Microsoft.VisualBasic;
using AngleSharp.Common;
using Microsoft.Data.SqlClient;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;


namespace study_scheduler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            change_today_information();
            sort_button();
            read_db();
        }

        private DateTime cur_date;


        //データベースを読み取りボタンの配色を変更させる
        private void read_db()
        {
            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=study_scheduler;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            // 実行するSELECT文

            // 接続のためのオブジェクトを生成
            // 実行後にオブジェクトのCloseが必要なため基本的にusing文で囲う
            using (var connection = new SqlConnection(connectionString))
            {
                // 接続を確立
                connection.Open();


                var sql = "SELECT * FROM Main_Table WHERE 年月日 BETWEEN '" + cur_date.ToString("yyyy/MM/01") + "' AND '"+cur_date.ToString("yyyy/MM/")+ DateTime.DaysInMonth(cur_date.Year, cur_date.Month).ToString() + "'; ";

                DateTime temp_time;
                int sum=0;
                // SqlCommand：DBにSQL文を送信するためのオブジェクトを生成
                // SqlDataReader：読み取ったデータを格納するためのオブジェクトを生成
                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        temp_time = (DateTime)reader["年月日"];
                        sum += (int)reader["トータル時間"];
                        Control[] button = this.Controls.Find("button" +((int)cur_date.DayOfWeek+1+temp_time.Day-1).ToString(), true);
                        if (button.Length > 0)
                        {
                            ((Button)button[0]).BackColor =Color.Orange;
                        }

                    }

                }

                total_time_label.Text = trans_minut_hour(ref sum).ToString("");
            }
           

        }

        private TimeOnly trans_minut_hour(ref int p_sum)
        {
            TimeOnly ret_time=new TimeOnly(0,0);
            if (p_sum>=60)
            {

                int temp=p_sum;

                 ret_time = new TimeOnly(p_sum/60, p_sum-((p_sum/60)*60));


            }
            else
            {
                ret_time = new TimeOnly(0, p_sum);
            }

            return ret_time;
        }


        //今日の情報(年,月日,名古屋の気温,天気)を更新
        private void change_today_information()
        {
            DateTime today = DateTime.Today;

            cur_date = new DateTime(today.Year, today.Month, 1); ;

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
                weather_pic_box.Visible = false;
                return;
            }

            if (element.TextContent.Contains("雨"))
            {
                Image img = Image.FromFile(@"Resources\rainy.png");

                weather_pic_box.Image = img;
            }

            else if (element.TextContent.Contains("晴"))
            {
                Image img = Image.FromFile(@"Resources\sunny.png");

                weather_pic_box.Image = img;

            }
            else if (element.TextContent.Contains("曇"))
            {
                Image img = Image.FromFile(@"Resources\cloudy.png");

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
                temp_max_label.Visible = false;
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
                temp_min_label.Visible = false;
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
        //閲覧中の月の情報を変更
        private void cur_label_change()
        {
            cur_month_num_label.Text = cur_date.Month.ToString();

            cur_month_str_label.Text = month_string_class.readOnlymonth[Convert.ToInt16(cur_date.Month) - 1];

            cur_year_label.Text = cur_date.Year.ToString();
        }

        //先月に移動
        private void previous_btn_MouseClick(object sender, MouseEventArgs e)
        {
            cur_date = cur_date.AddMonths(-1);

            cur_label_change();

            sort_button();

            read_db();

        }


        //来月に移動
        private void next_btn_MouseClick(object sender, MouseEventArgs e)
        {
            cur_date = cur_date.AddMonths(1);

            cur_label_change();

            sort_button();

            read_db() ;
        }

        private void sort_button()/*** 年月データを配列に代入 ***/
        {
            for (int i = 1; i < 38; i++)
            {
                Control[] button = this.Controls.Find("button" + i.ToString(), true);
                if (button.Length > 0)
                {
                    ((Button)button[0]).Visible = false;
                    ((Button)button[0]).BackColor= Color.White;
                }
            }

            for (int i = 0; i < DateTime.DaysInMonth(cur_date.Year, cur_date.Month); i++)
            {
                Control[] button = this.Controls.Find("button" + ((int)cur_date.DayOfWeek + 1 + i).ToString(), true);
                if (button.Length > 0)
                {
                    ((Button)button[0]).Visible = true;
                    ((Button)button[0]).Text = (1 + i).ToString();
                }
            }
        }
        //子フォームを開く
        private void open_childform(Form childForm)
        {
            cur_panel.Visible = false;
            cur_panel.Enabled = false;
            change_second_timer.Stop();

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            main_panel.Controls.Add(childForm);
            main_panel.Tag = childForm;

            childForm.Closed += new EventHandler(SubFormClosed);

            childForm.BringToFront();
            childForm.Show();
        }
        //子フォームが閉じたら元に戻す
        private void SubFormClosed(object? sender, EventArgs e)
        {
            cur_panel.Visible = true;
            cur_panel.Enabled = true;
            DateTime today = DateTime.Today;
            change_per_second_information(ref today);
            change_second_timer.Start();

        }

        //cur_panelの背景をグラデーションに変更
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
        //cur_panelの背景を変更
        private void panel1_Resize(object sender, EventArgs e)
        {
            // パネルの表面全体を無効化してパネルを再描画する
            cur_panel.Invalidate();
        }

        private void select_day_btn(object sender, MouseEventArgs e)
        {
            cur_form_information.cur_date_button = new DateTime(cur_date.Year, cur_date.Month, Convert.ToInt16(((Button)sender).Text));
            open_childform(new childforms.Daysform());
        }
    }
}
