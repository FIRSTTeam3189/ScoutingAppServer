﻿using ScoutingServer.SQLDataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoutingServer.ClientData
{
    public class ClientPerformance {
        public string Id { get; set; }
        public int TeamId { get; set; }
        public int MatchNumber { get; set; }
        public MatchType MatchType { get; set; }
        public string EventCode { get; set; }
        public List<ClientRobotEvent> Events { get; set; }
        public DateTimeOffset? LastUpdated { get; set; }
    }
}