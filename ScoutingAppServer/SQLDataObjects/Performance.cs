using Microsoft.Azure.Mobile.Server;
using ScoutingServer.ClientData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoutingServer.SQLDataObjects {
    public class Performance : EntityData {
        public int TeamId { get; set; }
        public int MatchNumber { get; set; }
        public virtual MatchType MatchTyp { get; set; }
        public string EventCode { get; set; }
        public virtual List<RobotEvent> Events { get; set; }

        public ClientPerformance getClient() {
            return new ClientPerformance() {
                EventCode = EventCode,
                Events = Events.Select(x => x.getClient()).ToList(),
                Id = Id,
                LastUpdated = UpdatedAt,
                MatchNumber = MatchNumber,
                MatchType = MatchTyp,
                TeamId = TeamId
            };
        }
    }
}