using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace subsequencia_mais_longa.Services
{
    internal class Filtro
    {
        public static int EncontrarMaiorValor(int[] listaDeNumeros)
        {
            var maiorNumero = listaDeNumeros.FirstOrDefault();
            foreach (var numero in listaDeNumeros)
            {
                if (numero > maiorNumero)
                {
                    maiorNumero = numero;
                }
            }

            return maiorNumero;
        }

        public static int[,] PegarTrechoDoArray(int[,] array, int linhaInicio, int colunaInicio, int linhaFinal, int colunaFinal)
        {

            int[,] trechoDoArray = new int[linhaFinal-linhaInicio, colunaFinal-colunaInicio];
            for (int i = linhaInicio; i < linhaFinal; i++)
            {
                for (int j = colunaInicio; j < colunaFinal; j++)
                {
                    trechoDoArray[i, j] = array[i, j];
                }
            }
            return trechoDoArray;
        }
    }
}
