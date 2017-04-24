using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mipsed7.DatabaseBackup.ApplicationLogic.Tools
{
    public class DateTimeTool
    {
        public static int WeekIndex(DateTime dateTime)
        {
            return System.Globalization.CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(dateTime, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        }
    }
}
