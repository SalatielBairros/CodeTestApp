namespace CodeTestApp.Pratices.CodeBuilder
{
    using System;

    public static class CodeBuilderExecute
    {
        public static void Execute()
        {
            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Console.WriteLine(cb);
        }
    }
}
