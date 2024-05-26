using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiakProject.Models
{
    public class AppStore
    {
        public long Id {  get; set; }
        public string TrackName { get; set; }
        public long SizeBytes { get; set; }
        public string Currency { get; set; }
        public long Price { get; set; }
        public long RatingCountTot { get; set; }
        public long RatingCountVer { get; set; }
        public double UserRating { get; set; }
        public double UserRatingVer { get; set; }
        public string Ver { get; set; }
        public string ContRating { get; set; }
        public string PrimeGenre { get; set; }
    }
}
