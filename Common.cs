using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace study_scheduler
{

   

    public static class cur_form_information
    {
        public static DateTime cur_date_button;
        public static bool exit_btn_flag;

        public static string? cur_data_base_name;
    }


    public static class edittime_information
    {
        public static string Title_Data_base_connect_code= @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = Title_data_base; Integrated Security = True; Connect Timeout = 30; Encrypt=False;Trust Server Certificate=False;Application Intent = ReadWrite; Multi Subnet Failover=False";
        public static string? sql_code;
        public static TimeOnly select_st_time;
        public static TimeOnly select_end_time;
        public static Color corr_color;
        public static string? corr_title;
        public static bool corr_study_flag;
        public static bool select_correction_flag;
    }

    public class Daysform_infromation
    {
        public const int x_start_pos = 47;
        public const int y_am_start_pos = 547;
        public const int y_pm_start_pos = 849;
        public const int x_size =12;//5分で12
        public const int y_size =55;
    }

    public class Remove_code()
    {
        public static string? remove_code;
    }

    public class Now_panel() 
    {
        public const int x_pos =33;
        public const int y_am_pos =478;
        public const int y_pm_pos =781;
    }

    public class Kakeibo_const() 
    {
        public static DateTime kakeibo_date;
        public static DateTime Temp_date_pick=new DateTime();
        public static string? cur_page_name;
        
    }
    public class kakeibo_goal_const()
    {
        public  Point title_point = new Point(116, 82);
        public  Point goal_point = new Point(484, 82);
        public  Point money_point = new Point(893, 82);
        public  Point diff_point = new Point(1299, 82);
        public Size under_line_size = new Size(1666,3);
        public Point under_line_point = new Point(3, 123);
        public static string? cur_setting_mode;
        public Point gene_label_point = new Point(18, 14);
    }
}


