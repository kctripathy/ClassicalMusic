using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassicalMusicApp.Models
{
    public class Language
    {
        public int ID { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(100)]
        public string Name_en { get; set; }

        public virtual ICollection<Composition> Compositions { get; set; }
    }

    public class UserRole
    {
        public int ID { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        public virtual ICollection<AppUser> Users { get; set; }
    }

    public class RagaType
    {
        public int ID { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public virtual ICollection<Thaat> Thaats { get; set; }
    }

    public class Thaat
    {
        public int ID { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(1000)]
        public string Description { get; set; }

        public int? RagaTypeID { get; set; }

        [ForeignKey("RagaTypeID")]
        public virtual RagaType RagaType { get; set; }

        public virtual ICollection<Raga> Ragas { get; set; }
    }

    public class Tala
    {
        public int ID { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        public int? Bits { get; set; }

        [StringLength(10)]
        public string Talis { get; set; }

        [StringLength(10)]
        public string Khalis { get; set; }

        [StringLength(200)]
        public string Bol { get; set; }

        public virtual ICollection<Composition> Compositions { get; set; }
    }

    public class Artist
    {
        public int ID { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Role { get; set; } // Vocalist, Instrumentalist, Composer

        [StringLength(200)]
        public string Biography { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        public virtual ICollection<Composition> Compositions { get; set; }
        public virtual ICollection<Performance> Performances { get; set; }
    }

    public class Raga
    {
        public int ID { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Time { get; set; }

        [StringLength(200)]
        public string Mood { get; set; }

        [StringLength(200)]
        public string Aroh { get; set; }

        [StringLength(200)]
        public string Avroh { get; set; }

        [StringLength(2)]
        public string Vadi { get; set; }

        [StringLength(2)]
        public string Samvadi { get; set; }

        [StringLength(150)]
        public string Pakad { get; set; }

        [StringLength(1500)]
        public string Swara { get; set; }

        public int? ThaatID { get; set; }

        [ForeignKey("ThaatID")]
        public virtual Thaat Thaat { get; set; }

        public virtual ICollection<Composition> Compositions { get; set; }
    }

    public class Composition
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string MadeFor { get; set; } // Vocal, Flute, etc.

        [Required, StringLength(200)]
        public string Title { get; set; }

        [StringLength(200)]
        public string Lyrics { get; set; }

        public int? LanguageID { get; set; }
        public int? RagaID { get; set; }
        public int? TalaID { get; set; }
        public int? ComposerID { get; set; }

        [ForeignKey("LanguageID")]
        public virtual Language Language { get; set; }

        [ForeignKey("RagaID")]
        public virtual Raga Raga { get; set; }

        [ForeignKey("TalaID")]
        public virtual Tala Tala { get; set; }

        [ForeignKey("ComposerID")]
        public virtual Artist Composer { get; set; }

        public virtual ICollection<CompositionAlap> Alaps { get; set; }
        public virtual ICollection<CompositionNotations> Notations { get; set; }
        public virtual ICollection<Performance> Performances { get; set; }
    }

    public class CompositionAlap
    {
        public int ID { get; set; }

        public int LineNumber { get; set; }

        [StringLength(500)]
        public string Notations { get; set; }

        public int CompositionID { get; set; }

        [ForeignKey("CompositionID")]
        public virtual Composition Composition { get; set; }
    }

    public class CompositionNotations
    {
        public int ID { get; set; }

        [StringLength(2)]
        public string LineType { get; set; } // ST, AN, AL, GA, TA

        public int LineNumber { get; set; }
        public int BITNumber { get; set; }

        [StringLength(10)]
        public string Notations { get; set; }

        public int CompositionID { get; set; }

        [ForeignKey("CompositionID")]
        public virtual Composition Composition { get; set; }
    }

    public class Performance
    {
        public int ID { get; set; }

        public DateTime? Date { get; set; }

        [StringLength(200)]
        public string Venue { get; set; }

        public int? ArtistID { get; set; }
        public int? CompositionID { get; set; }

        [StringLength(200)]
        public string Notes { get; set; }

        [ForeignKey("ArtistID")]
        public virtual Artist Artist { get; set; }

        [ForeignKey("CompositionID")]
        public virtual Composition Composition { get; set; }

        public virtual ICollection<Recording> Recordings { get; set; }
    }

    public class Recording
    {
        public int ID { get; set; }

        [StringLength(500)]
        public string FilePath { get; set; }

        [StringLength(50)]
        public string RecordingFormat { get; set; }

        public int? Duration { get; set; } // seconds

        public int PerformanceID { get; set; }

        [ForeignKey("PerformanceID")]
        public virtual Performance Performance { get; set; }
    }

    public class AppUser
    {
        public int ID { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; }

        [Required, StringLength(200)]
        public string Email { get; set; }

        [StringLength(50)]
        public string SubscriptionType { get; set; }

        public DateTime? JoinDate { get; set; }

        public int? RoleID { get; set; }

        [ForeignKey("RoleID")]
        public virtual UserRole Role { get; set; }
    }
}
