using System;

namespace CodeTestApp.Tuples
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7#tuples
    /// </summary>
    public class TuplesMethodsTests
    {
        public static void Execute()
        {
            InstanceSamples();
            TupleMethodsCall();
        }

        public static void InstanceSamples()
        {
            //Tuple suports seven values.
            var tupleSample1 = ("a", "b", 10);
            //(string, string, int) tupleSample1 = ("a", "b", 10);
            //tupleSample1.Item1;
            Console.WriteLine($"Type: {tupleSample1.GetType()}");
            Console.WriteLine();

            var tupleSample2 = (Alpha: "a", Beta: "b", Nmber: 10);
            Console.WriteLine($"Values: {tupleSample2}");
            Console.WriteLine($"Alpha Value: {tupleSample2.Alpha}");
            Console.WriteLine();
        }

        public static void TupleMethodsCall()
        {
            var test1 = TupleMethodTest1();
            Console.WriteLine($"First Call: {test1}");
            Console.WriteLine();

            var test2 = TupleMethodTest2();
            Console.WriteLine($"Seccond Call (Dc Value): {test2.Dc}");
            Console.WriteLine();

            //Deconstructing
            (int i, string s, decimal d) = TupleMethodTest2();
            Console.WriteLine($"Third Call (Deconstructing): ({i}, {s}, {d:##.###})");
            Console.WriteLine();

            //The third parameter is igrnored
            (int horizontal, int vertical, _) = DeconstructClass.Create();
            Console.WriteLine($"Fourth Call (Deconstructing): ({horizontal}, {vertical})");
            Console.WriteLine();

        }

        private static (int, string, decimal) TupleMethodTest1()
        {
            return (10, "Salatiel", 10.69M);
        }

        private static (int Nb, string St, decimal Dc) TupleMethodTest2()
        {
            return (10, "Salatiel", 10.69M);
        }
    }

    public class DeconstructClass
    {
        private DeconstructClass(int x, int y, int i = 0)
        {
            X = x;
            Y = y;
            I = i;
        }

        public static DeconstructClass Create(int x, int y)
        {
            return new DeconstructClass(x, y);
        }

        public static DeconstructClass Create()
        {
            return new DeconstructClass(10, 20);
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int I { get; set; }

        //The Deconstruct method is identified automaticaly
        public void Deconstruct(out int x, out int y, out int i)
        {
            x = this.X;
            y = this.Y;
            i = this.I;
        }
    }
}
