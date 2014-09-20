namespace MusicStore.ConsoleClient.ServicesUtils
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using MusicStore.Models;
    using Newtonsoft.Json;

    public class SongsUtils
    {
        const string ContentType = "application/json";

        public static void AddSong(HttpClient client, string title, int year, string producer, int artistId)
        {
            var song = new Song()
            {
                Title = title,
                Year = year,
                Producer = producer,
                ArtistId = artistId
            };

            var content = new StringContent(JsonConvert.SerializeObject(song));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(ContentType);

            var response = client.PostAsync("api/songs/create", content).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Song added successfully.");
            }
            else
            {
                Console.WriteLine("Song have not been added.");
            }
        }

        public static void UpdateSong(HttpClient client, int songId, string title, int year, string producer, int artistId)
        {
            var song = new Song()
            {
                Title = title,
                Year = year,
                Producer = producer,
                ArtistId = artistId
            };

            var content = new StringContent(JsonConvert.SerializeObject(song));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(ContentType);

            var response = client.PutAsync("api/songs/update/" + songId, content).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Song updated successfully.");
            }
            else
            {
                Console.WriteLine("Song have not been updated.");
            }
        }

        public static void DeleteSong(HttpClient client, int songId)
        {
            var response = client.DeleteAsync("api/songs/delete/" + songId).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Song deleted successfully.");
            }
            else
            {
                Console.WriteLine("Song have not been deleted.");
            }
        }

        public static void GetAllSongs(HttpClient client)
        {
            var response = client.GetAsync("api/songs/all").Result;

            if (response.IsSuccessStatusCode)
            {
                var songs = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(songs);
            }
            else
            {
                Console.WriteLine("Could not get all songs.");
                Console.WriteLine("{0} ({1})", (int) response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void GetSongById(HttpClient client, int id)
        {
            var response = client.GetAsync("api/songs/byId/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                var song = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(song);
            }
            else
            {
                Console.WriteLine("Could not get song with id: " + id + " .");
                Console.WriteLine("{0} ({1})", (int) response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}