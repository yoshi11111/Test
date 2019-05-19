namespace TaskEst
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.FLP3 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDai = new System.Windows.Forms.Button();
            this.btnSyo = new System.Windows.Forms.Button();
            this.FLP1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tblHeader = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.FLP2 = new System.Windows.Forms.FlowLayoutPanel();
            this.button4 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tblHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(321, 1175);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.FLP3);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(313, 1146);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "プロセス";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // FLP3
            // 
            this.FLP3.AllowDrop = true;
            this.FLP3.AutoScroll = true;
            this.FLP3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLP3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FLP3.Location = new System.Drawing.Point(3, 3);
            this.FLP3.Name = "FLP3";
            this.FLP3.Size = new System.Drawing.Size(307, 1140);
            this.FLP3.TabIndex = 0;
            this.FLP3.WrapContents = false;
            this.FLP3.DragDrop += new System.Windows.Forms.DragEventHandler(this.flowLayoutPanel2_DragDrop);
            this.FLP3.DragEnter += new System.Windows.Forms.DragEventHandler(this.flowLayoutPanel2_DragEnter);
            this.FLP3.Resize += new System.EventHandler(this.FLP3_Resize);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(313, 1146);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "タスク";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00063F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.99813F));
            this.tableLayoutPanel1.Controls.Add(this.btnDai, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSyo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.FLP1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox1, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.button3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.button1, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.button2, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.FLP2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.button4, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.55555F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.77778F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(307, 1140);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btnDai
            // 
            this.btnDai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDai.Font = new System.Drawing.Font("メイリオ", 9F);
            this.btnDai.Location = new System.Drawing.Point(3, 3);
            this.btnDai.Name = "btnDai";
            this.btnDai.Size = new System.Drawing.Size(70, 29);
            this.btnDai.TabIndex = 1;
            this.btnDai.Text = "大追加";
            this.btnDai.UseVisualStyleBackColor = true;
            this.btnDai.Click += new System.EventHandler(this.btnDai_Click);
            // 
            // btnSyo
            // 
            this.btnSyo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSyo.Font = new System.Drawing.Font("メイリオ", 9F);
            this.btnSyo.Location = new System.Drawing.Point(79, 3);
            this.btnSyo.Name = "btnSyo";
            this.btnSyo.Size = new System.Drawing.Size(70, 29);
            this.btnSyo.TabIndex = 6;
            this.btnSyo.Text = "小追加";
            this.btnSyo.UseVisualStyleBackColor = true;
            this.btnSyo.Click += new System.EventHandler(this.btnSyo_Click);
            // 
            // FLP1
            // 
            this.FLP1.AutoScroll = true;
            this.tableLayoutPanel1.SetColumnSpan(this.FLP1, 4);
            this.FLP1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLP1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FLP1.Location = new System.Drawing.Point(3, 68);
            this.FLP1.Name = "FLP1";
            this.FLP1.Size = new System.Drawing.Size(301, 552);
            this.FLP1.TabIndex = 7;
            this.FLP1.WrapContents = false;
            this.FLP1.Resize += new System.EventHandler(this.FLP1_Resize);
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 4);
            this.panel1.Controls.Add(this.tblHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(301, 24);
            this.panel1.TabIndex = 8;
            // 
            // tblHeader
            // 
            this.tblHeader.ColumnCount = 5;
            this.tblHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tblHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tblHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tblHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tblHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblHeader.Controls.Add(this.label1, 0, 0);
            this.tblHeader.Controls.Add(this.label2, 1, 0);
            this.tblHeader.Controls.Add(this.label3, 2, 0);
            this.tblHeader.Controls.Add(this.label6, 3, 0);
            this.tblHeader.Controls.Add(this.label7, 4, 0);
            this.tblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblHeader.Location = new System.Drawing.Point(0, 0);
            this.tblHeader.Name = "tblHeader";
            this.tblHeader.RowCount = 1;
            this.tblHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblHeader.Size = new System.Drawing.Size(301, 24);
            this.tblHeader.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("メイリオ", 8F);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "優先度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("メイリオ", 10F);
            this.label2.Location = new System.Drawing.Point(53, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "タスク";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("メイリオ", 8F);
            this.label3.Location = new System.Drawing.Point(154, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "見積工数";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("メイリオ", 8F);
            this.label6.Location = new System.Drawing.Point(204, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 24);
            this.label6.TabIndex = 5;
            this.label6.Text = "完了";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("メイリオ", 8F);
            this.label7.Location = new System.Drawing.Point(254, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 24);
            this.label7.TabIndex = 6;
            this.label7.Text = "削除";
            // 
            // richTextBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.richTextBox1, 4);
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 975);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(301, 162);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label8, 3);
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("メイリオ", 10F);
            this.label8.Location = new System.Drawing.Point(3, 937);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(222, 35);
            this.label8.TabIndex = 10;
            this.label8.Text = "メモ・優先度低いタスク等";
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Font = new System.Drawing.Font("メイリオ", 9F);
            this.button3.Location = new System.Drawing.Point(155, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(70, 29);
            this.button3.TabIndex = 3;
            this.button3.Text = "再表示";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label4, 2);
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 623);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 35);
            this.label4.TabIndex = 12;
            this.label4.Text = "共有事項・ﾙｰﾁﾝ";
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(155, 626);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 29);
            this.button1.TabIndex = 13;
            this.button1.Text = "追加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(231, 626);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(73, 29);
            this.button2.TabIndex = 14;
            this.button2.Text = "再表示";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FLP2
            // 
            this.FLP2.AutoScroll = true;
            this.tableLayoutPanel1.SetColumnSpan(this.FLP2, 4);
            this.FLP2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLP2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FLP2.Location = new System.Drawing.Point(3, 661);
            this.FLP2.Name = "FLP2";
            this.FLP2.Size = new System.Drawing.Size(301, 273);
            this.FLP2.TabIndex = 15;
            this.FLP2.WrapContents = false;
            this.FLP2.Resize += new System.EventHandler(this.FLP2_Resize);
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Location = new System.Drawing.Point(231, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(73, 29);
            this.button4.TabIndex = 16;
            this.button4.Text = "保存";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 1175);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tblHeader.ResumeLayout(false);
            this.tblHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnDai;
        private System.Windows.Forms.Button btnSyo;
        private System.Windows.Forms.FlowLayoutPanel FLP1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tblHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.FlowLayoutPanel FLP3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FlowLayoutPanel FLP2;
        private System.Windows.Forms.Button button4;
    }
}












