namespace AUTOSQL
{
    partial class AutoSQL
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbselect = new System.Windows.Forms.TextBox();
            this.tbjoin = new System.Windows.Forms.TextBox();
            this.tbwhere = new System.Windows.Forms.TextBox();
            this.tborder = new System.Windows.Forms.TextBox();
            this.tbgroup = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.richLeft = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.richRightUP = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.richRightDown = new System.Windows.Forms.RichTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.checkBox3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbselect, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbjoin, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbwhere, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.tborder, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbgroup, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkBox1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(857, 771);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanel1.SetColumnSpan(this.checkBox3, 2);
            this.checkBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox3.Location = new System.Drawing.Point(5, 4);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(159, 26);
            this.checkBox3.TabIndex = 16;
            this.checkBox3.Text = "常に前面表示";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(172, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(446, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Where";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(309, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Join";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(583, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Order By";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(720, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Group By";
            // 
            // tbselect
            // 
            this.tbselect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbselect.Enabled = false;
            this.tbselect.Location = new System.Drawing.Point(172, 37);
            this.tbselect.Name = "tbselect";
            this.tbselect.ReadOnly = true;
            this.tbselect.Size = new System.Drawing.Size(131, 25);
            this.tbselect.TabIndex = 5;
            // 
            // tbjoin
            // 
            this.tbjoin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbjoin.Enabled = false;
            this.tbjoin.Location = new System.Drawing.Point(309, 37);
            this.tbjoin.Name = "tbjoin";
            this.tbjoin.ReadOnly = true;
            this.tbjoin.Size = new System.Drawing.Size(131, 25);
            this.tbjoin.TabIndex = 6;
            // 
            // tbwhere
            // 
            this.tbwhere.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbwhere.Enabled = false;
            this.tbwhere.Location = new System.Drawing.Point(446, 37);
            this.tbwhere.Name = "tbwhere";
            this.tbwhere.ReadOnly = true;
            this.tbwhere.Size = new System.Drawing.Size(131, 25);
            this.tbwhere.TabIndex = 7;
            // 
            // tborder
            // 
            this.tborder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tborder.Enabled = false;
            this.tborder.Location = new System.Drawing.Point(583, 37);
            this.tborder.Name = "tborder";
            this.tborder.ReadOnly = true;
            this.tborder.Size = new System.Drawing.Size(131, 25);
            this.tborder.TabIndex = 8;
            // 
            // tbgroup
            // 
            this.tbgroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbgroup.Enabled = false;
            this.tbgroup.Location = new System.Drawing.Point(720, 37);
            this.tbgroup.Name = "tbgroup";
            this.tbgroup.ReadOnly = true;
            this.tbgroup.Size = new System.Drawing.Size(134, 25);
            this.tbgroup.TabIndex = 9;
            // 
            // splitContainer1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.splitContainer1, 7);
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 71);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.richLeft);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(851, 697);
            this.splitContainer1.SplitterDistance = 283;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 10;
            // 
            // richLeft
            // 
            this.richLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richLeft.Location = new System.Drawing.Point(0, 0);
            this.richLeft.MinimumSize = new System.Drawing.Size(251, 4);
            this.richLeft.Name = "richLeft";
            this.richLeft.Size = new System.Drawing.Size(283, 643);
            this.richLeft.TabIndex = 1;
            this.richLeft.Text = "";
            this.richLeft.WordWrap = false;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Location = new System.Drawing.Point(0, 643);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(283, 54);
            this.button1.TabIndex = 0;
            this.button1.Text = "１．SQL設計書の内容を\r\n上枠内に貼り付け、クリック";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.richRightUP, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.button2, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.button3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.richRightDown, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(563, 697);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // richRightUP
            // 
            this.richRightUP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richRightUP.Location = new System.Drawing.Point(3, 3);
            this.richRightUP.Name = "richRightUP";
            this.richRightUP.Size = new System.Drawing.Size(557, 294);
            this.richRightUP.TabIndex = 1;
            this.richRightUP.Text = "";
            this.richRightUP.WordWrap = false;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(3, 651);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(557, 43);
            this.button2.TabIndex = 0;
            this.button2.Text = "３．変換後SQLをA5SQLツール上で調整し、再度上枠に張り付けクリック";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(3, 303);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(557, 42);
            this.button3.TabIndex = 2;
            this.button3.Text = "２．論理名を物理名に変換";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // richRightDown
            // 
            this.richRightDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richRightDown.Location = new System.Drawing.Point(3, 351);
            this.richRightDown.Name = "richRightDown";
            this.richRightDown.Size = new System.Drawing.Size(557, 294);
            this.richRightDown.TabIndex = 3;
            this.richRightDown.Text = "";
            this.richRightDown.WordWrap = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.checkBox1, 2);
            this.checkBox1.Location = new System.Drawing.Point(5, 38);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(98, 22);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "サブクエリ";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // AutoSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AutoSQL";
            this.Size = new System.Drawing.Size(857, 771);
            this.Load += new System.EventHandler(this.AutoSQL_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbselect;
        private System.Windows.Forms.TextBox tbjoin;
        private System.Windows.Forms.TextBox tbwhere;
        private System.Windows.Forms.TextBox tborder;
        private System.Windows.Forms.TextBox tbgroup;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox richLeft;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richRightUP;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox richRightDown;
        private SQLSearch sqlSearch1;
        private System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.CheckBox checkBox3;
    }
}



