namespace CodeTestApp.Pratices.Proxy
{

  /*
   You are given the Person class and asked to write a ResponsiblePerson proxy that does the following:
      1 - Allows person to drink unless they are younger than 18 (in that case, return "too young")
      2 - Allows person to drive unless they are younger than 16 (otherwise, "too young")
      3 - In case of driving while drinking, returns "dead"    
   */

  public class Person
  {
    public int Age { get; set; }

    public string Drink()
    {
      return "drinking";
    }

    public string Drive()
    {
      return "driving";
    }

    public string DrinkAndDrive()
    {
      return "driving while drunk";
    }
  }

  public class ResponsiblePerson
  {
    private readonly Person person;

    public ResponsiblePerson(Person person)
    {
      this.person = person;
    }

    public int Age { get { return person.Age; } set { person.Age = value; } }

    public string Drink()
    {
      if (person.Age < 18) return "too young";
      return person.Drink();
    }

    public string Drive()
    {
      if (person.Age < 16) return "too young";
      return person.Drive();
    }

    public string DrinkAndDrive()
    {
      return "dead";
    }
  }
}
