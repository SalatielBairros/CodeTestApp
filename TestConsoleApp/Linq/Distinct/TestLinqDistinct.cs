using System.Collections.Generic;
using System.Linq;

namespace CodeTestApp.Linq.Distinct
{
  public class TestLinqDistinct
  {
    public static void Execute()
    {
      var pessoas = AtendimentoPessoa.Seed();
      //var selecionadas = pessoas.Distinct(new EqualityComparer());

      var page = 1;
      var pageSize = 2;

      var selecionadas = pessoas
        .GroupBy(x => x.Codigo)
        .Select(x => x.OrderByDescending(y => y.TipoAtendimento).First())
        .OrderBy(x => x.Codigo)
        .Skip(page * pageSize)
        .Take(pageSize);
    }
  }

  public class EqualityComparer : IEqualityComparer<AtendimentoPessoa>
  {
    public bool Equals(AtendimentoPessoa x, AtendimentoPessoa y)
    {
      return x.Codigo == y.Codigo;
    }

    public int GetHashCode(AtendimentoPessoa obj)
    {
      return obj.Codigo;
    }
  }

  public class AtendimentoPessoa
  {
    public int Codigo { get; set; }
    public string Nome { get; set; }
    public string TipoAtendimento { get; set; }

    public static List<AtendimentoPessoa> Seed()
    {
      return new List<AtendimentoPessoa>
      {
        new AtendimentoPessoa
        {
          Codigo = 1,
          Nome = "Pessoa1",
          TipoAtendimento = "I"
        },
        new AtendimentoPessoa
        {
          Codigo = 1,
          Nome = "Pessoa1",
          TipoAtendimento = "E"
        },
        new AtendimentoPessoa
        {
          Codigo = 2,
          Nome = "Pessoa2",
          TipoAtendimento = "E"
        },
        new AtendimentoPessoa
        {
          Codigo = 2,
          Nome = "Pessoa2",
          TipoAtendimento = "I"
        },
      };
    }
  }
}
