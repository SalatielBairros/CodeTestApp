using System;

namespace CodeTestApp.GPS
{
    internal static class GPSHelper
    {
        internal const double EarthRadius = 6371e3;

        internal static double ToRadian(this double angle)
        {
            return Math.PI * angle / 180.0;
        }

        internal static void CalculateDistance()
        {
            const double lat1 = -30.060017;
            const double long1 = -51.171026;

            const double lat2 = -30.060351;
            const double long2 = -51.193391;

            double a1 = lat1.ToRadian();
            double a2 = lat2.ToRadian();

            double d1 = (lat2 - lat1).ToRadian();
            double d2 = (long2 - long1).ToRadian();

            double a = Math.Sin(d1 / 2) * Math.Sin(d1 / 2) + Math.Cos(a1) * Math.Cos(a2) * Math.Sin(d2 / 2) * Math.Sin(d2 / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = EarthRadius * c;

            Console.WriteLine(Math.Round(d, 2));
        }
    }
}
