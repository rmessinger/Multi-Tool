using static WebTools.Constants;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Net.Http;
using System.IO;
using RestSharp;
using WebTools.Model;
using Shared;

namespace WebTools
{
    public class F1Stats
    {
        private XmlSerializer seasonSerializer;
        private XmlSerializer raceSerializer;
        private XmlSerializer driverSerializer;
        private XmlSerializer constructorSerializer;
        private XmlSerializer standingsSerializer;
        private XmlSerializer statusSerializer;

        private SeasonsResponse allSeasons;

        private string seasonsCache = CacheDirectory + SeasonsFileName + FileExtension;

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
            // this.allSeasons = (SeasonsResponse)this.PopulateSeasonsTable();
            this.allSeasons = (SeasonsResponse)this.PopulateTable<SeasonsResponse>(this.seasonsCache, SeasonsUrlBase, this.seasonSerializer);
            // this.SaveResults("Seasons", allSeasons, seasonSerializer, false);
            IDictionary<int, RaceResponse> racesResponse = new Dictionary<int, RaceResponse>();
            ConsoleUtilities.Log("Got all seasons. Getting race tables");
            foreach (Season season in allSeasons.SeasonTable)
            {
                string seasonCache = CacheDirectory + season.Value + " " + RacesSuffix + FileExtension;
                string url = RacesInSeasonBase + season.Value.ToString();
                // RaceResponse raceResponse = (RaceResponse)this.PopulateRaceTable(season.Value);
                RaceResponse raceResponse = (RaceResponse)this.PopulateTable<RaceResponse>(seasonCache, url, this.raceSerializer);
                foreach (Race race in raceResponse.RaceTable)
                {
                    string raceResultUrl = url + "/" + race.round + "/results";
                    // Table population needs to be changed for race results. Currently returns a single root element
                    // Need a way to count a sub-table
                    RaceResponse raceResults = (RaceResponse)this.PopulateTable<RaceResponse>("", raceResultUrl, this.raceSerializer);
                }
                // this.SaveResults(season.Value + " Races", raceResponse, raceSerializer, true);
                racesResponse.Add(season.Value, raceResponse);
            }

            TimeSpan elapsed = DateTime.Now - startTime;
            ConsoleUtilities.Log($"Execution took {elapsed.TotalMilliseconds}ms");
        }

        private Response PopulateTable<T>(string cacheFile, string urlBase, XmlSerializer serializer, bool useCache = true) where T : Response
        {
            T result;
            if (useCache && File.Exists(cacheFile))
            {
                ConsoleUtilities.Log("Found cache file. Populating from local cache");
                result = LoadFromFile<T>(cacheFile, serializer);
            }
            else
            {
                StringBuilder url = new StringBuilder(urlBase);
                result = this.GetPage<T>(url.ToString(), serializer);
                ConsoleUtilities.Log($"Retrieved items {1} through {result.GetTable(ResponseType.Status).Length}");
                int limit = result.limit;

                while (result.GetTable(ResponseType.Status).Length < result.total)
                {
                    url.Append($"?limit={limit}&offset={result.GetTable(ResponseType.Status).Length}");
                    T response = this.GetPage<T>(url.ToString(), serializer);
                    result.AppendToTable(response.GetTable(ResponseType.Status));
                    ConsoleUtilities.Log($"Retrieved items {response.offset} through {result.GetTable(ResponseType.Status).Length}");
                }
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

        private T LoadFromFile<T>(string path, XmlSerializer serializer)
        {
            System.IO.FileStream file = System.IO.File.OpenRead(path);
            return (T)serializer.Deserialize(file);
        }

        private void SaveResults(string fileName, Response result, XmlSerializer serializer, bool replace)
        {
            string path = CacheDirectory + fileName + FileExtension;
            if (replace && File.Exists(path))
            {
                File.Delete(path);
            }

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
