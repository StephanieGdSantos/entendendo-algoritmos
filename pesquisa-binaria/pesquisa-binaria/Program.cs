var nomes = new List<string>()
{
    "Alice", "Bruno", "Carla", "Daniel", "Eduarda", "Fábio", "Gabriela", "Hugo",
    "Isabela", "João", "Karen", "Lucas", "Mariana", "Nathan", "Olivia", "Pedro",
    "Quênia", "Rafael", "Sara", "Thiago", "Ursula", "Victor", "Wesley", "Xênia",
    "Yasmin", "Zé", "Adriana", "Benjamin", "Camila", "Diego", "Emanuel",
    "Fernanda", "Giovanni", "Helena", "Igor", "Juliana", "Kaio", "Leonardo",
    "Marcela", "Nina", "Otávio", "Paula", "Quintino", "Rebeca", "Samuel",
    "Tatiane", "Ulisses", "Valentina", "William", "Xavier", "Yago", "Zilda",
    "Ana", "Beto", "Cássia", "Davi", "Evelyn", "Felipe", "Guilherme", "Heloísa",
    "Iara", "José", "Karla", "Larissa", "Mauro", "Nicole", "Orlando", "Priscila",
    "Quirino", "Renato", "Sophia", "Tatiana", "Uriel", "Vanessa", "Washington",
    "Ximena", "Yuri", "Zora", "Alex", "Bianca", "Cauã", "Débora", "Elias",
    "Fernão", "Gabriel", "Henrique", "Ivana", "Julio", "Karenina", "Leandro",
    "Milena", "Natan", "Olga", "Paulo", "Quirina", "Roberta", "Sergio", "Túlio",
    "Uliana", "Vicente", "Wanda", "Xisto", "Yumi", "Zoraide", "Artur", "Bárbara",
    "César", "Dalila", "Elisa", "Francisco", "Gustavo", "Heitor", "Ivone",
    "Júlia", "Kevin", "Luana", "Matheus", "Natália", "Osvaldo", "Patrícia",
    "Quitéria", "Rodrigo", "Simone", "Tânia"
};

nomes.Sort();

Console.WriteLine("Qual nome deseja encontrar?");
var nomeProcurado = Console.ReadLine();

var nomeEncontrado = "";
int tamanhoDoArray = nomes.Count;
var tentativasAteEncontrar = 0;
while (nomeEncontrado != nomeProcurado || nomes.Count == 0)
{
    tentativasAteEncontrar++;
    tamanhoDoArray = tamanhoDoArray % 2 == 0 ? tamanhoDoArray / 2 : (int)tamanhoDoArray / 2 + 1;
    nomeEncontrado = nomes[tamanhoDoArray];

    if (nomeProcurado[0] > nomeEncontrado[0])
    {
        nomes = nomes.GetRange(tamanhoDoArray, tamanhoDoArray);
    }
    else if (nomeProcurado[0] < nomeEncontrado[0])
    {
        nomes = nomes.GetRange(0, tamanhoDoArray);
    }
}

if (nomeEncontrado != nomeProcurado)
{
    Console.WriteLine($"O nome {nomeProcurado} não está na lista.");
}
else
{
    Console.WriteLine($"Foram necessárias {tentativasAteEncontrar} tentativas até encontrar o nome {nomeProcurado}");
}