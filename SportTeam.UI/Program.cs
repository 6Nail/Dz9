using Microsoft.Extensions.Configuration;
using SportTeam.DataAccess;
using SportTeam.Services;
using System;
using System.IO;
using System.Linq;

namespace SportTeam.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json", false, true);
            IConfigurationRoot configurationRoot = builder.Build();
            var connectionString = configurationRoot.GetConnectionString("MyConnectionString");
            using (var context = new SportTeamContext(connectionString))
            {
                SearchService searchService = new SearchService(context);
                var teams = context.Teams.ToList();
                Console.WriteLine("Выберите команду:");
                for (int i = 0,y = 1; i < teams.Count; i++)
                {
                    Console.WriteLine($"{y++} - {teams[i].TeamName}");
                }
                Console.Write("Выбрать: ");
                var teamName = string.Empty;
                if (int.TryParse(Console.ReadLine(), out var choose))
                {
                    switch (choose)
                    {
                        case 1: teamName = "Raiders"; break;
                        case 2: teamName = "Stalker"; break;
                    }
                }
                var pageNumber = 1;
                while (true)
                {
                    Console.Clear();
                    searchService.SearchProductByName(teamName, pageNumber);
                    Console.Write("\nКакую страничку вы хотите открыть:");
                    int.TryParse(Console.ReadLine(), out pageNumber);
                }
            }

        }
    }
}
