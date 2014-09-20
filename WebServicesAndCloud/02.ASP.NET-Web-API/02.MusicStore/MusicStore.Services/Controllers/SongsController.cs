namespace MusicStore.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using MusicStore.Data;
    using MusicStore.Services.Models;
    using MusicStore.Models;

    public class SongsController : ApiController
    {
        private IMusicStoreData data;

        public SongsController()
            : this(new MusicStoreData())
        {

        }

        public SongsController(IMusicStoreData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var songs = this.data.Songs
                .All()
                .Select(SongModel.FromSong);

            return Ok(songs);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var song = this.data.Songs
                .All()
                .Where(s => s.SongId == id)
                .Select(SongModel.FromSong)
                .FirstOrDefault();

            if (song == null)
            {
                return BadRequest("The song with id: " + id + " does not exists.");
            }

            return Ok(song);
        }

        [HttpPost]
        public IHttpActionResult Create(SongModel song)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            if (this.data.Artists.All().FirstOrDefault(a => a.ArtistId == song.ArtistId) == null)
            {
                return BadRequest("The song can not be added to this artist, because the artist with id: " + song.SongId + " does not exists.");
            }

            var newSong = new Song()
            {
                Title = song.Title,
                Year = song.Year,
                Producer = song.Producer,
                ArtistId = song.ArtistId
            };

            this.data.Songs.Add(newSong);
            this.data.SaveChanges();

            song.SongId = newSong.SongId;
            return Ok(song);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, SongModel song)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var songToUpdate = this.data.Songs
                                    .All()
                                    .FirstOrDefault(s => s.SongId == id);

            if (songToUpdate == null)
            {
                return BadRequest("The song with id: " + id + " does not exists.");
            }

            songToUpdate.Title = song.Title;
            songToUpdate.Year = song.Year;
            songToUpdate.Producer = song.Producer;
            songToUpdate.ArtistId = song.ArtistId;
            this.data.SaveChanges();

            song.SongId = songToUpdate.SongId;
            return Ok(song);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var songToDelete = this.data.Songs
                                    .All()
                                    .FirstOrDefault(s => s.SongId == id);

            if (songToDelete == null)
            {
                return BadRequest("The song with id: " + id + " does not exists.");
            }

            this.data.Songs.Delete(songToDelete);
            this.data.SaveChanges();

            return Ok();
        }
    }
}
