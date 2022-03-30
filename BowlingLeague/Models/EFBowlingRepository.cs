using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Models
{
    public class EFBowlingRepository : IBowlingRepository
    {
        private BowlingDbContext _context { get; set; }
        public EFBowlingRepository (BowlingDbContext bowlingDbContext)
        {
            _context = bowlingDbContext;
        }
        public IQueryable<Bowler> bowlers => _context.bowlers;
        public IQueryable<Team> teams => _context.teams;
    }
}
