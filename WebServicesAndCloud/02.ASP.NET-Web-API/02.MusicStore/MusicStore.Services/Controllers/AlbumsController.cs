namespace MusicStore.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using MusicStore.Data;
    using MusicStore.Services.Models;
    using MusicStore.Models;

    public class AlbumsController : ApiController
    {
        private IMusicStoreData data;

        public AlbumsController() : this(new MusicStoreData())
        {
        }

        public AlbumsController(IMusicStoreData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var albums = this.data.Albums
                             .All()
                             .Select(AlbumModel.FromAlbum);

            return Ok(albums);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var album = this.data.Albums
                            .All()
                            .Where(a => a.AlbumId == id)
                            .Select(AlbumModel.FromAlbum)
                            .FirstOrDefault();

            if (album == null)
            {
                return BadRequest("The album with id: " + id + " does not exists.");
            }

            return Ok(album);
        }

        [HttpPost]
        public IHttpActionResult Create(AlbumModel album)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var newAlbum = new Album()
            {
                Title = album.Title,
                Year = album.Year,
                Producer = album.Producer
            };

            this.data.Albums.Add(newAlbum);
            this.data.SaveChanges();

            album.AlbumId = newAlbum.AlbumId;
            return Ok(album);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, AlbumModel album)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var albumToUpdate = this.data.Albums
                                    .All()
                                    .FirstOrDefault(a => a.AlbumId == id);
            if (albumToUpdate == null)
            {
                return BadRequest("The album with id: " + id + " does not exists.");
            }

            albumToUpdate.Producer = album.Producer;
            albumToUpdate.Title = album.Title;
            albumToUpdate.Year = album.Year;

            this.data.SaveChanges();

            album.AlbumId = albumToUpdate.AlbumId;
            return Ok(album);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var albumToDelete = this.data.Albums
                                    .All()
                                    .FirstOrDefault(a => a.AlbumId == id);

            if (albumToDelete == null)
            {
                return BadRequest("The album with id: " + id + " does not exists.");
            }

            this.data.Albums.Delete(albumToDelete);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddArtist(int id, int artistId)
        {
            var album = this.data.Albums
                            .All()
                            .FirstOrDefault(a => a.AlbumId == id);
            if (album == null)
            {
                return BadRequest("The album with id: " + id + " does not exists.");
            }

            var artist = this.data.Artists
                             .All()
                             .FirstOrDefault(a => a.ArtistId == artistId);

            if (artist == null)
            {
                return BadRequest("The artist with id: " + id + " does not exists.");
            }

            album.Artists.Add(artist);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddSong(int id, int songId)
        {
            var album = this.data.Albums
                            .All()
                            .FirstOrDefault(a => a.AlbumId == id);
            if (album == null)
            {
                return BadRequest("The album with id: " + id + " does not exists.");
            }

            var song = this.data.Songs
                             .All()
                             .FirstOrDefault(s => s.SongId == songId);

            if (song == null)
            {
                return BadRequest("The song with id: " + id + " does not exists.");
            }

            album.Songs.Add(song);
            this.data.SaveChanges();

            return Ok();
        }
    }
}