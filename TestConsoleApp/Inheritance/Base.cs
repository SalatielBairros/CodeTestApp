using System;
using System.Text;

namespace CodeTestApp.Inheritance
{
  public class Base
  {
    public Base(long p1, string p2, string p3)
    {
      Prop1 = p1;
      Prop2 = p2;
      Prop3 = p3;
    }

    public Base() : this(1, "Propriedade 2", "Propriedade 3")
    {

    }

    public long Prop1 { get; set; }
    public string Prop2 { get; set; }
    public string Prop3 { get; set; }

    public void BaseMethod()
    {
      Console.WriteLine("BASE METHODD");
    }

    public override string ToString()
    {
      return new StringBuilder()
              .AppendLine(nameof(Prop1) + ": " + Prop1)
              .AppendLine(nameof(Prop2) + ": " + Prop2)
              .AppendLine(nameof(Prop3) + ": " + Prop3)
              .ToString();
    }
  }
}
