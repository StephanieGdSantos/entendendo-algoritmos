using programacao_dinamica.Model;
using System.Collections.Generic;
using System.Linq;

namespace programacao_dinamica.Services
{
    internal class Seletor
    {
        public List<Item> SelecionarMelhoresItens(List<Item> itens, int capacidadeDaMochila)
        {
            var pesos = itens
                .Select(item => item.peso)
                .Distinct()
                .Order()
                .ToList();

            var tabelaMochilas = new List<Item>[itens.Count + 1, capacidadeDaMochila + 1];

            for (int i = 0; i <= itens.Count; i++)
            {
                for (int j = 0; j <= capacidadeDaMochila; j++)
                {
                    tabelaMochilas[i, j] = new List<Item>();
                }
            }

            for (int i = 1; i <= itens.Count; i++)
            {
                var itemAtual = itens[i - 1];
                for (int j = 1; j <= capacidadeDaMochila; j++)
                {
                    if (itemAtual.peso <= j)
                    {
                        var semItemAtual = tabelaMochilas[i - 1, j];
                        var comItemAtual = new List<Item>(tabelaMochilas[i - 1, j - (int)itemAtual.peso]) { itemAtual };

                        if (comItemAtual.Sum(item => item.importancia) > semItemAtual.Sum(item => item.importancia))
                        {
                            tabelaMochilas[i, j] = comItemAtual;
                        }
                        else
                        {
                            tabelaMochilas[i, j] = semItemAtual;
                        }
                    }
                    else
                    {
                        tabelaMochilas[i, j] = tabelaMochilas[i - 1, j];
                    }
                }
            }

            return tabelaMochilas[itens.Count, capacidadeDaMochila];
        }
    }
}
