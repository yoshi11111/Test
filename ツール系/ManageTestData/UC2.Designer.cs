namespace Manage_Test_Data
{
    partial class UC2
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbTableName = new System.Windows.Forms.TextBox();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelRow = new System.Windows.Forms.Button();
            this.btnDelCol = new System.Windows.Forms.Button();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddCol = new System.Windows.Forms.Button();
            this.tbColName = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.chkP = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tbTableName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.DataGridView1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDelRow, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnDelCol, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAddRow, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(838, 130);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // tbTableName
            // 
            this.tbTableName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTableName.Location = new System.Drawing.Point(103, 3);
            this.tbTableName.Name = "tbTableName";
            this.tbTableName.Size = new System.Drawing.Size(144, 22);
            this.tbTableName.TabIndex = 1;
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AllowUserToDeleteRows = false;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.DataGridView1, 3);
            this.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView1.Location = new System.Drawing.Point(103, 38);
            this.DataGridView1.Name = "DataGridView1";
            this.tableLayoutPanel1.SetRowSpan(this.DataGridView1, 3);
            this.DataGridView1.RowTemplate.Height = 24;
            this.DataGridView1.Size = new System.Drawing.Size(732, 89);
            this.DataGridView1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "テーブル名:";
            // 
            // btnDelRow
            // 
            this.btnDelRow.Location = new System.Drawing.Point(3, 98);
            this.btnDelRow.Name = "btnDelRow";
            this.btnDelRow.Size = new System.Drawing.Size(94, 24);
            this.btnDelRow.TabIndex = 4;
            this.btnDelRow.Text = "行削除";
            this.btnDelRow.UseVisualStyleBackColor = true;
            this.btnDelRow.Click += new System.EventHandler(this.btnDelRow_Click);
            // 
            // btnDelCol
            // 
            this.btnDelCol.Location = new System.Drawing.Point(3, 38);
            this.btnDelCol.Name = "btnDelCol";
            this.btnDelCol.Size = new System.Drawing.Size(94, 24);
            this.btnDelCol.TabIndex = 6;
            this.btnDelCol.Text = "ｶﾗﾑ削除";
            this.btnDelCol.UseVisualStyleBackColor = true;
            this.btnDelCol.Click += new System.EventHandler(this.btnDelCol_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Location = new System.Drawing.Point(3, 68);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(94, 24);
            this.btnAddRow.TabIndex = 3;
            this.btnAddRow.Text = "行追加";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(253, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 35);
            this.label2.TabIndex = 12;
            this.label2.Text = "ｶﾗﾑ追加:";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.btnAddCol, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbColName, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.comboBox1, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkP, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(353, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(482, 29);
            this.tableLayoutPanel2.TabIndex = 13;
            // 
            // btnAddCol
            // 
            this.btnAddCol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddCol.Location = new System.Drawing.Point(363, 3);
            this.btnAddCol.Name = "btnAddCol";
            this.btnAddCol.Size = new System.Drawing.Size(116, 23);
            this.btnAddCol.TabIndex = 5;
            this.btnAddCol.Text = "ｶﾗﾑ追加";
            this.btnAddCol.UseVisualStyleBackColor = true;
            this.btnAddCol.Click += new System.EventHandler(this.btnAddCol_Click);
            // 
            // tbColName
            // 
            this.tbColName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbColName.Location = new System.Drawing.Point(3, 3);
            this.tbColName.Name = "tbColName";
            this.tbColName.Size = new System.Drawing.Size(114, 22);
            this.tbColName.TabIndex = 8;
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(243, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(114, 23);
            this.comboBox1.TabIndex = 10;
            // 
            // chkP
            // 
            this.chkP.AutoSize = true;
            this.chkP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkP.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkP.Location = new System.Drawing.Point(123, 3);
            this.chkP.Name = "chkP";
            this.chkP.Size = new System.Drawing.Size(114, 23);
            this.chkP.TabIndex = 9;
            this.chkP.Text = "ﾌﾟﾗｲﾏﾘｷｰ";
            this.chkP.UseVisualStyleBackColor = true;
            // 
            // UC2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC2";
            this.Size = new System.Drawing.Size(838, 130);
            this.Load += new System.EventHandler(this.UC_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTableName;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.Button btnDelRow;
        private System.Windows.Forms.Button btnAddCol;
        private System.Windows.Forms.Button btnDelCol;
        private System.Windows.Forms.DataGridView DataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox chkP;
        private System.Windows.Forms.TextBox tbColName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}
