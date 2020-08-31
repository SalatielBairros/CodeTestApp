using CodeTestApp.Interfaces.TypeChange;
using System;

namespace CodeTestApp
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      TypeChangeService.Execute();
      Console.ReadKey();
    }
  }
}
