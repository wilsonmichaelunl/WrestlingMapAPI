using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.DataModels
{
    public class State
    {
        public int StateID { get; set; }
        public string PostalAbbreviation { get; set; }
        public string StateName { get; set; }

        // Virtual Properties
        public List<Wrestler> Wrestlers { get; set; }
    }
}
