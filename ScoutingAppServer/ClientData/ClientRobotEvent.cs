using ScoutingServer.SQLDataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoutingServer.ClientData {
    public class ClientRobotEvent {
        public EventTime EventTime { get; set; }
        public EventType EventType { get; set; }
    }
}