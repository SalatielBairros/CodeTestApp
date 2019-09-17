using System;
using CodeTestApp.Language.TestNamespace;

namespace CodeTestApp.Language
{
  public static class NullExtensionExecution
  {
    public static void Execute()
    {
      var testObject = TestObject.ReturnNullObject();

      Console.WriteLine($"Is Null: {testObject.IsNull()}");

      // OBS: Erro de ambiguidade caso use o Linq.
      //if (testObject.ObjectList.Any())
      //{
      //  Console.WriteLine("Funcionou");
      //}
    }
  }
}
