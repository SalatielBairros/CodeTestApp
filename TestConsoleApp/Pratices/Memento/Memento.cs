using System;

namespace CodeTestApp.Pratices.Memento
{
  public sealed class Memento<T>
    where T : ICloneable
  {
    private readonly T _entity;

    private Memento(T mementoObject)
    {
      _entity = (T)mementoObject.Clone();
    }

    public static implicit operator T(Memento<T> memento)
    {
      return (T)memento._entity.Clone();
    }

    public static implicit operator Memento<T>(T memento)
    {
      return new Memento<T>(memento);
    }
  }
}
