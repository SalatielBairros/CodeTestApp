using System;
using System.Collections.Generic;

namespace CodeTestApp.Pratices.ChainOfResponsability
{

  /*
   
     You are given a game scenario with classes Goblin and GoblinKing. Please implement the following rules:

        A goblin has base 1 attack/1 defense (1/1). 
        A goblin king is 3/3.
        When the Goblin King is in play, every other goblin gets +1 Attack.
        Goblins get +1 to Defense for every other Goblin in play (a GoblinKing is a Goblin!).</li></ul>


     The state of all the goblins has to be consistent as goblins are added and removed from the game.

  */

  public abstract class Creature
  {
    protected Game game;
    protected readonly int baseAttack;
    protected readonly int baseDefense;

    protected Creature(Game game, int baseAttack, int baseDefense)
    {
      this.game = game;
      this.baseAttack = baseAttack;
      this.baseDefense = baseDefense;
    }

    public virtual int Attack { get; set; }
    public virtual int Defense { get; set; }

    public abstract void Query(object source, StatusQuery query);
  }

  public class Goblin : Creature
  {
    public Goblin(Game game) : base(game, 1, 1) { }

    protected Goblin(Game game, int baseAttack, int baseDefense) : base(game,
        baseAttack, baseDefense)
    {
    }

    public override void Query(object source, StatusQuery query)
    {
      if (ReferenceEquals(source, this))
      {
        switch (query.Attribute)
        {
          case Attribute.Attack:
            query.Value += baseAttack;
            break;
          case Attribute.Defense:
            query.Value += baseDefense;
            break;
        }
      }
      else if (query.Attribute == Attribute.Defense)
      {
        query.Value++;
      }
    }

    public override int Defense => game.ExecutelAllCreatureGameQueriesFor(Attribute.Defense, this).Value;
    public override int Attack => game.ExecutelAllCreatureGameQueriesFor(Attribute.Attack, this).Value;
  }

  public class GoblinKing : Goblin
  {
    public GoblinKing(Game game) : base(game, 3, 3) { }

    public override void Query(object source, StatusQuery query)
    {
      if (!ReferenceEquals(source, this) && query.Attribute == Attribute.Attack)
      {
        query.Value++;
      }
      else base.Query(source, query);
    }
  }

  public enum Attribute
  {
    Attack, Defense
  }

  public class StatusQuery
  {
    public Attribute Attribute;
    public int Value;
  }

  public class Game
  {
    public IList<Creature> Creatures = new List<Creature>();

    public StatusQuery ExecutelAllCreatureGameQueriesFor(Attribute attribute, Creature creature)
    {
      var q = new StatusQuery { Attribute = attribute };
      foreach (var c in Creatures)
        c.Query(creature, q);
      return q;
    }
  }

  public class GameExercise
  {
    public void Execute()
    {
      var game = new Game();
      var goblin = new Goblin(game);
      game.Creatures.Add(goblin);

      Console.WriteLine($"Goblin attack is {goblin.Attack} and should be 1");
      Console.WriteLine($"Goblin defense is {goblin.Defense} and should be 1");

      var goblin2 = new Goblin(game);
      game.Creatures.Add(goblin2);

      Console.WriteLine($"Goblin attack is {goblin.Attack} and should be 1");
      Console.WriteLine($"Goblin defense is {goblin.Defense} and should be 2");

      var goblin3 = new GoblinKing(game);
      game.Creatures.Add(goblin3);

      Console.WriteLine($"Goblin attack is {goblin.Attack} and should be 2");
      Console.WriteLine($"Goblin defense is {goblin.Defense} and should be 3");
    }
  }
}
