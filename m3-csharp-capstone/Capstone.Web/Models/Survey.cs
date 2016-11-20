using Capstone.Web.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Models
{
    public class Survey
    {
        public string ParkCode { get; set; }

        [Required(ErrorMessage = "* Email address is required")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "* State is required")]
        public string State { get; set; }

        [Required(ErrorMessage = "* Activity level is required")]
        public string ActivityLevel { get; set; }

        public string ParkName { get; set; }
       
    }

}
