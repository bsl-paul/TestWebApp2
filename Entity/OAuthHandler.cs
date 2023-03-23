using System.Text.Json;
using TestWebApp2.Models;

namespace TestWebApp2.Entity;
public class OAuthHandler
{
    public static async Task<AccessTokenModel?> GetAccessTokenAsync()
    {
        string url = $"https://login.microsoftonline.com/{OAuthSettings.TenantId}/oauth2/v2.0/token";
        var data = new Dictionary<string, string>{
                {"grant_type","client_credentials"},
                {"scope","https://api.businesscentral.dynamics.com/.default"},
                {"client_id",OAuthSettings.ClientId},
                {"client_secret",OAuthSettings.ClientSecret}
            };

        using HttpClient client = new();
        var response = await client.PostAsync(url, new FormUrlEncodedContent(data));
        return await JsonSerializer.DeserializeAsync<AccessTokenModel>(await response.Content.ReadAsStreamAsync());
    }
}