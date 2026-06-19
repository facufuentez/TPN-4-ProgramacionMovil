using System.Text.Json.Serialization;

namespace TPN_4_ProgramacionMovil.Models
{
    public class User
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("username")]
        public string Username { get; set; } = string.Empty;

        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public UserName? Name { get; set; }

        [JsonPropertyName("address")]
        public UserAddress? Address { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; } = string.Empty;
    }

    public class UserName
    {
        [JsonPropertyName("firstname")]
        public string Firstname { get; set; } = string.Empty;

        [JsonPropertyName("lastname")]
        public string Lastname { get; set; } = string.Empty;
    }

    public class UserAddress
    {
        [JsonPropertyName("city")]
        public string City { get; set; } = string.Empty;

        [JsonPropertyName("street")]
        public string Street { get; set; } = string.Empty;

        [JsonPropertyName("number")]
        public int Number { get; set; }

        [JsonPropertyName("zipcode")]
        public string Zipcode { get; set; } = string.Empty;

        [JsonPropertyName("geolocation")]
        public Geolocation? Geolocation { get; set; }
    }

    public class Geolocation
    {
        [JsonPropertyName("lat")]
        public string Lat { get; set; } = string.Empty;

        [JsonPropertyName("long")]
        public string Long { get; set; } = string.Empty;
    }
}
