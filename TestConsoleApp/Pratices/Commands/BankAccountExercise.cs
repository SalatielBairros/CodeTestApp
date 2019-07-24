using System;
using System.Collections.Generic;

namespace CodeTestApp.Pratices.Commands
{
  /*
    Implement the Account.Process() method to process diferent account commands. The rules are obvious:
      1 - Success indicates whether the operation was successful
      2 - You can only withdraw money if you have enough in your account

    This exercise is from Design Patterns in C# and .NET Udemy Course. 
    It does not represents the right or best implementation of commands.

   */
  public class Command
  {
    public enum Action
    {
      Deposit,
      Withdraw
    }

    public Action TheAction;
    public int Amount;
    public bool Success;

    public Command(Action theAction, int amount, bool success)
    {
      TheAction = theAction;
      Amount = amount;
      Success = success;
    }

    public Command()
    {

    }
  }

  public class Account
  {
    public Account()
    {
      ExecutedCommandList = new List<Command>();
    }

    public int Balance { get; set; }
    public List<Command> ExecutedCommandList { get; }

    public void Process(Command c)
    {
      switch (c.TheAction)
      {
        case Command.Action.Deposit:
          Deposite(c.Amount);
          c.Success = true;
          break;
        case Command.Action.Withdraw:
          c.Success = Withdraw(c.Amount);
          break;
        default:
          throw new ArgumentOutOfRangeException(nameof(c));
      }

      ExecutedCommandList.Add(c);
    }

    private bool Withdraw(int amount)
    {
      if (Balance >= amount)
      {
        Balance -= amount;
        return true;
      }
      return false;
    }

    private void Deposite(int amount)
    {
      Balance += amount;
    }
  }
}
