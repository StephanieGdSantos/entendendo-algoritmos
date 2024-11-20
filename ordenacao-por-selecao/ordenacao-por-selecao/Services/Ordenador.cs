using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordenacao_por_selecao.Services
{
    internal class Ordenador
    {
        public static Dictionary<string, int> OrdernarDeFormaCrescente(Dictionary<string, int> listaDesordenada)
        {
            string itemDeMaiorRelevancia;
            int relevanciaDoItem;
            var itensEmOrdemDeRelevancia = new Dictionary<string, int>();

            while (listaDesordenada.Count != 0)
            {
                itemDeMaiorRelevancia = listaDesordenada.Keys.First();
                relevanciaDoItem = listaDesordenada.Values.First();
                foreach (var item in listaDesordenada.Keys)
                {
                    if (relevanciaDoItem < listaDesordenada[item])
                    {
                        itemDeMaiorRelevancia = item;
                        relevanciaDoItem = listaDesordenada[item];
                    }
                }
                itensEmOrdemDeRelevancia.Add(itemDeMaiorRelevancia, relevanciaDoItem);
                listaDesordenada.Remove(itemDeMaiorRelevancia);
            }

            return itensEmOrdemDeRelevancia;
        }

        public static Dictionary<string, int> OrdernarDeFormaDecrescente(Dictionary<string, int> listaDesordenada)
        {
            string itemDeMaiorRelevancia;
            int relevanciaDoItem;
            var itensEmOrdemDeRelevancia = new Dictionary<string, int>();

            while (listaDesordenada.Count != 0)
            {
                itemDeMaiorRelevancia = listaDesordenada.Keys.First();
                relevanciaDoItem = listaDesordenada.Values.First();
                foreach (var item in listaDesordenada.Keys)
                {
                    if (relevanciaDoItem < listaDesordenada[item])
                    {
                        itemDeMaiorRelevancia = item;
                        relevanciaDoItem = listaDesordenada[item];
                    }
                }
                itensEmOrdemDeRelevancia.Add(itemDeMaiorRelevancia, relevanciaDoItem);
                listaDesordenada.Remove(itemDeMaiorRelevancia);
            }

            return itensEmOrdemDeRelevancia;
        }
    }
}
