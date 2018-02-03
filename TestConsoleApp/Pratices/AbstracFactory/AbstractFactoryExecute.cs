using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTestApp.Pratices.AbstracFactory
{
    public class AbstractFactoryExecute
    {
        public static void Execute()
        {
            var machine = new HotDrinkMachine();
            var drink = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Tea, 300);
            drink.Consume();

            //IHotDrink drink = machine.MakeDrink();
            //drink.Consume();
        }
    }
}
