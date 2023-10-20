using Bogus;
using static CodeSamples.Util.Enumeracao;

namespace CodeSamples.Model;

public class BogusGenerator : IDataGenerador
{
    Faker<Pessoa> personFaker;

    public BogusGenerator()
    {
        Randomizer.Seed = new Random(123); // Deixa os resultado não Randomicos, facilitando os testes
        personFaker = new Faker<Pessoa>()
            .RuleFor(u => u.Id, f => f.Random.Int(1, 10000))
            .RuleFor(u => u.PrimeiroNome, f => f.Name.FirstName())
            .RuleFor(u => u.UltimoNome, f => f.Name.LastName())
            .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.PrimeiroNome, u.UltimoNome))
            .RuleFor(u => u.Telefone, f => f.Phone.PhoneNumber())
            .RuleFor(u => u.Endereco, f => f.Address.StreetAddress())
            .RuleFor(u => u.Cidade, f => f.Address.City())
            .RuleFor(u => u.Estado, f => f.Address.StateAbbr())
            .RuleFor(u => u.CEP, f => f.Address.ZipCode())
            .RuleFor(u => u.Credito, f => f.PickRandom<ECredito>());


    }
    public List<Pessoa> GenerateData(int rows)
    {
        return personFaker.Generate(rows);
    }

    public List<Pessoa> GerarDataIndefinitivamente()
    {
        return personFaker.GenerateForever().Take(1000).ToList();
    }
}
