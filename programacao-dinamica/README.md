# Programação Dinâmica - o problema da mochila
Resolução do exercício 9.2 do livro.

A programação dinâmica se refere a uma programação baseada em reduzir um grande problema em problemas menores que podem ser resolvidos de forma separada. Neste exercício, temos uma mochila com capacidade de 6kg e diversos itens que podem ser roubados. A ideia aqui é escolher os melhores itens a fim de levar os mais importantes de acordo com a nossa capacidade. 
O execício propõe uma lista de itens, que é representada no código da seguinte forma:

```csharp
var itens = new List<Item>()
{
    new Item { nome = "Água", peso = 3, importancia = 10 },
    new Item { nome = "Livro", peso = 1, importancia = 3 },
    new Item { nome = "Comida", peso = 2, importancia = 9 },
    new Item { nome = "Casaco", peso = 2, importancia = 5 },
    new Item { nome = "Câmera", peso = 1, importancia = 6 }
};
```

Na resolução, os melhores itens escolhidos devem ser a câmera, comida e água.
