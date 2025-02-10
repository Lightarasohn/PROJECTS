using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

namespace Youtube_Spotify_Link_Converter;

public class YoutubeAPI
{
    private static readonly string apiKey = "<YOUR_API_KEY>";
    private static string pattern = @"\s*-\s*|\(.*?\)|\[.*?\]|\bHD\b";
    public static async Task<string> GetYoutubeVideoName(string VideoID)
    {
        // API anahtarını buraya yaz
        string videoId = VideoID;
        string url = "https://www.googleapis.com/youtube/v3/videos";

        // Parametreler
        var parameters = new[]
        {
        $"part=snippet",     // Video bilgisi için snippet kısmını istiyoruz
        $"id={videoId}",     // Video ID'si
        $"key={apiKey}"      // API anahtarı
    };

        // Parametreleri URL'ye ekle
        string requestUrl = $"{url}?{string.Join("&", parameters)}";

        // HttpClient ile isteği gönder
        using (HttpClient client = new HttpClient())
        {
            // Set the Referer header
            client.DefaultRequestHeaders.Referrer = new Uri("http://localhost:5142"); // Replace with your actual referer URL

            try
            {
                HttpResponseMessage response = await client.GetAsync(requestUrl);
                response.EnsureSuccessStatusCode(); // Hata durumlarında exception fırlatır
                string responseBody = await response.Content.ReadAsStringAsync();

                // JSON'u parse et
                var json = JsonObject.Parse(responseBody);
                // Video başlığını al
                var items = json!["items"];
                if (items != null)
                {
                    string videoTitle = (string)items[0]!["snippet"]!["title"]!;
                    if (videoTitle != null) {
                        while (Regex.IsMatch(videoTitle, pattern))
                        {
                            videoTitle = Regex.Replace(videoTitle, pattern, " ").Trim();
                        }
                        videoTitle = Regex.Replace(videoTitle, @"\s+", " ");
                        return videoTitle;
                            }
                    else
                        return "bulunamadi";
                    
                }
                else
                {
                    return "Video bulunamadı!";
                }
            }
            catch (Exception)
            {
                return "bulunamadi";
            }
        }
    }


    public static async Task<string> GetYoutubeVideoUrl(string query)
    {
        string apiUrl = $"https://www.googleapis.com/youtube/v3/search?part=snippet&q={Uri.EscapeDataString(query)}&maxResults=1&type=video&key={apiKey}";

        using HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync(apiUrl);

        if (response.IsSuccessStatusCode)
        {
            string jsonResponse = await response.Content.ReadAsStringAsync();
            using JsonDocument doc = JsonDocument.Parse(jsonResponse);
            JsonElement root = doc.RootElement;

            if (root.TryGetProperty("items", out JsonElement items) && items.GetArrayLength() > 0)
            {
                string videoId = items[0].GetProperty("id").GetProperty("videoId").GetString()!;
                return $"https://music.youtube.com/watch?v={videoId}";
            }
        }

        return await response.Content.ReadAsStringAsync();
    }

    private static string ExtractYouTubeVideoId(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
            return string.Empty;

        // YouTube linklerinden video ID’yi yakalamak için Regex desenleri
        string pattern = @"(?:youtu\.be/|youtube\.com/(?:.*v=|embed/|shorts/|watch\?v=))([^&?/]+)";

        Match match = Regex.Match(url, pattern);
        return match.Success ? match.Groups[1].Value : string.Empty;
    }
}
