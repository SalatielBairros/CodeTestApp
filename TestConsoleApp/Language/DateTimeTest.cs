using System;

namespace CodeTestApp.Language
{
    internal class DateTimeTest
    {
        internal static void DateArithimeticTest()
        {
            var newYears = new DateTime(2012, 1, 1);
            for (int i = 0; i < 365; i++)
            {
                var date = newYears.AddDays(i);
                var newDate = IncrementByYear(date);
                //var newDate = date.AddYears(1); => It works
            }
        }

        private static DateTime IncrementByYear(DateTime date)
        {
            //February 29th!!! 
            //2013 had that day!
            return new DateTime(date.Year + 1, date.Month, date.Day);
        }
    }
}
