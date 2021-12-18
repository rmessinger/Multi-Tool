using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Net.Http;
using System.IO;
using RestSharp;
using WebTools.Model;
using System.Linq;

namespace WebTools
{
    public class F1Stats
    {
        private const string CacheDirectory = "C:\\Users\\reidm\\OneDrive\\Documents\\F1Stats\\";
        private const string SeasonsUrlBase = "http://ergast.com/api/f1/seasons";
        private const string RacesInSeasonBase = "http://ergast.com/api/f1/";

        private XmlSerializer seasonSerializer;
        private XmlSerializer raceSerializer;
        private XmlSerializer driverSerializer;
        private XmlSerializer constructorSerializer;
        private XmlSerializer standingsSerializer;
        private XmlSerializer statusSerializer;

        public F1Stats()
        {
            this.seasonSerializer = new XmlSerializer(typeof(SeasonsResponse));
            this.raceSerializer = new XmlSerializer(typeof(RaceResponse));
            this.driverSerializer = new XmlSerializer(typeof(DriverResponse));
            this.constructorSerializer = new XmlSerializer(typeof(ConstructorResponse));
            this.standingsSerializer = new XmlSerializer(typeof(StandingsResponse));
            this.statusSerializer = new XmlSerializer(typeof(StatusResponse));
        }

        public void Run()
        {
            // var client = new RestClient("http://ergast.com/api/f1/drivers?=123");
            // var client = new RestClient("http://ergast.com/api/f1/2021");
            
            // get all seasons
            SeasonsResponse allSeasons = (SeasonsResponse)this.GetFullSeasonTable(SeasonsUrlBase);
            IDictionary<int, RaceResponse> racesResponse = new Dictionary<int, RaceResponse>();

            foreach (Season season in allSeasons.SeasonTable)
            {
                racesResponse.Add(season.Value, (RaceResponse)this.GetFullRaceTable(RacesInSeasonBase + season.Value.ToString()));
            }
        }

        private Response GetFullSeasonTable(string urlBase)
        {
            StringBuilder url = new StringBuilder(urlBase);
            SeasonsResponse result = (SeasonsResponse)this.GetPage(url.ToString(), this.seasonSerializer);
            int limit = result.limit;
            
            // Initialize list of seasons
            while (result.SeasonTable.Length < result.total)
            {
                url.Append($"?limit={limit}&offset={result.SeasonTable.Length}");
                SeasonsResponse response = (SeasonsResponse)this.GetPage(url.ToString(), this.seasonSerializer);
                result.SeasonTable = result.SeasonTable.Concat(response.SeasonTable).ToArray();
            }

            return result;
        }

        private Response GetFullRaceTable(string urlBase)
        {
            StringBuilder url = new StringBuilder(urlBase);
            RaceResponse result = (RaceResponse)this.GetPage(url.ToString(), this.raceSerializer);
            int limit = result.limit;

            // Initialize list of seasons
            while (result.RaceTable.Length < result.total)
            {
                url.Append($"?limit={limit}&offset={result.RaceTable.Length}");
                RaceResponse response = (RaceResponse)this.GetPage(url.ToString(), this.raceSerializer);
                result.RaceTable = result.RaceTable.Concat(response.RaceTable).ToArray();
            }

            return result;
        }

        private Response GetPage(string url, XmlSerializer serializer)
        {
            var client = new RestClient(url.ToString());
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Response result = (Response)serializer.Deserialize(GenerateStreamFromString(response.Content));
            return result;
        }

        private void SaveResults(string fileName, Response result, XmlSerializer serializer)
        {
            string path = CacheDirectory + fileName;
            System.IO.FileStream file = System.IO.File.OpenWrite(path);
            serializer.Serialize(file, result);
        }

        private static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
