using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLangProjekt.Utility
{
    public abstract class FlightsRestClient
    {
        private const string _apiUrl = "https://opensky-network.org/api/";

        protected RestClient Client { get; set; }

        protected FlightsRestClient()
        {
            RestClientOptions clientOptions = new(_apiUrl)
            {
                UserAgent = "Flights Rest Client",
                FollowRedirects = true
                
            };
            Client = new RestClient(options: clientOptions);
        }

        protected RestRequest CreateRequest(string resource)
        {
            RestRequest request = new(resource);
            request.AddHeader("accept", "application/json");
            request.AddHeader("accept-version", "v10");
            return request;
        }

        protected async Task<T> CallEndpointAsync<T>(string endpointName) where T : new()
        {
            RestRequest request = CreateRequest(endpointName);

            RestResponse<T> response = await Client.ExecuteAsync<T>(request);

            // Handle errors and throw exceptions if needed 
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new DirectoryNotFoundException("The Called endpoint was not found");
            }
            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }


            return response.Data;
        }
    }
}
