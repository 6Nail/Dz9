using SportTeam.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportTeam.Services
{
    public class SearchService
    {
        private readonly SportTeamContext context;
        private const int playerCount = 2;

        public SearchService(SportTeamContext context)
        {
            this.context = context;
        }

        public void SearchProductByName(string teamName, int pageNumber = 1)
        {
            var result = context.Teams.Where(team => team.TeamName.Contains(teamName)).ToList();
            if (result.Count == 0) return;
            var pageCount = Math.Ceiling(result.First().Players.Count / (double)playerCount);

            if (pageNumber > pageCount || pageNumber <= 0)
            {
                Console.WriteLine("Нет такой страницы");
                return;
            }
            var page = result.First().Players.Skip(playerCount * --pageNumber).Take(playerCount).ToList();

            foreach (var player in page)
            {
                Console.WriteLine($"Имя игрока: {player.FullName}\n\n");
            }

            Console.WriteLine($"{++pageNumber} | {pageCount}");
        }
    }
}
