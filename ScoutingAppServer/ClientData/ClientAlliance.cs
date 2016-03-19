using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure.Mobile.Server;
using ScoutingServer.ClientData;

namespace ScoutingServer.SQLDataObjects
{
    public class ClientAlliance
    {
        public virtual ClientPerformance TeamOne { get; set; }

        public virtual ClientPerformance TeamTwo { get; set; }

        public virtual ClientPerformance TeamThree { get; set; }
    }
}