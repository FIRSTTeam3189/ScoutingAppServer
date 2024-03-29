﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using ScoutingServer.ClientData;
using Microsoft.Azure.Mobile.Server;

namespace ScoutingServer.SQLDataObjects
{
    public class Team:EntityData
    {
        public int RookieYear { get; set; }

        public string NickName { get; set; }
  
        public string TeamLocation { get; set; }

        public int TeamNumber { get; set; }

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

        public static bool operator ==(Team a, Team b) {
            return a?.Id == b?.Id;
        }

        public static bool operator !=(Team a, Team b) {
            return a?.Id != b?.Id;
        }

        public override bool Equals(object obj) {
            if(obj is Account)
                return (obj as Account)?.Id == Id;
            return false;
        }

        public override int GetHashCode() {
            return Id.GetHashCode();
        }
    }
}