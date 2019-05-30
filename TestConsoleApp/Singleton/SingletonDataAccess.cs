using System;
using System.Collections.Generic;

namespace CodeTestApp.Singleton
{
  public class SingletonDataAccess : IDataAccess
  {
    private readonly List<string> _dataFromBase;
    private static int _instanceCount = 0;
    public static int InstanceCount => _instanceCount;

    private SingletonDataAccess()
    {
      _instanceCount++;

      _dataFromBase = new List<string>();

      using (var database = DataBase.Open())
      {
        _dataFromBase.AddRange(database.DataList);
      }
    }

    public static SingletonDataAccess NormalSingleton => new SingletonDataAccess();
    private static Lazy<SingletonDataAccess> instance = new Lazy<SingletonDataAccess>(() => new SingletonDataAccess());
    public static SingletonDataAccess Instance => instance.Value;

    public bool ExistData(string key) => _dataFromBase.Contains(key);
  }

  public interface IDataAccess
  {
    bool ExistData(string key);
  }
}
