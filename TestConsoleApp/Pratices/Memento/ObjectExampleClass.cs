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

    private ObjectExampleClass(ObjectExampleClass objectExampleClass)
    {
      Date = objectExampleClass.Date;
      Code = objectExampleClass.Code;
      //É possivel aqui transmitir o memento da outra.
    }

    private readonly Memento<ObjectExampleClass> _memento;

    public ObjectExampleClass Old => _memento;

    public DateTime Date { get; set; }
    public string Code { get; set; }

    public object Clone() => new ObjectExampleClass(this);

    /// <summary>
    /// Sobrescrevendo o método para facilitar a exibição no exemplo, apenas.
    /// </summary>
    /// <returns></returns>
    public override string ToString() => $"Código: {this.Code} | Data: {this.Date:dd/MM/yyyy HH:mm:ss}";
  }
}