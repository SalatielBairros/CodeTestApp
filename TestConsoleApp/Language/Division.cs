using System;

namespace CodeTestApp.Language
{
    internal class Division
    {
        private static void DecimalByZero()
        {
            try
            {
                decimal zero = 0;
                decimal number = 3;
                decimal result = (number / zero);
                Console.WriteLine("DECIMAL: {0:R}", result);

            }
            catch (Exception ex)
            {
                Console.WriteLine("DECIMAL: {0}", ex.Message);
            }
        }

        private static void IntegerByZero()
        {
            try
            {
                int zero = 0;
                int number = 3;
                int result = (number / zero);
                Console.WriteLine("INTEGER: {0}", result);

            }
            catch (Exception ex)
            {
                Console.WriteLine("INTEGER: {0}", ex.Message);
            }
        }

        private static void DoubleByZero()
        {
            try
            {
                double zero = 0;
                double number = 3;
                double result = (number / zero);
                Console.WriteLine("DOUBLE: {0:R}", result);
                //Double accepts intifiny.

            }
            catch (Exception ex)
            {
                Console.WriteLine("DOUBLE: {0}", ex.Message);
            }
        }

        internal static void ExecuteDivisionByZero()
        {
            DecimalByZero();
            IntegerByZero();
            DoubleByZero();
            Console.ReadKey();
        }
    }
}
