using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Security.Cryptography;
using subsequencia_mais_longa.Services;

namespace subsequencia_mais_longaTests
{
    [TestClass]
    public class FiltroTests
    {
        [TestMethod]
        public void DevePegarUmTrechoEscolhidoDeUmArrayBidimensional()
        {
            var array = new int[2,5];
            Random random = new Random();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    array[i, j] = random.Next();
                }
            }

            var LinhaInicioDoTrecho = 0;
            var LinhaFinalDoTrecho = 1;
            var colunaInicioDoTrecho = 0;
            var colunaFinalDoTrecho = 4;

            var trecho = Filtro.PegarTrechoDoArray()
        }
    }
}
