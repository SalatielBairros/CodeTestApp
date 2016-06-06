using System;

namespace CodeTestApp.Language
{
    internal class OverloadTest
    {
        internal static void Execute()
        {
            Int16 v1 = 42; //Short
            Int32 v2 = 42;
            Int64 v3 = 42;
            DateTime date = new DateTime(2006, 03, 25);

            Console.WriteLine(Test(v1));
            Console.WriteLine(Test(v2));
            Console.WriteLine(Test(v3));
            Console.WriteLine(Test(date));
            Console.ReadKey();
        }

        private static string Test(Int64 value)
        {
            //INT
            return "Int64 version";
        }

        private static string Test(Int32 value)
        {
            //LONG
            return "Int32 version";
        }

        //private static string Test(object value)
        //{
        //    return "Object version";
        //}

        private static string Test<T>(T value)
        {
            return "Generic version";
        }

        /*
        
        With the method that recives an object, the return is:

            Int32 Version => The Int16 is reconized as an Int32. It is called Implicit Conversion
            Int32 Version
            Int64 Version
            Object Version

        With the generic method, the return is:

            Generic Version
            Int32 Version
            Int64 Version
            Generic Version
        
        */

    }
}
