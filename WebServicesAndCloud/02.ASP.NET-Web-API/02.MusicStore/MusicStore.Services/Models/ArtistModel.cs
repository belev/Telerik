namespace MusicStore.Services.Models
{
    using MusicStore.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;

    public class ArtistModel
    {
        public static Expression<Func<Artist, ArtistModel>> FromArtist
        {
            get
            {
                return a => new ArtistModel()
                {
                    ArtistId = a.ArtistId,
                    Name = a.Name,
                    Country = a.Country,
                    DateOfBirth = a.DateOfBirth
                };
            }
        }

        public int ArtistId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }

        [MinLength(3)]
        [MaxLength(20)]
        public string Country { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}