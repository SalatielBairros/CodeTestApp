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

    /// <inheritdoc />
    /// <summary>
    /// Para casos onde apenas ValueTypes forem ser usados (int, string, long, etc) ou classes como DateTime, é possível utilizar o MemberwiseClone().
    /// </summary>
    /// <returns></returns>
    public object Clone() => this.MemberwiseClone();

    /// <summary>
    /// Sobrescrevendo o método para facilitar a exibição no exemplo, apenas.
    /// </summary>
    /// <returns></returns>
    public override string ToString() => $"Código: {this.Code} | Data: {this.Date:dd/MM/yyyy HH:mm:ss}";
  }
}