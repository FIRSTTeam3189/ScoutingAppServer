using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure.Mobile.Server;

namespace flipyserverService.SQLDataObjects
{
    public class Match: EntityData
    {
        public virtual Alliance RedAlliance { get; set; }

        public virtual Alliance BlueAlliance { get; set; }
    }
}