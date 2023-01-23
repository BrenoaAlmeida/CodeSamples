namespace CodeSamples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var opcao = 1;
            Console.WriteLine("==========STARTING THE TEST PROGRAM==========");
            switch (opcao)

            {
                case 1:
                    new NanoSeconds().Run();
                    break;
                case 2:
                    new NullParameterCheck().Run();
                    break;
                case 3:
                    new StringInterpolation().Run();
                    break;
            }

            new NanoSeconds().Run();
            Console.WriteLine("==========ENDING THE TEST PROGRAM============");
        }
    }
}