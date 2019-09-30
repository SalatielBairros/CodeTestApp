using System;

namespace CodeTestApp.Pratices
{
    // (new Implementation1()).ExecuteMethod();
    //    (new Implementation2()).ExecuteMethod();
    //Console.ReadKey();

    public interface IBase
    {
        object GetClass();
    }

    public class Implementation1 : IBase
    {
        #region Implementation of IBase

        public object GetClass()
        {
            return new Prop1
            {
                Teste1 = "Implementation One"
            };
        }

        #endregion
    }

    internal class Implementation2 : IBase
    {
        #region Implementation of IBase

        public object GetClass()
        {
            return new Prop2
            {
                Teste2 = "Implementation Two"
            };
        }

        #endregion
    }

    internal static class ExtensionMethods
    {
        internal static void ExecuteMethod(this IBase executableClass)
        {
            Console.WriteLine(executableClass.GetClass().ToString());
        }
    }

    public class Prop1
    {
        public string Teste1 { get; set; }

        public override string ToString()
        {
            return string.Concat("TESTE UM ", Teste1);
        }
    }

    public class Prop2
    {
        public string Teste2 { get; set; }

        public override string ToString()
        {
            return string.Concat("TESTE DOIS ", Teste2);
        }
    }
}