using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using flipyserverService.ClientData;
using Microsoft.Azure.Mobile.Server;

namespace flipyserverService.SQLDataObjects
{
    public class Team:EntityData
    {
        public int TeamNumber { get; set; }

        public int RookieYear { get; set; }

        public string NickName { get; set; }
  
        public string TeamLocation { get; set; }

        public virtual ICollection<Performance> TeamPerformance { get; set; }

        public ClientTeam GetClientTeam()
        {
            return new ClientTeam()
            {
                TeamNumber = TeamNumber,
                RookieYear = RookieYear,
                NickName = NickName,
                TeamLocation = TeamLocation
            };
        }
    }
}