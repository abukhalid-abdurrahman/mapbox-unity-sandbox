using System.Collections.Generic;
using Newtonsoft.Json;

namespace Models.Geocoding
{
    public class ForwardGeocodingProperties
    {
    }

    public class ForwardGeocodingGeometry
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("coordinates")]
        public List<double> Coordinates { get; set; }

        [JsonProperty("interpolated")]
        public bool Interpolated { get; set; }

        [JsonProperty("omitted")]
        public bool Omitted { get; set; }
    }

    public class ForwardGeocodingContext
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("wikidata")]
        public string Wikidata { get; set; }

        [JsonProperty("short_code")]
        public string ShortCode { get; set; }
    }

    public class ForwardGeocodingFeature
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("place_type")]
        public List<string> PlaceType { get; set; }

        [JsonProperty("relevance")]
        public double Relevance { get; set; }

        [JsonProperty("properties")]
        public ForwardGeocodingProperties ForwardGeocodingProperties { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("place_name")]
        public string PlaceName { get; set; }

        [JsonProperty("matching_text")]
        public string MatchingText { get; set; }

        [JsonProperty("matching_place_name")]
        public string MatchingPlaceName { get; set; }

        [JsonProperty("center")]
        public List<double> Center { get; set; }

        [JsonProperty("geometry")]
        public ForwardGeocodingGeometry ForwardGeocodingGeometry { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("context")]
        public List<ForwardGeocodingContext> Context { get; set; }
    }

    public class ForwardGeocoding
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("query")]
        public List<string> Query { get; set; }

        [JsonProperty("features")]
        public List<ForwardGeocodingFeature> Features { get; set; }

        [JsonProperty("attribution")]
        public string Attribution { get; set; }   
    }
}