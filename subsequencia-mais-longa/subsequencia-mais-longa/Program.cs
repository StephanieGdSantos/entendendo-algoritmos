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

int linha = 1;
int coluna = 1;
var letrasProcuradas = new List<char>();
var palavraMaisProxima = palavrasDisponiveis.FirstOrDefault();
var valorPalavraMaisProxima = 0;

foreach (var palavra in palavrasDisponiveis)
{
    var subsequenciaComum = new int[palavraProcurada.Length + 1, palavra.Length + 1];
    letrasProcuradas.Clear();

    for (int i = 1; i < palavraProcurada.Length + 1; i++)
    {
        for (int j = 1; j < palavra.Length + 1; j++)
        {
            if (!letrasProcuradas.Contains(palavra[j - 1]))
            {
                var trechoAnterior = new int[2, palavra.Length + 1];
                if (palavra[j - 1] == palavraProcurada[i - 1])
                {
                    subsequenciaComum[i, j] = subsequenciaComum[i - 1, j - 1] + 1;
                    letrasProcuradas.Add(palavra[j - 1]);
                }
                else
                {
                    var linhaTrecho = 0;
                    var colunaTrecho = 0;

                    for (int k = i - 1; k < i + 1; k++)
                    {

                        for (int l = 1; l < palavra.Length + 1; l++)
                        {
                            trechoAnterior[linhaTrecho, colunaTrecho] = subsequenciaComum[k, l];
                            colunaTrecho++;
                        }
                        linhaTrecho++;
                        colunaTrecho = 0;
                    }
                    subsequenciaComum[i, j] = Filtro.EncontrarMaiorValor(trechoAnterior);
                }
            }
            else
            {
                var trechoAnterior = new int [2, palavra.Length + 1];
                var linhaTrecho = 0;
                var colunaTrecho = 0;

                for (int k = i - 1; k < i + 1; k++)
                {

                    for (int l = 1; l < palavra.Length + 1; l++)
                    {
                        trechoAnterior[linhaTrecho, colunaTrecho] = subsequenciaComum[k, l];
                        colunaTrecho++;
                    }
                    linhaTrecho++;
                    colunaTrecho = 0;
                }
                subsequenciaComum[i, j] = Filtro.EncontrarMaiorValor(trechoAnterior);
            }
        }
    }

    var maiorValor = Filtro.EncontrarMaiorValor(subsequenciaComum);
    if (maiorValor > valorPalavraMaisProxima)
    {
        valorPalavraMaisProxima = maiorValor;
        palavraMaisProxima = palavra;
    }
}

Console.WriteLine($"Você estava procurando por _{palavraMaisProxima}_?");