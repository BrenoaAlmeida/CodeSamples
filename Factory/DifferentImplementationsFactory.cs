using CodeSamples.Model;
using Microsoft.Extensions.DependencyInjection;

namespace Factory;

public static class DifferentImplementationsFactoryExtension
{
    public static void AddVehicleFactory(this IServiceCollection services)
    {
        services.AddTransient<IVeiculo, Carro>();
        services.AddTransient<IVeiculo, Truck>();
        services.AddTransient<IVeiculo, Van>();
        services.AddSingleton<Func<IEnumerable<IVeiculo>>>
            (x => () => x.GetService<IEnumerable<IVeiculo>>()!);
        services.AddSingleton<IVehicleFactory, VehicleFactory>();
    }
}

public interface IVehicleFactory
{
    IVeiculo Create(string name);
}

public class VehicleFactory : IVehicleFactory
{
    private readonly Func<IEnumerable<IVeiculo>> _factory;

    public VehicleFactory(Func<IEnumerable<IVeiculo>> factory)
    {
        _factory = factory;
    }

    public IVeiculo Create(string name)
    {
        var set = _factory();
        IVeiculo output = set.Where(x => x.TipoVeiculo == name).First();
        return output;
    }
}