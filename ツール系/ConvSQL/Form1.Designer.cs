namespace SqlConverter
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPh = new System.Windows.Forms.TextBox();
            this.tbJP = new System.Windows.Forms.TextBox();
            this.rtSQL = new System.Windows.Forms.RichTextBox();
            this.btnCvt = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSv = new System.Windows.Forms.Button();
            this.btnRd = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbPh);
            this.groupBox1.Controls.Add(this.tbJP);
            this.groupBox1.Location = new System.Drawing.Point(-1, 478);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(761, 116);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "テーブル定義取り込み";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(607, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 32);
            this.button1.TabIndex = 6;
            this.button1.Text = "追加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "フィールド／テーブル名";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(228, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "物理名";
            // 
            // tbPh
            // 
            this.tbPh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tbPh.Location = new System.Drawing.Point(231, 67);
            this.tbPh.Name = "tbPh";
            this.tbPh.Size = new System.Drawing.Size(186, 22);
            this.tbPh.TabIndex = 1;
            // 
            // tbJP
            // 
            this.tbJP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tbJP.Location = new System.Drawing.Point(13, 67);
            this.tbJP.Name = "tbJP";
            this.tbJP.Size = new System.Drawing.Size(184, 22);
            this.tbJP.TabIndex = 0;
            // 
            // rtSQL
            // 
            this.rtSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtSQL.Location = new System.Drawing.Point(-1, 3);
            this.rtSQL.Name = "rtSQL";
            this.rtSQL.Size = new System.Drawing.Size(761, 325);
            this.rtSQL.TabIndex = 1;
            this.rtSQL.Text = "";
            this.rtSQL.TextChanged += new System.EventHandler(this.rtSQL_TextChanged);
            // 
            // btnCvt
            // 
            this.btnCvt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCvt.Location = new System.Drawing.Point(606, 418);
            this.btnCvt.Name = "btnCvt";
            this.btnCvt.Size = new System.Drawing.Size(103, 36);
            this.btnCvt.TabIndex = 2;
            this.btnCvt.Text = "SQL変換";
            this.btnCvt.UseVisualStyleBackColor = true;
            this.btnCvt.Click += new System.EventHandler(this.btnCvt_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(21, 431);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(238, 19);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "フィールド／テーブル名　⇒　物理名";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(-1, 605);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(761, 263);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "テーブル定義書から取り込み";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btnSv
            // 
            this.btnSv.Location = new System.Drawing.Point(454, 334);
            this.btnSv.Name = "btnSv";
            this.btnSv.Size = new System.Drawing.Size(83, 31);
            this.btnSv.TabIndex = 6;
            this.btnSv.Text = "保存";
            this.btnSv.UseVisualStyleBackColor = true;
            this.btnSv.Click += new System.EventHandler(this.btnSv_Click);
            // 
            // btnRd
            // 
            this.btnRd.Location = new System.Drawing.Point(606, 334);
            this.btnRd.Name = "btnRd";
            this.btnRd.Size = new System.Drawing.Size(75, 31);
            this.btnRd.TabIndex = 7;
            this.btnRd.Text = "読込";
            this.btnRd.UseVisualStyleBackColor = true;
            this.btnRd.Click += new System.EventHandler(this.btnRd_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 880);
            this.Controls.Add(this.btnRd);
            this.Controls.Add(this.btnSv);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnCvt);
            this.Controls.Add(this.rtSQL);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtSQL;
        private System.Windows.Forms.Button btnCvt;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPh;
        private System.Windows.Forms.TextBox tbJP;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSv;
        private System.Windows.Forms.Button btnRd;
    }
}

