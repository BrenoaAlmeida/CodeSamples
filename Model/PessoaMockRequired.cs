using System.Diagnostics.CodeAnalysis;

namespace CodeSamples.Model
{

    //Funcionalidade do .NET 7 para frente
    public class PessoaMockRequired
    {
        public required string Nome { get; set; }
        public required string SobreNome { get; set; }


        //Para a utilizacao de um construtor que preenche uma propriedade required, é necessario a DataAnnotation SetsRequiredMembers
        [SetsRequiredMembers]
        public PessoaMockRequired(string nome, string sobrenome)
        {
            Nome = nome;
            SobreNome = sobrenome;
        }

        public PessoaMockRequired() { }

        PessoaMockRequired mockExample = new PessoaMockRequired("Jonh", "Doe");        
        PessoaMockRequired mockExample2 = new("Jonh", "Doe");


        //Inicialização de objeto sem preenchimento de propriedades no construtor
        PessoaMockRequired mockExample3 = new PessoaMockRequired() { Nome = "John", SobreNome = "Doe" };
        PessoaMockRequired mockExample4 = new() { Nome = "Jonh", SobreNome = "Doe" };
    }
}