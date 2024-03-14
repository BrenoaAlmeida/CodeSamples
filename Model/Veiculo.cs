namespace Model;

public interface IVeiculo
{
    string TipoVeiculo { get; set; }

    string Iniciar();
}

public class Carro : IVeiculo
{
    public string TipoVeiculo { get; set; } = "Car";
    public string Iniciar()
    {
        return "The car has been started.";
    }
}

public class Truck : IVeiculo
{
    public string TipoVeiculo { get; set; } = "Truck";
    public string Iniciar()
    {
        return "The truck has been started.";
    }
}

public class Van : IVeiculo
{
    public string TipoVeiculo { get; set; } = "Van";
    public string Iniciar()
    {
        return "The van has been started.";
    }
}