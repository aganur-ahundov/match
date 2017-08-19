using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Match.Models
{
    public class SoccerMatch
    {
        public string HomeTeamTitle { get; set; }

        public string GuestTeamTitle { get; set; }

        public string Tournament { get; set; }

        public DateTime Date { get; set; }

        public string Time { get; set; }

        public string Score { get; set; }

        public bool IsInProgres { get; set; }

        public Line Line { get; set; }
    }
}