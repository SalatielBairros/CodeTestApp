using System;

namespace CodeTestApp.CharEnum
{
  public static class CharEnumParse
  {
    public static void Execute()
    {
      Console.WriteLine($"ParseCharToEnum: {ParseCharToEnum()}");
      Console.WriteLine($"ParseEnumToChar: {ParseEnumToChar()}");
      Console.WriteLine($"ParseStringToEnum: {ParseStringToEnum()}");
      Console.WriteLine($"ParseEnumToString_1: {ParseEnumToString_1()}");
      Console.WriteLine($"ParseEnumToString_2: {ParseEnumToString_2()}");
    }

    private static CharEnum ParseCharToEnum()
    {
      return (CharEnum)'A';
    }

    private static char ParseEnumToChar()
    {
      return (char)CharEnum.Second;
    }

    private static CharEnum ParseStringToEnum()
    {
      var str = "C";
      return (CharEnum)str[0];
    }

    private static string ParseEnumToString_1()
    {
      return CharEnum.First.ToString();
    }

    private static string ParseEnumToString_2()
    {
      return ((char)CharEnum.First).ToString();
    }
  }

  public enum CharEnum
  {
    First = 'A',
    Second = 'B',
    Third = 'C'
  }
}
