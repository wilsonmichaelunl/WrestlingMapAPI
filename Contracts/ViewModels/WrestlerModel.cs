using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.ViewModels
{
    public class WrestlerModel
    {
        public string Name { get; set; }
        public string State { get; set; }
        public string Team { get; set; }
        public string YearsChampion { get; set; }
        public string Hometown { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Weight { get; set; }
        public string WrestleStat { get; set; }
    }
}
