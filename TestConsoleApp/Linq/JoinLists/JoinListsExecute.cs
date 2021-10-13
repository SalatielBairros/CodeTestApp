using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTestApp.Linq.JoinLists
{
    public static class JoinListsExecute
    {
        public static void Execute()
        {
            var (First, Second) = Seed();

            var tempList = new List<BaseClass>();
            
            tempList.AddRange(First);
            tempList.AddRange(Second);

            var result = tempList.GroupBy(x => new { x.Action, x.Metric }).Select(x =>
            {
                var first = ((FirstClass)x.FirstOrDefault(y => y.GetType().Equals(typeof(FirstClass))));
                var second = ((SecondClass)x.FirstOrDefault(y => y.GetType().Equals(typeof(SecondClass))));

                return new ResultClass
                {
                    Action = x.Key.Action,
                    Metric = x.Key.Metric,
                    FirstCount = first?.FirstCount ?? 0,
                    SecondCount = second?.SecondCount ?? 0,
                };
            }).ToList();           

            Console.WriteLine($"Result cout: {result.Count()}");
        }

        private static (IEnumerable<FirstClass> First, IEnumerable<SecondClass> Second) Seed()
        {
            var first = new List<FirstClass>
            {
                new FirstClass
                {
                    Action="a1",
                    Metric="m1",
                    FirstCount=1
                },
                new FirstClass
                {
                    Action="a2",
                    Metric="m2",
                    FirstCount=2
                },
                new FirstClass
                {
                    Action="a3",
                    Metric="m3",
                    FirstCount=3
                },
            };

            var second = new List<SecondClass>
            {
                new SecondClass
                {
                    Action="a1",
                    Metric="m1",
                    SecondCount=4
                },
                new SecondClass
                {
                    Action="a2",
                    Metric="m4",
                    SecondCount=5
                },
                new SecondClass
                {
                    Action="a4",
                    Metric="m5",
                    SecondCount=6
                },
            };

            return (first, second);
        }

        private static IEnumerable<ResultClass> GetExpectedResultClass()
        {
            return new List<ResultClass>
            {
                new ResultClass
                {
                    Action="a1",
                    Metric="m1",
                    FirstCount=1,
                    SecondCount=4
                },
                new ResultClass
                {
                    Action="a2",
                    Metric="m2",
                    FirstCount=2
                },
                new ResultClass
                {
                    Action="a2",
                    Metric="m4",
                    SecondCount=5
                },
                new ResultClass
                {
                    Action="a3",
                    Metric="m3",
                    FirstCount=3
                },
                new ResultClass
                {
                    Action="a4",
                    Metric="m5",
                    SecondCount=6
                },
            };
        }
    }
}
