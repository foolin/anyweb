namespace Import
{
    partial class ImportForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnImport = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Font = new System.Drawing.Font( "宋体", 12F, System.Drawing.FontStyle.Bold );
            this.btnImport.Location = new System.Drawing.Point( 22, 31 );
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size( 83, 37 );
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "导 入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler( this.btnImport_Click );
            // 
            // btnStop
            // 
            this.btnStop.Font = new System.Drawing.Font( "宋体", 12F, System.Drawing.FontStyle.Bold );
            this.btnStop.Location = new System.Drawing.Point( 136, 31 );
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size( 83, 37 );
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "停 止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler( this.btnStop_Click );
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.btnImport );
            this.groupBox1.Controls.Add( this.btnStop );
            this.groupBox1.Location = new System.Drawing.Point( 11, 2 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 240, 89 );
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler( this.backgroundWorker1_DoWork );
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler( this.backgroundWorker1_RunWorkerCompleted );
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler( this.backgroundWorker1_ProgressChanged );
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size( 100, 16 );
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.ProgressBar1,
            this.StatusLabel1} );
            this.statusStrip1.Location = new System.Drawing.Point( 0, 96 );
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size( 263, 22 );
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel1
            // 
            this.StatusLabel1.Name = "StatusLabel1";
            this.StatusLabel1.Size = new System.Drawing.Size( 0, 17 );
            // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 263, 118 );
            this.Controls.Add( this.statusStrip1 );
            this.Controls.Add( this.groupBox1 );
            this.MaximizeBox = false;
            this.Name = "ImportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "简历导入";
            this.groupBox1.ResumeLayout( false );
            this.statusStrip1.ResumeLayout( false );
            this.statusStrip1.PerformLayout();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel1;

    }
}

