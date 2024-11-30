using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace subsequencia_mais_longa.Services
{
    internal class Buscador
    {
        internal static string BuscarPorMaiorStringComum(string[] palavrasDisponiveis, string palavraProcurada)
        {
            var letrasProcuradas = new List<char>();
            var palavraMaisProxima = palavrasDisponiveis.FirstOrDefault();
            var valorPalavraMaisProxima = 0;

            foreach (var palavra in palavrasDisponiveis)
            {
                var subsequenciaComum = new int[palavraProcurada.Length + 1, palavra.Length + 1];
                letrasProcuradas.Clear();

                var trechoAnterior = new int[2, palavra.Length + 1];

                for (int i = 1; i < palavraProcurada.Length + 1; i++)
                {
                    for (int j = 1; j < palavra.Length + 1; j++)
                    {
                        if (!letrasProcuradas.Contains(palavraProcurada[i - 1]) && palavraProcurada[i - 1] == palavra[j - 1])
                        {
                            subsequenciaComum[i, j] = subsequenciaComum[i - 1, j - 1] + 1;
                            letrasProcuradas.Add(palavra[j - 1]);
                        }
                        else
                        {
                            trechoAnterior = Filtro.PegarTrechoDoArray(subsequenciaComum, j, palavraProcurada.Length + 1, 2, i, j);
                            subsequenciaComum[i, j] = Filtro.EncontrarMaiorValor(trechoAnterior);
                        }
                    }
                }

                var maiorValor = Filtro.EncontrarMaiorValor(subsequenciaComum);
                if (maiorValor > valorPalavraMaisProxima)
                {
                    valorPalavraMaisProxima = maiorValor;
                    palavraMaisProxima = palavra;
                }
            }

            return palavraMaisProxima;
        }

        internal static string BuscarPorMaiorProporcaoSemelhante(string[] palavrasDisponiveis, string palavraProcurada)
        {
            var letrasProcuradas = new List<char>();
            var palavraMaisProxima = palavrasDisponiveis.FirstOrDefault();
            double proporcaoPalavraMaisProxima = -1;

            foreach (var palavra in palavrasDisponiveis)
            {
                var subsequenciaComum = new int[palavraProcurada.Length + 1, palavra.Length + 1];
                letrasProcuradas.Clear();

                var trechoAnterior = new int[2, palavra.Length + 1];

                for (int i = 1; i < palavraProcurada.Length + 1; i++)
                {
                    for (int j = 1; j < palavra.Length + 1; j++)
                    {
                        if (!letrasProcuradas.Contains(palavraProcurada[i - 1]) && palavraProcurada[i - 1] == palavra[j - 1])
                        {
                            subsequenciaComum[i, j] = subsequenciaComum[i - 1, j - 1] + 1;
                            letrasProcuradas.Add(palavra[j - 1]);
                        }
                        else
                        {
                            trechoAnterior = Filtro.PegarTrechoDoArray(subsequenciaComum, j, palavraProcurada.Length + 1, 2, i, j);
                            subsequenciaComum[i, j] = Filtro.EncontrarMaiorValor(trechoAnterior);
                        }
                    }
                }

                var maiorValor = Filtro.EncontrarMaiorValor(subsequenciaComum);

                double proporcao = maiorValor / (double)palavra.Length;
                if (proporcao > proporcaoPalavraMaisProxima)
                {
                    proporcaoPalavraMaisProxima = proporcao;
                    palavraMaisProxima = palavra;
                }
            }

            return palavraMaisProxima;
        }

    }
}
