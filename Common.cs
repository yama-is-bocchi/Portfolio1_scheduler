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
}
