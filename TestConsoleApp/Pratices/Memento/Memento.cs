using System;

namespace CodeTestApp.Pratices.Memento
{
  public class MementoExecute
  {
    public static void Execute()
    {
      //Criando objeto novo.
      var exampleClass1 = new ObjectExampleClass(DateTime.Now, "CODE");
      Console.WriteLine("ORIGINAL CLASS");
      Console.WriteLine(exampleClass1);
      Console.WriteLine();

      //Realizando alterações nos dados do objeto novo
      exampleClass1.Date = DateTime.Now.AddDays(10);
      exampleClass1.Code = "SALATIEL";
      Console.WriteLine("EDITED CLASS");
      Console.WriteLine(exampleClass1);
      Console.WriteLine();

      //Classe antiga deve estar igual
      Console.WriteLine("OLD CLASS");
      //Note que a chamada ao old é transparente para quem cria a instância.
      Console.WriteLine(exampleClass1.Old);
      Console.WriteLine();

      //Mesmo tentando editar os seus valores, ela não deve editar
      exampleClass1.Old.Date = DateTime.Now.AddDays(5);
      exampleClass1.Old.Code = "BAIRROS";
      Console.WriteLine("EDITED OLD CLASS");
      Console.WriteLine(exampleClass1.Old);
      Console.WriteLine();
    }
  }

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
