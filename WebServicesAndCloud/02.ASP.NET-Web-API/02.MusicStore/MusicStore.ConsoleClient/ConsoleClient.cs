namespace MusicStore.ConsoleClient
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using MusicStore.ConsoleClient.ServicesUtils;

    internal class ConsoleClient
    {
        const string BaseAddressUri = "http://localhost:3861";

        private static HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri(BaseAddressUri)
        };

        private static void Main()
        {
            AlbumsUtilsUsage();
            ArtistsUtilsUsage();
            SongsUtilsUsage();

            ArtistsUtils.AddSong(client, 2, 2);
            ArtistsUtils.AddSong(client, 1, 1);
            ArtistsUtils.AddAlbum(client, 2, 1);
            ArtistsUtils.AddAlbum(client, 3, 3);
        }

        private static void AlbumsUtilsUsage()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            AlbumsUtils.AddAlbum(client, "test consuming services", 2000, "services consumer");
            AlbumsUtils.AddAlbum(client, "test 2", 2000, "test 2");

            Console.WriteLine("All albums: ");
            AlbumsUtils.GetAllAlbums(client);

            Console.WriteLine("------------------------");

            Console.WriteLine("Album with id = 1:");
            AlbumsUtils.GetAlbumById(client, 1);

            Console.WriteLine("Album before update:");
            AlbumsUtils.GetAlbumById(client, 2);
            Console.WriteLine("*****************************************");

            AlbumsUtils.UpdateAlbum(client, 2, "updated for test", 100, "updated producer test");

            Console.WriteLine("Album after update:");
            AlbumsUtils.GetAlbumById(client, 2);
            Console.WriteLine("*****************************************");

            AlbumsUtils.DeleteAlbum(client, 2);
        }

        private static void ArtistsUtilsUsage()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            ArtistsUtils.AddArtist(client, "test 1", "test country 1", new DateTime(1993, 5, 5));
            ArtistsUtils.AddArtist(client, "test 2", "test country 2", new DateTime(1994, 3, 15));
            ArtistsUtils.AddArtist(client, "test 3", "test country 3", new DateTime(1998, 1, 18));
            ArtistsUtils.AddArtist(client, "test 4", "test country 4", new DateTime(1993, 10, 2));

            Console.WriteLine("All artists: ");
            ArtistsUtils.GetAllArtists(client);

            Console.WriteLine("-------------------------------------------");

            Console.WriteLine("Artist with id = 4: ");
            ArtistsUtils.GetArtistById(client, 4);

            Console.WriteLine("Artist before update:");
            ArtistsUtils.GetArtistById(client, 3);
            Console.WriteLine("**********************************************");

            ArtistsUtils.UpdateArtist(client, 3, "updated 3", "updated country 3", DateTime.Now);

            Console.WriteLine("Artist after update:");
            ArtistsUtils.GetArtistById(client, 3);
            Console.WriteLine("**********************************************");

            ArtistsUtils.DeleteArtist(client, 4);
            ArtistsUtils.GetArtistById(client, 4);
        }

        private static void SongsUtilsUsage()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            SongsUtils.AddSong(client, "test consuming services", 2000, "services consumer", 1);
            SongsUtils.AddSong(client, "test 2", 2000, "test 2", 1);

            Console.WriteLine("All songs: ");
            SongsUtils.GetAllSongs(client);

            Console.WriteLine("------------------------");

            Console.WriteLine("Song with id = 1:");
            SongsUtils.GetSongById(client, 2);

            Console.WriteLine("Song before update:");
            SongsUtils.GetSongById(client, 1);
            Console.WriteLine("*****************************************");

            SongsUtils.UpdateSong(client, 1, "updated song title", 1500, "updated song producer", 2);

            Console.WriteLine("Song after update:");
            SongsUtils.GetSongById(client, 1);
            Console.WriteLine("*****************************************");

            SongsUtils.DeleteSong(client, 1);
        }
    }
}