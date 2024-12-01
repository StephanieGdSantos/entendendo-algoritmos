using ordenacao_rapida.Services;

var listaDeNumeros = new List<int>()
{
    0, 9, 10, 5, 7, 8, 3, 4
};

var listaOrdenadaDeFormaCrescente = Ordenador.OrdenarDeFormaCrescente(listaDeNumeros);
var listaOrdenadaDeFormaDecrescente = Ordenador.OrdenarDeFormaDecrescente(listaDeNumeros);

Console.Write($"A lista em ordem crescente fica: ");
foreach (var item in listaOrdenadaDeFormaCrescente)
{
    Console.Write($"{item} ");
}
Console.WriteLine("\n-----------------------------------------------------------");

Console.Write($"A lista em ordem decrescente fica: ");
foreach (var item in listaOrdenadaDeFormaDecrescente)
{
    Console.Write($"{item} ");
}