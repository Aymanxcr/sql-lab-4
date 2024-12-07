using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lab4
{
    // Class representing a GitHub project repository
    public class GitHubProjektRepo
    {
        // The name of the repository
        [JsonPropertyName("name")]
        public string Name { get; set; }

        // A short description of the repository
        [JsonPropertyName("description")]
        public string Description { get; set; }

        // The URL to access the repository on GitHub
        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; set; }

        // The homepage URL associated with the repository (if any)
        [JsonPropertyName("homepage")]
        public string Homepage { get; set; }

        // The number of watchers (people following the repository)
        [JsonPropertyName("watchers")]
        public int Watchers { get; set; }

        // The date and time of the last push to the repository
        [JsonPropertyName("pushed_at")]
        public string PushedAt { get; set; }
    }

    // Class representing information about a Zip Code
    public class ZipCodeInfo
    {
        // A list of places associated with the Zip Code
        [JsonPropertyName("places")]
        public List<Place> Places { get; set; }

        // The postal code
        [JsonPropertyName("post code")]
        public string PostCode { get; set; }
    }

    // Class representing a place within a Zip Code
    public class Place
    {
        // The name of the place
        [JsonPropertyName("place name")]
        public string Places { get; set; }

        // The state where the place is located
        [JsonPropertyName("state")]
        public string State { get; set; }

        // The latitude of the place
        [JsonPropertyName("latitude")]
        public string Latitude { get; set; }

        // The longitude of the place
        [JsonPropertyName("longitude")]
        public string Longitude { get; set; }
    }
}
