using System;
using System.Collections.Generic;

namespace CodeTestApp.Language
{
    internal class KeyValuePairTest
    {
        private static IEnumerable<KeyValuePair<string, bool>> DuplicateTest()
        {
            return new List<KeyValuePair<string, bool>>
            {
                new KeyValuePair<string, bool>("A", true),
                new KeyValuePair<string, bool>("B", true),
                new KeyValuePair<string, bool>("C", true),
                new KeyValuePair<string, bool>("A", false),
                new KeyValuePair<string, bool>("A", true),
            };
        }

        internal static void Print()
        {
            foreach (var obj in DuplicateTest())
            {
                Console.WriteLine("Key: {0} - Value: {1}", obj.Key, obj.Value);
            }
        }
    }
}
