using System;
using System.Collections.Generic;

namespace CodeTestApp.Singleton
{
  public class DataBase : IDisposable, IDataBase
  {
    private readonly List<string> _list;

    public IReadOnlyList<string> DataList => _list;

    private DataBase()
    {
      _list = new List<string>();
      Seed();
    }

    // Simple singleton.
    public static DataBase Open() => new DataBase();

    public void Close()
    {
      _list.Clear();
    }

    public void Dispose() => Dispose(true);

    protected virtual void Dispose(bool disposing)
    {
      if (disposing)
      {
        Close();
      }
    }

    ~DataBase()
    {
      Dispose(false);
    }

    private void Seed()
    {
      _list.Add("TEST_1");
      _list.Add("TEST_2");
      _list.Add("TEST_3");
      _list.Add("TEST_4");
    }
  }

  public interface IDataBase
  {
    void Close();
    IReadOnlyList<string> DataList { get; }
  }
}
