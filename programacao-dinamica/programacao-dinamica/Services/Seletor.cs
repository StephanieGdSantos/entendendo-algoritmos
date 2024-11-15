using programacao_dinamica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programacao_dinamica.Services
{
    internal class Seletor
    {
        public List<Item> SelecionarMelhoresItens(List<Item> itens)
        {
            var pesos = itens
                .Select(item => item.peso)
                .Distinct()
                .Order()
                .ToList();

            var tabelaMochilas = new List<Item>[itens.Count, pesos.Count];

            var itemVazio = new Item { nome = "", importancia = 0, peso = 0 };

            for (int linha = 0; linha < itens.Count; linha++)
            {
                var itemAtual = itens[linha];
                for (int coluna = 0; coluna < pesos.Count; coluna++)
                {
                    var capacidadeDaMochilaAtual = pesos[coluna];

                    if (tabelaMochilas[linha, coluna] == null)
                    {
                        tabelaMochilas[linha, coluna] = new List<Item>();
                    }

                    if (linha != 0)
                    {
                        var mochilaDeCima = tabelaMochilas[linha - 1, coluna];
                        var itemComPesoAproximadoDoItemAtual = mochilaDeCima.FirstOrDefault(item => item.peso <= itemAtual.peso) != null ? mochilaDeCima.FirstOrDefault(item => item.peso <= itemAtual.peso) : null;

                        if (mochilaDeCima.Count != 0)
                        {
                            if (mochilaDeCima == null)
                            {
                                tabelaMochilas[linha, coluna].Add(itemAtual);
                            }
                            else if (capacidadeDaMochilaAtual - mochilaDeCima.Sum(item => item.peso) >= itemAtual.peso)
                            {
                                mochilaDeCima.ForEach(item => tabelaMochilas[linha, coluna].Add(item));
                                tabelaMochilas[linha, coluna].Add(itemAtual);
                            }
                            else
                            {
                                if (mochilaDeCima.Count == 1)
                                {
                                    if (mochilaDeCima.FirstOrDefault().importancia < itemAtual.importancia && capacidadeDaMochilaAtual >= itemAtual.peso)
                                    {
                                        tabelaMochilas[linha, coluna].Add(itemAtual);
                                    }
                                    else
                                    {
                                        tabelaMochilas[linha, coluna].Add(mochilaDeCima.FirstOrDefault());
                                    }
                                }
                                else
                                {
                                    var itensPassiveisDeTroca = new List<Item>();
                                    foreach (var itemDaMochilaDeCima in mochilaDeCima)
                                    {
                                        if (itemDaMochilaDeCima.peso >= itemAtual.peso && itemDaMochilaDeCima.importancia < itemAtual.importancia)
                                        {
                                            itensPassiveisDeTroca.Add(itemDaMochilaDeCima);
                                        }
                                    }

                                    if (itensPassiveisDeTroca.Count != 0)
                                    {
                                        var menorImportancia = itensPassiveisDeTroca.Min(item => item.importancia);
                                        var itemParaSerTrocado = itensPassiveisDeTroca.Where(item => item.importancia.Equals(menorImportancia)).FirstOrDefault();

                                        foreach (var item in mochilaDeCima)
                                        {
                                            while (item.nome != itemParaSerTrocado.nome)
                                            {
                                                tabelaMochilas[linha, coluna].Add(item);
                                            }
                                        }
                                        tabelaMochilas[linha, coluna].Add(itemAtual);
                                    }
                                    else
                                    {
                                        mochilaDeCima.ForEach(item => tabelaMochilas[linha, coluna].Add(item));
                                    }
                                }
                            }
                        }
                        else
                        {
                            tabelaMochilas[linha, coluna].Add(itemAtual);
                        }
                    }
                    else
                    {
                        if (itemAtual.peso <= capacidadeDaMochilaAtual)
                        {
                            tabelaMochilas[linha, coluna].Add(itemAtual);
                        }
                    }
                }
            }

            float capacidadeDaMochila = 6;
            var itensQueDevemSerLevados = new List<Item>();
            var contador = 0;
            while (capacidadeDaMochila >= pesos[contador])
            {
                foreach (var item in tabelaMochilas[itens.Count - 1, contador])
                {
                    itensQueDevemSerLevados.Add(item);
                    capacidadeDaMochila -= item.peso;
                }
                contador++;

                if (pesos.Count == contador)
                    break;
            }

            return itensQueDevemSerLevados;
        }
    }
}
