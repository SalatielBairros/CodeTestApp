namespace CodeTestApp.Interfaces.SegregationPrinciple
{
    public static class SegregationPrincipleExecute
    {
        public static void Execute()
        {
            var d = new Document();
            var mfd = MultiFunctionDevice.Instance;
            mfd.Print(d);
            mfd.Scan(d);
        }
    }
}