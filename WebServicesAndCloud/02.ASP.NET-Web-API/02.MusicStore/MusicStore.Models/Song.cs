namespace MusicStore.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Song
    {
        public int SongId { get; set; }

        [Required]
        [MinLength(6)]
        public string Title { get; set; }

        public int Year { get; set; }

        public string Producer { get; set; }

        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; }
    }
}