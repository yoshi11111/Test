using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateSystem.Models
{
    public class MasterItem
    {
        public MasterItem()
        {
            kmkLIst = new List<Kmk>();
        }
        public int id { get; set; }

        public int shoID { get; set; }

        public Kmk selectingKmk { get; set; }
        public string sho_Text { get; set; }
        public int kmkTypeDD { get; set; }

        public int requiredDD { get; set; }

        public int zenteiDD { get; set; }

        public int jokenDD { get; set; }

        public int jotaiDD { get; set; }


        public List<Kmk> kmkLIst { get; set; }
    }
}