using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchSampleCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const string GitHubCsharpUrl = "https://gist.github.com/search?l=C%23&q=";


        private void button1_Click_1(object sender, EventArgs e)
        {
            // TODO xamarinでwin、android対応、ワードランダム表示、通勤中もしくは開発中参考用
            // TODO 毎回取得せずxmlにurlリスト
            string word = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(word))
            {
                return;
            }
            try
            {
                lbLd.Visible = true;
                ExecScrap(word);
            }
            catch (Exception ex)
            {
                lbLd.Visible = false;
                Console.WriteLine(ex.ToString());
            }
          
        }

        private delegate void DelegateUpdateText(int idx);

        private async void ExecScrap(string word)
        {
            Dictionary<string, string> urlDic = new Dictionary<string, string>();
            string uTmp = GitHubCsharpUrl + Uri.EscapeDataString(word);

            DelegateUpdateText del = LblChange;
            

            for (int i = 1; i < 50; i++)
            {
                this.BeginInvoke(del, i);

                string uri = uTmp + "&p=" + i;
                HttpClient client = new HttpClient();
                HttpResponseMessage res;
                res = await client.GetAsync(uri);
             
                Encoding enc = Encoding.GetEncoding("utf-8");
                string str = string.Empty;
                using (var stream = (await res.Content.ReadAsStreamAsync()))
                using (var reader = (new StreamReader(stream, enc, true)) as TextReader)
                {
                    str = await reader.ReadToEndAsync();
                }


                //System.Text.Encoding enc = System.Text.Encoding.GetEncoding(Encoding.UTF8.HeaderName);
                //string urlEncSjis = System.Web.HttpUtility.UrlEncode(url, enc);
                string descriptionStartStr = "class=\"description\">";
                string descriptionEndstr = "</span>";


                string urlStartStr = "class=\"link-overlay\" href=\"";
                string urlEndStr = "\"";

                int idx = 0;
                bool emptyPage = true;
                while (0 <= idx)
                {
                    string tmpDescription = string.Empty;
                    idx = str.IndexOf(descriptionStartStr);

                    if (0 <= idx)
                    {
                        str = str.Substring(idx + descriptionStartStr.Length);
                        tmpDescription = str.Substring(0, str.IndexOf(descriptionEndstr));

                    }


                    string tmpUrl = string.Empty;
                    idx = str.IndexOf(urlStartStr);
                    if (0 <= idx)
                    {
                        str = str.Substring(idx + urlStartStr.Length);
                        tmpUrl = str.Substring(0, str.IndexOf(urlEndStr));
                        if (!string.IsNullOrEmpty(tmpDescription) && !string.IsNullOrEmpty(tmpUrl))
                        {
                            emptyPage = false;
                            urlDic[tmpUrl.Trim()] = tmpDescription.Trim();
                        }
                    }
                }
                if (emptyPage)
                {
                    lbLd.Visible = false;
                    break;
                }


                // 1秒開ける
                Thread.Sleep(1000);
            }
            listView1.Items.Clear();

            foreach (KeyValuePair<string, string> kvp in urlDic)
            {
                ListViewItem item = new ListViewItem(new string[2] { kvp.Value, kvp.Key });

                listView1.Items.Add(item);

            }

        }

        private void LblChange(int i)
        {
            lbLd.Text = i+"ページ目";
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idx = 0;
                idx = listView1.SelectedItems[0].Index;
                string url = listView1.Items[idx].SubItems[1].Text.ToString();
                webBrowser1.Navigate(url);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                int scroll = Math.Min(webBrowser1.Document.Window.Size.Height, 1850);
                webBrowser1.Document.Window.ScrollTo(new Point(0, scroll));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            int width = listView1.Width;

            foreach (ColumnHeader ch in listView1.Columns)
            {
                ch.Width = width / 2;
            }
        }
    }
}
