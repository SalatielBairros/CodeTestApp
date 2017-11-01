namespace CodeTestApp.Interfaces.SegregationPrinciple
{
    /* This Principle was obtained from a Udemy course by Dmitri Nesteruk: Design Patterns in C# and .NET */

    /// <summary>
    /// This class represents the document and its actions.
    /// </summary>
    public class Document
    {
        public string PrintAction => "Print action";
        public string ScanAction => "Scan action";
        public string FaxAction => "Fax action";
    }
}
