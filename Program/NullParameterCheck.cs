
public class NullParameterCheck
{
    public void Run(string message = null)
    {

        //throw null reference exception on C# 9 and bellow
        //if(message == null)
        //{
        //  throw new ArgumentNullException(nameof(message));
        //}

        //throw null reference exception on C# 10

        //string? info = null;
        ArgumentNullException.ThrowIfNull(message);
        Console.WriteLine($"Hello {message}");
    }
}