using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordenacao_rapida.Services
{
    internal class Ordenador
    {
        internal static List<int> OrdenarDeFormaCrescente(List<int> listaDeNumeros)
        {
            if (listaDeNumeros.Count <= 1)
            {
                return listaDeNumeros;
            }

            var pivo = listaDeNumeros.FirstOrDefault();

            var numerosMenoresDoQueOPivo = new List<int>();
            var numerosMaioresDoQueOPivo = new List<int>();

            foreach (var numero in listaDeNumeros.Skip(1))
            {
                if (numero <= pivo)
                {
                    numerosMenoresDoQueOPivo.Add(numero);
                }
                else
                {
                    numerosMaioresDoQueOPivo.Add(numero);
                }
            }

            var listaOrdenada = new List<int>();
            listaOrdenada.AddRange(OrdenarDeFormaCrescente(numerosMenoresDoQueOPivo));
            listaOrdenada.Add(pivo);
            listaOrdenada.AddRange(OrdenarDeFormaCrescente(numerosMaioresDoQueOPivo));

            return listaOrdenada;
        }

        internal static List<int> OrdenarDeFormaDecrescente(List<int> listaDeNumeros)
        {
            if (listaDeNumeros.Count <= 1)
            {
                return listaDeNumeros;
            }

            var pivo = listaDeNumeros.FirstOrDefault();

            var numerosMenoresDoQueOPivo = new List<int>();
            var numerosMaioresDoQueOPivo = new List<int>();

            foreach (var numero in listaDeNumeros.Skip(1))
            {
                if (numero <= pivo)
                {
                    numerosMenoresDoQueOPivo.Add(numero);
                }
                else
                {
                    numerosMaioresDoQueOPivo.Add(numero);
                }
            }

            var listaOrdenada = new List<int>();
            listaOrdenada.AddRange(OrdenarDeFormaDecrescente(numerosMaioresDoQueOPivo));
            listaOrdenada.Add(pivo);
            listaOrdenada.AddRange(OrdenarDeFormaDecrescente(numerosMenoresDoQueOPivo));

            return listaOrdenada;
        }
    }
}
