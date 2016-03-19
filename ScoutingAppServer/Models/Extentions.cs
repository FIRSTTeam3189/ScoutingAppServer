using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScoutingServer.SQLDataObjects;

namespace ScoutingServer.Models
{
    public static class Extentions
    {
        public static bool Contains(this List<Event> events, Event e)
        {
            return events.Any(ev => e.Id == ev.Id);
        }
    }
}