using System;
using System.IO;
using System.Text;

namespace CodeTestApp.Exceptions
{
    internal class IOExceptionTest
    {
        private const string FileName = @"C:\Users\salat\OneDrive\Documentos\ProjetosUteis\C#\TestConsoleApp\TestConsoleApp\UsedDocumentTest.txt";

        internal static void ThrowUsedDocumentException()
        {
            try
            {
                File.Open(FileName, FileMode.Open);
                OpenFile();
            }
            catch (Exception ex)
            {
                if (ex is IOException)
                {
                    Console.WriteLine(ex.Message);
                }
                else
                {
                    Console.WriteLine("RETORNO DIFERENTE.");
                }
            }
        }

        private static void OpenFile()
        {
            File.ReadAllText(FileName, Encoding.UTF8);
        }
    }
}
