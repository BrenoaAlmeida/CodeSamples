using CodeSamples.Model;
using CodeSamples.Util;
using System.Runtime.CompilerServices;
using Visual_Code;

namespace CodeSamples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var util = new Util.Util();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var diretorioDoProjeto = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            string pastaDeArquivos = @"\tar\fonte\";
            string pastaDeArquivosComprimidos = @"\tar\comprimido\";
            string pastaDeArquivosDescomprimidos = @"\tar\extraido\";
            string nomeArquivoTar = "test.tar";

            var opcao = MostrarEObterOpcoes();
            switch (opcao)
            {
                case "1":
                    new NanoSeconds().Run();
                    break;
                case "2":
                    new NullParameterCheck().Run();
                    break;
                case "3":
                    new StringInterpolation().Run();
                    break;
                case "4":
                    util.CriarArquivoTar(diretorioDoProjeto + pastaDeArquivos, diretorioDoProjeto + pastaDeArquivosComprimidos + nomeArquivoTar);
                    break;
                case "5":
                    util.ExtrairArquivoTar(diretorioDoProjeto + pastaDeArquivosComprimidos + nomeArquivoTar, diretorioDoProjeto + pastaDeArquivosDescomprimidos);
                    break;
                case "6":
                    new RawStringLiteral().Run();
                    break;
                case "7":
                    new GenerateRandomData<BogusGenerator>().Run();
                    break;
                case "8":
                    new DictionaryExample().Run();
                    break;
                default:
                    Console.WriteLine("Opcao digitada é invalida!!");
                    break;
            }
            Console.WriteLine("==========ENDING THE TEST PROGRAM============");
        }

        public static string MostrarEObterOpcoes()
        {
            Console.WriteLine("==========STARTING THE TEST PROGRAM==========");
            Console.WriteLine("1 - NanoSeconds");
            Console.WriteLine("2 - Null Parameter Check");
            Console.WriteLine("3 - String Interpolation");
            Console.WriteLine("4 - Criar Arquivo Tar");
            Console.WriteLine("5 - Extrair Arquivo Tar");
            Console.WriteLine("6 - Raw String Literal");
            Console.WriteLine("7 - Gerador de data Aleatoria com BOGUS");
            Console.WriteLine("8 - Gerador de data Aleatoria com BOGUS");

            var opcao = Console.ReadLine();
            opcao = opcao != null ? opcao.Trim() : "";

            return opcao;
        }
    }
}
