using programacao_dinamica.Model;
using programacao_dinamica.Services;
using System.ComponentModel.DataAnnotations;
using System.Linq;

var itens = new List<Item>()
{
    new Item { nome = "Água", peso = 3, importancia = 10 },
    new Item { nome = "Livro", peso = 1, importancia = 3 },
    new Item { nome = "Comida", peso = 2, importancia = 9 },
    new Item { nome = "Casaco", peso = 2, importancia = 5 },
    new Item { nome = "Câmera", peso = 1, importancia = 6 }
};

var seletor = new Seletor();
var itensQueDevemSerLevados = seletor.SelecionarMelhoresItens(itens);

Console.WriteLine("Seria melhor você levar:");
foreach (var item in itensQueDevemSerLevados)
{
    Console.WriteLine($"Item: {item.nome} |   Peso:{item.peso}kg |   Importância:{item.importancia}");
}