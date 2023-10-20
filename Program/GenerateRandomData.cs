using System.Text.Json;

namespace CodeSamples.Model;
public class GenerateRandomData<IDataGenerator>
{
    public void Run()
    {
        var persons = GenerateRandomDataWithBogus(new BogusGenerator());

        foreach (var person in persons)
        {
            var jsonArray = JsonSerializer.Serialize<Pessoa>(person);
            Console.WriteLine(jsonArray);
        }
    }

    public List<Pessoa> GenerateRandomDataWithBogus(IDataGenerador generador)
    {
        int quantityOfRows = 20;
        return generador.GenerateData(quantityOfRows);
    }
}