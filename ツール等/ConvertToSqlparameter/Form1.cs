using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertToSqlparameter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> ret = new List<string>();
            List<string> tmpList = richTextBox1.Text.Split(';').ToList();
            string tgt = @"\{\s*[0-9]\s*\}";
            for (int i = 0; i < tmpList.Count(); i++)
            {
                string line = tmpList[i];
                if (!Regex.IsMatch(line, tgt))
                {
                    ret.Add(line);
                    continue;
                }
                bool isLikeSql = line.ToUpper().Contains(" LIKE ");
                // AppendFormat or string.Format
                bool isStringFormat = line.Contains("string.Format");
                if (isStringFormat)
                {
                    // 不要部削除
                    line = line.Replace("string.Format(", "");
                    line = line.Remove(line.LastIndexOf(@")"));
                }
                line = line.Replace("AppendFormat", "Append");
                int paramStart = line.LastIndexOf("\"") + 1;
                int paramEnd = line.LastIndexOf(@")");
                string paramStrLine = line.Substring(paramStart, (paramEnd - paramStart));
                List<string> paramStrList = paramStrLine.Split(',').ToList();
                // 最初の要素を削除
                paramStrList.RemoveAt(0);
                Dictionary<string, string> paramDic = new Dictionary<string, string>();
                MatchCollection matche = Regex.Matches(line, tgt);
                for (int k = 0; k < matche.Count; k++)
                {
                    Match m = matche[k];
                    // string paramName = "param" + k;
                    string paramName = paramStrList[k].Trim();
                    line = line.Replace(m.Value, "@" + paramName);
                    paramDic[paramName] = paramStrList[k];
                }
                // 不要部削除
                line = line.Replace(paramStrLine, "");
                ret.Add(line);
                ret.Add("List<SqlParameter> paramList = new List<SqlParameter>()");
                foreach (KeyValuePair<string, string> kvp in paramDic)
                {
                    ret.Add($"paramList.Add(new SqlParameter(\"{kvp.Key}\",{kvp.Value} ))");
                }
                if (isLikeSql)
                {
                    ret.Add("contains LIKE !!!!");
                }
            }
            StringBuilder sb = new StringBuilder();
            foreach (string line in ret)
            {
                sb.AppendLine(line + ";");
            }
            richTextBox1.Text = sb.ToString();
        }
    }
}
