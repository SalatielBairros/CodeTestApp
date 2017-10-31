using System.Text;

namespace CodeTestApp.Inheritance
{
    public class Additional : Base
    {
        public Additional() : this("Additional Property 4", true, 2)
        {

        }

        public Additional(string ap4, bool ap5, int ap6)
        {
            AddProp4 = ap4;
            AddProp5 = ap5;
            AddProp6 = ap6;
        }

        public static Additional Instance => new Additional();

        public string AddProp4 { get; set; }
        public bool AddProp5 { get; set; }
        public int AddProp6 { get; set; }

        public override string ToString()
        {
            return string.Concat(base.ToString(),
                new StringBuilder()
                    .AppendLine(nameof(AddProp4) + ": " + AddProp4)
                    .AppendLine(nameof(AddProp5) + ": " + AddProp5)
                    .AppendLine(nameof(AddProp6) + ": " + AddProp6)
                    .ToString());
        }
    }
}