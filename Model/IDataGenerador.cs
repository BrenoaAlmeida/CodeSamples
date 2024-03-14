namespace Model;

public interface IDataGenerador
{
    List<Pessoa> GerarDataIndefinitivamente();

    List<Pessoa> GenerateData(int rows);
}