using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateSystem.Models
{
    public static class Const
    {
        public const int RequiredType_Required = 0;
        public const int RequiredType_DontRequired = 0;
        public const int Joken_Nyuryoku = 0;
        public const int Joken_MiNyuryoku = 1;
        public const int Joken_Sentaku = 2;
        public const int Joken_Misentaku = 3;
        public const int Jotai_Hyoji = 0;
        public const int Jotai_Hihyoji = 1;


        public  enum 項目種別列挙体{
            テキスト表示=0,
            テキスト入力=1,
            ラジオボタン=2,
            チェックボックス=3
        }
    }
}