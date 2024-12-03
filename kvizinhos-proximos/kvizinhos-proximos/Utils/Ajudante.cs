using kvizinhos_proximos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kvizinhos_proximos.Utils
{
    internal class Ajudante
    {
        internal static string RecomendarFilme(Usuario usuario)
        {
            var usuariosCadastrados = ObterUsuariosCadastrados();

            var listaDeGenerosDeFilmes = new List<string>()
            {
                "romance", "terror", "drama", "comédia", "ação", "suspense"
            };

            var usuariosProximos = new Dictionary<double, string>();
            foreach (var usuarioCadastrado in usuariosCadastrados)
            {
                var proximidadeDosGeneros = new List<double>();
                for (int i = 0; i < listaDeGenerosDeFilmes.Count; i++)
                {
                    proximidadeDosGeneros.Add(Math.Pow(usuario.NotaPorGenero.Values.ElementAt(i) - usuarioCadastrado.NotaPorGenero.Values.ElementAt(i), 2));
                }

                var proximidadeFinal = Math.Sqrt(proximidadeDosGeneros.Sum(notaDoGenero => notaDoGenero));

                usuariosProximos.Add(proximidadeFinal, usuarioCadastrado.FilmeFavorito);
            }

            var recomendacao = usuariosProximos.OrderBy(genero => genero.Key).ToDictionary().FirstOrDefault().Value;

            return recomendacao;
        }

        internal static Usuario CadastrarInformacoesDoUsuario(string nome)
        {
            var usuario = new Usuario()
            {
                Nome = nome,
                NotaPorGenero = new Dictionary<string, double>()
            };

            var listaDeGenerosDeFilmes = new List<string>()
            {
                "romance", "terror", "drama", "comédia", "ação", "suspense"
            };

            foreach (var genero in listaDeGenerosDeFilmes)
            {
                Console.Write($"\nDe 0 a 10, insira o quanto você gosta de filmes de {genero}: ");
                var nota = Console.ReadLine();
                var notaEhValida = double.TryParse(nota, out double validadeDaNota);
                if (notaEhValida && double.Parse(nota) >= 0 && double.Parse(nota) <= 10)
                {
                    usuario.NotaPorGenero.Add(genero, double.Parse(nota));
                }
                else
                {
                    while (notaEhValida == false || double.Parse(nota) < 0 || double.Parse(nota) > 10)
                    {
                        Console.WriteLine("[ entrada inválida ]");
                        Console.Write($"\nDe 0 a 10, insira o quanto você gosta de filmes de {genero}: ");
                        nota = Console.ReadLine();
                        notaEhValida = double.TryParse(nota, out double validade);
                    }
                    usuario.NotaPorGenero.Add(genero, double.Parse(nota));
                }
            }

            return usuario;
        }

        internal static List<Usuario> ObterUsuariosCadastrados()
        {
            List<Usuario> usuarios = new List<Usuario>();

            usuarios.Add(new Usuario
            {
                Nome = "Andreia",
                NotaPorGenero = new Dictionary<string, double>
                {
                    { "romance", 5 },
                    { "terror",  10},
                    { "drama", 10 },
                    { "comédia", 8.5 },
                    { "ação", 7 },
                    { "suspense", 8 }
                },
                FilmeFavorito = "Hereditário"
            });

            usuarios.Add(new Usuario
            {
                Nome = "Luciana",
                NotaPorGenero = new Dictionary<string, double>
            {
                { "romance", 8 },
                { "terror", 7 },
                { "drama", 8 },
                { "comédia", 5.5 },
                { "ação", 5 },
                { "suspense", 4 }
            },
                FilmeFavorito = "Como eu era antes de você"
            });

            usuarios.Add(new Usuario
            {
                Nome = "Paulo",
                NotaPorGenero = new Dictionary<string, double>
            {
                { "romance", 4 },
                { "terror", 7 },
                { "drama", 6 },
                { "comédia", 7 },
                { "ação", 8 },
                { "suspense", 4 }
            },
                FilmeFavorito = "Velozes e furiosos"
            });

            usuarios.Add(new Usuario
            {
                Nome = "Cesar",
                NotaPorGenero = new Dictionary<string, double>
            {
                { "romance", 2 },
                { "terror", 1 },
                { "drama", 0 },
                { "comédia", 5 },
                { "ação", 6 },
                { "suspense", 4 }
            },
                FilmeFavorito = "Hora do Rush"
            });

            usuarios.Add(new Usuario
            {
                Nome = "Juliana",
                NotaPorGenero = new Dictionary<string, double>
            {
                { "romance", 4 },
                { "terror", 10 },
                { "drama", 5 },
                { "comédia", 10 },
                { "ação", 2 },
                { "suspense", 4 }
            },
                FilmeFavorito = "Todo mundo em pânico"
            });

            usuarios.Add(new Usuario
            {
                Nome = "Otavio",
                NotaPorGenero = new Dictionary<string, double>
            {
                { "romance", 9 },
                { "terror", 4 },
                { "drama", 7 },
                { "comédia", 7 },
                { "ação", 5 },
                { "suspense", 4 }
            },
                FilmeFavorito = "Como se fosse a primeira vez"
            });

            return usuarios;
        }
    }
}
