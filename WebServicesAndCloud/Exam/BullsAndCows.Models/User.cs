namespace Exam.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public User()
            : base()
        {
            this.Guesses = new HashSet<Guess>();
        }

        public int WinsCount { get; set; }

        public int LoosesCount { get; set; }

        [MinLength(4)]
        [MaxLength(4)]
        public string NumberToGuess { get; set; }

        public virtual ICollection<Guess> Guesses { get; set; }
    }
}