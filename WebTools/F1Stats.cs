using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Net.Http;
using System.IO;
using RestSharp;

namespace WebTools
{
    public class F1Stats
    {
        public async void Run()
        {
            var client = new RestClient("http://ergast.com/api/f1/drivers?=123");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            XmlSerializer deserializer = new XmlSerializer(typeof(MRData));
            MRData result = (MRData)deserializer.Deserialize(GenerateStreamFromString(response.Content));
            
            if (result.DriverTable.Length < result.total)
            {
            
            }
            // File.WriteAllText("C:\\dev\\PitStops.xml", response.Content);

            //HttpContent responseContent = response.Content;
            //MRData result = new MRData();
            //XmlSerializer deserializer = new XmlSerializer(typeof(MRData));

            //// Get the stream of the content.
            //using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
            //{
            //    // Write the output.
            //    //File.WriteAllText("C:\\dev\\StatsOutput.xml", await reader.ReadToEndAsync());
            //    result = (MRData)deserializer.Deserialize(reader);
            //}
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
