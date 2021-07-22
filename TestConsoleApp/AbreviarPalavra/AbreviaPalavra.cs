using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeTestApp.AbreviarPalavra
{
  public class AbreviaPalavra
  {
    public static void Executar_Tradicional()
    {
      string fraseAtual;
      while ((fraseAtual = Console.ReadLine()) != ".")
      {
        string[] palavras = fraseAtual.Replace("  ", " ").Split(' ');
        List<string> abreviadas = new List<string>();
        string fraseAbreviada = fraseAtual;

        var palavrasAbreviadas =
          palavras
            .Where(x => x.Length > 2)
            .GroupBy(x => x)
            .Select(x => new PalavraAbreviada(x.Key, x.Count()))
            .GroupBy(x => x.Letra)
            .Select(x => x.OrderByDescending(y => y.TamanhoTotal).First())
            .ToList();
        
        palavrasAbreviadas.ForEach(x => fraseAbreviada = fraseAbreviada.Replace(x.Palavra, $"{x.Letra}."));

        Console.WriteLine(fraseAbreviada);
      }
    }
  }

  public class PalavraAbreviada
  {
    public PalavraAbreviada(string palavra, int ocorrencias)
    {
      Palavra = palavra;
      Letra = palavra[0];
      NroOcorrencias = ocorrencias;
      TamanhoTotal = NroOcorrencias * Palavra.Length;
    }

    public string Palavra { get; set; }
    public char Letra { get; }
    public int NroOcorrencias { get; }
    public int TamanhoTotal { get; }
  }
}
