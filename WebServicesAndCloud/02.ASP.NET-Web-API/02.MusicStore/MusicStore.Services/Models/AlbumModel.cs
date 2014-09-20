namespace MusicStore.Services.Models
{
    using MusicStore.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;

    public class AlbumModel
    {
        public static Expression<Func<Album, AlbumModel>> FromAlbum
        {
            get
            {
                return a => new AlbumModel()
                {
                    AlbumId = a.AlbumId,
                    Title = a.Title,
                    Year = a.Year,
                    Producer = a.Producer
                };
            }
        }

        public int AlbumId { get; set; }

        [Required]
        [MinLength(6)]
        public string Title { get; set; }

        public int Year { get; set; }

        public string Producer { get; set; }
    }
}