using System;

namespace CodeTestApp.Inheritance.Override
{
  public abstract class BaseClass
  {
    protected abstract void Method();
  }

  public class DerivatedClass : BaseClass
  {
    protected override void Method() => throw new NotImplementedException();
  }

  public static class OverrideTest
  {
    public static void Execute()
    {
      Show(new DerivatedClass());
    }

    public static void Show(BaseClass obj)
    {

    }
  }
}
