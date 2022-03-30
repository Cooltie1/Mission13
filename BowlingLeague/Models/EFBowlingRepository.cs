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

        public void SaveBowler(Bowler bowler)
        {
            _context.AttachRange(_context.teams.Single(x => x.TeamID == bowler.TeamID));
            if (bowler.BowlerID == 0)
            {
                _context.bowlers.Add(bowler);
            } else
            {
                _context.Update(bowler);
            }
            _context.SaveChanges();
        }
        public void DeleteBowler(Bowler bowler)
        {
            var teams = _context.teams.ToList();
            _context.Remove(bowler);
            _context.SaveChanges();
        }
    }
}
