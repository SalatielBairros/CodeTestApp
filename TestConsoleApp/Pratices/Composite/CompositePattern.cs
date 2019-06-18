using System.Collections;
using System.Collections.Generic;

namespace CodeTestApp.Pratices.Composite
{
  public interface IValueContainer : IEnumerable<int>
  {

  }

  public class SingleValue : IValueContainer
  {
    public int Value;

    public IEnumerator<int> GetEnumerator()
    {
      yield return Value;
    }

    IEnumerator IEnumerable.GetEnumerator() { yield return Value; }
  }

  public class ManyValues : List<int>, IValueContainer
  {
  }

  public static class ExtensionMethods
  {
    public static int Sum(this List<IValueContainer> containers)
    {
      int result = 0;
      foreach (var c in containers)
        foreach (var i in c)
          result += i;
      return result;
    }
  }
}
