using System;
using System.Text.RegularExpressions;

namespace CodeTestApp.RegexFormat
{
  public static class RegexFormatExecution
  {
    private const string Format = "@(?<xNumber>.*),X=(?<xValue>.*)@(?<yNumber>.*),Y=(?<yValue>.*)";

    public static void Execute(string value)
    {
      int x, y;
      x = y = 0;

      if (Regex.IsMatch(value, Format))
      {
        var matches = Regex.Match(value, Format);
        int.TryParse(matches.Groups["xValue"].ToString(), out x);
        int.TryParse(matches.Groups["yValue"].ToString(), out y);
      }

      Console.WriteLine("X => " + x.ToString());
      Console.WriteLine("Y => " + y.ToString());
    }
  }


}
