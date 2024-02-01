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
        public static string? select_register_label_num;
    }


    public static class edittime_information
    {
        public static DateTime select_st_time;
        public static DateTime select_end_time;
    }

}
