using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anju.Navigate.Utilities
{
    public static partial class Extensions
    {
        public static DateTime AddBusinessDays(this DateTime current,int? days,IEnumerable<DateTime> holidays = null)
        {
         
            var sign = Math.Sign((decimal)days);
            var unsignedDays = Math.Abs((decimal)days);
            for (var i = 0; i < unsignedDays; i++)
            {
                do
                {
                    current = current.AddDays(sign);
                }
                while (current.DayOfWeek == DayOfWeek.Saturday
                    || current.DayOfWeek == DayOfWeek.Sunday
                    || (holidays != null && holidays.Contains(current.Date))
                    );
            }
            return current;
        }

        public static DateTime AddCalenderDays(this DateTime current, int? days, IEnumerable<DateTime> holidays = null)
        {
            var sign = Math.Sign((decimal)days);
            var unsignedDays = Math.Abs((decimal)days);
            for (var i = 0; i < unsignedDays; i++)
            {
                do
                {
                    current = current.AddDays(sign);
                }
                while (holidays != null && holidays.Contains(current.Date));                    
            }
            return current;
        }


        public static Int32 DiffMonths(this DateTime? start, DateTime? end)
        {
            Int32 months = 0;
            DateTime? tmp = start;

            while (tmp < end)
            {
                months++;
                tmp = tmp?.AddMonths(1);
            }

            return months;
        }

    }
}
