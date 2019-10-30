using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SportTeam.Domain
{
    public class Team : Entity
    {
        public string TeamName { get; set; }
        public virtual List<Player> Players { get; set; }
    }
}