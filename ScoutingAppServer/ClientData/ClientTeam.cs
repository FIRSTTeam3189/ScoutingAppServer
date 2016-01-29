﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using flipyserverService.SQLDataObjects;

namespace flipyserverService.ClientData
{
    public class ClientTeam
    {
        public int TeamNumber { get; set; }

        public int RookieYear { get; set; }

        public string NickName { get; set; }

        public string TeamLocation { get; set; }

        public virtual ICollection<ClientPerformance> TeamPerformance { get; set; }

    }
}