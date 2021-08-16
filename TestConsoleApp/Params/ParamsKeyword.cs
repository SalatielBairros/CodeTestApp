using System;
using System.Linq;

namespace CodeTestApp.Params
{
    public class ParamsKeyword
    {
        public static void Execute(params string[] s)
        {
            var baseString = "baseString";            
            StringMethod(s.Append(baseString).ToArray());
        }

        public static void StringMethod(params string[] s)
        {
            s.ToList().ForEach(x => Console.WriteLine(x));
        }
    }
}
