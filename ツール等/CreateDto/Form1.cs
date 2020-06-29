using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CreateDto
{
    public partial class Form1 : Form
    {
        public class Row
        {
            public string ColNameSnake { get; set; }
            public string ColNamePascal { get; set; }
            public string Type { get; set; }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tableName = ToPascal(textBox1.Text.ToLower());
            List<Row> List = new List<Row>();
            using (System.IO.StringReader rs = new System.IO.StringReader(richTextBox1.Text))
            {
                while (rs.Peek() > -1)
                {
                    Row row = new Row();
                    if (!IsValid(rs.ReadLine(), ref row))
                    {
                        continue;
                    }
                    List.Add(row);
                }
            }
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"public class {tableName}");
            sb.AppendLine("{");
            foreach(Row row in List)
            {
                sb.AppendLine($"[DataColumn(name=\"{row.ColNameSnake}\")]");
                sb.AppendLine($"public {row.Type} {row.ColNamePascal}"+"{get;set;}");
            }
            sb.AppendLine("}");
            richTextBox1.Text = sb.ToString();
        }

        private bool IsValid(string line, ref Row row)
        {
            line = line.Replace(" ", "");
            line = line.Replace("　", "");
            string[] vals = line.Split(',');
            try
            {
                if (vals.Count() != 2)
                {
                    return false;
                }
                foreach (string val in vals)
                {
                    if (string.IsNullOrEmpty(val) || val.Contains("\"") || val.Contains("\'"))
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            row.ColNameSnake = vals[0];
            row.ColNamePascal = ToPascal(vals[0].ToLower());
            row.Type = ConvertType(vals[1]);
            return true;
        }


        public string ConvertType(string type)
        {
            type = type.Replace("NVARCHAR", "string");
            type = type.Replace("DATETIME", "DateTime?");
            type = type.Replace("DECIMAL", "decimal?");
            return type;
        }


        private static string ToPascal(string text)
        {
            return Regex.Replace(
                text.Replace("_", " "),
                @"\b[a-z]",
                match => match.Value.ToUpper()).Replace(" ", "");
        }
    }

}
