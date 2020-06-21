using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateSystem.ViewModel
{
    public class MasterKmkVM
    {
        public bool 選択チェックボックス { get; set; }
        public int No { get; set; }
        public string 項目ID { get; set; }
        public string 項目種別 { get; set; }
        public string 項目条件 { get; set; }
        public string 項目内容 { get; set; }
        public string 前提項目ID { get; set; }
        public string 前提条件 { get; set; }

        public string 項目の状態 { get; set; }

    }

}