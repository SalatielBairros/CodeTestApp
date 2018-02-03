using System;
using System.Collections.Generic;

namespace CodeTestApp.Pratices.AbstracFactory
{
    public class HotDrinkMachine
    {
        // VIOLATES OPEN-CLOSED PRINCIPLE
        /*         
            In object-oriented programming, the open/closed principle states "software entities (classes, modules, functions, etc.)
            should be open for extension, but closed for modification"; that is, such an entity can allow its behaviour to be extended 
            without modifying its source code.
            https://en.wikipedia.org/wiki/Open/closed_principle
        */
        public enum AvailableDrink
        {
            Coffee, Tea
        }

        private readonly Dictionary<AvailableDrink, IHotDrinkFactory> _factories =
            new Dictionary<AvailableDrink, IHotDrinkFactory>();

        //private readonly List<Tuple<string, IHotDrinkFactory>> _namedFactories =
        //    new List<Tuple<string, IHotDrinkFactory>>();

        public HotDrinkMachine()
        {
            foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
            {
                var name = Enum.GetName(typeof(AvailableDrink), drink);

                //OBS: Parece gambiarra.
                var type = Type.GetType("DotNetDesignPatternDemos.Creational.AbstractFactory." + name + "Factory");

                if (string.IsNullOrEmpty(name) || type == null) continue;
                var factory = (IHotDrinkFactory)Activator.CreateInstance(type);
                _factories.Add(drink, factory);
            }

            //foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
            //{
            //    if (typeof(IHotDrinkFactory).IsAssignableFrom(t) && !t.IsInterface)
            //    {
            //        _namedFactories.Add(Tuple.Create(
            //            t.Name.Replace("Factory", string.Empty), (IHotDrinkFactory)Activator.CreateInstance(t)));
            //    }
            //}
        }

        //public IHotDrink MakeDrink()
        //{
        //    Console.WriteLine("Available drinks");
        //    for (var index = 0; index < namedFactories.Count; index++)
        //    {
        //        var tuple = namedFactories[index];
        //        Console.WriteLine($"{index}: {tuple.Item1}");
        //    }

        //    while (true)
        //    {
        //        string s;
        //        if ((s = Console.ReadLine()) != null
        //            && int.TryParse(s, out int i) // c# 7
        //            && i >= 0
        //            && i < namedFactories.Count)
        //        {
        //            Console.Write("Specify amount: ");
        //            s = Console.ReadLine();
        //            if (s != null
        //                && int.TryParse(s, out int amount)
        //                && amount > 0)
        //            {
        //                return namedFactories[i].Item2.Prepare(amount);
        //            }
        //        }
        //        Console.WriteLine("Incorrect input, try again.");
        //    }
        //}

        public IHotDrink MakeDrink(AvailableDrink drink, int amount)
        {
            return _factories[drink].Prepare(amount);
        }
    }
}