using kvizinhos_proximos.Model;
using kvizinhos_proximos.Utils;
using System.Xml;

Console.Write("Seja bem vindo(a)! Qual é o seu nome? ");
var nomeUsuario = Console.ReadLine();

Console.Clear();
Console.WriteLine($"{nomeUsuario}, vamos decidir o que assistir hoje? Eu te ajudo!");

var usuario = Ajudante.CadastrarInformacoesDoUsuario(nomeUsuario);
var recomendacao = Ajudante.RecomendarFilme(usuario);

Console.WriteLine($"\n{usuario.Nome}, talvez você goste de '{recomendacao}'! Vamos assistir?");