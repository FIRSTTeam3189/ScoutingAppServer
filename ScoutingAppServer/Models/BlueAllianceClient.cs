using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using flipyserverService.SQLDataObjects;
using Newtonsoft.Json.Linq;
using ScoutingModels.Test;

namespace ScoutingModels.Scrubber
{
    public class BlueAllianceClient
    {
        HttpClient client;

        public BlueAllianceClient()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add(BlueAllianceConstants.HeaderKey, BlueAllianceConstants.HeaderValue);
        }

        /// <summary>
        /// Gets the events for specified year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Event>> GetEvents(int year)
        {
            var reqeustUri = string.Format(
                Path.Combine(BlueAllianceConstants.ApiPath, BlueAllianceConstants.EventsList), year);

            // Get the array from the client
            var array = (await client.GetStreamAsync(reqeustUri)).JArrayFromStream();

            return array.Select(x => x.GetEventFromJToken());
        }

        /// <summary>
        /// Gets the Teams from a page on blue alliance
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Team>> GetTeams(int page)
        {
            var requestUri = string.Format(
                Path.Combine(BlueAllianceConstants.ApiPath, BlueAllianceConstants.Teams), page);

            var array = (await client.GetStreamAsync(requestUri)).JArrayFromStream();

            return array.Select(x => x.GetTeamFromJToken());
        }

        /// <summary>
        /// Gets the Team's Number from blue alliance
        /// </summary>
        /// <param name="teamnumber"></param>
        /// <returns></returns>
        public async Task<Team> GetTeam(int teamnumber)
        {
            var requestUri = string.Format(
                Path.Combine(BlueAllianceConstants.ApiPath, BlueAllianceConstants.Teams), teamnumber);

            var array = (await client.GetStreamAsync(requestUri)).JTokenFromStream();

            return array.GetTeamFromJToken();
        }

        /// <summary>
        /// Gets the Teams for an event from a certain year
        /// </summary>
        /// <param name="year"></param>
        /// <param name="eventCode"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Team>> GetEventTeams(int year, int eventCode)
        {
            var requestUri = string.Format(
                Path.Combine(BlueAllianceConstants.ApiPath, BlueAllianceConstants.EventTeams), year, eventCode);

            var array = (await client.GetStreamAsync(requestUri)).JArrayFromStream();

            return array.Select(x => x.GetTeamFromJToken());
        }

        public async Task<IEnumerable<Match>> GetEventMatches(int year, int eventCode)
        {
            var requestUri = string.Format(
                Path.Combine(BlueAllianceConstants.ApiPath, BlueAllianceConstants.EventMatches), year, eventCode);

            var array = (await client.GetStreamAsync(requestUri)).JArrayFromStream();

            throw new NotImplementedException();
            //return array.Select(x => x.GetMatchFro)
        }
    }
}
