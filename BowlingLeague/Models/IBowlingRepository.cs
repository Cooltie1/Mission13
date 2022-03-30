using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Models
{
    public interface IBowlingRepository
    {
        public IQueryable<Bowler> bowlers { get; }
        public IQueryable<Team> teams { get; }

        public void SaveBowler(Bowler bowler);
        public void DeleteBowler(Bowler bowler);
    }
}
