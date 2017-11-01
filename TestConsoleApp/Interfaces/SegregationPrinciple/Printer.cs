using System;

namespace CodeTestApp.Interfaces.SegregationPrinciple
{
    public class Printer : IPrinter
    {
        public static Printer Instance => new Printer();

        #region Implementation of IPrinter

        public void Print(Document d)
        {
            Console.WriteLine(d.PrintAction);
        }

        #endregion
    }
}