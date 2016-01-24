using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure.Mobile.Server;

namespace flipyserverService.SQLDataObjects
{
    public class Alliance: EntityData
    {

        public virtual Team TeamOne { get; set; }

        public virtual Team TeamTwo { get; set; }

        public virtual Team TeamThree { get; set; }
    }
}