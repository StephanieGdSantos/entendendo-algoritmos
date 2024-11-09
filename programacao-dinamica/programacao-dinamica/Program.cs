using NPOI.Util.ArrayExtensions;
using programacao_dinamica.Model;
using programacao_dinamica.Utils;
using System.Linq;

var itens = new List<Item>()
{
    new Item { nome = "Água", peso = 3, importancia = 10 },
    new Item { nome = "Livro", peso = 1, importancia = 3 },
    new Item { nome = "Comida", peso = 2, importancia = 9 },
    new Item { nome = "Casaco", peso = 2, importancia = 5 },
    new Item { nome = "Câmera", peso = 1, importancia = 6 }
};

var capacidadeDaMochila = 6;

var pesos = itens
    .Select(item => item.peso)
    .Distinct()
    .Order()
    .ToList();

Item[,] tabelaMochilas = new Item[itens.Count, pesos.Count];

var itemVazio = new Item { nome = "", importancia = 0, peso = 0 };

float importanciaDoItemDeCima, importanciaDoItemAtual;
for (int i = 0; i < itens.Count; i++)
{
    var itemAtual = itens[i];
    for (int j = 0; j < pesos.Count; j++)
    {
        var pesoDaMochilaAtual = pesos[j];

        var itemDeCima = i != 0 ? tabelaMochilas[i - 1, j] : itemVazio;

        if (i != 0 && itemAtual.peso <= pesoDaMochilaAtual && itemDeCima.nome != null)
        {

            if (pesoDaMochilaAtual - itemDeCima.peso >= itemAtual.peso)
            {
                tabelaMochilas[i, j] = new Item { nome = itemAtual.nome, importancia = itemAtual.importancia, peso = itemAtual.peso };
            }
            else if (itemAtual.importancia > itemDeCima.importancia)
            {
                tabelaMochilas[i, j] = new Item { nome = itemAtual.nome, importancia = itemAtual.importancia, peso = itemAtual.peso };
            }
            else
            {
                tabelaMochilas[i, j] = itemDeCima;
            }
        }
        else
        {
            if (itemAtual.peso <= pesoDaMochilaAtual)
                tabelaMochilas[i, j] = new Item { nome = itemAtual.nome, importancia = itemAtual.importancia, peso = itemAtual.peso };
            else
                tabelaMochilas[i, j] = itemVazio;
        }
    }
}