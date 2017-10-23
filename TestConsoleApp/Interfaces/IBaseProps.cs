namespace CodeTestApp.Interfaces
{
    public interface IBaseProps
    {
        string PropTeste1 { get; set; }
        string PropTeste2 { get; set; }
    }

    public interface IMethodBase
    {
        TResult TestMethod<TResult, TParameter>(TParameter parameter);
    }
}
