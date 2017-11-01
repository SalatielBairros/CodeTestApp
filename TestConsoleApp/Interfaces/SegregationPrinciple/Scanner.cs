using System;

namespace CodeTestApp.Interfaces.SegregationPrinciple
{
    public class Scanner : IScanner
    {
        public static Scanner Instance => new Scanner();

        #region Implementation of IScanner

        public void Scan(Document d)
        {
            Console.WriteLine(d.ScanAction);
        }

        #endregion
    }
}