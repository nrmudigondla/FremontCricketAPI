using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FremontCricket.DTO
{
    public class TeamPlayer
    {
        public long Number { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public int MatchesPlayed { get; set; } = 0;
        public int MOM { get; set; } = 0;
        public int RunsScored { get; set; } = 0;
        public int WicketsTaken { get; set; } = 0;
        public int Umpired { get; set; } = 0;
        public Guid TeamId { get; set; }
    }
}
