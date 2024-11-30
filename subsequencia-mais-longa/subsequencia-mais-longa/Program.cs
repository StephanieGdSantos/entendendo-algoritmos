using subsequencia_mais_longa.Services;
using System.Data.Common;

var palavrasDisponiveis = new string[]
{
    "carta", "mar", "parte", "arte", "barco",
    "contato", "monte", "ponto", "sonho", "tonel",
    "estrela", "festa", "mesa", "resto", "texto",
    "cinto", "instante", "tinta", "vinho"
};

Console.WriteLine("Como deseja fazer a busca? \n[ 1 ] Maior substring comum \n[ 2 ] Proporção mais semelhante");
var tipoDeBusca = int.Parse(Console.ReadLine());

Console.WriteLine("Insira a palavra que deseja encontrar:");
var palavraProcurada = Console.ReadLine();

string palavraMaisProxima = "";
if (tipoDeBusca == 1)
{
    palavraMaisProxima = Buscador.BuscarPorMaiorStringComum(palavrasDisponiveis, palavraProcurada);
}
else if (tipoDeBusca == 2)
{
    palavraMaisProxima = Buscador.BuscarPorMaiorProporcaoSemelhante(palavrasDisponiveis, palavraProcurada);
}
else
{
    while (tipoDeBusca != 0 && tipoDeBusca != 1)
    {
        Console.Clear();
        Console.WriteLine("[ ESCOLHA NÃO RECONHECIDA ]");
        Console.WriteLine("Como deseja fazer a busca? \n[ 1 ] Maior substring comum \n[ 2 ] Proporção mais semelhante");
        tipoDeBusca = int.Parse(Console.ReadLine());
    }
}

Console.WriteLine($"Você estava procurando por _{palavraMaisProxima}_?");