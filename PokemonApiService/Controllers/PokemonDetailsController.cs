using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
            return pokemonName;
        }
    }
}
