using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokeAPI;
using PokemonApiService.Clients;
using PokemonApiService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokemonApiService.PokemonTranslator
{
    public class TranslatorForPokemon
    {
        public static async Task<JsonResult> getTranslatedDescription(string pokemonName)
        {
            PokemonSpecies p;

            try
            {
                p = await DataFetcher.GetNamedApiObject<PokemonSpecies>(pokemonName);
            }
            catch (HttpRequestException)
            {
                return new JsonResult(ErrorMessage.pokeMonNotFoundOrUnAvailable)
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

                JsonResult shakespeareResult = await ShakespeareClient.getShakespeareTranslated(description);

                if (shakespeareResult.StatusCode == StatusCodes.Status429TooManyRequests)
                {
                    return new JsonResult(ErrorMessage.tooManyRequest)
                    {
                        StatusCode = StatusCodes.Status429TooManyRequests
                    };
                }

                PokemonDetails pDetails = new PokemonDetails()
                {
                    Name = p.Name,
                    Description = shakespeareResult.Value.ToString()
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
