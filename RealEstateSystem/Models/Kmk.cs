using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateSystem.Models
{
    





    public class Kmk
    {
        public Kmk()
        {
            kmkYsList = new List<KmkYs>();
        }
        public int kmkId { get; set; }

        public int kmkType { get;set;}

        public int requiredType { get; set; }

        public int zenteiKmkId { get; set; }
     
        public int joken { get; set; }

        public int jotai { get; set; }
        public int displaySort { get; set; }

        public List<KmkYs> kmkYsList { get; set; }
    }
}