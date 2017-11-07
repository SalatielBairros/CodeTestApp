namespace CodeTestApp.Pratices.CodeBuilder
{
    public class CodeBuilder
    {
        public string ClassName;
        public CodeClass Cl;

        public CodeBuilder(string className)
        {
            ClassName = className;
            this.Cl = new CodeClass(className);
        }

        public CodeBuilder AddField(string name, string type)
        {
            this.Cl.AddField(name, type);
            return this;
        }

        public override string ToString()
        {
            return this.Cl.ToString();
        }
    }
}
