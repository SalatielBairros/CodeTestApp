using System;

namespace CodeTestApp.Pratices.Memento.DesignCourse
{
  public class TokenMementoTestsExecution
  {
    public static void Execute()
    {
      var instance = new TokenMementoTestsExecution();
      instance.SingleTokenTest();
      instance.TwoTokenTest();
    }

    public void SingleTokenTest()
    {
      var tm = new TokenMachine();
      var m = tm.AddToken(123);
      tm.AddToken(456);
      tm.Revert(m);

      Console.WriteLine($"Should count be 1: {tm.Tokens.Count == 1}");
      Console.WriteLine($"Should value be 123: {tm.Tokens[0].Value == 123}");
    }

    public void TwoTokenTest()
    {
      var tm = new TokenMachine();
      tm.AddToken(1);
      var m = tm.AddToken(2);
      tm.AddToken(3);
      tm.Revert(m);

      Console.WriteLine($"Should count be 2: {tm.Tokens.Count == 2}");
      Console.WriteLine($"Should value[0] be 1: {tm.Tokens[0].Value == 1}");
      Console.WriteLine($"Should value[1] be 2: {tm.Tokens[1].Value == 2}");
    }
  }
}
