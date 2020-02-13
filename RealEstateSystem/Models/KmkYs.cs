using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateSystem.Models
{
    public class KmkYs
    {
        public int kmkYsId { get; set; }

        public int kmkType { get; set; }
        public string inputText_Prev { get; set; }
        public string inputText_Back { get; set; }
    
        public int input_Text_Sort { get; set; }
        public string checkBox_Text { get; set; }

        public int checkBox_Sort { get; set; }
        public string radio_Text { get; set; }
        public int radio_Sort { get; set; }


    }
}