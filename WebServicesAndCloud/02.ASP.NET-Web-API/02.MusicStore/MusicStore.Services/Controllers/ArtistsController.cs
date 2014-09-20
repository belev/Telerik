namespace MusicStore.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using MusicStore.Data;
    using MusicStore.Services.Models;
    using MusicStore.Models;

    public class ArtistsController : ApiController
    {
        private IMusicStoreData data;

        public ArtistsController() : this(new MusicStoreData())
        {
        }

        public ArtistsController(IMusicStoreData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var artists = this.data.Artists
                              .All()
                              .Select(ArtistModel.FromArtist);

            return Ok(artists);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var artist = this.data.Artists
                             .All()
                             .Where(a => a.ArtistId == id)
                             .Select(ArtistModel.FromArtist)
                             .FirstOrDefault();

            if (artist == null)
            {
                return BadRequest("The artist with id: " + id + " does not exists.");
            }

            return Ok(artist);
        }

        [HttpPost]
        public IHttpActionResult Create(ArtistModel artist)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var newArtist = new Artist()
            {
                Name = artist.Name,
                Country = artist.Country,
                DateOfBirth = artist.DateOfBirth
            };

            this.data.Artists.Add(newArtist);
            this.data.SaveChanges();

            artist.ArtistId = newArtist.ArtistId;
            return Ok(artist);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, ArtistModel artist)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var artistToUpdate = this.data.Artists
                                     .All()
                                     .FirstOrDefault(a => a.ArtistId == id);

            if (artistToUpdate == null)
            {
                return BadRequest("The artist with id: " + id + " does not exists.");
            }

            artistToUpdate.Name = artist.Name;
            artistToUpdate.Country = artist.Country;
            artistToUpdate.DateOfBirth = artist.DateOfBirth;
            this.data.SaveChanges();

            artist.ArtistId = artistToUpdate.ArtistId;
            return Ok(artist);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var artistToDelete = this.data.Artists
                                     .All()
                                     .FirstOrDefault(a => a.ArtistId == id);

            if (artistToDelete == null)
            {
                return BadRequest("The artist with id: " + id + " does not exists.");
            }

            this.data.Artists.Delete(artistToDelete);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddSong(int id, int songId)
        {
            var artist = this.data.Artists
                             .All()
                             .FirstOrDefault(a => a.ArtistId == id);
            if (artist == null)
            {
                return BadRequest("The artist with id: " + id + " does not exists.");
            }

            var song = this.data.Songs
                           .All()
                           .FirstOrDefault(s => s.SongId == songId);

            if (song == null)
            {
                return BadRequest("The song with id: " + songId + " does not exists.");
            }

            artist.Songs.Add(song);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddAlbum(int id, int albumId)
        {
            var artist = this.data.Artists
                             .All()
                             .FirstOrDefault(a => a.ArtistId == id);
            if (artist == null)
            {
                return BadRequest("The artist with id: " + id + " does not exists.");
            }

            var album = this.data.Albums
                            .All()
                            .FirstOrDefault(a => a.AlbumId == albumId);

            if (album == null)
            {
                return BadRequest("The album with id: " + albumId + " does not exists.");
            }

            artist.Albums.Add(album);
            this.data.SaveChanges();

            return Ok();
        }
    }
}