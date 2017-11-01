namespace CodeTestApp.Interfaces.SegregationPrinciple
{
    /// <summary>
    /// Genera interface with all needed methods.
    /// </summary>
    public interface IMachine
    {
        void Print(Document d);
        void Fax(Document d);
        void Scan(Document d);
    }
}