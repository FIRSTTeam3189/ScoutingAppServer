using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using flipyserverService.ClientData;
using flipyserverService.Models;
using Microsoft.Azure.Mobile.Server.Config;
using ScoutingModels.Scrubber;

namespace flipyserverService.Controllers
{
    [MobileAppController]
    [RoutePrefix("api/events")]
    public class EventController : ApiController
    {
        public async Task<List<ClientEvent>> Refresh(int year)
        {
            BlueAllianceClient refresher = new BlueAllianceClient();

            var events = await refresher.GetEvents(year);

            MobileServiceContext context = new MobileServiceContext();

            var dbEvents = context.Events.ToList();

            foreach (var e in dbEvents)
            {
                var ev = events.SingleOrDefault(x => x.Id == e.Id);
                if (ev != null)
                {
                    e.Location = ev.Location;
                    e.Match = ev.Match;
                    e.EndDate = ev.EndDate;
                    e.EventCode = ev.EventCode;
                    e.Official = ev.Official;
                    e.Year = ev.Year;
                    e.Website = ev.Website;
                    e.StartDate = ev.StartDate;
                    events.Remove(ev);
                }
                else
                {
                    context.Events.Remove(e);
                }
            }

            foreach (var e in events)
            {
                context.Events.Add(e);
            }
            context.SaveChanges();
            var list = context.Events.ToList();
            return (from e in list
                    select new ClientEvent()
                    {
                        StartDate = e.StartDate,
                        Official = e.Official,
                        Year = e.Year,
                        EndDate = e.EndDate,
                        EventCode = e.EventCode,
                        Location = e.Location,
                        Website = e.Website
                    }).ToList();
        }
    }
}