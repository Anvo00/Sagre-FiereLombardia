using System.Text.Json.Serialization;

namespace Sagre_FiereLombardia.Models
{

    public class Event
    {

        [JsonPropertyName("id")]
        public string? ID {get; set;}

        [JsonPropertyName("denom")]
        public string? NomeEvento { get; set; }

        [JsonPropertyName("tipo")]
        public string? TipoEvento { get; set; }

        [JsonPropertyName("n_ediz")]
        public string? Edizione { get; set; }

        [JsonPropertyName("data_in")]
        public DateTime? DataInizio { get; set; }

        [JsonPropertyName("ora_in")]
        public string? OraInzio { get; set; }

        [JsonPropertyName("data_fine")]
        public DateTime? DataFine { get; set; }

        [JsonPropertyName("ora_fine")]
        public string? OraFine { get; set; }

        [JsonPropertyName("anno")]
        public string? Anno { get; set; }

        [JsonPropertyName("prov")]
        public string? Provincia { get; set; }

        [JsonPropertyName("comune")]
        public string? Comune { get; set; }

        [JsonPropertyName("toponimo")]
        public string? Toponimo { get; set; }

        [JsonPropertyName("indirizzo")]
        public string? Indirizzo { get; set; }

        [JsonPropertyName("cap")]
        public string? CAP { get; set; }

        [JsonPropertyName("nome_org")]
        public string? Organizzazione { get; set; }

        // Controllare il link
        [JsonPropertyName("url_programma")]
        public string? URL { get; set; }

        public GeoPoint? geopoint { get; set; }
    }

    public class GeoPoint
    {
        [JsonPropertyName("geo_x")]
        public double? Latitude { get; set; }

        [JsonPropertyName("geo_y")]
        public double? Longitude { get; set; }
    }
}
