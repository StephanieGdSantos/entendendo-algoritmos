using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programacao_dinamica.Utils
{
    public class Filtro
    {
        internal static List<float> RetirarDuplicatas(List<float> lista)
        {
            var listaSemDuplicacoes = new List<float>();

            foreach (var item in lista)
            {
                var numeroAtual = item;

                if (!listaSemDuplicacoes.Contains(numeroAtual))
                {
                    listaSemDuplicacoes.Add(numeroAtual);
                }
            }

            return listaSemDuplicacoes;
        }
    }
}
