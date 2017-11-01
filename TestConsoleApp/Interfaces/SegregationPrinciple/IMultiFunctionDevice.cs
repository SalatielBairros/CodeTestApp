namespace CodeTestApp.Interfaces.SegregationPrinciple
{
    /// <summary>
    /// This interface exists just for aggregate two (or more) "atomic" interfaces.
    /// </summary>
    public interface IMultiFunctionDevice : IPrinter, IScanner
    {

    }
}