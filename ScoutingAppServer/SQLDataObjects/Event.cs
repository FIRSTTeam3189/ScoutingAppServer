using System;
using System.Collections.Generic;
using Microsoft.Azure.Mobile.Server;

namespace ScoutingServer.SQLDataObjects
{
    public class Event:EntityData
    {
        public string Name { get; set; }

        public string Location { get; set; }

        public int Year { get; set; }

        public string Website { get; set; }

        public string EventCode { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool Official { get; set; }

        public virtual ICollection<string> Teams { get; set; }

        public virtual ICollection<Match> Matchs { get; set; }

        public ClientData.ClientEvent GetClientEvent() {
            return new ClientData.ClientEvent {
                EndDate = EndDate,
                EventCode = EventCode,
                Location = Location,
                Official = Official,
                StartDate = StartDate,
                Website = Website,
                Year = Year
            };
        }
    }
}