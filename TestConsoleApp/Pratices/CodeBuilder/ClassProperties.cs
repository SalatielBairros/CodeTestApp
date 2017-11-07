namespace CodeTestApp.Pratices.CodeBuilder
{
    public class ClassProperties
    {
        public string Name, Type;

        public ClassProperties(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public override string ToString() => string.Format("public {0} {1};", Type, Name);
    }
}
