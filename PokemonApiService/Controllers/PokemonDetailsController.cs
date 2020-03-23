using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        public PokemonDetailsController() { }

        [Route("pokemon/{pokemonName}")]
        [HttpGet]
        public async Task<JsonResult> Get(string pokemonName)
        {
            PokemonSpecies p;

            try
            {
                p = await DataFetcher.GetNamedApiObject<PokemonSpecies>(pokemonName);
            }
            catch (HttpRequestException)
            {
                return new JsonResult("Pokemon not found or Pokemon API not available")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            catch (PokemonParseException ex)
            {
                return new JsonResult(ex.Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }

            try
            {
                string description = Array.Find(p.FlavorTexts, element => element.Language.Name == "en").FlavorText;

                string translatedDes = await ShakespeareClient.getShakespeareTranslated(description);

                if (string.IsNullOrEmpty(translatedDes))
                {
                    return new JsonResult("Exceed shakespeare API Ratelimit, Please try after a few minutes")
                    {
                        StatusCode = StatusCodes.Status429TooManyRequests
                    };
                }

                PokemonDetails pDetails = new PokemonDetails()
                {
                    Name = p.Name,
                    Description = translatedDes
                };

                return new JsonResult(pDetails)
                {
                    StatusCode = StatusCodes.Status200OK // Status code here 
                };
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError // Status code here 
                };
            }
        }
    }
}
