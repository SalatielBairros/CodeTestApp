using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace CodeTestWs.Helpers
{
    public class ExcelHelper
    {
        public static void WriteTsv<T>(IEnumerable<T> data, TextWriter output)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            foreach (PropertyDescriptor prop in props)
            {
                output.Write(prop.DisplayName);
                output.Write("\t");
            }
            output.WriteLine();
            foreach (T item in data)
            {
                foreach (PropertyDescriptor prop in props)
                {
                    if (prop?.Converter != null && item != null)
                    {
                        output.Write(prop.Converter.ConvertToString(prop.GetValue(item)));
                    }
                    output.Write("\t");
                }
                output.WriteLine();
            }
        }
    }
}