var listaDeRadios = new Dictionary<string,HashSet<string>>()
{
    {
        "Rádio 1", new HashSet<string>()
        {
            "SP", "RJ", "BH", "BA", "RO"
        }
    },
    {
        "Rádio 2", new HashSet<string>()
        {
            "SC", "RJ", "PA", "AM", "AC", "AL", "GO"
        }
    },
    {
        "Rádio 3", new HashSet<string>()
        {
            "MG", "MS", "PE", "PR", "SP", "SC"
        }
    },
    {
        "Rádio 4", new HashSet<string>()
        {
            "TO", "SP", "PA", "AM", "RO", "RR", "RN", "PI", "GO"
        }
    },
    {
        "Rádio 5", new HashSet<string>()
        {
            "PI", "PE", "AM"
        }
    },
    {
        "Rádio 6", new HashSet<string>()
        {
            "DF", "CE", "BA", "AC", "RR", "MS"
        }
    },
    {
        "Rádio 7", new HashSet<string>()
        {
            "AP", "SP", "MA", "RR", "TO", "SE"
        }
    },
    {
        "Rádio 8", new HashSet<string>()
        {
            "DF", "AL", "AP", "SE", "AM", "ES"
        }
    },
    {
        "Rádio 9", new HashSet<string>()
        {
            "PB", "MT", "SC", "RS", "PR", "PA"
        }
    }
};

var siglasEstadosBrasil = new HashSet<string>()
{
    "AC","AL","AM","AP","BA","CE","DF","ES","GO","MA",
    "MG","MS","MT","PA","PB","PE","PI","PR","RJ","RN",
    "RO","RR","RS","SC","SE","SP","TO"
};

var radiosEscolhidas = new List<string>();

while (siglasEstadosBrasil.Count > 0)
{
    string melhorRadio = null;
    var estadosCobertosPelaMelhorRadio = new HashSet<string>();

    foreach (var radio in listaDeRadios)
    {
        var estadosCobertos = radio.Value;
        estadosCobertos.IntersectWith(siglasEstadosBrasil);

        if (estadosCobertos.Count > estadosCobertosPelaMelhorRadio.Count)
        {
            melhorRadio = radio.Key;
            estadosCobertosPelaMelhorRadio = estadosCobertos;
        }
    }

    if (melhorRadio != null)
    {
        radiosEscolhidas.Add(melhorRadio);
        siglasEstadosBrasil.ExceptWith(estadosCobertosPelaMelhorRadio);
        listaDeRadios.Remove(melhorRadio);
    }
}

Console.Write("As rádios escolhidas foram: ");
foreach (var radio in radiosEscolhidas)
{
    if (radiosEscolhidas.Count - radiosEscolhidas.IndexOf(radio) > 1 && radiosEscolhidas.IndexOf(radio) != 0)
    {
        Console.Write(", ");
    }
    else if (radiosEscolhidas.IndexOf(radio) != 0)
    {
        Console.Write(" e ");
    }
    Console.Write($"{radio}");
}