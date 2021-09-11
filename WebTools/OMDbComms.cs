using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RestSharp;


namespace WebTools
{
    public class OMDbComms
    {
        string apiKey;
        public OMDbComms(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public string getTitleData(string title)
        {
            title = title.Replace(' ', '+');
            string ret = string.Empty;
            string url = $"http://www.omdbapi.com/?t={ title }&apikey={ this.apiKey }";

            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);

            try
            {
                IRestResponse response = client.Execute(request);

                if (response.IsSuccessful)
                {
                    ret = response.Content;
                }
            }
            catch (Exception ex)
            {
                // do nothing
            }

            return ret;
        }
    }
}
