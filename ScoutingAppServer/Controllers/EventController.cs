using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;

namespace flipyserverService.Controllers
{
    [MobileAppController]
    [RoutePrefix("api/events")]
    public class EventController : ApiController
    {
        public HttpResponseMessage Refresh()
        {
            
        }
    }
}