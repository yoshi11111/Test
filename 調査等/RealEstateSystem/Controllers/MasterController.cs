using RealEstateSystem.Models;
using RealEstateSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static RealEstateSystem.Models.Const;
using RealEstateSystem.Extensions;
using System.Data.Entity.Core;

namespace RealEstateSystem.Controllers
{

    public class MasterController : Controller
    {
        //保存元のファイル名
        string fileName = @"C:\test\sample.xml";
        public string sessionKey = "sessionKey";


        // GET: Master
        public ActionResult Index(int? id)
        {
            保持データ data = LoadMasterViewModel(id);
            data.章ID = id;
            HttpContext.Session[sessionKey] = data;
            return View(CreateViewModel(data));
        }




        public ActionResult GetJokenList(string zenteiid)
        {
            保持データ data = (保持データ)HttpContext.Session[sessionKey];
            項目マスタ kmk = data.前提項目IDリスト.Where(m => m.項目Id == zenteiid).FirstOrDefault();
            if (kmk == null)
            {
                return null;
            }
            List<SelectListItem> items;
            if (kmk.項目種別 == (int)Const.項目種別列挙体.テキスト入力)
            {
                items = new List<SelectListItem>()
                {
                     new SelectListItem() { Value=(int)Joken_MiNyuryoku+"", Text="指定なし" },
                      new SelectListItem() { Value=(int)Joken_MiNyuryoku+"", Text="未入力" },
                      new SelectListItem() { Value=(int)Joken_Nyuryoku+"", Text="入力" }
                };
            }
            else
            {

                items = new List<SelectListItem>()
                {
                     new SelectListItem() { Value=(int)Joken_MiNyuryoku+"", Text="指定なし" }
                };
                items.AddRange(data.前提項目要素リスト.Where(m => m.項目ID == zenteiid).ToList().Select(s => new SelectListItem { Text = s.項目内容, Value = s.項目要素ID + "" }).ToList());

            }
            return Json(items, JsonRequestBehavior.AllowGet);
        }


        public const string EditKmkAll = "EdiKmkAll";

        [HttpPost]
        [Button(ButtonName = "addKmk")]
        [ActionName(EditKmkAll)]
        public ActionResult AddKmk(MasterViewModel postedItem)
        {
            保持データ data = (保持データ)HttpContext.Session[sessionKey];
            if (data == null)
            {
                data = new 保持データ();
            }
            項目マスタ kmk = new 項目マスタ();
            kmk.項目Id = data.編集用項目リスト.Count() + 1 + "";
            kmk.項目条件 = postedItem.項目条件;
            kmk.項目種別 = postedItem.項目種別;
            kmk.前提項目ID = postedItem.前提項目ID + "";
            kmk.項目の状態 = postedItem.項目の状態;
            kmk.テキスト = postedItem.テキスト;
            kmk.表示順 = data.編集用項目リスト.Count();
            data.編集用項目リスト.Add(kmk);
            data.選択中の項目 = null;
            data.編集用項目要素リスト.AddRange(data.一時データ項目要素リスト);
            data.一時データ項目要素リスト = new List<項目要素マスタ>();

            HttpContext.Session[sessionKey] = data;
            return View("Index", CreateViewModel(data));
        }

        [HttpPost]
        [Button(ButtonName = "clearKmk")]
        [ActionName(EditKmkAll)]
        public ActionResult ClearKmk(MasterViewModel postedItem)
        {
            保持データ data = (保持データ)HttpContext.Session[sessionKey];
            if (data == null)
            {
                data = new 保持データ();
            }
            data.選択中の項目 = null;

            HttpContext.Session[sessionKey] = data;
            return View("Index", CreateViewModel(data));
        }

        [HttpPost]
        [Button(ButtonName = "delKmk")]
        [ActionName(EditKmkAll)]
        public ActionResult DelKmk(MasterViewModel postedItem)
        {
            保持データ data = (保持データ)HttpContext.Session[sessionKey];
            if (data == null)
            {
                data = new 保持データ();
            }
            data.選択中の項目 = null;
            foreach (MasterKmkVM vm in postedItem.項目リスト)
            {
                if (!vm.選択チェックボックス)
                {
                    continue;
                }
                項目マスタ kmk = data.編集用項目リスト.Where(m => m.項目Id == vm.項目ID).FirstOrDefault();
                if (kmk != null)
                {
                    data.編集用項目リスト.Remove(kmk);
                }
            }
            data.編集用項目リスト = data.編集用項目リスト.OrderBy(m => m.表示順).ToList();
            for (int i = 0; i < data.編集用項目リスト.Count(); i++)
            {
                data.編集用項目リスト[i].表示順 = i + 1;
            }


            HttpContext.Session[sessionKey] = data;
            return View("Index", CreateViewModel(data));
        }


