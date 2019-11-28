using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeTestApp.Eldorado
{
    public class TestExecution
    {
        public static void MainT()
        {
            var nNumbers = ConsoleHelper.GetConsoleIntValue();

            // Now we need to read and output "numberCount" times
            for (var i = 0; i < nNumbers; i++)
            {
                var currentNumber = ConsoleHelper.GetConsoleIntValue();

                Console.WriteLine(new Fibonacci().CalculateNext(currentNumber));
            }
        }
    }

    public static class ConsoleHelper
    {
        public static int GetConsoleIntValue()
        {
            var value = 0;
            var input = string.Empty;

            do
            {
                input = Console.ReadLine();
            } while (!int.TryParse(input, out value));

            return value;
        }
    }

    public class Fibonacci
    {
        private static readonly List<int> _sequence = new List<int>() { 0, 1 };

        public int CalculateNext(int baseNumber)
        {
            if (baseNumber >= _sequence.Last())
            {
                do
                {
                    SetNext();
                }
                while (baseNumber >= _sequence.Last());

                return _sequence.Last();
            }

            return GetFromList(baseNumber);
        }

        private int GetFromList(int value)
        {
            // Aqui poderia ser usado algum algorítimo melhor de pesquisa.
            foreach (var f in _sequence)
            {
                if (f > value) return f;
            }

            return CalculateNext(value);
        }

        private void SetNext()
        {
            var actual = _sequence.Last();
            var previous = _sequence[_sequence.Count - 2];

            _sequence.Add(actual + previous);
        }
    }
}
