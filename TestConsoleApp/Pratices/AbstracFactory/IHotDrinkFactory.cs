namespace CodeTestApp.Pratices.AbstracFactory
{
    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }
}