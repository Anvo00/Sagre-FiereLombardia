using Newtonsoft.Json;

namespace Sagre_FiereLombardia.Models
{

    public class Event
    {

        [JsonProperty("id")]
        public string? ID { get; set; }

        [JsonProperty("denom")]
        public string? NomeEvento { get; set; }

        [JsonProperty("tipo")]
        public string? TipoEvento { get; set; }

        [JsonProperty("n_ediz")]
        public string? Edizione { get; set; }

        [JsonProperty("data_in")]
        public DateTime? DataInizio { get; set; }

        [JsonProperty("ora_in")]
        public string? OraInzio { get; set; }

        [JsonProperty("data_fine")]
        public DateTime? DataFine { get; set; }

        [JsonProperty("ora_fine")]
        public string? OraFine { get; set; }

        [JsonProperty("anno")]
        public string? Anno { get; set; }

        [JsonProperty("prov")]
        public string? Provincia { get; set; }

        [JsonProperty("comune")]
        public string? Comune { get; set; }

        [JsonProperty("toponimo")]
        public string? Toponimo { get; set; }

        [JsonProperty("indirizzo")]
        public string? Indirizzo { get; set; }

        [JsonProperty("cap")]
        public string? CAP { get; set; }

        [JsonProperty("nome_org")]
        public string? Organizzazione { get; set; }

        public GeoPoint? geopoint { get; set; }
    }

    public class GeoPoint
    {
        [JsonProperty("geo_x")]
        public double? Latitude { get; set; }

        [JsonProperty("geo_y")]
        public double? Longitude { get; set; }
    }
}