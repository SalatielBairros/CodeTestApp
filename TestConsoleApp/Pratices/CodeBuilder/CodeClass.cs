namespace CodeTestApp.Pratices.CodeBuilder
{
    using System.Collections.Generic;
    using System.Text;

    public class CodeClass
    {
        public string Name;
        public List<ClassProperties> Properties = new List<ClassProperties>();
        private const int indentSize = 2;

        public CodeClass(string name)
        {
            Name = name;
        }

        public CodeClass AddField(string name, string type)
        {
            Properties.Add(new ClassProperties(name, type));
            return this;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder().Append("public class ").AppendLine(Name).AppendLine("{");
            Properties.ForEach(
                x =>
                    {
                        sb.Append(new string(' ', indentSize * 1));
                        sb.AppendLine(x.ToString());
                    });
            sb.Append("}");
            return sb.ToString();
        }
    }
}
