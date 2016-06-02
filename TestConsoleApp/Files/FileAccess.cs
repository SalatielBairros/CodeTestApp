using System;
using System.IO;

namespace CodeTestApp.Files
{
    internal class FileAccess
    {
        internal void AccessFileWhileCopying()
        {
            try
            {
                //Criando arquivo com texto inicial.
                using (StreamWriter writer = File.CreateText("ARQUIVO_TESTE.txt"))
                {
                    writer.WriteLine("CONTEÚDO INICIAL");
                }

                //using (StreamReader reader = File.rea)
                //{
                //    writer.WriteLine("CONTEÚDO INICIAL");
                //}

                Console.WriteLine("AccessFileWhileCopying -> WORKS!");
            }
            catch
            {
                Console.WriteLine("AccessFileWhileCopying -> DOESN'T WORKS!");
            }
        }
    }
}
