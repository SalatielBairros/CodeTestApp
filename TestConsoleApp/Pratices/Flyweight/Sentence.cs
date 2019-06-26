using System;
using System.Collections.Generic;

namespace CodeTestApp.Pratices
{
  /// <summary>
  /// O padrão Flyweight busca reduzir o uso de memória compartilhando dados entre objetos similares.
  /// https://en.wikipedia.org/wiki/Flyweight_pattern
  /// </summary>
  public class Sentence
  {
    private readonly Dictionary<int, WordToken> tokens = new Dictionary<int, WordToken>();
    private readonly string[] words;

    public Sentence(string plainText)
    {
      words = plainText.Split(' ');
    }

    public WordToken this[int index]
    {
      get
      {
        if (!tokens.ContainsKey(index))
        {
          WordToken wt = new WordToken();
          tokens.Add(index, wt);
        }
        return tokens[index];
      }
    }

    public override string ToString()
    {
      var ws = new List<string>();
      for (var i = 0; i < words.Length; i++)
      {
        var w = words[i];
        if (tokens.ContainsKey(i) && tokens[i].Capitalize)
          w = w.ToUpperInvariant();
        ws.Add(w);
      }
      return string.Join(" ", ws);
    }

    public class WordToken
    {
      public bool Capitalize;
    }
  }

  public class SentenceExecute
  {
    public void Execute()
    {
      var sentence = new Sentence("hello world");
      sentence[1].Capitalize = true;
      Console.WriteLine(sentence);
    }
  }
}
