using CodeSamples.Model;
using Microsoft.Extensions.DependencyInjection;

namespace CodeSamples.Factory;

public static class GenerateClassWithDataFactoryExtension
{
    public static void AddGenericClassWithDataFactory(this IServiceCollection services)
    {
        services.AddTransient<IUsuario, Usuario>();
        services.AddSingleton<Func<IUsuario>>(x => () => x.GetService<IUsuario>()!);
        services.AddSingleton<IUserDataFactory, UserDataFactory>();
    }
}

public interface IUserDataFactory
{
    IUsuario Create(string name);
}

public class UserDataFactory : IUserDataFactory
{
    private readonly Func<IUsuario> _factory;

    public UserDataFactory(Func<IUsuario> factory)
    {
        _factory = factory;
    }

    public IUsuario Create(string name)
    {
        var output = _factory();
        output.Nome = name;
        return output;
    }
}