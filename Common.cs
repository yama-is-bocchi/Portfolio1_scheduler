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
        public const int x_size =12;//5分で11
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
}


