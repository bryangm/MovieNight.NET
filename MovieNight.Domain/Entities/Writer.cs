using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MovieNight.Domain.Enums;

namespace MovieNight.Domain.Entities
{
    public class Writer
    {
        [Key]
        public int PersonId { get; set; }
        public int MovieId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
