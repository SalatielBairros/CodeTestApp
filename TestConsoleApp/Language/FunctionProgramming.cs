using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
// ReSharper disable CoVariantArrayConversion

namespace CodeTestApp.Language
{
    #region GenericUsingExample
    internal static class Disposable
    {
        public static TResult Using<TDisposable, TResult>(
            Func<TDisposable> factory,
            Func<TDisposable, TResult> map)
            where TDisposable : IDisposable
        {
            using (var disposable = factory())
            {
                return map(disposable);
            }
        }
    }

    internal class CallDisposable
    {
        public static void Call()
        {

            XElement xElement = Disposable.Using(
                () => new System.Net.WebClient(),
                client => XDocument.Parse(client.DownloadString("http://time.gov/actualtime.cgi")))
                .Root;

            if (xElement != null)
            {
                var timeDoc = xElement.Attribute("time").Value;
                Console.Write(timeDoc);
            }
            Console.ReadKey();
        }
    }
    #endregion

    #region StringBuilderExM

    internal static class StringBuilderExtends
    {
        internal static StringBuilder AppendFormattedLine
            (this StringBuilder @this, string value, params string[] args)
            => @this.AppendFormat(value, args).AppendLine();

        internal static StringBuilder AppendWhen
            (this StringBuilder @this, Func<bool> predicate, string value)
            => predicate() ? @this.AppendLine(value) : @this;

        internal static StringBuilder AppendWhen
            (this StringBuilder @this, Func<bool> predicate, Func<StringBuilder, StringBuilder> fn)
            => predicate() ? fn(@this) : @this;

        //Func<T, U, T>
        internal static StringBuilder AppendSequence<T>
            (this StringBuilder @this, IEnumerable<T> values, Func<StringBuilder, T, StringBuilder> fn)
            => values.Aggregate(@this, fn);
    }

    internal class ConsoleExtends
    {
        internal static void WriteConsole(object value)
        {
            Console.WriteLine(value);
            Console.ReadLine();
        }
    }

    internal class CallSbExtents
    {
        internal static void Call(bool testConditional = false, string format = "TesteFormat")
        {
            var sequence = GetSequence();
            (new StringBuilder())
                .AppendFormattedLine("{0}", format)
                .AppendWhen(() => testConditional, "CONDICIONAL")
                .AppendWhen(() => testConditional, sb => sb.AppendFormattedLine("{0}", (format + "CONDICIONAL")))
                .AppendSequence(sequence,
                    (sb, opt) => sb.AppendFormattedLine("{0}",
                        opt.Map(st => st.ToString())))
                .Tee(ConsoleExtends.WriteConsole);

        }

        private static IEnumerable<object> GetSequence()
        {
            return new List<object>
            {
                "TESTE1",
                true,
                1,
                "TESTE5",
                "TESTE2"
            };
        }
    }

    #endregion

    #region FunctionalExtensions

    internal static class FunctionalExtensions
    {
        internal static TResult Map<TSource, TResult>(this TSource @this, Func<TSource, TResult> fn)
            => fn(@this);

        internal static T Tee<T>(this T @this, Action<T> act)
        {
            act(@this);
            return @this;
        }
    }

    #endregion
}
