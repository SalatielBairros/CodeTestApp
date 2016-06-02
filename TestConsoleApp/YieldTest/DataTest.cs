using System.Collections.Generic;

namespace CodeTestApp.YieldTest
{
    public class DataTest
    {
        public IEnumerable<int> Numbers
        {
            get
            {
                yield return 2;
                yield return 4;
                yield return 6;
                yield return 8;
                yield return 10;
            }
        }

        internal static void RefTest(ref int a)
        {
            a = 20;
        }
    }
}
