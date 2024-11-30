using subsequencia_mais_longa.Services;
using System.Data.Common;

var palavrasDisponiveis = new string[]
{
    "carta", "mar", "parte", "arte", "barco",
    "contato", "monte", "ponto", "sonho", "tonel",
    "estrela", "festa", "mesa", "resto", "texto",
    "cinto", "instante", "tinta", "vinho"
};

Console.Write("Insira a palavra que deseja encontrar: ");
var palavraProcurada = Console.ReadLine();

var palavraMaisProxima = Buscador.BuscarPorMaiorStringComum(palavrasDisponiveis, palavraProcurada); ;
var palavraProporcionalmenteMaisProxima = Buscador.BuscarPorMaiorProporcaoSemelhante(palavrasDisponiveis, palavraProcurada);

if (palavraMaisProxima != palavraProporcionalmenteMaisProxima)
    Console.WriteLine($"Você estava procurando por _{palavraMaisProxima}_ ou _{palavraProporcionalmenteMaisProxima}_?");
else
    Console.WriteLine($"Você estava procurando por _{palavraMaisProxima}_?");