using programacao_dinamica.Model;

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

var tabelaMochilas = new List<Item>[itens.Count, pesos.Count];
/*for (int i = 0; i < itens.Count; i++)
{
    tabelaMochilas[i] = new List<Item>[numColunas];
    for (int j = 0; j < numColunas; j++)
    {
        tabelaMochilas[i][j] = new List<Item>();
    }
}*/

var itemVazio = new Item { nome = "", importancia = 0, peso = 0 };

float importanciaDoItemDeCima, importanciaDoItemAtual;

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
                if (capacidadeDaMochilaAtual - mochilaDeCima.Sum(item => item.peso) >= itemAtual.peso)
                {
                    mochilaDeCima.ForEach(item => tabelaMochilas[linha,coluna].Add(item));
                    tabelaMochilas[linha,coluna].Add(itemAtual);
                }
                else if (itemComPesoAproximadoDoItemAtual != null && capacidadeDaMochilaAtual - mochilaDeCima.Sum(item => item.peso) >= itemAtual.peso && itemComPesoAproximadoDoItemAtual.importancia < itemAtual.importancia)
                {
                    tabelaMochilas[linha,coluna].Add(itemAtual);
                }
                else
                {
                    mochilaDeCima.ForEach(item => tabelaMochilas[linha, coluna].Add(item));
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
                tabelaMochilas[linha,coluna].Add(itemAtual);
            }
        }
    }
}