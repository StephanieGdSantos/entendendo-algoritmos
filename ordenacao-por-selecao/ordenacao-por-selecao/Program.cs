using ordenacao_por_selecao.Services;

var musicasMaisOuvidas = new Dictionary<string, int>()
{
    { "Blinding Lights - The Weeknd", 25 },
    { "Someone Like You - Adele", 18 },
    { "Shape of You - Ed Sheeran", 32 },
    { "Levitating - Dua Lipa", 22 },
    { "Bohemian Rhapsody - Queen", 12 },
    { "Smells Like Teen Spirit - Nirvana", 15 },
    { "Rolling in the Deep - Adele", 20 },
    { "Perfect - Ed Sheeran", 28 },
    { "Take On Me - A-ha", 14 },
    { "Stay - The Kid LAROI & Justin Bieber", 30 },
    { "Yesterday - The Beatles", 17 },
    { "Bad Guy - Billie Eilish", 19 },
    { "Hotel California - Eagles", 10 },
    { "Lose Yourself - Eminem", 21 },
    { "Don't Start Now - Dua Lipa", 16 }
};

var musicasEmOrdemDeOuvintes = Ordenador.OrdernarDeFormaDecrescente(musicasMaisOuvidas);

Console.WriteLine("As músicas mais ouvidas em ordem de ouvintes são:");

foreach (var musica in musicasEmOrdemDeOuvintes.Keys)
{
    Console.WriteLine($"{musica}: {musicasEmOrdemDeOuvintes[musica]}");
}