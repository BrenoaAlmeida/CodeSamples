namespace CodeSamples
{
    public class StringInterpolation
    {
        public void Run()
        {
            int age = 44;
            /* Nova funcionalidade que permite o uso de Statements dentro das chaves em uma interpolação de String */

            /* FORMA NORMAL DE INTERPOLAÇÃO DE STRING
            string ageText = age switch
            {
                > 80 => "old",
                > 60 => "getting old",
                > 20 => "a good age",
                _ => "young"
            };
            Console.WriteLine($"The user is {age} years old, which is {ageText}");                
            */

            Console.WriteLine($"The user is {age} years old, which is {age switch
            {
                > 80 => "old",
                > 60 => "getting old",
                > 20 => "a good age",
                _ => "young"
            }}");
        }
    }
}
