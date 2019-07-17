using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeTestApp.Language
{
  public class TaskToAction
  {
    public Action Convert(Task<List<int>> task) => () => task.Wait();
  }
}
