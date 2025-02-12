using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FremontCricket.DTO
{
    public class Match
    {
        public Guid GuestTeamId { get; set; }
        public Guid HostTeamId { get; set; }
    }
}
