using System;
using System.Collections.Generic;

namespace CodeTestApp.YieldTest
{
    internal class ExYield
    {
        internal static IEnumerable<int> YieldTesT()
        {
            for (int i = 0; i <= 10; i++)
            {
                yield return i;
            }
        }

        internal static void GetNextPar()
        {
            foreach (int item in (new DataTest()).Numbers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
