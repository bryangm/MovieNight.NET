using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieNight.Domain.Entities
{
    public class Night
    {
        [Key]
        public int NightId { get; set; }
        public DateTime ViewBy { get; set; }

        public virtual List<Submission> Submissions { get; set; }
    }
}
