﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieNight.Domain.Entities
{
    public class Submission
    {
        [Key]
        public int SubmissionId { get; set; }
        public int NightId { get; set; }
        public int MovieId { get; set; }
        public int Votes { get; set; }

        public virtual Night Night { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
