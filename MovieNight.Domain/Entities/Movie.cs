using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieNight.Domain.Entities
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Rating { get; set; }
        public int Length { get; set; }
        public DateTime ReleaseDate { get; set; }

        public virtual List<string> Genre { get; set; }
        public virtual List<Director> Directors { get; set; }
        public virtual List<Writer> Writers { get; set; }
        public virtual List<CastMember> CastMembers { get; set; } 
    }
}
