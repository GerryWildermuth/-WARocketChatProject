using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SWARocketChat.Models
{
    public class App
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string AppName { get; set; }
        public virtual ICollection<AppLanguage> AppLanguages { get; set; }
        public virtual ICollection<AppLocation> AppLocations { get; set; }
    }

    public class Region
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string RegionName { get; set; }
        public string Manager { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
    }

    public class Location
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [StringLength(5)]
        public string GeoCode { get; set; }
        public virtual Region Regions { get; set; }
        [Required]
        public Guid RegionId { get; set; }
        public virtual ICollection<AppLocation> AppLocations { get; set; }
    }

    public class AppLocation
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; }
        [Required]
        public Guid AppId { get; set; }
        public virtual App App { get; set; }

        [Required, Url]
        public string Url { get; set; }
    }

    public class AppLanguage
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public Guid AppId { get; set; }
        public virtual App App { get; set; }
        [Required, MinLength(5, ErrorMessage = "Image must not be empty")]
        public string Image { get; set; }
        public string Thumbnail { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public Guid LanguageId { get; set; }
        public Language Language { get; set; }
    }

    public class Language
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required, MaxLength(3), MinLength(2)]
        public string LanguageCode { get; set; }
        public string LanguageName { get; set; }
        public string Image { get; set; }
    }

    public class ToolboxContext : DbContext
    {
        public DbSet<App> Apps { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<AppLocation> AppLocations { get; set; }
        public DbSet<AppLanguage> AppLanguages { get; set; }
        public DbSet<Language> Languages { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(@"server=localhost;port=3306;Database=ProjectRocketChat2;user=root;password=admin");
            }
        }
    }
    //Add-Migration *MigrationName*
    //Update-Database to apply the new migration to the database
}
