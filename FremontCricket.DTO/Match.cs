using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FremontCricket.DTO
{
    public class Match
    {
        public Guid Id { get; set; }
        public Guid? GuestTeamId { get; set; }
        public Guid? HostTeamId { get; set; }
        public Guid? MatchWonBy { get; set; }
        public Guid? MatchLostBy { get; set; }
        public Guid? TossWonBy { get; set; }
        public int MatchTied { get; set; }
        public string GuestTeamName { get; set; } = string.Empty;
        public string HostTeamName { get; set; } = string.Empty;
    }
}
