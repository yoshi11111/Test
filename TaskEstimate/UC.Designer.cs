﻿namespace TaskEst
{
    partial class UC
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
            this.tbTask = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnDoing = new System.Windows.Forms.Button();
            this.tbEstimate = new System.Windows.Forms.TextBox();
            this.tbPerformance = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbTask, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBox1, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnDel, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnDoing, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbEstimate, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbPerformance, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 8, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBox1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(651, 42);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tbTask
            // 
            this.tbTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTask.Font = new System.Drawing.Font("メイリオ", 10F);
            this.tbTask.Location = new System.Drawing.Point(78, 7);
            this.tbTask.Name = "tbTask";
            this.tbTask.Size = new System.Drawing.Size(208, 32);
            this.tbTask.TabIndex = 3;
            this.tbTask.TextChanged += new System.EventHandler(this.tbTask_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox1.Font = new System.Drawing.Font("メイリオ", 10F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(7, 7);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(65, 33);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox1.Font = new System.Drawing.Font("メイリオ", 10F);
            this.checkBox1.Location = new System.Drawing.Point(576, 7);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(65, 28);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "完了";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnDel
            // 
            this.btnDel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDel.Font = new System.Drawing.Font("メイリオ", 10F);
            this.btnDel.Location = new System.Drawing.Point(505, 7);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(65, 28);
            this.btnDel.TabIndex = 0;
            this.btnDel.Text = "削除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDoing
            // 
            this.btnDoing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDoing.Font = new System.Drawing.Font("メイリオ", 10F);
            this.btnDoing.Location = new System.Drawing.Point(434, 7);
            this.btnDoing.Name = "btnDoing";
            this.btnDoing.Size = new System.Drawing.Size(65, 28);
            this.btnDoing.TabIndex = 2;
            this.btnDoing.Text = "実行中";
            this.btnDoing.UseVisualStyleBackColor = true;
            this.btnDoing.Click += new System.EventHandler(this.btnDoing_Click);
            // 
            // tbEstimate
            // 
            this.tbEstimate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbEstimate.Font = new System.Drawing.Font("メイリオ", 10F);
            this.tbEstimate.Location = new System.Drawing.Point(292, 7);
            this.tbEstimate.Name = "tbEstimate";
            this.tbEstimate.Size = new System.Drawing.Size(65, 32);
            this.tbEstimate.TabIndex = 5;
            this.tbEstimate.TextChanged += new System.EventHandler(this.tbEstimate_TextChanged);
            this.tbEstimate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbEstimate_KeyPress);
            // 
            // tbPerformance
            // 
            this.tbPerformance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPerformance.Enabled = false;
            this.tbPerformance.Font = new System.Drawing.Font("メイリオ", 10F);
            this.tbPerformance.Location = new System.Drawing.Point(363, 7);
            this.tbPerformance.Name = "tbPerformance";
            this.tbPerformance.Size = new System.Drawing.Size(65, 32);
            this.tbPerformance.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(647, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1, 34);
            this.label1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1, 34);
            this.label2.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.HotTrack;
            this.tableLayoutPanel1.SetColumnSpan(this.label3, 9);
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(645, 4);
            this.label3.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.HotTrack;
            this.tableLayoutPanel1.SetColumnSpan(this.label4, 9);
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(645, 4);
            this.label4.TabIndex = 10;
            // 
            // UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC";
            this.Size = new System.Drawing.Size(651, 42);
            this.Load += new System.EventHandler(this.UC_Load);
            this.Enter += new System.EventHandler(this.UC_Enter);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox tbTask;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnDoing;
        private System.Windows.Forms.TextBox tbEstimate;
        private System.Windows.Forms.TextBox tbPerformance;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}