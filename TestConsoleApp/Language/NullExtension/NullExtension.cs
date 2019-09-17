using System;
using System.Collections.Generic;

namespace CodeTestApp.Language.TestNamespace
{
  public static class NullExtension
  {
    public static bool IsNull(this TestObject testObject) => testObject == null;

    public static bool Any<TSource>(this IEnumerable<TSource> source)
    {
      Console.WriteLine("chamou o any local");
      return false;
    }
  }

  public class TestObject
  {
    private List<int> _objectList;

    public static TestObject ReturnNullObject() => null;

    public TestObject()
    {
      _objectList = new List<int>();
    }

    public int MyProperty { get; set; }

    public List<int> ObjectList
    {
      get
      {
        if (_objectList == null)
          _objectList = new List<int>();

        return _objectList;
      }
      set
      {
        _objectList = value;
      }
    }
  }
}
