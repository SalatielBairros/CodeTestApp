using System;

namespace CodeTestApp.Interfaces.SegregationPrinciple
{
    public class Photocopier : IPrinter, IScanner
    {
        #region Implementation of IPrinter

        public void Print(Document d)
        {
            Console.WriteLine(d.PrintAction);
        }

        #endregion

        #region Implementation of IScanner

        public void Scan(Document d)
        {
            Console.WriteLine(d.ScanAction);
        }

        #endregion
    }
}