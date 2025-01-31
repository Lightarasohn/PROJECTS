using System.Text.Json;
using System.Text.Json.Serialization;
using Youtube_Spotify_Link_Converter;

var builder = WebApplication.CreateSlimBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "hello");
var todosApi = app.MapGroup("/convert");
todosApi.MapGet("/", () => "hello convert");
todosApi.MapGet("/youtubetospotify/{videoid}", async (string videoid) => await SpotifyAPI.GetSpotifyTrackUrlAsync(await YoutubeAPI.GetYoutubeVideoName(videoid)) + "\n" + await YoutubeAPI.GetYoutubeVideoName(videoid));
todosApi.MapGet("/spotifytoyoutube{songurl}", (string songurl) => $"spotify link, example:<{songurl}>, to youtube link");
app.Run();