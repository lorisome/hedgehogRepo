using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Park
    {
        public string parkName { get; set; }
        public string location { get; set; }
        public string summary { get; set; }
        public string imgName { get; set; }
        public int elevation { get; set; }
        public int acreage { get; set; }
        public int milesOfTrail { get; set; }
        public int numberOfCampsites { get; set; }
        public string climate { get; set; }
        public int yearFounded { get; set; }
        public string annualVisitorCount { get; set; }
        public double entryFee { get; set; }
        public string inspirationalQuote { get; set; }
        public string inspirationalQuoteSource { get; set; }
        public int numberOfAnimalSpecies { get; set; }



    }
}