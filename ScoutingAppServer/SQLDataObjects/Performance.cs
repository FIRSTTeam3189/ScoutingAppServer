using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure.Mobile.Server;

namespace flipyserverService.SQLDataObjects
{
    public class Performance: EntityData
    {
        /// <summary>
        /// Sends ints 0-4 for Autonomous phase to
        /// Determine enums in App
        /// </summary>
        public int Auto { get; set; }

        /// <summary>
        /// Tele-Op Portion
        /// </summary>
        public int DefensesCrossed { get; set; }

        public int HighShotsMade { get; set; }
        
        public int LowShotsMade { get; set; }

        public int HightShotsMissed { get; set; }

        public int LowShotsMissed { get; set; }

        public int Fouls { get; set; }


        /// <summary>
        /// EndGame sends a 0, 1, or 2 to determine
        /// wether the Bot Challenged the tower, scaled
        /// Tower, or did Neither, via enum when sent to
        /// the app. 0 = nothing, 1 = challenged, 2 = Scaled
        /// -King George ( ͡° ͜ʖ ͡°) and human slave #55686
        /// </summary>
        public int EndGame { get; set; }


    }
}