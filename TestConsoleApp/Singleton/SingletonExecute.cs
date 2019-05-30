using System;

namespace CodeTestApp.Singleton
{
  public class SingletonExecute
  {
    public void Execute()
    {
      NormalSingletonTest();
      Line();
      LazySingletonTest();
    }

    private static void Line()
    {
      Console.WriteLine();
      Console.WriteLine("*******************************");
      Console.WriteLine();
    }

    private static void NormalSingletonTest()
    {
      Console.WriteLine("NORMAL SINGLETON");
      Console.WriteLine();

      Console.WriteLine($"Número de chamadas Singleton Antes: {SingletonDataAccess.InstanceCount}");

      var st = SingletonDataAccess.NormalSingleton;
      var st2 = SingletonDataAccess.NormalSingleton;

      Console.WriteLine($"Número de chamadas Singleton Depois: {SingletonDataAccess.InstanceCount}");
      Console.WriteLine($"São o mesmo objeto? {Object.Equals(st, st2).ToString()}");
    }

    private static void LazySingletonTest()
    {
      Console.WriteLine("LAZY SINGLETON");
      Console.WriteLine();

      Console.WriteLine($"Número de chamadas Singleton Antes: {SingletonDataAccess.InstanceCount}");

      var st = SingletonDataAccess.Instance;
      var st2 = SingletonDataAccess.Instance;

      Console.WriteLine($"Número de chamadas Singleton Depois: {SingletonDataAccess.InstanceCount}");
      Console.WriteLine($"São o mesmo objeto? {Object.Equals(st, st2).ToString()}");
    }
  }
}
