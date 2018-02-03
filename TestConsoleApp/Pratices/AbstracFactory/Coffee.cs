using System;

namespace CodeTestApp.Pratices.AbstracFactory
{
    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("This coffee is delicious!");
        }
    }
}