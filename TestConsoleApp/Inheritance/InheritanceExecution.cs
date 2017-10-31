using System;

namespace CodeTestApp.Inheritance
{
    public static class InheritanceExecution
    {
        public static void TestImplictCast()
        {
            Base b = InheritanceMethods.Instance.GetAdditional();
            Console.WriteLine("BASE CLASS");
            Console.WriteLine(b.GetType());
            Console.WriteLine(b.ToString());

            /* 
             * CONCLUSION
             * - Always it returns the Derived class.
             */
        }

        public static void Execute()
        {
            TestImplictCast();
        }
    }
}