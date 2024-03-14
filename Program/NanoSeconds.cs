namespace CodeSamples
{
    public class NanoSeconds
    {
        /*
            No .NET 7 é possivel usar o NanoSeconds e MicroSeconds como propriedades, quando antes era necessario fazer um calculo utilizando a propriedade Ticks
            É Possivel utilizar esse recurso nos tipos: TimeStamp, DateTime, DateTimeOffset e TimeOnly.
        */
        public void Run()
        {
            DateTime horaAtual = DateTime.Now;

            Console.WriteLine($"Ticks: {horaAtual.Ticks}");
            Console.WriteLine($"Microsecond: {horaAtual.Microsecond}");
            Console.WriteLine($"Nanosecond: {horaAtual.Nanosecond}");
        }
    }
}
