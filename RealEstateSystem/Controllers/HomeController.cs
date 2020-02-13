using RealEstateSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static RealEstateSystem.Models.Const;

namespace RealEstateSystem.Controllers
{
    public class HomeController : Controller
    {

        //保存元のファイル名
        string fileName = @"C:\test\sample.xml";
        // GET: Home
        public ActionResult Index()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult SaveModel()
        {
            // セッションから取得
            MasterItem model = (MasterItem)HttpContext.Session[sessionKey];

            try
            {

                //保存先のファイル名
                string fileName = @"C:\test\sample.xml";

                //XmlSerializerオブジェクトを作成
                //オブジェクトの型を指定する
                System.Xml.Serialization.XmlSerializer serializer =
                    new System.Xml.Serialization.XmlSerializer(typeof(MasterItem));
                //書き込むファイルを開く（UTF-8 BOM無し）
                System.IO.StreamWriter sw = new System.IO.StreamWriter(
                    fileName, false, new System.Text.UTF8Encoding(false));
                //シリアル化し、XMLファイルに保存する
                serializer.Serialize(sw, model);
                //ファイルを閉じる
                sw.Close();
            }
            catch (Exception e)
            {
                string a = e.ToString();
            }
            DropDownInit(model);
            return View("Master", model);
        }




        public string sessionKey = "sessionKey";
        public ActionResult Master()
        {
            MasterItem model;
            try
            {
                //XmlSerializerオブジェクトを作成
                System.Xml.Serialization.XmlSerializer serializer =
                    new System.Xml.Serialization.XmlSerializer(typeof(MasterItem));
                //読み込むファイルを開く
                System.IO.StreamReader sr = new System.IO.StreamReader(
                    fileName, new System.Text.UTF8Encoding(false));
                //XMLファイルから読み込み、逆シリアル化する
                model = (MasterItem)serializer.Deserialize(sr);
                //ファイルを閉じる
                sr.Close();

            }
            catch (Exception e)
            {
                string a = e.ToString();
                model = new MasterItem();
            }

            DropDownInit(model);
            HttpContext.Session[sessionKey] = model;

            return View(model);
        }
        [HttpPost]
        public ActionResult AddKmk(MasterItem postedItem)
        {
            MasterItem model = (MasterItem)HttpContext.Session[sessionKey];
            if (model == null)
            {
                model = new MasterItem();
            }
            Kmk kmk = new Kmk();
            kmk.requiredType = postedItem.requiredDD;
            kmk.kmkType = postedItem.kmkTypeDD;
            kmk.kmkId = model.kmkLIst.Count() + 1;
            kmk.zenteiKmkId = postedItem.zenteiDD;
            kmk.joken = postedItem.jokenDD;
            kmk.jotai = postedItem.jotaiDD;

            model.kmkLIst.Add(kmk);

            DropDownInit(model);
            HttpContext.Session[sessionKey] = model;
            return View("Master", model);
        }

        [HttpPost]
        public ActionResult SelectKmk(Kmk kmk)
        {
            MasterItem model = (MasterItem)HttpContext.Session[sessionKey];
            model.selectingKmk = kmk;
            DropDownInit(model);
            HttpContext.Session[sessionKey] = model;
            return View("Master", model);
        }





        public void DropDownInit(MasterItem model)
        {

            // 項目種別
            ViewBag.KmkTypeOptions = new SelectListItem[] {
            new SelectListItem() { Value=(int)KmkType_ShowText+"", Text="テキスト表示" },
            new SelectListItem() { Value=(int)KmkType_InputText+"", Text="テキスト入力" },
            new SelectListItem() { Value=(int)KmkType_CheckBox+"", Text="チェックボックス" },
            new SelectListItem() { Value=(int)KmkType_RadioButton+"", Text="ラジオボタン" },
          };
            // 必須
            ViewBag.RequiredOptions = new SelectListItem[] {
            new SelectListItem() { Value=(int)RequiredType_Required+"", Text="必須" },
            new SelectListItem() { Value=(int)RequiredType_DontRequired+"", Text="必須ではない" },
          };



            // 前提項目ID
            ViewBag.ZenteiOptions = model.kmkLIst.Select(m => new SelectListItem() { Value = m.kmkId + "", Text = m.kmkId + "" }).ToArray();


            // 条件
            ViewBag.JokenOptions = new SelectListItem[] {
            new SelectListItem() { Value=(int)Joken_MiNyuryoku+"", Text="未入力" },
            new SelectListItem() { Value=(int)Joken_Nyuryoku+"", Text="入力" },
            new SelectListItem() { Value=(int)Joken_Misentaku+"", Text="未選択" },
            new SelectListItem() { Value=(int)Joken_Sentaku+"", Text="選択" },
                    };
            // 状態
            ViewBag.JotaiOptions = new SelectListItem[] {
            new SelectListItem() { Value=(int)Jotai_Hyoji+"", Text="非表示" },
            new SelectListItem() { Value=(int)Jotai_Hyoji+"", Text="表示" },



          };

            model.kmkTypeDD = 0;
            model.requiredDD = 0;
            model.zenteiDD = 0;
            model.jotaiDD = 0;
            model.jokenDD = 0;
 



        }

    }
}