        [HttpPost]
        [Button(ButtonName = "addKmkYs")]
        [ActionName(EditKmkAll)]
        public ActionResult AddKmkYs(MasterViewModel postedItem)
        {
            保持データ data = (保持データ)HttpContext.Session[sessionKey];
            if (data == null)
            {
                data = new 保持データ();
            }
            項目要素マスタ kmkYs = new 項目要素マスタ();
            kmkYs.項目要素ID = data.一時データ項目要素リスト.Count() + 1;
            kmkYs.項目ID = postedItem.選択中項目ID;
            kmkYs.項目種別 = postedItem.項目種別;
            kmkYs.表示順 = data.一時データ項目要素リスト.Count();
            switch (postedItem.項目種別)
            {
                case (int)項目種別列挙体.テキスト入力:
                    kmkYs.文言前 = postedItem.文言前;
                    kmkYs.文言後 = postedItem.文言後;
                    kmkYs.改行 = postedItem.改行;
                    kmkYs.入力チェック = postedItem.入力チェック;


                    break;
                case (int)項目種別列挙体.チェックボックス:
                    kmkYs.項目内容 = postedItem.項目内容;



                    break;
                case (int)項目種別列挙体.ラジオボタン:
                    kmkYs.項目内容 = postedItem.項目内容;




                    break;
                default:
                    break;

            }
            data.一時データ項目要素リスト.Add(kmkYs);
            HttpContext.Session[sessionKey] = data;
            return View("Index", CreateViewModel(data));
        }

        public ActionResult KmkSelect(string kmkid)
        {
            保持データ data = (保持データ)HttpContext.Session[sessionKey];
            if (data == null)
            {
                data = new 保持データ();
            }
            項目マスタ kmk = data.編集用項目リスト.Where(m => m.項目Id == kmkid).FirstOrDefault();
            if (kmk != null)
            {
                data.選択中の項目 = kmk;
                data.一時データ項目要素リスト = data.編集用項目要素リスト.Where(m => m.項目ID == kmk.項目Id).ToList();

            }
            HttpContext.Session[sessionKey] = data;
            return View("Index", CreateViewModel(data));
        }


        public ActionResult KmkUp(string kmkid)
        {
            保持データ data = (保持データ)HttpContext.Session[sessionKey];
            if (data == null)
            {
                data = new 保持データ();
            }
            EditSortOrder(kmkid, true, ref data);
            HttpContext.Session[sessionKey] = data;
            return View("Index", CreateViewModel(data));
        }


        public ActionResult KmkDown(string kmkid)
        {
            保持データ data = (保持データ)HttpContext.Session[sessionKey];
            if (data == null)
            {
                data = new 保持データ();
            }
            EditSortOrder(kmkid, false, ref data);
            HttpContext.Session[sessionKey] = data;
            return View("Index", CreateViewModel(data));
        }


        public void EditSortOrder(string kmkID, bool doUp, ref 保持データ data)
        {

            項目マスタ kmk = data.編集用項目リスト.Where(m => m.項目Id == kmkID).FirstOrDefault();
            if (kmk != null)
            {
                data.編集用項目リスト = data.編集用項目リスト.OrderBy(m => m.表示順).ToList();
                int idx = data.編集用項目リスト.IndexOf(kmk);
                if (doUp)
                {
                    if (idx != 0)
                    {
                        int obj = (int)data.編集用項目リスト[idx].表示順;
                        int target = (int)data.編集用項目リスト[idx - 1].表示順;
                        data.編集用項目リスト[idx].表示順 = target;
                        data.編集用項目リスト[idx - 1].表示順 = obj;
                    }
                }
                else
                {
                    if (idx != data.編集用項目リスト.Count() - 1)
                    {
                        int obj = (int)data.編集用項目リスト[idx].表示順;
                        int target = (int)data.編集用項目リスト[idx + 1].表示順;
                        data.編集用項目リスト[idx].表示順 = target;
                        data.編集用項目リスト[idx + 1].表示順 = obj;
                    }


                }
            }
        }
        public ActionResult KmkysUp(int? kmkysid)
        {
            保持データ data = (保持データ)HttpContext.Session[sessionKey];
            if (data == null)
            {
                data = new 保持データ();
            }
            EditYsSortOrder((int)kmkysid, true, ref data);
            HttpContext.Session[sessionKey] = data;
            return View("Index", CreateViewModel(data));
        }


