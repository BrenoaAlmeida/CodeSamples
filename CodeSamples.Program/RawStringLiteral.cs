using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual_Code
{
    public class RawStringLiteral
    {
        public void Run()
        {
            string rawString = "{\r\n  \"Logging\": {\r\n    \"LogLevel\": {\r\n      \"Default\": \"Information\",\r\n      \"Microsoft.AspNetCore\": \"Warning\"\r\n    }\r\n  },\r\n  \"AllowedHosts\": \"*\"\r\n}";
                //Strings literais começam com pelo menos 3 aspas duplas mas pode  ter mais 
                //Para ter interpolação de string adicione dois sinais de dolar e a mesma quantidade de chaves na variavel que usa a interpolação
            string level = "Warning";
            string rawStringLiteral = $$"""
               {
                 "Logging": {
                   "LogLevel": {
                     "Default": "Information",
                     "Microsoft.AspNetCore": {{level}}
                   }
                 },
                 "AllowedHosts": "*"
               }
               """;

            Console.WriteLine("rawString:");
            Console.WriteLine(rawString);

            Console.WriteLine("rawStringLiteral:");
            Console.WriteLine(rawStringLiteral);
        }
    }
}
