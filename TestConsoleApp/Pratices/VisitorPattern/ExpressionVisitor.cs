using System.Text;

namespace CodeTestApp.Pratices.VisitorPattern
{
  public abstract class ExpressionVisitor
  {
    public abstract void Visit(Value value);
    public abstract void Visit(AdditionExpression ae);
    public abstract void Visit(MultiplicationExpression me);
  }

  public abstract class Expression
  {
    public abstract void Accept(ExpressionVisitor ev);
  }

  public class Value : Expression
  {
    public readonly int TheValue;

    public Value(int value)
    {
      TheValue = value;
    }

    public override void Accept(ExpressionVisitor ev)
    {
      ev.Visit(this);
    }

  }

  public class AdditionExpression : Expression
  {
    public readonly Expression LHS, RHS;

    public AdditionExpression(Expression lhs, Expression rhs)
    {
      LHS = lhs;
      RHS = rhs;
    }

    public override void Accept(ExpressionVisitor ev)
    {
      ev.Visit(this);
    }
  }

  public class MultiplicationExpression : Expression
  {
    public readonly Expression LHS, RHS;

    public MultiplicationExpression(Expression lhs, Expression rhs)
    {
      LHS = lhs;
      RHS = rhs;
    }

    public override void Accept(ExpressionVisitor ev)
    {
      ev.Visit(this);
    }
  }

  public class ExpressionPrinter : ExpressionVisitor
  {
    private readonly StringBuilder builder = new StringBuilder();

    public override void Visit(Value value)
    {
      builder.Append(value.TheValue);
    }

    public override void Visit(AdditionExpression ae)
    {
      builder.Append("(");
      ae.LHS.Accept(this);
      builder.Append("+");
      ae.RHS.Accept(this);
      builder.Append(")");
    }

    public override void Visit(MultiplicationExpression me)
    {
      me.LHS.Accept(this);
      builder.Append("*");
      me.RHS.Accept(this);
    }

    public override string ToString()
    {
      return builder.ToString();
    }
  }
}
