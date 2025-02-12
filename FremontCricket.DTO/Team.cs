using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FremontCricket.DTO
{
    public class Team
    {
        public Guid Id { get; set; }
        public string TeamName { get; set; } = string.Empty;
        public Guid MatchId { get; set; }
        public Guid HostTeamId { get; set; }
        public Guid GuestTeamId { get; set; }
        public Guid MatchWonBy { get; set; }
        public Guid MatchLostBy { get; set; }
        public int MatchesPlayed { get; set; }
        public int MatchesWon { get; set; }
        public int MatchesLost { get; set; }
    }
}
