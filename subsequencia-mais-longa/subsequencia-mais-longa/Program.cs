using subsequencia_mais_longa.Services;
using System.Data.Common;

List<string> palavrasDisponiveis = new List<string>
{
    "carta", "mar", "parte", "arte", "barco",
    "contato", "monte", "ponto", "sonho", "tonel",
    "estrela", "festa", "mesa", "resto", "texto",
    "cinto", "instante", "tinta", "vinho"
};

Console.WriteLine("Insira a palavra que deseja encontrar:");
var palavraProcurada = Console.ReadLine();

var palavraProcuradaDividida = palavraProcurada.Split();

string palavraMaisProxima = palavrasDisponiveis[0];
int subsequenciaMaisLonga = 0;
string[] palavraAtualDividida;
var letrasProcuradasNaPalavra = new List<char>();
int quantidadeDeLetrasEmComum;
var linha = 1;
var coluna = 1;

foreach (var palavra in palavrasDisponiveis)
{
    var subsequenciaComum = new int[palavraProcurada.Length + 1, palavra.Length];

    for (int letraNaPalavraProcurada = 0; letraNaPalavraProcurada < palavraProcurada.Length; letraNaPalavraProcurada++)
    {
        for (int letraNaPalavraAtual = 0; letraNaPalavraAtual < palavra.Length; letraNaPalavraAtual++)
        {
            if (!letrasProcuradasNaPalavra.Contains(palavra[letraNaPalavraAtual]))
            {
                if (palavraProcurada[letraNaPalavraProcurada] == palavra[letraNaPalavraAtual])
                {
                    var subsequenciaAnterior = subsequenciaComum[linha - 1, coluna - 1];
                    subsequenciaComum[linha, coluna] = subsequenciaAnterior + 1;
                }
                else
                {
                    var trechoAnterior = Filtro.PegarTrechoDoArray(subsequenciaComum, letraNaPalavraProcurada - 1, letraNaPalavraAtual, letraNaPalavraProcurada, letraNaPalavraAtual - 1);
                    subsequenciaComum[linha, coluna] = Filtro.EncontrarMaiorValor(trechoAnterior);
                }
                letrasProcuradasNaPalavra.Add(palavra[letraNaPalavraAtual]);
            }
        }
    }
}

Console.WriteLine($"Você estava procurando por _{palavraMaisProxima}_?");