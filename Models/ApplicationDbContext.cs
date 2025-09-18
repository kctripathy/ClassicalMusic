using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;


namespace ClassicalMusicApp.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<ClassicalMusicApp.Models.Raaga> Raagas { get; set; }

        public System.Data.Entity.DbSet<ClassicalMusicApp.Models.AppResource> AppResources { get; set; }

        public System.Data.Entity.DbSet<ClassicalMusicApp.Models.MusicType> MusicTypes { get; set; }

        public System.Data.Entity.DbSet<ClassicalMusicApp.Models.Thaat> Thaats { get; set; }
    }
}