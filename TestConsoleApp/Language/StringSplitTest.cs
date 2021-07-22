using System;

namespace CodeTestApp.Language
{
  public static class StringSplitTest
  {
    public static void Execute()
    {
      var tString = "teste";
      var tString2 = "teste1,teste2";

      Console.WriteLine(tString.Split(',')[0]);
      Console.WriteLine(tString2.Split(',')[1]);
    }
  }
}
