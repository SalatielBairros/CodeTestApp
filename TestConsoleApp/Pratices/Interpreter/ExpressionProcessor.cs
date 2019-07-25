using System.Collections.Generic;
using System.Linq;

namespace CodeTestApp.Pratices.Interpreter
{
  public class ExpressionProcessor
  {
    public Dictionary<char, int> Variables = new Dictionary<char, int>();

    public int Calculate(string expression)
    {
      var elements = GetElements(expression)
        .SetVariables(Variables)
        .GetValids();

      if (elements.Any() && elements[0].ElementType == Element.Type.Number)
      {
        int leftValue = elements[0].Value;
        for (int i = 1; i < elements.Count; i++)
        {
          if (elements[i].ElementType == Element.Type.Subtraction)
          {
            i++;
            if (i >= elements.Count) return 0;
            leftValue -= elements[i].Value;
          }
          else if (elements[i].ElementType == Element.Type.Plus)
          {
            i++;
            if (i >= elements.Count) return 0;
            leftValue += elements[i].Value;
          }
        }
        return leftValue;
      }

      return 0;
    }

    private ElementCollection GetElements(string expression)
    {
      var elements = new ElementCollection();
      var digits = expression.ToCharArray();

      var word = string.Empty;
      for (int i = 0; i < digits.Length; i++)
      {
        if (Operators.List.Contains(digits[i]))
        {
          elements.Add(word);
          elements.Add(digits[i].ToString());
          word = string.Empty;
        }
        else
        {
          word += digits[i].ToString();
        }
      }
      elements.Add(word);
      return elements;
    }
  }

  public static class Operators
  {
    public const char Plus = '+';
    public const char Subtraction = '-';

    public static readonly char[] List = { Plus, Subtraction };
  }

  public class Element
  {
    private Element(Type elementType, int value)
    {
      ElementType = elementType;
      Value = value;
    }

    private Element(Type elementType)
    {
      ElementType = elementType;
      Value = 0;
    }

    private Element(Type elementType, char variableName)
    {
      ElementType = elementType;
      Value = 0;
      VariableName = variableName;
    }

    public enum Type
    {
      Subtraction,
      Variable,
      Plus,
      Number,
      Invalid
    }

    public Type ElementType { get; private set; }
    public int Value { get; private set; }
    public char VariableName { get; }

    public void SetValueToVariable(int value)
    {
      if (ElementType == Type.Variable)
      {
        Value = value;
        ElementType = Type.Number;
      }
    }

    public void SetAsInvalid()
    {
      Value = 0;
      ElementType = Type.Invalid;
    }

    public static explicit operator Element(string value)
    {
      int result = 0;
      if (!string.IsNullOrEmpty(value))
      {
        if (value[0].Equals(Operators.Plus))
        {
          return new Element(Type.Plus);
        }
        else if (value[0].Equals(Operators.Subtraction))
        {
          return new Element(Type.Subtraction);
        }
        else if (int.TryParse(value, out result))
        {
          return new Element(Type.Number, result);
        }
        else if (value.Length == 1)
        {
          return new Element(Type.Variable, value.ToArray()[0]);
        }
      }
      return new Element(Type.Invalid);
    }
  }

  public class ElementCollection : List<Element>
  {
    public ElementCollection Add(string elementValue)
    {
      this.Add((Element)elementValue);
      return this;
    }

    public ElementCollection SetVariables(Dictionary<char, int> variables)
    {
      this.ForEach(x =>
      {
        if (x.ElementType == Element.Type.Variable)
        {
          if (variables.ContainsKey(x.VariableName))
          {
            x.SetValueToVariable(variables[x.VariableName]);
          }
          else
          {
            x.SetAsInvalid();
          }
        }
      });

      return this;
    }

    public List<Element> GetValids()
    {
      return
          this
            .Where(x => x.ElementType != Element.Type.Invalid)
            .ToList();
    }
  }
}
