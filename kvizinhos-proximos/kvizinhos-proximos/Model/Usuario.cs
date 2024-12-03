using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace kvizinhos_proximos.Model
{
    internal class Usuario
    {
        public required string Nome { get; set; }
        public required Dictionary<string, double> NotaPorGenero { get; set; }
        public string FilmeFavorito { get; set; }
    }
}
