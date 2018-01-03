using System;
using Microsoft.Extensions.Configuration;

namespace ConfigSample.JsonConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("class.json");

            var configuration = builder.Build();
            Console.WriteLine($"ClassNo:{configuration["ClassNo"]}");
            Console.WriteLine($"ClassDesc:{configuration["ClassDesc"]}");

            Console.WriteLine("Studdents:");

            Console.Write(configuration["Students:0:name"]);
            Console.WriteLine(configuration["Students:0:age"]);

            Console.Write(configuration["Students:1:name"]);
            Console.WriteLine(configuration["Students:1:age"]);

            Console.Write(configuration["Students:2:name"]);
            Console.WriteLine(configuration["Students:2:age"]);

            Console.ReadLine();
        }
    }
}
