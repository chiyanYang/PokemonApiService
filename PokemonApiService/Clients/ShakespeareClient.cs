using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PokemonApiService.Clients
{
    public class ShakespeareClient
    {
        public readonly static string DefaultSiteURL = "https://api.funtranslations.com/translate/shakespeare.json";

        public static async Task<string> getShakespeareTranslated(string content)
        {
            string formDataBoundary = String.Format("----------{0:N}", Guid.NewGuid());
            var client = new RestClient("https://api.funtranslations.com/translate/shakespeare.json");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("text", content);
            var cancellationTokenSource = new CancellationTokenSource();
            IRestResponse response = await client.ExecuteAsync(request, cancellationTokenSource.Token);

            ShakespeareResponse shakespeareResponse = JsonConvert.DeserializeObject<ShakespeareResponse>(response.Content);

            return shakespeareResponse.Contents.translated;
        }
    }
}
