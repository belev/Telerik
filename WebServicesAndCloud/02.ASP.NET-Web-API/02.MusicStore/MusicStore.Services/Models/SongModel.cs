namespace MusicStore.Services.Models
{
    using MusicStore.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;

    public class SongModel
    {
        public static Expression<Func<Song, SongModel>> FromSong
        {
            get
            {
                return s => new SongModel()
                {
                    SongId = s.SongId,
                    Title = s.Title,
                    Year = s.Year,
                    Producer = s.Producer,
                    ArtistId = s.ArtistId
                };
            }
        }

        public int SongId { get; set; }

        [Required]
        [MinLength(6)]
        public string Title { get; set; }

        public int Year { get; set; }

        public string Producer { get; set; }

        public int ArtistId { get; set; }
    }
}