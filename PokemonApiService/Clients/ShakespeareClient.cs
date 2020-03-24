using Newtonsoft.Json;
using PokemonApiService.Models;
using RestSharp;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PokemonApiService.Clients
{
    public class ShakespeareClient
    {
        public readonly static string DefaultSiteURL = "https://api.funtranslations.com/translate/shakespeare.json";

        public static async Task<string> getShakespeareTranslated(string content)
        {
            var client = new RestClient("https://api.funtranslations.com/translate/shakespeare.json");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("text", content);
            var cancellationTokenSource = new CancellationTokenSource();
            IRestResponse response = await client.ExecuteAsync(request, cancellationTokenSource.Token);

            if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
            {
                return string.Empty;
            }

            if (response.ErrorException != null)
            {
                string message = ErrorMessage.unExpectedShakespeareError;
                var shakespeareException = new ApplicationException(message, response.ErrorException);
                throw shakespeareException;
            }

            ShakespeareResponse shakespeareResponse = JsonConvert.DeserializeObject<ShakespeareResponse>(response.Content);

            return shakespeareResponse.Contents.Translated;
        }
    }
}
