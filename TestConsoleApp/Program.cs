using System;

namespace CodeTestApp
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      var uri = new Uri("http://google.com.br");
      Console.WriteLine(uri);
      Console.ReadKey();
    }
  }
}
