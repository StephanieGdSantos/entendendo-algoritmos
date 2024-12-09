using System.Linq;
using System.Runtime.ConstrainedExecution;

var lugares = new Dictionary<string, Dictionary<string, int>>
    {
        {"parque", new Dictionary<string, int>
            {
                {"casa", 4},
                {"padaria", 1},
                {"mercado", 3}
            }
        },
        {"casa", new Dictionary<string, int>
            {
                {"ponto de ônibus", 3}
            }
        },
        {"padaria", new Dictionary<string, int>
            {
                {"ponto de ônibus", 2},
                {"mercado", 2}
            }
        },
        {"ponto de ônibus", new Dictionary<string, int>
            {
                {"avenida", 4},
                {"shopping", 1 }
            }
        },
        {"mercado", new Dictionary<string, int>
            {
                {"avenida", 5}
            }
        },
        {"avenida", new Dictionary<string, int>
            {
                {"shopping", 2}
            }
        },
        {
            "shopping", new Dictionary<string, int>()
        }
    };

Console.Write("Escolha o lugar de partida (parque, casa, padaria, ponto de ônibus, mercado, avenida): ");
var partida = Console.ReadLine();

Console.Write("Escolha onde quer chegar (parque, casa, padaria, ponto de ônibus, mercado, avenida, shopping): ");
var chegada = Console.ReadLine();

Dictionary<string, int> BuscarCaminhoMaisRapido(Dictionary<string, Dictionary<string, int>> lugares, string partida, string chegada)
{
    Dictionary<string, int>? vizinhosDosPrimeirosVizinhos;
    var primeirosVizinhos = lugares[partida];
    var caminhos = new List<Dictionary<string, int>>();
    string? lugarAtual;
    foreach (var primeiroVizinho in primeirosVizinhos.Keys)
    {
        var caminhoMaisBarato = new Dictionary<string, int>();
        lugarAtual = primeiroVizinho;
        vizinhosDosPrimeirosVizinhos = lugares[primeiroVizinho];
        caminhoMaisBarato.Add(primeiroVizinho, lugares[partida][primeiroVizinho]);

        while (lugarAtual != chegada)
        {
            var lugarMaisBarato = vizinhosDosPrimeirosVizinhos
                .OrderBy(vizinho => vizinho.Value)
                .FirstOrDefault();

            caminhoMaisBarato.Add(lugarMaisBarato.Key, lugarMaisBarato.Value);
            lugarAtual = lugarMaisBarato.Key;
            vizinhosDosPrimeirosVizinhos = lugares[lugarAtual];
            if (vizinhosDosPrimeirosVizinhos.Count == 0 && lugarAtual != chegada)
            {
                lugarAtual = chegada;
                caminhoMaisBarato.Clear();
            }
        }
        if (caminhoMaisBarato.Count != 0) caminhos.Add(caminhoMaisBarato);
    }

    var menorCaminho = caminhos
        .OrderBy(rota => rota.Values
        .Sum())
        .FirstOrDefault();

    return menorCaminho;
}

var caminhoMaisRapido = BuscarCaminhoMaisRapido(lugares, partida, chegada);
if (caminhoMaisRapido != null)
{
    Console.WriteLine("-------------------------------------------------");
    Console.WriteLine($"[ CAMINHO MAIS RÁPIDO: SAINDO DE {partida.ToUpper()} PARA {chegada.ToUpper()} ]");
    foreach (var rota in caminhoMaisRapido)
    {
        Console.WriteLine($"{rota.Key}: {rota.Value}");
    }
    Console.WriteLine("-------------------------------------------------");
}
else
{
    Console.WriteLine("-------------------------------------------------");
    Console.WriteLine($"Não foi possível encontrar um caminho para chegar a {chegada.ToUpper()}");
    Console.WriteLine("-------------------------------------------------");
}