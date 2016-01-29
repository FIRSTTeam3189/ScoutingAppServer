using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Microsoft.Azure.Mobile.Server;
using Microsoft.WindowsAzure.Storage.Table;

namespace flipyserverService.SQLDataObjects
{
    public class Event:EntityData
    {
        public string Name { get; set; }

        public string Location { get; set; }

        public int Year { get; set; }

        public string EventCode { get; set; }

        public string Website { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool Official { get; set; }

        public virtual ICollection<Match> Match { get; set; }
    }
}