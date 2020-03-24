using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonApiService.Models
{
    public class ErrorMessage
    {
        public static readonly string tooManyRequest = "Exceed shakespeare API Ratelimit, Please try after a few minutes";

        public static readonly string pokeMonNotFoundOrUnAvailable = "Pokemon not found or Pokemon API not available";

        public static readonly string unExpectedShakespeareError = "Unexpected error from Shakespeare API";
    }
}
