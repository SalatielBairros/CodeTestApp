namespace CodeTestApp.Inheritance
{
    public class InheritanceMethods
    {
        public static InheritanceMethods Instance => new InheritanceMethods();

        public Additional GetAdditional()
        {
            return Additional.Instance;
        }
    }
}