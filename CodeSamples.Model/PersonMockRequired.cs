using System.Diagnostics.CodeAnalysis;

namespace CodeSamples.Model
{

    //Funcionalidade do .NET 7 para frente
    public class PersonMockRequired
    {
        public required string Nome { get; set; }
        public required string SobreNome { get; set; }


        //Para a utilizacao de um construtor que preenche uma propriedade required, é necessario a DataAnnotation SetsRequiredMembers
        [SetsRequiredMembers]
        public PersonMockRequired(string nome, string sobrenome)
        {
            Nome = nome;
            SobreNome = sobrenome;
        }

        public PersonMockRequired() { }

        PersonMockRequired mockExample = new PersonMockRequired("x", "x");        
        PersonMockRequired mockExample2 = new("x", "x");


        //Inicialização de objeto sem preenchimento de propriedades no construtor
        PersonMockRequired mockExample3 = new PersonMockRequired() { Nome = "z", SobreNome = "z" };
        PersonMockRequired mockExample4 = new() { Nome = "X", SobreNome = "X" };
    }
}