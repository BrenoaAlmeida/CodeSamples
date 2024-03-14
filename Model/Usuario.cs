namespace Model;

public interface IUsuario
{
    string? Nome { get; set; }
}

public class Usuario : IUsuario
{
    public string? Nome { get; set; }
}
