namespace Janapnes
{
    partial class MainForm
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
            this.btnFileSelect = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ssToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startNo = new System.Windows.Forms.NumericUpDown();
            this.endNo = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLearn = new System.Windows.Forms.Button();
            this.chkEnglish = new System.Windows.Forms.CheckBox();
            this.nmFrequency = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRecord = new System.Windows.Forms.Button();
            this.sharedDictionaryStorage1 = new DevExpress.XtraSpellChecker.SharedDictionaryStorage(this.components);
            this.btnRecordStop = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblCountDown = new System.Windows.Forms.Label();
            this.txTranslation = new System.Windows.Forms.RichTextBox();
            this.chkRecord = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmFrequency)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFileSelect
            // 
            this.btnFileSelect.Location = new System.Drawing.Point(307, 50);
            this.btnFileSelect.Name = "btnFileSelect";
            this.btnFileSelect.Size = new System.Drawing.Size(54, 25);
            this.btnFileSelect.TabIndex = 6;
            this.btnFileSelect.Text = "file";
            this.btnFileSelect.UseVisualStyleBackColor = true;
            this.btnFileSelect.Click += new System.EventHandler(this.button1_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.ssToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // ssToolStripMenuItem
            // 
            this.ssToolStripMenuItem.Name = "ssToolStripMenuItem";
            this.ssToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ssToolStripMenuItem.Text = "ss";
            // 
            // startNo
            // 
            this.startNo.Location = new System.Drawing.Point(109, 21);
            this.startNo.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.startNo.Name = "startNo";
            this.startNo.Size = new System.Drawing.Size(58, 20);
            this.startNo.TabIndex = 1;
            this.startNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // endNo
            // 
            this.endNo.Location = new System.Drawing.Point(193, 22);
            this.endNo.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.endNo.Name = "endNo";
            this.endNo.Size = new System.Drawing.Size(59, 20);
            this.endNo.TabIndex = 2;
            this.endNo.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "learning interval:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "~";
            // 
            // btnLearn
            // 
            this.btnLearn.Location = new System.Drawing.Point(367, 50);
            this.btnLearn.Name = "btnLearn";
            this.btnLearn.Size = new System.Drawing.Size(59, 25);
            this.btnLearn.TabIndex = 7;
            this.btnLearn.Text = "learn";
            this.btnLearn.UseVisualStyleBackColor = true;
            this.btnLearn.Click += new System.EventHandler(this.button2_Click);
            // 
            // chkEnglish
            // 
            this.chkEnglish.AutoSize = true;
            this.chkEnglish.Checked = true;
            this.chkEnglish.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnglish.Location = new System.Drawing.Point(109, 58);
            this.chkEnglish.Name = "chkEnglish";
            this.chkEnglish.Size = new System.Drawing.Size(81, 17);
            this.chkEnglish.TabIndex = 4;
            this.chkEnglish.Text = "english/JP/";
            this.chkEnglish.UseVisualStyleBackColor = true;
            // 
            // nmFrequency
            // 
            this.nmFrequency.Location = new System.Drawing.Point(367, 21);
            this.nmFrequency.Name = "nmFrequency";
            this.nmFrequency.Size = new System.Drawing.Size(59, 20);
            this.nmFrequency.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(304, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "frequency:";
            // 
            // btnRecord
            // 
            this.btnRecord.Location = new System.Drawing.Point(307, 81);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(119, 23);
            this.btnRecord.TabIndex = 9;
            this.btnRecord.Text = "recordVoice";
            this.btnRecord.UseVisualStyleBackColor = true;
            // 
            // btnRecordStop
            // 
            this.btnRecordStop.Location = new System.Drawing.Point(307, 110);
            this.btnRecordStop.Name = "btnRecordStop";
            this.btnRecordStop.Size = new System.Drawing.Size(119, 23);
            this.btnRecordStop.TabIndex = 10;
            this.btnRecordStop.Text = "stopRecord";
            this.btnRecordStop.UseVisualStyleBackColor = true;
            // 
            // lblCountDown
            // 
            this.lblCountDown.AutoSize = true;
            this.lblCountDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountDown.Location = new System.Drawing.Point(17, 113);
            this.lblCountDown.Name = "lblCountDown";
            this.lblCountDown.Size = new System.Drawing.Size(61, 20);
            this.lblCountDown.TabIndex = 11;
            this.lblCountDown.Text = "Lesson";
            // 
            // txTranslation
            // 
            this.txTranslation.Enabled = false;
            this.txTranslation.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txTranslation.Location = new System.Drawing.Point(20, 139);
            this.txTranslation.Name = "txTranslation";
            this.txTranslation.Size = new System.Drawing.Size(889, 404);
            this.txTranslation.TabIndex = 12;
            this.txTranslation.Text = "";
            // 
            // chkRecord
            // 
            this.chkRecord.AutoSize = true;
            this.chkRecord.Checked = true;
            this.chkRecord.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRecord.Location = new System.Drawing.Point(193, 58);
            this.chkRecord.Name = "chkRecord";
            this.chkRecord.Size = new System.Drawing.Size(82, 17);
            this.chkRecord.TabIndex = 5;
            this.chkRecord.Text = "notify/read/";
            this.chkRecord.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 555);
            this.Controls.Add(this.chkRecord);
            this.Controls.Add(this.txTranslation);
            this.Controls.Add(this.lblCountDown);
            this.Controls.Add(this.btnRecordStop);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nmFrequency);
            this.Controls.Add(this.chkEnglish);
            this.Controls.Add(this.btnLearn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.endNo);
            this.Controls.Add(this.startNo);
            this.Controls.Add(this.btnFileSelect);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Afen learning";
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.startNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmFrequency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFileSelect;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ssToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown startNo;
        private System.Windows.Forms.NumericUpDown endNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLearn;
        private System.Windows.Forms.CheckBox chkEnglish;
        private System.Windows.Forms.NumericUpDown nmFrequency;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRecord;
        private DevExpress.XtraSpellChecker.SharedDictionaryStorage sharedDictionaryStorage1;
        private System.Windows.Forms.Button btnRecordStop;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblCountDown;
        private System.Windows.Forms.RichTextBox txTranslation;
        private System.Windows.Forms.CheckBox chkRecord;
    }
}

