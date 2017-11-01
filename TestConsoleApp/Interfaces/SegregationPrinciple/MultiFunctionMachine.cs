using System;

namespace CodeTestApp.Interfaces.SegregationPrinciple
{
    /// <summary>
    /// The "big interface" works fine in a MultiFuncion Printer, because it implements all the methods.
    /// </summary>
    public class MultiFunctionMachine : IMachine
    {
        #region Implementation of IMachine

        public void Print(Document d)
        {
            Console.WriteLine(d.PrintAction);
        }

        public void Fax(Document d)
        {
            Console.WriteLine(d.FaxAction);

        }

        public void Scan(Document d)
        {
            Console.WriteLine(d.ScanAction);
        }

        #endregion
    }
}