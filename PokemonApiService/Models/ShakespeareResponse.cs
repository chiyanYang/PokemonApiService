using System;

namespace PokemonApiService
{
    public class ShakespeareResponse
    {
        public Status Success { get; set; }

        public ResponseContents Contents { get; set; }

    }

    public class ResponseContents
    {
        public string translated { get; set; }

        public string text { get; set; }

        public string translation { get; set; }
    }

    public class Status
    {
        public int total { get; set; }
    }
}
