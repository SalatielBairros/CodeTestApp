using System;

namespace CodeTestApp.Pratices.Memento
{
  public class ObjectExampleClass : IMementoEntity<ObjectExampleClass>
  {
    public ObjectExampleClass(DateTime date, string code)
    {
      Date = date;
      Code = code;
      _memento = this;
    }

    private readonly Memento<ObjectExampleClass> _memento;

    public ObjectExampleClass Old => _memento;

    public DateTime Date { get; set; }
    public string Code { get; set; }

    public object Clone() => new ObjectExampleClass(this.Date, this.Code);
  }

  public class Memento<T>
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

  public interface IMementoEntity<out T> : ICloneable
  {
    T Old { get; }
  }
}
