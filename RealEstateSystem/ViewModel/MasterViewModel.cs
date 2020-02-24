using RealEstateSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateSystem.ViewModel
{
    public class MasterViewModel
    {
        public MasterViewModel()
        {
            章ID = 0;
            項目種別 = 0;
            項目条件 = 0;
            前提項目ID ="";
            前提条件 = 0;
            項目の状態 = 0;
            項目要素リスト = new List<MasterKmkYsVM>();
            項目リスト = new List<MasterKmkVM>();
        }

        public string 選択中項目ID { get; set; }
       
        public int 章ID { get; set; }
        public string 章タイトル { get; set; }

        public string 検索キーワード { get; set; }

        public int 項目種別 { get; set; }

        public int 項目条件 { get; set; }

        public string 文言前 { get; set; }

        public string 文言後 { get; set; }

        public string 項目内容 { get; set; }

        public int 改行 { get; set; }
        public int 入力チェック { get; set; }

        public string 前提項目ID { get; set; }

        public int 前提条件 { get; set; }

        public int 項目の状態 { get; set; }
        public string テキスト { get; set; }

        public List<MasterKmkYsVM> 項目要素リスト { get; set; }

        public List<MasterKmkVM> 項目リスト { get; set; }




    }

}