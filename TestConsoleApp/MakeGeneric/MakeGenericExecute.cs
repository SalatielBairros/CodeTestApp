﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTestApp.Eldorado;

namespace CodeTestApp.MakeGeneric
{
    public static class MakeGenericExecute
    {
        public static void Execute()
        {
            Console.WriteLine("\r\n--- Create a constructed type from the generic Dictionary type.");

            // Create a type object representing the generic Dictionary 
            // type, by omitting the type arguments (but keeping the 
            // comma that separates them, so the compiler can infer the
            // number of type parameters).      
            Type generic = typeof(Entity<>);
            DisplayTypeInfo(generic);

            // Create an array of types to substitute for the type
            // parameters of Dictionary. The key is of type string, and
            // the type to be contained in the Dictionary is Test.
            Type[] typeArgs = { typeof(TypeParameter) };

            // Create a Type object representing the constructed generic
            // type.
            Type constructed = generic.MakeGenericType(typeArgs);
            DisplayTypeInfo(constructed);

            // Compare the type objects obtained above to type objects
            // obtained using typeof() and GetGenericTypeDefinition().
            Console.WriteLine("\r\n--- Compare types obtained by different methods:");

            Type t = typeof(Dictionary<String, Test>);
            Console.WriteLine("\tAre the constructed types equal? {0}", t == constructed);
            Console.WriteLine("\tAre the generic types equal? {0}",
                t.GetGenericTypeDefinition() == generic);
        }

        private static void DisplayTypeInfo(Type t)
        {
            Console.WriteLine("\r\n{0}", t);

            Console.WriteLine("\tIs this a generic type definition? {0}",
                t.IsGenericTypeDefinition);

            Console.WriteLine("\tIs it a generic type? {0}",
                t.IsGenericType);

            Type[] typeArguments = t.GetGenericArguments();
            Console.WriteLine("\tList type arguments ({0}):", typeArguments.Length);
            foreach (Type tParam in typeArguments)
            {
                Console.WriteLine("\t\t{0}", tParam);
            }
        }
    }

    public class Entity<T>
    {
        public Entity()
        {
            Console.WriteLine("construtor chamado e criado");
        }
    }

    public class TypeParameter
    {

    }
}
