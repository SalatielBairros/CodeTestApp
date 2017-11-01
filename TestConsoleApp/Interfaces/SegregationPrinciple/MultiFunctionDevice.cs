using System;

namespace CodeTestApp.Interfaces.SegregationPrinciple
{
    public class MultiFunctionDevice : IMultiFunctionDevice
    {
        // compose this out of several modules
        private readonly IPrinter printer;
        private readonly IScanner scanner;

        public MultiFunctionDevice(IPrinter printer, IScanner scanner)
        {
            this.printer = printer ?? throw new ArgumentNullException(paramName: nameof(printer));
            this.scanner = scanner ?? throw new ArgumentNullException(paramName: nameof(scanner));
        }

        public static MultiFunctionDevice Instance => new MultiFunctionDevice(Printer.Instance, Scanner.Instance);

        public void Print(Document d)
        {
            printer.Print(d);
        }

        public void Scan(Document d)
        {
            scanner.Scan(d);
        }
    }
}