using System;

namespace CodeTestApp
{
    internal class DerivedClass : BaseClass
    {
        public override void M1()
        {
            ShowMessage("Derived");
        }
    }

    internal abstract class BaseClass : IImplementation
    {
        public void Execute()
        {
            M1();
        }

        protected void ShowMessage(string message)
        {
            Console.WriteLine("{0} Method", message);
        }

        public abstract void M1();
    }

    internal interface IImplementation
    {
        void M1();
    }
}