        public ActionResult KmkYsDown(int? kmkysid)
        {
            保持データ data = (保持データ)HttpContext.Session[sessionKey];
            if (data == null)
            {
                data = new 保持データ();
            }
            EditYsSortOrder((int)kmkysid, false, ref data);
            HttpContext.Session[sessionKey] = data;
            return View("Index", CreateViewModel(data));
        }


        public void EditYsSortOrder(int kmkysID, bool doUp, ref 保持データ data)
        {

            項目要素マスタ kmk = data.一時データ項目要素リスト.Where(m => m.項目要素ID == kmkysID).FirstOrDefault();
            if (kmk != null)
            {
                data.一時データ項目要素リスト = data.一時データ項目要素リスト.OrderBy(m => m.表示順).ToList();
                int idx = data.一時データ項目要素リスト.IndexOf(kmk);
                if (doUp)
                {
                    if (idx != 0)
                    {
                        int obj = (int)data.一時データ項目要素リスト[idx].表示順;
                        int target = (int)data.一時データ項目要素リスト[idx - 1].表示順;
                        data.一時データ項目要素リスト[idx].表示順 = target;
                        data.一時データ項目要素リスト[idx - 1].表示順 = obj;
                    }
                }
                else
                {
                    if (idx != data.一時データ項目要素リスト.Count() - 1)
                    {
                        int obj = (int)data.一時データ項目要素リスト[idx].表示順;
                        int target = (int)data.一時データ項目要素リスト[idx + 1].表示順;
                        data.一時データ項目要素リスト[idx].表示順 = target;
                        data.一時データ項目要素リスト[idx + 1].表示順 = obj;
                    }


                }
            }
        }


        public ActionResult KmkYsDel(int? kmkysid)
        {
            保持データ data = (保持データ)HttpContext.Session[sessionKey];
            if (data == null)
            {
                data = new 保持データ();
            }
            項目要素マスタ kmkYs = data.一時データ項目要素リスト.Where(m => m.項目要素ID == kmkysid).FirstOrDefault();
            if (kmkYs != null)
            {
                data.一時データ項目要素リスト.Remove(kmkYs);
            }
            HttpContext.Session[sessionKey] = data;
            return View("Index", CreateViewModel(data));
        }

        public MasterViewModel CreateViewModel(保持データ data)
        {
            DropDownInit(data);

            MasterViewModel ret = new MasterViewModel();
            int no = 0;
            foreach (項目マスタ 項目 in data.編集用項目リスト.OrderBy(m => m.表示順).ToList())
            {
                MasterKmkVM kmkVm = new MasterKmkVM();
                kmkVm.No = ++no;
                kmkVm.項目ID = 項目.項目Id + "";
                kmkVm.項目種別 = 項目.項目種別 + "";
                kmkVm.項目条件 = 項目.項目条件 + "";
                kmkVm.項目内容 = 項目.テキスト + "";
                kmkVm.前提項目ID = 項目.前提項目ID + "";
                kmkVm.項目の状態 = 項目.項目の状態 + "";

                ret.項目リスト.Add(kmkVm);

            }
            foreach (項目要素マスタ 項目要素 in data.一時データ項目要素リスト.OrderBy(m => m.表示順).ToList())
            {
                MasterKmkYsVM kmkYsVm = new MasterKmkYsVM();
                kmkYsVm.項目要素ID = 項目要素.項目要素ID;
                kmkYsVm.項目種別 = (int)項目要素.項目種別;
                kmkYsVm.項目内容 = 項目要素.項目内容 + "";

                ret.項目要素リスト.Add(kmkYsVm);

            }
            項目マスタ curKmk = data.選択中の項目;
            if (curKmk == null)
            {
                ret.項目種別 = 0;
                ret.項目条件 = 0;
                ret.項目の状態 = 0;
                ret.項目内容 = "";
                ret.前提項目ID = "";
                ret.前提条件 = 0;
                ret.テキスト = "";
                ret.選択中項目ID = null;
                ret.文言前 = string.Empty;
                ret.文言後 = string.Empty;

            }
            else
            {
                ret.項目種別 = (int)curKmk.項目種別;
                ret.項目条件 = (int)curKmk.項目条件;
                ret.項目の状態 = (int)curKmk.項目の状態;
                ret.項目内容 = "";
                ret.前提項目ID = curKmk.前提項目ID;
                ret.前提条件 = 0;
                ret.テキスト = curKmk.テキスト;
                ret.選択中項目ID = curKmk.項目Id;



            }

            ModelState.Clear();
            return ret;

        }









