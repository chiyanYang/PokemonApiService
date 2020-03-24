using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PokeAPI;
using PokemonApiService;
using PokemonApiService.Clients;
using PokemonApiService.Controllers;
using PokemonApiService.Models;
using System.Threading.Tasks;

namespace LiveTest
{
    [TestClass]
    public class UnitTest
    {
        const string pokemonName = "weedle";

        [TestMethod]
        public async Task TestPokemonApi()
        {
            PokemonSpecies p = await DataFetcher.GetNamedApiObject<PokemonSpecies>(pokemonName);
            Assert.IsNotNull(p);
            Assert.AreEqual(p.Name, pokemonName);
        }

        [TestMethod]
        public async Task TestShakespeareApi()
        {
            const string content = "You gave Mr. Tim a hearty meal, but unfortunately what he ate made him die.";
            string translatedContent = await ShakespeareClient.getShakespeareTranslated(content);

            Assert.IsNotNull(translatedContent);
            Assert.AreEqual(translatedContent, "Thee did giveth mr. Tim a hearty meal,  but unfortunately what he did doth englut did maketh him kicketh the bucket.");
        }

        [TestMethod]
        public async Task TestPokemonDetailsAPI()
        {
            var controller = new PokemonDetailsController();
            var response = await controller.Get(pokemonName);

            Assert.IsNotNull(response);

            if (response.StatusCode == StatusCodes.Status429TooManyRequests)
            {
                Assert.AreEqual(response.Value, ErrorMessage.tooManyRequest);
            }
            else
            {
                PokemonDetails pokemonDetails = response.Value as PokemonDetails;
                Assert.IsNotNull(pokemonDetails);
                Assert.IsNotNull(pokemonDetails.Description);
                Assert.AreEqual(pokemonDetails.Name, pokemonName);
            }
        }

        [TestMethod]
        public async Task TestPokemonDetailsAPIWithNotAnPokemonName()
        {
            var controller = new PokemonDetailsController();
            var response = await controller.Get("a3f");

            Assert.IsNotNull(response);
            Assert.AreEqual(response.StatusCode, StatusCodes.Status404NotFound);
        }

        [TestMethod]
        public async Task TestShakespeareApiWhenReachingRateLimiter()
        {
            const int count = 5;
            string[] content = new string[count] { "eat", "drink", "run", "play", "work" };

            for (int i = 0; i < count; i++)
            {
                await ShakespeareClient.getShakespeareTranslated(content[i]);
            }

            string translatedContent = await ShakespeareClient.getShakespeareTranslated(content[0]);
            Assert.AreEqual(translatedContent, string.Empty);
        }
    }
}
