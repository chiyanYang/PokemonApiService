using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PokeAPI;
using PokemonApiService;
using PokemonApiService.Clients;
using PokemonApiService.Controllers;
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
            string response = await controller.Get(pokemonName);
            PokemonDetails pokemonDetails = JsonConvert.DeserializeObject<PokemonDetails>(response);

            Assert.IsNotNull(pokemonDetails);
            Assert.IsNotNull(pokemonDetails.Description);
            Assert.AreEqual(pokemonDetails.Name, pokemonName);
        }
    }
}