        public void DropDownInit(保持データ data)
        {

            // 項目種別
            ViewBag.KmkTypeOptions = new SelectListItem[] {
            new SelectListItem() { Value=(int)項目種別列挙体.テキスト表示+"", Text="テキスト表示" },
            new SelectListItem() { Value=(int)項目種別列挙体.テキスト入力+"", Text="テキスト入力" },
            new SelectListItem() { Value=(int)項目種別列挙体.チェックボックス+"", Text="チェックボックス" },
            new SelectListItem() { Value=(int)項目種別列挙体.ラジオボタン+"", Text="ラジオボタン" },
          };
            // 必須
            ViewBag.RequiredOptions = new SelectListItem[] {
            new SelectListItem() { Value=(int)RequiredType_Required+"", Text="必須" },
            new SelectListItem() { Value=(int)RequiredType_DontRequired+"", Text="必須ではない" },
          };



            //// 前提項目ID
            //ViewBag.ZenteiOptions = model.kmkLIst.Select(m => new SelectListItem() { Value = m.kmkId + "", Text = m.kmkId + "" }).ToArray();
            List<SelectListItem> def = new List<SelectListItem>() { new SelectListItem() { Text = "指定しない", Value = "0" } };
            List<SelectListItem> list = data.前提項目IDリスト.Where(m => m.項目Id !=  (data.選択中の項目==null?null: data.選択中の項目.項目Id)).Select(s => new SelectListItem { Text = s.項目Id, Value = s.項目Id }).ToList();
            def.AddRange(list);

            ViewBag.ZenteiOptions = def;


            // 条件
            ViewBag.JokenOptions = new SelectListItem[] {
            new SelectListItem() { Value=(int)Joken_MiNyuryoku+"", Text="指定なし" },
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

        }



        [HttpPost]
        public ActionResult SaveModel()
        {
            // セッションから取得
            保持データ data = (保持データ)HttpContext.Session[sessionKey];

            try
            {
                List<string> 編集前項目IDList = data.編集前項目リスト.Select(m => m.項目Id).ToList();
                List<string> 編集用項目IDList = data.編集用項目リスト.Select(m => m.項目Id).ToList();
                List<int> 編集前項目要素IDList = data.編集前項目要素リスト.Select(m => m.項目要素ID).ToList();
                List<int> 編集用項目要素IDList = data.編集用項目要素リスト.Select(m => m.項目要素ID).ToList();

                List<項目マスタ> 更新項目IDリスト = data.編集前項目リスト.Where(m => 編集用項目IDList.Contains(m.項目Id)).ToList();
                List<項目マスタ> 削除項目IDリスト = data.編集前項目リスト.Where(m => !編集用項目IDList.Contains(m.項目Id)).ToList();
                List<項目マスタ> 追加項目IDリスト = data.編集用項目リスト.Where(m => !編集前項目IDList.Contains(m.項目Id)).ToList();
                List<項目要素マスタ> 更新項目要素IDリスト = data.編集前項目要素リスト.Where(m => 編集用項目要素IDList.Contains(m.項目要素ID)).ToList();
                List<項目要素マスタ> 削除項目要素IDリスト = data.編集前項目要素リスト.Where(m => !編集用項目要素IDList.Contains(m.項目要素ID)).ToList();
                List<項目要素マスタ> 追加項目要素IDリスト = data.編集用項目要素リスト.Where(m => !編集前項目要素IDList.Contains(m.項目要素ID)).ToList();

                // TODO ロック制御
                // TODO 項ID処理


                //項目
                foreach (項目マスタ kmk in 更新項目IDリスト)
                {
                    項目マスタ 対象 = DBConnection.GetInstance().項目マスタ.Where(m => m.項目Id == kmk.項目Id).FirstOrDefault();
                    if (!Equals(kmk, 対象))
                    {
                        対象.項目条件 = kmk.項目条件;
                        対象.項目種別 = kmk.項目種別;
                        対象.前提項目ID = kmk.前提項目ID;
                        対象.項目の状態 = kmk.項目の状態;
                        対象.テキスト = kmk.テキスト;
                        対象.表示順 = kmk.表示順;
                    }
                }
                foreach (項目マスタ kmk in 削除項目IDリスト)
                {
                    DBConnection.GetInstance().項目マスタ.Remove(kmk);
                }
                foreach (項目マスタ kmk in 追加項目IDリスト)
                {
                    // TODO項処理
                    kmk.項ID = 1;

                    DBConnection.GetInstance().項目マスタ.Add(kmk);
                }
                //項目要素
                foreach (項目要素マスタ kmk in 更新項目要素IDリスト)
                {
                    項目要素マスタ 対象 = DBConnection.GetInstance().項目要素マスタ.Where(m => m.項目要素ID == kmk.項目要素ID).FirstOrDefault();
                    if (!Equals(kmk, 対象))
                    {
                        DBConnection.GetInstance().項目要素マスタ.Remove(対象);
                        DBConnection.GetInstance().項目要素マスタ.Add(kmk);
                    }
                }
                foreach (項目要素マスタ kmk in 削除項目要素IDリスト)
                {
                    DBConnection.GetInstance().項目要素マスタ.Remove(kmk);
                }
                foreach (項目要素マスタ kmk in 追加項目要素IDリスト)
                {
                    DBConnection.GetInstance().項目要素マスタ.Add(kmk);
                }



                DBConnection.GetInstance().SaveChanges();
            }
            catch (OptimisticConcurrencyException oex)
            {
                return View(oex.ToString());
            }
            catch (UpdateException uex)
            {
                return View(uex.ToString());
            }
            catch (ArgumentException aex)
            {
                return View(aex.ToString());
            }

            return View("Index", CreateViewModel(data));
        }

        public 保持データ LoadMasterViewModel(int? 章id)
        {

            保持データ ret = new 保持データ();
            try
            {
                List<int> 項idリスト = DBConnection.GetInstance().ガイダンス項マスタ.Where(m => m.ガイダンス章Id == 章id).Select(m => m.ガイダンス項Id).ToList();
                ret.編集前項目リスト = DBConnection.GetInstance().項目マスタ.Where(m => 項idリスト.Contains((int)m.項ID)).ToList();
                ret.編集用項目リスト = new List<項目マスタ>(ret.編集前項目リスト);
                List<string> 項目要素idリスト = ret.編集前項目リスト.Select(m => m.項目Id).ToList();
                ret.編集前項目要素リスト = DBConnection.GetInstance().項目要素マスタ.Where(m => 項目要素idリスト.Contains(m.項目ID)).ToList();
                ret.編集用項目要素リスト = new List<項目要素マスタ>(ret.編集前項目要素リスト);

                int? 前提ガイダンスメンバID = DBConnection.GetInstance().ガイダンス章マスタ.Where(m => m.章ID == 章id).Select(m => m.メンバマスタID).FirstOrDefault();
                List<int> 前提章IDリスト = DBConnection.GetInstance().ガイダンス章マスタ.Where(m => m.メンバマスタID == 前提ガイダンスメンバID).Select(m => m.章ID).ToList();
                List<int> 前提項IDリスト = DBConnection.GetInstance().ガイダンス項マスタ.Where(m => 前提章IDリスト.Contains((int)m.ガイダンス章Id)).Select(m => m.ガイダンス項Id).ToList();
                List<int> 前提項目種別 = new List<int>() { (int)Const.項目種別列挙体.チェックボックス, (int)Const.項目種別列挙体.ラジオボタン, (int)Const.項目種別列挙体.テキスト入力 };
                ret.前提項目IDリスト = DBConnection.GetInstance().項目マスタ.Where(m => 前提項IDリスト.Contains((int)m.項ID) && 前提項目種別.Contains((int)m.項目種別)).ToList();

                List<KeyValuePair<string, int>> 前提項目ID種別kvp = ret.前提項目IDリスト.Select(m => new KeyValuePair<string, int>(m.項目Id, (int)m.項目種別)).ToList();
                ret.前提項目要素リスト = new List<項目要素マスタ>();
                foreach (KeyValuePair<string, int> item in 前提項目ID種別kvp)
                {
                    ret.前提項目要素リスト.AddRange(DBConnection.GetInstance().項目要素マスタ.Where(m => m.項目ID == item.Key && m.項目種別 == item.Value).ToList());
                }


            }
            catch (Exception e)
            {
                string a = e.ToString();
                ret = new 保持データ();
            }
            return ret;


        }
    }
}