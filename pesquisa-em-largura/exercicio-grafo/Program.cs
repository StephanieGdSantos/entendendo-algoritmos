using System.Collections.Generic;

var amigos = new Dictionary<string, string[]>()
{
    {"luana",["ana", "lucas", "paulo"]},
    {"julia", ["andré", "pedro", "paulo"]},
    {"lucas", ["andré", "marianana"]},
    {"ana", ["paula"] },
    {"lucia", []}
};

var procurado = new List<string>();

string ProcurarVendedorDeBanana(Dictionary<string, string[]> amigos, List<string> procurado)
{
    foreach (string pessoa in amigos.Keys)
    {
        if (!procurado.Contains(pessoa) && pessoa.Contains("nana"))
        {
            return $"{amigos} vende banana";
        }
        else
        {
            if (!procurado.Contains(pessoa)) procurado.Add(pessoa);

            foreach (string amigoDeAmigo in amigos[pessoa])
            {
                if (!procurado.Contains(amigoDeAmigo) && amigoDeAmigo.Contains("nana"))
                {
                    return $"{amigoDeAmigo}, amigo de {pessoa} vende banana";
                }
                else if (!procurado.Contains(amigoDeAmigo))
                {
                    procurado.Add(amigoDeAmigo);
                }
            }
        }
    }
    return "Ninguém vende banana";
}

Console.WriteLine(ProcurarVendedorDeBanana(amigos, procurado));