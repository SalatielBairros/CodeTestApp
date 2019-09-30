using System;
using System.Numerics;

namespace CodeTestApp.Pratices.Strategy
{
  public interface IDiscriminantStrategy
  {
    double CalculateDiscriminant(double a, double b, double c);
  }

  public class OrdinaryDiscriminantStrategy : IDiscriminantStrategy
  {
    public double CalculateDiscriminant(double a, double b, double c)
    {
      return Math.Pow(b, 2) - (4 * a * c);
    }
  }

  public class RealDiscriminantStrategy : IDiscriminantStrategy
  {
    public double CalculateDiscriminant(double a, double b, double c)
    {
      var ret = Math.Pow(b, 2) - (4 * a * c);
      if (ret < 0) return double.NaN;

      return ret;
    }
  }

  public class QuadraticEquationSolver
  {
    private readonly IDiscriminantStrategy strategy;

    public QuadraticEquationSolver(IDiscriminantStrategy strategy)
    {
      this.strategy = strategy;
    }

    public Tuple<Complex, Complex> Solve(double a, double b, double c)
    {
      var discriminant = new Complex(strategy.CalculateDiscriminant(a, b, c), 0);
      var minusB = b * -1;
      var discriminantRoot = Complex.Sqrt(discriminant);
      var a2 = 2 * a;

      return Tuple.Create(
        ((minusB + discriminantRoot) / a2),
        ((minusB - discriminantRoot) / a2)
      );

    }
  }
}
