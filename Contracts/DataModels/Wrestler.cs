using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.DataModels
{
    public class Wrestler
    {
        public Guid WrestlerID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Hometown { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int StateID { get; set; }
        public string WrestleStat { get; set; }

        // Virtual Properties
        public virtual List<Champion> Champions { get; set; }
        public virtual State State { get; set; }
    }
}
