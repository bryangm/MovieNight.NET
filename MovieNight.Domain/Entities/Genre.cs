using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNight.Domain.Enums;

namespace MovieNight.Domain.Entities
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        public int MovieId { get; set; }
        public GenreType Type { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
