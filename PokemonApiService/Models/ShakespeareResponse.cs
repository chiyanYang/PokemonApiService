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
        public string Translated { get; set; }

        public string Text { get; set; }

        public string Translation { get; set; }
    }

    public class Status
    {
        public int Total { get; set; }
    }
}
