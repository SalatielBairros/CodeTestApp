using System;

namespace CodeTestApp.Interfaces.SegregationPrinciple
{
    /// <summary>
    /// The problem is if some class does NOT implements all the methods of the interface.
    /// </summary>
    public class OldFashionedPrinter : IMachine
    {
        #region Implementation of IMachine

        public void Print(Document d)
        {
            Console.WriteLine(d.PrintAction);
        }

        public void Fax(Document d)
        {
            throw new NotImplementedException();
        }

        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}