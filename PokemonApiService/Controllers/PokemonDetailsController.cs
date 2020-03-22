using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PokeAPI;

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
            PokemonDetails pDetails = new PokemonDetails()
            {
                Name = p.Name,
                Description = Array.Find(p.FlavorTexts, element => element.Language.Name == "en").FlavorText
            };

            return JsonConvert.SerializeObject(pDetails);
        }
    }
}
