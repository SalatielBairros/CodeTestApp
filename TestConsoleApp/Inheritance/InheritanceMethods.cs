using System;

namespace CodeTestApp.Inheritance
{
  public class InheritanceMethods
  {
    public static InheritanceMethods Instance => new InheritanceMethods();

    public Additional GetAdditional()
    {
      return Additional.Instance;
    }
  }

  public class Derivated : Base
  {
    public new void BaseMethod()
    {
      Console.WriteLine("DERIVATED METHODD");
      base.BaseMethod();
    }
  }
}