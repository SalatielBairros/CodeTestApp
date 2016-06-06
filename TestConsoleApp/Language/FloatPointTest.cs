using System;
using System.Text;

namespace CodeTestApp.Language
{
    internal class FloatPointTest
    {
        internal static void ComparingSingle()
        {
            Single v1 = 1;
            Single v3 = 3;
            Single result = v1 / v3;
            double check = v3 * result;
            //Single check = v3 * result;

            bool comparingResult = (check == 1.0);
            //bool comparingResult = result < 1.0;
            //bool comparingResult = result > 1.0;
            //bool comparingResult = Math.Round(result, 7) == 1;
            //Console.WriteLine(Math.Round(result, 7));
            Console.WriteLine(
                new StringBuilder().AppendFormat("Result: {0} \n Check 1: {1} \n Comparing Test: {2}",
                    result, check, comparingResult)
                    .ToString());
            Console.ReadKey();


            /*
            
            EXPLANATION

            Single is the same as float.
            When the variable 'check' is a double, the precision is different and de result is different than 1.
            Using the decimal base, the logical explanation is that the result isn't different because (0,3333 * 3) = 0,9999. 
            But to computers, isn't the same logic, because it use a binary system. The test (result > 1.0) returns true.
            It is possible to try round the number to obtain the result, but could not work depending of the decimal digits.
            To this case, there is two possible solutions: 
                1 - Change the project platform to x64
                2 - Change de 'check' variable to Single            
            */

        }

        internal static void SumSingle()
        {
            double x = .1;
            double result = x*10;
            double result2 = x + x + x + x + x + x + x + x + x + x;

            Console.WriteLine("Result 1: {0}", result);
            Console.WriteLine("Result 2: {0}", result2);

            Console.WriteLine();

            Console.WriteLine("Result 1: {0:R}", result);
            Console.WriteLine("Result 2: {0:R}", result2);

            Console.WriteLine();

            //That result is false if the software uses double, but if the method uses float, the result will be true;
            Console.WriteLine("Equal: {0}", result == result2);
            Console.ReadKey();

            //The conclusion about these last two methods is that the best choise is to avoid convertion between fractionary types.
        }

        internal static void DivisionTest()
        {
            int maxDiscountPercent = 30;
            int markupPercent = 20;
            double niceFactor = 30;
            //int niceFactor = 30; => Original. Int divided by int results in a int and the result is truncated (in this case, to zero).
            double discount = maxDiscountPercent * (markupPercent / niceFactor);
            Console.WriteLine("{0:R}", discount);
            Console.ReadKey();
        }

        internal static void RoudingTest()
        {
            //DOUBLE
            double v1 = 3.5;
            double v2 = 4.5;
            double v3 = 3.25;
            var x = Math.Round(v1); //Rount to 4 => rounding up
            var y = Math.Round(v2); //Rount to 4 => 
            var z = Math.Round(v3, 1); //Rount to 3.2

            //SOLUTION
            //var x = Math.Round(v1, MidpointRounding.AwayFromZero); //Rount to 4
            //var y = Math.Round(v2, MidpointRounding.AwayFromZero); //Rount to 5
            //var z = Math.Round(v3, 1, MidpointRounding.AwayFromZero); //Rount to 3.3

            Console.WriteLine(" DOUBLE: \n X: {0:R} \n Y: {1:R} \n Z: {2:R}", x, y, z);

            // DECIMAL
            decimal v4 = 3.5m;
            decimal v5 = 4.5m;
            decimal v6 = 3.25m;
            var a = Math.Round(v4); //Rount to 4
            var b = Math.Round(v5); //Rount to 4
            var c = Math.Round(v6, 1); //Rount to 3.2
            Console.WriteLine("\n\n DECIMAL: \n A: {0} \n B: {1} \n C: {2}", a, b, c);
            //It is the same thing to both.


            Console.ReadKey();
        }
    }
}
