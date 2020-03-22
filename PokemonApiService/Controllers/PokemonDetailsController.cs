using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PokeAPI;
using PokemonApiService.Clients;
using RestSharp;

namespace PokemonApiService.Controllers
{
    public class PokemonDetailsController : ControllerBase
    {
        private readonly ILogger<PokemonDetailsController> _logger;

        public PokemonDetailsController(ILogger<PokemonDetailsController> logger)
        {
            _logger = logger;
        }

        [Route("pokemon/{pokemonName}")]
        [HttpGet]
        public async Task<string> Get(string pokemonName)
        {
            PokemonSpecies p = await DataFetcher.GetNamedApiObject<PokemonSpecies>(pokemonName);

            string description = Array.Find(p.FlavorTexts, element => element.Language.Name == "en").FlavorText;

            string translatedDes = await ShakespeareClient.getShakespeareTranslated(description);

            PokemonDetails pDetails = new PokemonDetails()
            {
                Name = p.Name,
                Description = translatedDes
            };

            return JsonConvert.SerializeObject(pDetails);
        }
    }
}
