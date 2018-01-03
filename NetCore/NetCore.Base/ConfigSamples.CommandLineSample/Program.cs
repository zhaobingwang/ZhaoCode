using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace ConfigSamples.CommandLineSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = new Dictionary<string, string> {
                { "name","zhangsan"},
                { "age","20"}
            };
            var builder = new ConfigurationBuilder()
                .AddInMemoryCollection(settings)
                .AddCommandLine(args);
            var configuration = builder.Build();
            Console.WriteLine($"name:{configuration["name"]}");
            Console.WriteLine($"age:{configuration["age"]}");
        }
    }
}
