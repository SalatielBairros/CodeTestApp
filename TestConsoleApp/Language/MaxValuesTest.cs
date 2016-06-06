using System;

namespace CodeTestApp.Language
{
    internal class MaxValuesTest
    {
        internal static void MaxValueInt()
        {
            try
            {
                int top = int.MaxValue;
                int next = top + 1;
                Console.WriteLine("INTEGER: {0}", next);

            }
            catch (Exception ex)
            {
                Console.WriteLine("INTEGER: {0}", ex.Message);
            }
        }

        internal static void MaxValueDouble()
        {
            try
            {
                double top = double.MaxValue;
                double next = top + 1;
                Console.WriteLine("DOUBLE: {0}", next);

            }
            catch (Exception ex)
            {
                Console.WriteLine("DOUBLE: {0}", ex.Message);
            }
        }

        internal static void MaxValueDecimal()
        {
            try
            {
                decimal top = decimal.MaxValue;
                decimal next = top + 1;
                Console.WriteLine("DECIMAL: {0}", next);

            }
            catch (Exception ex)
            {
                Console.WriteLine("DECIMAL: {0}", ex.Message);
            }
        }

        internal static void Execute()
        {
            MaxValueInt();
            MaxValueDouble();
            MaxValueDecimal();
            Console.ReadKey();

            /*
            EXPLANATION

            Just decimal throws an exception when the maximum value is added by one. 
            Double, as float, just does not change de value because de alteration is really small.
            Integer use binary systems, so when the MaxValue is added with one, the number turns igual to MinValue (the negative version of MaxValue)
            There is a property that can be setted on projects that defines to Visual Studio that Integer Overflow must to be tested. That property is not setted by default.
            
            */
        }
    }
}
