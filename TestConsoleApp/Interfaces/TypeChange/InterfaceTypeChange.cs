namespace CodeTestApp.Interfaces.TypeChange
{
  public interface ITypeChange
  {
    string FirstProperty { get; }
    string SecondProperty { get; }
  }

  public class FirstImplementation : ITypeChange
  {
    public FirstImplementation(string firstProperty, string secondProperty)
    {
      FirstProperty = firstProperty;
      SecondProperty = secondProperty;
    }

    public string FirstProperty { get; private set; }

    public string SecondProperty { get; private set; }
  }

  public class SecondImplementation : ITypeChange
  {
    public string FirstProperty { get; set; }

    public string SecondProperty { get; set; }
  }

  public class TypeChangeService
  {
    public static void Execute()
    {
      var service = new TypeChangeService();

      //ALERT: It throws an exception.
      //var firstToSecond = (SecondImplementation)service.ReturnFirstImplementation();
      //var secondToFirst = (FirstImplementation)service.ReturnSecondImplementation();

      //Console.WriteLine($"First to second: {firstToSecond.FirstProperty}");
      //Console.WriteLine($"Second to first: {secondToFirst.FirstProperty}");
    }

    public ITypeChange ReturnFirstImplementation() => new FirstImplementation("FIRST", "SECOND");
    public ITypeChange ReturnSecondImplementation() => new SecondImplementation
    {
      FirstProperty = "FIRST",
      SecondProperty = "SECOND"
    };
  }
}
