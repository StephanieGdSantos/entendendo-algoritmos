var listaDeNumeros = new List<int>()
{
    0, 9, 10, 5, 7, 8, 3, 4
};

var listaOrdenada = Ordenar(listaDeNumeros);

static List<int> Ordenar(List<int> listaDeNumeros)
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
    listaOrdenada.AddRange(Ordenar(numerosMenoresDoQueOPivo));
    listaOrdenada.Add(pivo);
    listaOrdenada.AddRange(Ordenar(numerosMaioresDoQueOPivo));

    return listaOrdenada;
}

Console.Write($"A lista em ordem fica: ");
foreach (var item in listaOrdenada)
{
    Console.Write($"{item} ");
}