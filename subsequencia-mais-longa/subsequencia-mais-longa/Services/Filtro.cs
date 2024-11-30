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

    }
}
