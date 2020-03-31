using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonApiService.PokemonTranslator;

namespace PokemonApiService.Controllers
{
    public class PokemonDetailsController : ControllerBase
    {

        public PokemonDetailsController() { }

        [Route("pokemon/{pokemonName}")]
        [HttpGet]
        public async Task<JsonResult> Get(string pokemonName)
        {
            return await TranslatorForPokemon.getTranslatedDescription(pokemonName);
        }
    }
}
