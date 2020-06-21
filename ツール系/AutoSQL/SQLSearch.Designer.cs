namespace AUTOSQL
{
    partial class SQLSearch
    {
        /// <summary> 
        /// 必要なデザイナー変数です。 
        /// </summary> 
        private System.ComponentModel.IContainer components = null;


        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。 
        /// </summary> 
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param> 
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows フォーム デザイナーで生成されたコード 


        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。 
        /// </summary> 
        private void InitializeComponent()
        {
            this.rtSQL = new System.Windows.Forms.RichTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnSv = new System.Windows.Forms.Button();
            this.btnRd = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.ckTable = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.autoSQL1 = new AUTOSQL.AutoSQL();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtSQL
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.rtSQL, 2);
            this.rtSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtSQL.Location = new System.Drawing.Point(2, 77);
            this.rtSQL.Margin = new System.Windows.Forms.Padding(2);
            this.rtSQL.Name = "rtSQL";
            this.rtSQL.Size = new System.Drawing.Size(314, 492);
            this.rtSQL.TabIndex = 1;
            this.rtSQL.Text = "";
            this.rtSQL.WordWrap = false;
            this.rtSQL.TextChanged += new System.EventHandler(this.rtSQL_TextChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanel3.SetColumnSpan(this.checkBox1, 2);
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox1.Location = new System.Drawing.Point(2, 2);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(314, 21);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "論理名　⇒　物理名";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnSv
            // 
            this.btnSv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSv.Enabled = false;
            this.btnSv.Location = new System.Drawing.Point(2, 573);
            this.btnSv.Margin = new System.Windows.Forms.Padding(2);
            this.btnSv.Name = "btnSv";
            this.btnSv.Size = new System.Drawing.Size(155, 21);
            this.btnSv.TabIndex = 6;
            this.btnSv.Text = "保存";
            this.btnSv.UseVisualStyleBackColor = true;
            this.btnSv.Click += new System.EventHandler(this.btnSv_Click);
            // 
            // btnRd
            // 
            this.btnRd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRd.Enabled = false;
            this.btnRd.Location = new System.Drawing.Point(161, 573);
            this.btnRd.Margin = new System.Windows.Forms.Padding(2);
            this.btnRd.Name = "btnRd";
            this.btnRd.Size = new System.Drawing.Size(155, 21);
            this.btnRd.TabIndex = 7;
            this.btnRd.Text = "読込";
            this.btnRd.UseVisualStyleBackColor = true;
            this.btnRd.Click += new System.EventHandler(this.btnRd_Click);
            // 
            // button2
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.button2, 2);
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(3, 53);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(312, 19);
            this.button2.TabIndex = 8;
            this.button2.Text = "SQL変換";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listView1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.listView1, 2);
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(3, 78);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(327, 490);
            this.listView1.TabIndex = 11;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // button3
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.button3, 2);
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(3, 53);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(327, 19);
            this.button3.TabIndex = 10;
            this.button3.Text = "テーブル名・カラム名論理名検索";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // textBox1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.textBox1, 2);
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(327, 19);
            this.textBox1.TabIndex = 9;
            // 
            // button1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.button1, 2);
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(3, 574);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(327, 19);
            this.button1.TabIndex = 12;
            this.button1.Text = "クリップボードから取り込み(論理名\\t物理名\\r\\n)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.checkBox2, 2);
            this.checkBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox2.Location = new System.Drawing.Point(3, 3);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(327, 19);
            this.checkBox2.TabIndex = 13;
            this.checkBox2.Text = "テーブル名を検索";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // ckTable
            // 
            this.ckTable.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.ckTable, 2);
            this.ckTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckTable.Location = new System.Drawing.Point(3, 28);
            this.ckTable.Name = "ckTable";
            this.ckTable.Size = new System.Drawing.Size(312, 19);
            this.ckTable.TabIndex = 14;
            this.ckTable.Text = "テーブル名を変換";
            this.ckTable.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(685, 628);
            this.tabControl1.TabIndex = 17;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.autoSQL1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(677, 602);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "設計書からSQL作成";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(677, 602);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "テーブル名項目名検索・SQL変換";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel3);
            this.splitContainer2.Size = new System.Drawing.Size(671, 596);
            this.splitContainer2.SplitterDistance = 333;
            this.splitContainer2.SplitterWidth = 20;
            this.splitContainer2.TabIndex = 16;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.button1, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.listView1, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.button3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.textBox1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.checkBox2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(333, 596);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.btnRd, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.btnSv, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.ckTable, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.checkBox1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.button2, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.rtSQL, 1, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(318, 596);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // autoSQL1
            // 
            this.autoSQL1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autoSQL1.Location = new System.Drawing.Point(3, 3);
            this.autoSQL1.Margin = new System.Windows.Forms.Padding(2);
            this.autoSQL1.Name = "autoSQL1";
            this.autoSQL1.Size = new System.Drawing.Size(671, 596);
            this.autoSQL1.TabIndex = 0;
            // 
            // SQLSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 628);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SQLSearch";
            this.Text = "AutoSQL";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }


        #endregion

        public System.Windows.Forms.RichTextBox rtSQL;
        public System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.Button btnSv;
        public System.Windows.Forms.Button btnRd;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.ListView listView1;
        public System.Windows.Forms.Button button3;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.CheckBox checkBox2;
        public System.Windows.Forms.CheckBox ckTable;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private AutoSQL autoSQL1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.SplitContainer splitContainer2;
    }
}

