using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportTeam.Domain
{
    public class Player : Entity
    {
        public string FullName { get; set; }
        public Guid TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
