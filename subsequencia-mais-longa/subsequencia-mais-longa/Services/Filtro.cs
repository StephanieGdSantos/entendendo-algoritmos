using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace subsequencia_mais_longa.Services
{
    public class Filtro
    {
        public static int EncontrarMaiorValor(int[,] listaDeNumeros)
        {
            var maiorNumero = listaDeNumeros[0,0];
            foreach (var numero in listaDeNumeros)
            {
                if (numero > maiorNumero)
                {
                    maiorNumero = numero;
                }
            }

            return maiorNumero;
        }

        public static int[,] PegarTrechoDoArray(int[,] array, int linhaInicio, int colunas, int linhas, int linhaDoItem, int colunaDoItem)
        {
            var trecho = new int[linhas, colunas];
            var linhaTrecho = 0;
            var colunaTrecho = 0;

            for (int k = linhaInicio - 1; k < linhaInicio + 1; k++)
            {
                for (int l = 1; l < colunas; l++)
                {
                    if (l == linhaDoItem && k == colunaDoItem)
                        break;
                    trecho[linhaTrecho, colunaTrecho] = array[l, k];
                    colunaTrecho++;
                }
                linhaTrecho++;
                colunaTrecho = 0;
            }

            return trecho;
        }
    }
}
