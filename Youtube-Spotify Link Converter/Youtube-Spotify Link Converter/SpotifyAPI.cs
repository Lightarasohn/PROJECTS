using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;

namespace Youtube_Spotify_Link_Converter;

public class SpotifyAPI
{
    private static readonly HttpClient HttpClient = new HttpClient();

    public static async Task<string> GetSpotifyTrackName(string trackUrl) {
        string token = await GetSpotifyAccessTokenAsync();
        if (string.IsNullOrEmpty(token)) return "Token alınamadı.";

        string searchUrl = $"https://api.spotify.com/v1/search?q={Uri.EscapeDataString(trackUrl)}&type=track&limit=1";

        using var request = new HttpRequestMessage(HttpMethod.Get, searchUrl);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        using var response = await HttpClient.SendAsync(request);
        if (!response.IsSuccessStatusCode) return "Şarkı bulunamadı.";

        string jsonResponse = await response.Content.ReadAsStringAsync();
        using JsonDocument json = JsonDocument.Parse(jsonResponse);
        var track = json.RootElement
            .GetProperty("name")
            .ToString();
        return track;
    }

    public static async Task<string> GetSpotifyTrackUrlAsync(string trackName)
    {
        string token = await GetSpotifyAccessTokenAsync();
        if (string.IsNullOrEmpty(token)) return "Token alınamadı.";

        string searchUrl = $"https://api.spotify.com/v1/search?q={Uri.EscapeDataString(trackName)}&type=track&limit=1";

        using var request = new HttpRequestMessage(HttpMethod.Get, searchUrl);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        using var response = await HttpClient.SendAsync(request);
        if (!response.IsSuccessStatusCode) return "Şarkı bulunamadı.";

        string jsonResponse = await response.Content.ReadAsStringAsync();
        using JsonDocument json = JsonDocument.Parse(jsonResponse);
        
        string trackUrl = json.RootElement
            .GetProperty("tracks")
            .GetProperty("items")[0]
            .GetProperty("external_urls")
            .GetProperty("spotify")
            .GetString();

        return trackUrl ?? "URL bulunamadı.";
    }

    private static async Task<string> GetSpotifyAccessTokenAsync()
    {
        string tokenUrl = "https://accounts.spotify.com/api/token";
        string credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{ClientId}:{ClientSecret}"));

        using var request = new HttpRequestMessage(HttpMethod.Post, tokenUrl);
        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", credentials);
        request.Content = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");

        using var response = await HttpClient.SendAsync(request);
        if (!response.IsSuccessStatusCode) return string.Empty;

        string jsonResponse = await response.Content.ReadAsStringAsync();
        using JsonDocument json = JsonDocument.Parse(jsonResponse);

        return json.RootElement.GetProperty("access_token").GetString();
    }
}
