namespace MusicStore.ConsoleClient.ServicesUtils
{
    using MusicStore.Models;
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using System.Net.Http;

    public class AlbumsUtils
    {
        const string ContentType = "application/json";

        public static void AddAlbum(HttpClient client, string title, int year, string producer)
        {
            var album = new Album()
            {
                Title = title,
                Year = year,
                Producer = producer
            };

            var content = new StringContent(JsonConvert.SerializeObject(album));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(ContentType);

            var response = client.PostAsync("api/albums/create", content).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Album added successfully.");
            }
            else
            {
                Console.WriteLine("Album have not been added.");
            }
        }

        public static void UpdateAlbum(HttpClient client, int albumId, string title, int year, string producer)
        {
            var album = new Album()
            {
                Title = title,
                Year = year,
                Producer = producer
            };

            var content = new StringContent(JsonConvert.SerializeObject(album));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(ContentType);

            var response = client.PutAsync("api/albums/update/" + albumId, content).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Album updated successfully.");
            }
            else
            {
                Console.WriteLine("Album have not been updated.");
            }
        }

        public static void DeleteAlbum(HttpClient client, int albumId)
        {
            var response = client.DeleteAsync("api/albums/delete/" + albumId).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Album deleted successfully.");
            }
            else
            {
                Console.WriteLine("Album have not been deleted.");
            }
        }

        public static void GetAllAlbums(HttpClient client)
        {
            var response = client.GetAsync("api/albums/all").Result;

            if (response.IsSuccessStatusCode)
            {
                var albums = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(albums);
            }
            else
            {
                Console.WriteLine("Could not get all albums.");
                Console.WriteLine("{0} ({1})", (int) response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void GetAlbumById(HttpClient client, int id)
        {
            var response = client.GetAsync("api/albums/byId/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                var album = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(album);
            }
            else
            {
                Console.WriteLine("Could not get album with id: " + id + " .");
                Console.WriteLine("{0} ({1})", (int) response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
