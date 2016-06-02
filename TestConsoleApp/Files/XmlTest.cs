using System;
using System.IO;
using System.Linq;
using System.Xml;

namespace CodeTestApp
{
    internal class XmlTest
    {
        internal static void AppendXmlFile()
        {
            XmlDocument docSend = new XmlDocument();
            docSend.Load(@"C:\Users\Salatiel\OneDrive\Documentos\Projetos Úteis e de Estudo\CodeTestApp\teste.xml");

            using (FileStream fs = new FileStream(@"C:\Users\Salatiel\OneDrive\Documentos\Projetos Úteis e de Estudo\CodeTestApp\BAK20160106.xml",
                FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
            {
                XmlDocument docBak = new XmlDocument();
                docBak.Load(fs);

                XmlNodeList xnList = docSend.GetElementsByTagName("SIVA_ADM_GPS_ADICIONAR");
                foreach (XmlNode node in (from XmlNode xn in xnList select docBak.ImportNode(xn, true)).Where(node => docBak.DocumentElement != null))
                {
                    if (docBak.DocumentElement != null)
                    {
                        docBak.DocumentElement.InsertAfter(node, docBak.DocumentElement.LastChild);
                    }
                }

                fs.SetLength(0);
                docBak.Save(fs);
            }
            Console.ReadLine();
        }
    }
}
