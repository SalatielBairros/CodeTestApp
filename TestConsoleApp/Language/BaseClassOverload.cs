using System;

namespace CodeTestApp.Language
{
    public class BaseClassOverload
    {
        public static void Execute()
        {
            //STRING
            (new B1()).Execute();

            //OBJECT
            Console.WriteLine();
            (new B2()).Execute();


            //STRING
            Console.WriteLine();
            (new B3()).Execute();

            Console.ReadLine();
        }
    }

    public class A1
    {
        public string Sample(string x) => "string overload";
        public string Sample(object x) => "object overload";
    }

    public class B1 : A1
    {
        public void Execute()
        {
            Console.WriteLine("TESTE B1");
            Console.WriteLine(Sample(""));
        }
    }

    public class A2
    {
        public string Sample(string x) => "string overload";
    }

    public class B2 : A2
    {
        public string Sample(object x) => "object overload";

        public void Execute()
        {
            Console.WriteLine("TESTE B2");
            Console.WriteLine(Sample(""));
        }
    }

    public class A3
    {
        public string Sample(string x) => "string overload";
        public virtual string Sample(object x) => "object base overload";
    }

    public class B3 : A3
    {
        public override string Sample(object x) => base.Sample(x);

        public void Execute()
        {
            Console.WriteLine("TESTE B3");
            Console.WriteLine(Sample(""));
        }
    }
}
