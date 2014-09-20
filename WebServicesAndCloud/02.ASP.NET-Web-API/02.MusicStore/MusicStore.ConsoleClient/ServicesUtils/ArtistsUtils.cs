namespace MusicStore.ConsoleClient.ServicesUtils
{
    using MusicStore.Models;
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using System.Net.Http;

    public class ArtistsUtils
    {
        const string ContentType = "application/json";

        public static void AddArtist(HttpClient client, string name, string country, DateTime dateOfBirth)
        {
            var artist = new Artist()
            {
                Name = name,
                Country = country,
                DateOfBirth = dateOfBirth
            };

            var content = new StringContent(JsonConvert.SerializeObject(artist));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(ContentType);

            var response = client.PostAsync("api/artists/create", content).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist added successfully.");
            }
            else
            {
                Console.WriteLine("Artist have not been added.");
            }
        }

        public static void UpdateArtist(HttpClient client, int artistId, string name, string country, DateTime dateOfBirth)
        {
            var artist = new Artist()
            {
                Name = name,
                Country = country,
                DateOfBirth = dateOfBirth
            };

            var content = new StringContent(JsonConvert.SerializeObject(artist));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(ContentType);

            var response = client.PutAsync("api/artists/update/" + artistId, content).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist updated successfully.");
            }
            else
            {
                Console.WriteLine("Artist have not been updated.");
            }
        }

        public static void DeleteArtist(HttpClient client, int artistId)
        {
            var response = client.DeleteAsync("api/artists/delete/" + artistId).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist deleted successfully.");
            }
            else
            {
                Console.WriteLine("Artist have not been deleted.");
            }
        }

        public static void GetAllArtists(HttpClient client)
        {
            var response = client.GetAsync("api/artists/all").Result;

            if (response.IsSuccessStatusCode)
            {
                var artists = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(artists);
            }
            else
            {
                Console.WriteLine("Could not get all artists.");
                Console.WriteLine("{0} ({1})", (int) response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void GetArtistById(HttpClient client, int id)
        {
            var response = client.GetAsync("api/artists/byId/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                var artist = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(artist);
            }
            else
            {
                Console.WriteLine("Could not get artist with id: " + id + " .");
                Console.WriteLine("{0} ({1})", (int) response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void AddSong(HttpClient client, int artistId, int songId) 
        {
            var response = client.PostAsync("api/artists/addSong/" + artistId + "?songId=" + songId, new StringContent("")).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Song added successfully to artist.");
            }
            else
            {
                Console.WriteLine("Song have been added to artist.");
            }
        }

        public static void AddAlbum(HttpClient client, int artistId, int albumId) 
        {
            var response = client.PostAsync("api/artists/addAlbum/" + artistId + "?albumId=" + albumId, new StringContent("")).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Album added successfully to artist.");
            }
            else
            {
                Console.WriteLine("Album have been added to artist.");
            }
        }
    }
}
