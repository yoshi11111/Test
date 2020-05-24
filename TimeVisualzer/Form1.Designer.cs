namespace ExcelTopMemoLink
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.PnlMemoPage = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.TbSrc = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.RichForSearch = new System.Windows.Forms.RichTextBox();
            this.BtnClear = new System.Windows.Forms.Button();
            this.BtnUnder = new System.Windows.Forms.Button();
            this.BtnBold = new System.Windows.Forms.Button();
            this.BtnRed = new System.Windows.Forms.Button();
            this.BtnBlue = new System.Windows.Forms.Button();
            this.BtnBlack = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.FLP3 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.PressTimer = new System.Windows.Forms.Timer(this.components);
            this.MinutesTimer = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.AllowDrop = true;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 48);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(884, 430);
            this.tabControl1.TabIndex = 9;
            this.tabControl1.Resize += new System.EventHandler(this.tabControl1_Resize);
            // 
            // tabPage1
            // 
            this.tabPage1.AllowDrop = true;
            this.tabPage1.Controls.Add(this.flowLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(876, 398);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "時間";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.AllowDrop = true;
            this.tabPage2.Controls.Add(this.tableLayoutPanel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(876, 398);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "メモ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 392F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(870, 392);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(2, 2);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.PnlMemoPage);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox1);
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel4);
            this.splitContainer1.Size = new System.Drawing.Size(866, 388);
            this.splitContainer1.SplitterDistance = 43;
            this.splitContainer1.TabIndex = 1;
            // 
            // PnlMemoPage
            // 
            this.PnlMemoPage.AutoScroll = true;
            this.PnlMemoPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMemoPage.Location = new System.Drawing.Point(0, 0);
            this.PnlMemoPage.Margin = new System.Windows.Forms.Padding(2);
            this.PnlMemoPage.Name = "PnlMemoPage";
            this.PnlMemoPage.Size = new System.Drawing.Size(822, 39);
            this.PnlMemoPage.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(822, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "＋";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 37);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(862, 300);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 10;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.Controls.Add(this.TbSrc, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.button2, 9, 0);
            this.tableLayoutPanel4.Controls.Add(this.RichForSearch, 8, 0);
            this.tableLayoutPanel4.Controls.Add(this.BtnClear, 7, 0);
            this.tableLayoutPanel4.Controls.Add(this.BtnUnder, 6, 0);
            this.tableLayoutPanel4.Controls.Add(this.BtnBold, 5, 0);
            this.tableLayoutPanel4.Controls.Add(this.BtnRed, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.BtnBlue, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.BtnBlack, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.button4, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(862, 37);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // TbSrc
            // 
            this.TbSrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbSrc.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TbSrc.Location = new System.Drawing.Point(2, 2);
            this.TbSrc.Margin = new System.Windows.Forms.Padding(2);
            this.TbSrc.Name = "TbSrc";
            this.TbSrc.Size = new System.Drawing.Size(528, 27);
            this.TbSrc.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(824, 2);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(36, 33);
            this.button2.TabIndex = 1;
            this.button2.Text = "透";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.SaveClicked);
            // 
            // RichForSearch
            // 
            this.RichForSearch.Location = new System.Drawing.Point(816, 4);
            this.RichForSearch.Margin = new System.Windows.Forms.Padding(4);
            this.RichForSearch.Name = "RichForSearch";
            this.RichForSearch.Size = new System.Drawing.Size(2, 29);
            this.RichForSearch.TabIndex = 6;
            this.RichForSearch.Text = "";
            this.RichForSearch.Visible = false;
            // 
            // BtnClear
            // 
            this.BtnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnClear.Font = new System.Drawing.Font("MS UI Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnClear.Location = new System.Drawing.Point(774, 2);
            this.BtnClear.Margin = new System.Windows.Forms.Padding(2);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(36, 33);
            this.BtnClear.TabIndex = 5;
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.FontChange);
            // 
            // BtnUnder
            // 
            this.BtnUnder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnUnder.Font = new System.Drawing.Font("MS UI Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnUnder.Location = new System.Drawing.Point(734, 2);
            this.BtnUnder.Margin = new System.Windows.Forms.Padding(2);
            this.BtnUnder.Name = "BtnUnder";
            this.BtnUnder.Size = new System.Drawing.Size(36, 33);
            this.BtnUnder.TabIndex = 4;
            this.BtnUnder.Text = "＿";
            this.BtnUnder.UseVisualStyleBackColor = true;
            this.BtnUnder.Click += new System.EventHandler(this.FontChange);
            // 
            // BtnBold
            // 
            this.BtnBold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnBold.Font = new System.Drawing.Font("MS UI Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnBold.Location = new System.Drawing.Point(694, 2);
            this.BtnBold.Margin = new System.Windows.Forms.Padding(2);
            this.BtnBold.Name = "BtnBold";
            this.BtnBold.Size = new System.Drawing.Size(36, 33);
            this.BtnBold.TabIndex = 3;
            this.BtnBold.Text = "B";
            this.BtnBold.UseVisualStyleBackColor = true;
            this.BtnBold.Click += new System.EventHandler(this.FontChange);
            // 
            // BtnRed
            // 
            this.BtnRed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnRed.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnRed.ForeColor = System.Drawing.Color.Red;
            this.BtnRed.Location = new System.Drawing.Point(654, 2);
            this.BtnRed.Margin = new System.Windows.Forms.Padding(2);
            this.BtnRed.Name = "BtnRed";
            this.BtnRed.Size = new System.Drawing.Size(36, 33);
            this.BtnRed.TabIndex = 0;
            this.BtnRed.Text = "A";
            this.BtnRed.UseVisualStyleBackColor = false;
            this.BtnRed.Click += new System.EventHandler(this.FontChange);
            // 
            // BtnBlue
            // 
            this.BtnBlue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnBlue.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnBlue.ForeColor = System.Drawing.Color.DodgerBlue;
            this.BtnBlue.Location = new System.Drawing.Point(614, 2);
            this.BtnBlue.Margin = new System.Windows.Forms.Padding(2);
            this.BtnBlue.Name = "BtnBlue";
            this.BtnBlue.Size = new System.Drawing.Size(36, 33);
            this.BtnBlue.TabIndex = 1;
            this.BtnBlue.Text = "A";
            this.BtnBlue.UseVisualStyleBackColor = false;
            this.BtnBlue.Click += new System.EventHandler(this.FontChange);
            // 
            // BtnBlack
            // 
            this.BtnBlack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnBlack.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnBlack.ForeColor = System.Drawing.Color.Black;
            this.BtnBlack.Location = new System.Drawing.Point(574, 2);
            this.BtnBlack.Margin = new System.Windows.Forms.Padding(2);
            this.BtnBlack.Name = "BtnBlack";
            this.BtnBlack.Size = new System.Drawing.Size(36, 33);
            this.BtnBlack.TabIndex = 2;
            this.BtnBlack.Text = "A";
            this.BtnBlack.UseVisualStyleBackColor = false;
            this.BtnBlack.Click += new System.EventHandler(this.FontChange);
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Location = new System.Drawing.Point(535, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(34, 31);
            this.button4.TabIndex = 9;
            this.button4.Text = "検";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.AllowDrop = true;
            this.tabPage3.Controls.Add(this.FLP3);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(876, 398);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "リンク";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // FLP3
            // 
            this.FLP3.AllowDrop = true;
            this.FLP3.AutoScroll = true;
            this.FLP3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLP3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FLP3.Location = new System.Drawing.Point(3, 3);
            this.FLP3.Margin = new System.Windows.Forms.Padding(4);
            this.FLP3.Name = "FLP3";
            this.FLP3.Size = new System.Drawing.Size(870, 392);
            this.FLP3.TabIndex = 1;
            this.FLP3.WrapContents = false;
            this.FLP3.DragDrop += new System.Windows.Forms.DragEventHandler(this.FLP3_DragDrop);
            this.FLP3.DragEnter += new System.Windows.Forms.DragEventHandler(this.FLP3_DragEnter);
            this.FLP3.Resize += new System.EventHandler(this.FLP3_Resize);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AllowDrop = true;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tabControl1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(890, 481);
            this.tableLayoutPanel2.TabIndex = 10;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.TableLayoutPanel2_Paint);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 39);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // PressTimer
            // 
            this.PressTimer.Tick += new System.EventHandler(this.PressTimer_Tick);
            // 
            // MinutesTimer
            // 
            this.MinutesTimer.Tick += new System.EventHandler(this.MinutesTimer_Tick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(870, 392);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 481);
            this.Controls.Add(this.tableLayoutPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.MinimumSize = new System.Drawing.Size(201, 81);
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.VisibleChanged += new System.EventHandler(this.Form1_VisibleChanged);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TabPage tabPage3;
        public System.Windows.Forms.FlowLayoutPanel FLP3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel PnlMemoPage;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TextBox TbSrc;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox RichForSearch;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.Button BtnUnder;
        private System.Windows.Forms.Button BtnBold;
        private System.Windows.Forms.Button BtnRed;
        private System.Windows.Forms.Button BtnBlue;
        private System.Windows.Forms.Button BtnBlack;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer PressTimer;
        private System.Windows.Forms.Timer MinutesTimer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Timer timer1;
    }
}



