using System;
using System.Linq;

namespace CodeTestApp.Pratices.ObserverPattern
{
  public class Game
  {
    public event EventHandler RatAdded, RatRemoved;
    public event EventHandler<Rat> NotifyRat;

    public void AddRat(Rat rat)
    {
      RatAdded?.Invoke(rat, EventArgs.Empty);
    }

    public void RemoveRat(Rat rat)
    {
      RatRemoved?.Invoke(rat, EventArgs.Empty);
    }

    public void FireNotifyRat(object sender, Rat whichRat)
    {
      NotifyRat?.Invoke(sender, whichRat);
    }
  }

  public class Rat : IDisposable
  {
    public int Attack = 1;
    private readonly Game _game;

    public Rat(Game game)
    {
      _game = game;
      _game.RatAdded += Game_RatAdded;
      _game.RatRemoved += Game_RatRemoved;
      game.NotifyRat += (sender, rat) =>
      {
        if (rat == this) ++Attack;
      };
      _game.AddRat(this);
    }

    private void Game_RatAdded(object sender, EventArgs e)
    {
      if (this != (Rat)sender)
      {
        Attack++;
        _game.FireNotifyRat(this, (Rat)sender);
      }
    }

    private void Game_RatRemoved(object sender, EventArgs e)
    {
      Attack--;
    }

    public void Dispose()
    {
      _game.RemoveRat(this);
    }
  }

  public class RatsGame
  {
    public static void Execute()
    {
      var ratsGame = new RatsGame();
      ratsGame.PlayingByTheRules();
      ratsGame.SingleRatTest();
      ratsGame.TwoRatTest();
      ratsGame.ThreeRatsOneDies();
    }

    public void PlayingByTheRules()
    {
      Console.WriteLine($"Fields Number: {typeof(Game).GetFields().Count()}");
      Console.WriteLine($"Properties Number: {typeof(Game).GetProperties().Count()}");
    }

    public void SingleRatTest()
    {
      var game = new Game();
      var rat = new Rat(game);
      Console.WriteLine($"Attack should be one: {rat.Attack}");
    }

    public void TwoRatTest()
    {
      var game = new Game();
      var rat = new Rat(game);
      var rat2 = new Rat(game);
      Console.WriteLine($"Attack of first ract should be two: {rat.Attack}");
      Console.WriteLine($"Attack second ract should be two: {rat2.Attack}");
    }

    public void ThreeRatsOneDies()
    {
      var game = new Game();

      var rat = new Rat(game);
      Console.WriteLine($"Attack should be one: {rat.Attack}");

      var rat2 = new Rat(game);
      Console.WriteLine($"Attack of first ract should be two: {rat.Attack}");
      Console.WriteLine($"Attack second ract should be two: {rat2.Attack}");

      using (var rat3 = new Rat(game))
      {
        Console.WriteLine($"Attack of first ract should be three: {rat.Attack}");
        Console.WriteLine($"Attack second ract should be three: {rat2.Attack}");
        Console.WriteLine($"Attack third ract should be three: {rat3.Attack}");
      }

      Console.WriteLine($"Attack first ract should be two: {rat2.Attack}");
      Console.WriteLine($"Attack second ract should be two: {rat2.Attack}");
    }
  }
}
