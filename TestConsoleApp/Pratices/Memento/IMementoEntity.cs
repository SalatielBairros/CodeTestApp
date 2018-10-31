using System;

namespace CodeTestApp.Pratices.Memento
{
  public interface IMementoEntity<out T> : ICloneable
  {
    T Old { get; }
  }
}