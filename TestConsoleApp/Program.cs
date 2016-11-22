using System;
using CodeTestApp.Cryptography;

namespace CodeTestApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            RSA.Execute("It is a sample text.");
            Console.ReadKey();
        }
    }
}
