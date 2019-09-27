using System;
using System.ComponentModel;

namespace CodeTestApp.Language
{
  public class ObservableMarket
  {
    private static Lazy<ObservableMarket> _instance = new Lazy<ObservableMarket>(() => new ObservableMarket());
    public static ObservableMarket Instance => _instance.Value;

    private ObservableMarket()
    {
      Prices = new BindingList<decimal>();
    }

    public BindingList<decimal> Prices { get; }

    public void AddPrice(decimal price) => Prices.Add(price);
    public void RemovePrice(decimal price) => Prices.Remove(price);
  }

  public class MarketAddObserver
  {
    private static Lazy<MarketAddObserver> _instance = new Lazy<MarketAddObserver>(() => new MarketAddObserver());
    public static MarketAddObserver Start() => _instance.Value;

    private MarketAddObserver()
    {
      var market = ObservableMarket.Instance;
      market.Prices.ListChanged += Prices_ListChanged;
    }

    private void Prices_ListChanged(object sender, ListChangedEventArgs e)
    {
      if (e.ListChangedType == ListChangedType.ItemAdded)
        Console.WriteLine($"Item valor {((BindingList<decimal>)sender)[e.NewIndex]} adicionado no índice {e.NewIndex}");
    }
  }

  public class MarketRemoveObserver
  {
    private static Lazy<MarketRemoveObserver> _instance = new Lazy<MarketRemoveObserver>(() => new MarketRemoveObserver());
    public static MarketRemoveObserver Start() => _instance.Value;

    private MarketRemoveObserver()
    {
      var market = ObservableMarket.Instance;
      market.Prices.ListChanged += Prices_ListChanged;
    }

    private void Prices_ListChanged(object sender, ListChangedEventArgs e)
    {
      if (e.ListChangedType == ListChangedType.ItemDeleted)
        Console.WriteLine($"Item índice {e.NewIndex} removido");
    }
  }

  public static class MarketProgram
  {
    public static void Execute()
    {
      MarketAddObserver.Start();
      MarketRemoveObserver.Start();

      ObservableMarket.Instance.AddPrice(10);
      ObservableMarket.Instance.AddPrice(20);
      ObservableMarket.Instance.AddPrice(30);
      ObservableMarket.Instance.AddPrice(30);
      ObservableMarket.Instance.RemovePrice(10);
    }
  }
}
