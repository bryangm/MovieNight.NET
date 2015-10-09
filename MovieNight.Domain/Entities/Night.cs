using System;
using System.Collections.Generic;

namespace MovieNight.Domain.Entities
{
    public class Night
    {
        public int NightId { get; set; }
        public DateTime ViewBy { get; set; }
        public List<Submission> Submissions { get; set; }
    }
}
