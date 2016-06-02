using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeTestApp
{
    internal class AsyncParallelTest
    {
        private static AsyncParallelTest _instance;
        internal static AsyncParallelTest Instance => (_instance ?? (_instance = new AsyncParallelTest()));

        internal async Task<string> AsyncTestMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(2000);
            }
            return "MÉTODO ENCERRADO";
        }

        internal void TesteAssincrono()
        {
            var r = AsyncTestMethod();

            while (!r.IsCompleted)
            {
                Console.WriteLine("AINDA NAO");
            }
            Console.WriteLine(r.Result);
        }

        /// <summary>
        /// FROM https://msdn.microsoft.com/pt-br/library/dd997425(v=vs.110).aspx
        /// </summary>
        internal static void PLinqTest()
        {
            var source = Enumerable.Range(1, 10000);

            Stopwatch w = Stopwatch.StartNew();
            // Opt in to PLINQ with AsParallel.
            Console.WriteLine("nSEQUENCIAL: ");
            IEnumerable<int> enumerable = source as int[] ?? source.ToArray();
            var evenNums = from num in enumerable
                           where num % 2 == 0
                           select num;
            Console.WriteLine("{0} even numbers out of {1} total",
                              evenNums.Count(), enumerable.Count());
            w.Stop();
            Console.WriteLine("\n\n TIME: " + w.Elapsed);

            w.Restart();
            Console.WriteLine("\n\nPARALLEL: ");
            var evenNums2 = from num in enumerable.AsParallel()
                            where num % 2 == 0
                            select num;
            Console.WriteLine("{0} even numbers out of {1} total",
                              evenNums2.Count(), enumerable.Count());
            w.Stop();
            Console.WriteLine("\n\n TIME: " + w.Elapsed);
            Console.ReadLine();

            //CONCLUSÃO: Neste caso, operações sequenciais são mais rápidas que operações paralelas, 
            //claro que há uma variação no tempo se for utilizada uma máquina diferente, já que paralelo depende de consumir 
            //os diversos núcleos do processador
        }

        internal async Task<string> Async1()
        {
            await Task.Delay(3000);
            return "1 - CONCLUIDO";
        }

        internal void NormalMethod()
        {
            var w = Stopwatch.StartNew();


            var taskA1 = Async1();
            Thread.Sleep(3000);
            Console.WriteLine(taskA1.Result);
            Console.WriteLine("2 - CONCLUIDO");



            Console.WriteLine(w.Elapsed);
            Console.ReadKey();
        }
    }
}
