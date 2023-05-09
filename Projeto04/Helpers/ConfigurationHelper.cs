using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto04.Helpers
{
    public class ConfigurationHelper
    {
        public static string GetConnectionString()
        {
            // lendo o conteúdo do arquivo appSettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("AppSettings.json")
                .Build();

            // retornando o valor da connectionString contido no arquivo. 
            return configuration.GetConnectionString("Projeto04");
        }
    }
}