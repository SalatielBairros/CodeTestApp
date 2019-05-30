using System;
using CodeTestApp.Singleton;

namespace CodeTestApp
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      new SingletonExecute().Execute();
      Console.ReadKey();
    }
  }
}
