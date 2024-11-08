using NPOI.Util.ArrayExtensions;
using programacao_dinamica.Model;
using programacao_dinamica.Utils;

Item[] itens = new Item[]
{
    new Item { nome = "Água", peso = 3, importancia = 10 },
    new Item { nome = "Livro", peso = 1, importancia = 3 },
    new Item { nome = "Comida", peso = 2, importancia = 9 },
    new Item { nome = "Casaco", peso = 2, importancia = 5 },
    new Item { nome = "Câmera", peso = 1, importancia = 6 }
};

var capacidadeDaMochila = 6;

var pesos = new List<float>();
Array.ForEach(itens, item => pesos.Add(item.peso));
pesos = Filtro.RetirarDuplicatas(pesos);

var tabelaMochilas = new float[itens.Length,pesos.Count];

for (int i = 0; i < pesos.Count; i++)
{

}