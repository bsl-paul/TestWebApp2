using System.Text.Json.Serialization;

namespace TestWebApp2.Models;
public class AccessTokenModel
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }
        [JsonPropertyName("expires_in")]
        public long ExpiresIn { get; set; }
        [JsonPropertyName("scope")]
        public string Scope { get; set; }

        private long tokenStartTime;
        private long tokenExpiresInTicks { get { return ExpiresIn * 1000; } }

        public AccessTokenModel()
        {
            tokenStartTime = DateTime.Now.Ticks;
            this.AccessToken = "";
            this.TokenType = "";
            this.ExpiresIn = 0;
            this.Scope = "";
        }

        public bool IsExpired()
        {
            return (tokenStartTime + tokenExpiresInTicks > DateTime.Now.Ticks) ? true : false;
        }
    }