﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study_scheduler
{
    public  class month_string_class
    {
       public static List<string> month_list = new List<string>() 
            {
                "January",
                "February",
                 "March",
                 "April",
                "May",
                "June",
                "July",
                "August",
                "September",
                 "October",
                 "November",
                 "December"
            };
        public static ReadOnlyCollection<string> readOnlymonth =
           new ReadOnlyCollection<string>(month_list);
     }


    public static class cur_form_information
    {
        public static DateTime cur_date_button;
    }


    public static class edittime_information
    {
        public static TimeOnly select_st_time;
        public static TimeOnly select_end_time;
        public static bool select_correction_flag;
    }

    public class Daysform_infromation
    {
        public const int x_start_pos = 48;
        public const int y_am_start_pos = 562;
        public const int y_pm_start_pos = 864;
        public const int x_size =12;//5分で11
        public const int y_size =40;
    }
}


