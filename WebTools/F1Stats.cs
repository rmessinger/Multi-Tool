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
        private const string AllDriversUrl = "http://ergast.com/api/f1/drivers?=123";

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
            // get all seasons
            DateTime startTime = DateTime.Now;
            SeasonsResponse allSeasons = (SeasonsResponse)this.GetFullSeasonTable();
            IDictionary<int, RaceResponse> racesResponse = new Dictionary<int, RaceResponse>();
            LogToConsole("Got all seasons. Getting race tables");
            foreach (Season season in allSeasons.SeasonTable)
            {
                racesResponse.Add(season.Value, (RaceResponse)this.GetFullRaceTable(season.Value));
            }

            TimeSpan elapsed = DateTime.Now - startTime;
            LogToConsole($"Execution took {elapsed.TotalMilliseconds}ms");
        }

        private Response GetFullSeasonTable()
        {
            StringBuilder url = new StringBuilder(SeasonsUrlBase);
            SeasonsResponse result = this.GetPage<SeasonsResponse>(url.ToString(), this.seasonSerializer);
            LogToConsole($"Retrieved seasons {result.SeasonTable.First()?.Value} through {result.SeasonTable.LastOrDefault()?.Value}");
            int limit = result.limit;
            
            while (result.SeasonTable.Length < result.total)
            {
                url.Append($"?limit={limit}&offset={result.SeasonTable.Length}");
                SeasonsResponse response = this.GetPage<SeasonsResponse>(url.ToString(), this.seasonSerializer);
                LogToConsole($"Retrieved seasons {response.SeasonTable.First()?.Value} through {response.SeasonTable.LastOrDefault()?.Value}");
                result.SeasonTable = result.SeasonTable.Concat(response.SeasonTable).ToArray();
            }

            return result;
        }

        private Response GetFullRaceTable(int year)
        {
            StringBuilder url = new StringBuilder(RacesInSeasonBase + year.ToString());
            RaceResponse result = this.GetPage<RaceResponse>(url.ToString(), this.raceSerializer);
            LogToConsole($"Retrieved {year} rounds {result.RaceTable.First()?.round} through {result.RaceTable.LastOrDefault()?.round}");
            int limit = result.limit;

            while (result.RaceTable.Length < result.total)
            {
                url.Append($"?limit={limit}&offset={result.RaceTable.Length}");
                RaceResponse response = this.GetPage<RaceResponse>(url.ToString(), this.raceSerializer);
                LogToConsole($"Retrieved {year} rounds {response.RaceTable.First()?.round} through {response.RaceTable.LastOrDefault()?.round}");
                result.RaceTable = result.RaceTable.Concat(response.RaceTable).ToArray();
            }

            return result;
        }

        private T GetPage<T>(string url, XmlSerializer serializer)
        {
            var client = new RestClient(url.ToString());
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            T result = (T)serializer.Deserialize(GenerateStreamFromString(response.Content));
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

        private static void LogToConsole(string s)
        {
            string prefix = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + " " + (DateTime.Now.Hour < 10 ? "0" : "") + 
                DateTime.Now.Hour + ":" + DateTime.Now. Minute + ":" + DateTime.Now.Second + "." + DateTime.Now.Millisecond + " - ";
            Console.WriteLine(prefix + s);
        }
    }
}
