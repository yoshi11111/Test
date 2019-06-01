using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Manual.DataMng.Mdl;

namespace Manual
{
    public partial class ItemUC : UserControl
    {
        public BaseItem parent;
        public BaseItem item;

        public ItemUC(BaseItem parent, BaseItem item)
        {
            InitializeComponent();
            this.parent = parent;
            this.item = item;
            numericUpDown1.Value = item.sort;
            richTextBox1.Text = item.text;

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            parent.RemoveItem(this.item);
            Program.fm.ShowItems();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            BaseItem addItem;
            if (this.item is MajorItem)
            {
                addItem = new MiddleItem();
            }
            else
            {
                addItem = new SmallItem();

            }

            this.item.AddItem(addItem);
            Program.fm.ShowItems();
        }

        public void SetSmallItemProperty()
        {
            tableLayoutPanel1.ColumnStyles[3].Width = 0;



        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            item.text = richTextBox1.Text;
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
          
        }

        private void NumericUpDown1_Click(object sender, EventArgs e)
        {
            int sort = 0;
            if (int.TryParse(numericUpDown1.Value.ToString(), out sort))
            {
                this.item.sort = sort;
                //parent.SortItems();
                //parent.items = (from itm in parent.items
                //                orderby itm.sort
                //                select itm).ToList();
                Program.fm.ShowItems();
            }
        }
    }
}
