using Microsoft.Azure.Mobile.Server;
using ScoutingServer.ClientData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoutingServer.SQLDataObjects {
    public class RobotEvent : EntityData{
        public EventTime EventTime { get; set; }
        public EventType EventType { get; set; }

        public ClientRobotEvent getClient() {
            return new ClientRobotEvent() {
                EventTime = EventTime,
                EventType = EventType
            };
        }
    }

    public enum EventTime {
        Auto = 1,
        Teleop = 2,
        Final = 3
    }

    public enum EventType {
        MakeLow = 1,
        MakeHigh = 2,
        MissLow = 3,
        MissHigh = 4,
        CrossOne = 5,
        CrossTwo = 6,
        CrossThree = 7,
        CrossFour = 8,
        CrossFive = 9,
        AssistOne = 10,
        AssistTwo = 11,
        AssistThree = 12,
        AssistFour = 13,
        AssistFive = 14,
        ReachDefense = 15,
        Challenge = 16,
        Hang = 17,
        Foul = 18,
        TechnicalFoul = 19,
        BlockedShot = 20

    }
}