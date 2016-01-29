using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Http;
using flipyserverService.ClientData;
using flipyserverService.Models;
using flipyserverService.SQLDataObjects;
using Microsoft.Azure.Mobile.Server.Config;
using ScoutingModels.Scrubber;

namespace flipyserverService.Controllers

{
    [MobileAppController]
    [RoutePrefix("api/Teams")]
    public class TeamController : ApiController
    {
        private object async;

        [Route("GetTeam")]
        [ActionName("GetTeam")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<ClientTeam> GetTeam(int teamNumber)
        {
             MobileServiceContext context = new MobileServiceContext();

            Team team = context.Teams.SingleOrDefault(a => a.TeamNumber == teamNumber);

            if (team == null)
            {

                BlueAllianceClient client = new BlueAllianceClient();

                team = await client.GetTeam(teamNumber);

                context.Teams.Add(team);
                context.SaveChanges();
            }
            return team.GetClientTeam();
        }
    }
}
}

