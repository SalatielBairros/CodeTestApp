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
}