namespace Visual_Code;


public class DictionaryExample
{
    public void Run()
    {

        WriteLine("Criação e Uso de um Dictionary");
        //creating a dictionary using collection-initializer syntax
        var cidades = new Dictionary<string, string>()
            {
                {"UK","London, Manchester, Birmingham"},
                {"USA","Chicago, New York, Washington"},
                {"India","Mumbai, New Delhi, Pune"}
            };

        foreach (var keyValuePair in cidades)
            WriteLine($"Key: {keyValuePair.Key}, Value: {keyValuePair.Value}");

        AcessarElementos(cidades);
        EditarChave(cidades, "UK");
        RemoverChaves(cidades);
    }

    private void EditarChave(Dictionary<string, string> cidades, string cidadeAEditar)
    {
        WriteLine("Atualizando valor de um elemento no Dictionary");
        WriteLine("Antes: " + cidades[cidadeAEditar]);
        cidades["UK"] = "Liverpool, Bristol"; // update value of UK key
        WriteLine("Depois: " + cidades[cidadeAEditar]);
    }

    private void RemoverChaves(Dictionary<string, string> cidades)
    {
        WriteLine("Removendo Chave do Dictionary");
        cidades.Remove("UK"); // removes UK Key                                   
        cidades.Clear(); //removes all elements
    }

    public void AcessarElementos(Dictionary<string, string> cidades)
    {
        WriteLine("Acessando elementos de um Dictionary");
        WriteLine(cidades["UK"]); //prints value of UK key

        //use ContainsKey() to check for an unknown key
        if (cidades.ContainsKey("France"))
            WriteLine(cidades["France"]);

        //use TryGetValue() to get a value of unknown key
        string? result;

        if (cidades.TryGetValue("France", out result))
            WriteLine(result);

        //use ElementAt() to retrieve key-value pair using index
        for (int i = 0; i < cidades.Count; i++)
            WriteLine($"Key: {cidades.ElementAt(i).Key}, Value: {cidades.ElementAt(i).Value}");
    }
}