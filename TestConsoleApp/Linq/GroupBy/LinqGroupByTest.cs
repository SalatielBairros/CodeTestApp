using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeTestApp.Linq.GroupBy
{
  public class LinqGroupByTest
  {
    public class OriginalValues
    {
      public OriginalValues(string code, string name, string component)
      {
        Code = code;
        Name = name;
        Component = component;
      }

      public string Code { get; set; }
      public string Name { get; set; }
      public string Component { get; set; }

      public static List<OriginalValues> Seed()
      {
        return new List<OriginalValues>
        {
          new OriginalValues("008-0001", "ANCORON 100 MG", "Ceftriaxone"),
          new OriginalValues("008-0001", "ANCORON 100 MG", "Amiodarona"),
          new OriginalValues("008-0003", "ANCORON 150 MG INJ", "Ceftriaxone"),
          new OriginalValues("008-0002", "ANCORON 200 MG", "Ceftriaxone"),
          new OriginalValues("104-0005", "ATLANSIL 200 M", "Amiodarona"),
          new OriginalValues("002-0001", "BICARBONATO DE SODIO PÓ ", "Sistemico")
        };
      }
    }

    public class FinalValues
    {
      public FinalValues(string code, string name)
      {
        this.Code = code;
        this.Name = name;
      }

      public string Code { get; set; }
      public string Name { get; set; }
      public List<string> Components { get; set; }
    }

    public static class ExecuteTest
    {
      public static void Execute()
      {
        var seed = OriginalValues.Seed();
        var finalValues = seed
          .GroupBy(x => new { x.Code, x.Name })
          .Select(x => new FinalValues(x.Key.Code, x.Key.Name)
          {
            Components = x.Select(y => y.Component).ToList()
          });
        Console.WriteLine(finalValues);
      }
    }
  }
}
