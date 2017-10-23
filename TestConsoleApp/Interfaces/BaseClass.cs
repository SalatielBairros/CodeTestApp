namespace CodeTestApp.Interfaces
{
    public partial class BaseClassPartialTests : IBaseProps//AbstractClass, 
    {
        public string PropTeste1 { get; set; }
        public string PropTeste2 { get; set; }
        public string PropTeste3 { get; set; }

        //public override ClassTest1 TestMethod(ClassTest2 tet)
        //{
        //    return new ClassTest1();
        //}
    }

    public abstract class AbstractClass : IMethodBase
    {
        public abstract TResult TestMethod<TResult, TParameter>(TParameter parameter);
    }

    public class ClassTest1
    {

    }

    public class ClassTest2
    {

    }
}
