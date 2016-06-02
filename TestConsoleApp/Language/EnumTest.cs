using System;
using System.ComponentModel;
using System.Reflection;

namespace CodeTestApp.Language
{
    public class EnumTest
    {
        public void Execute()
        {
            Console.WriteLine(GetEnumDescription<Teste>("A1"));
            Console.ReadKey();
        }

        public static string GetEnumDescription<T>(object value)
           where T : struct
        {
            string text = value.ToString();
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            T r;
            return Enum.TryParse<T>(text, out r) ? GetEnumDescription(r as Enum) : null;
        }

        internal static string GetEnumDescription(System.Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

        internal enum Teste
        {
            [Description("TESTE 1")]
            Att = 1,
            [Description("SEGUNDO TESTE")]
            AA,
            [Description("Terceiro TESTE")]
            A1
        }
    }
}
