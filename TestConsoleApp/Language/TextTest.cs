using System;

namespace CodeTestApp.Language
{
    public class TextTest
    {
        public static void IndexOfTest()
        {
            const string stringLineSample =
                @"<evento id=""2222"" x="" - 30.100001"" y="" - 20.100001"" data=""2003 - 01 - 01 13:00:42"" tipo=""89"" subtipo=""0"" valor="""" />";
            const string stringToFind = "id=\"";
            const int idLength = 4;
            int index = stringLineSample.IndexOf(stringToFind, StringComparison.InvariantCulture);
            string locatedString = stringLineSample.Substring(index + stringToFind.Length, idLength);
            Console.WriteLine("Start Index: 8");
            Console.WriteLine("Final Index: 12");
            Console.WriteLine("Method Index: {0}", index);
            Console.WriteLine("Located String: {0}", locatedString);
        }
    }
}
