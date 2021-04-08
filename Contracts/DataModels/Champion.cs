using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Contracts.DataModels
{
    public class Champion
    {
        [Key]
        public Guid ChampionID { get; set; }
        public Guid WrestlerID { get; set; }
        public int Year { get; set; }
        public string Team { get; set; }
        public int Weight { get; set; }

        // Virtual Properties
        public virtual Wrestler Wrestler { get; set; }
    }
}
