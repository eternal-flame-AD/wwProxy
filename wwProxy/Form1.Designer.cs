namespace wwProxy
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.countrySelection = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.proxyStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.source1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.proxySelection = new System.Windows.Forms.ComboBox();
            this.btnSetProxy = new System.Windows.Forms.Button();
            this.btnClearProxy = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // countrySelection
            // 
            this.countrySelection.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.countrySelection.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.countrySelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countrySelection.FormattingEnabled = true;
            this.countrySelection.Location = new System.Drawing.Point(88, 66);
            this.countrySelection.Name = "countrySelection";
            this.countrySelection.Size = new System.Drawing.Size(262, 20);
            this.countrySelection.TabIndex = 0;
            this.countrySelection.Tag = "Country";
            this.countrySelection.SelectedIndexChanged += new System.EventHandler(this.countrySelection_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Country";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Source";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(30, 17);
            this.StatusLabel.Text = "Idle";
            this.StatusLabel.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.proxyStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // proxyStatusLabel
            // 
            this.proxyStatusLabel.Name = "proxyStatusLabel";
            this.proxyStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // source1
            // 
            this.source1.AutoSize = true;
            this.source1.Checked = true;
            this.source1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.source1.Location = new System.Drawing.Point(88, 29);
            this.source1.Name = "source1";
            this.source1.Size = new System.Drawing.Size(72, 16);
            this.source1.TabIndex = 3;
            this.source1.Text = "spys.one";
            this.source1.UseVisualStyleBackColor = true;
            this.source1.CheckedChanged += new System.EventHandler(this.source1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Proxy";
            this.label3.Click += new System.EventHandler(this.label1_Click);
            // 
            // proxySelection
            // 
            this.proxySelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.proxySelection.FormattingEnabled = true;
            this.proxySelection.Location = new System.Drawing.Point(88, 113);
            this.proxySelection.Name = "proxySelection";
            this.proxySelection.Size = new System.Drawing.Size(262, 20);
            this.proxySelection.TabIndex = 4;
            this.proxySelection.SelectedIndexChanged += new System.EventHandler(this.proxySelection_SelectedIndexChanged);
            // 
            // btnSetProxy
            // 
            this.btnSetProxy.Location = new System.Drawing.Point(503, 46);
            this.btnSetProxy.Name = "btnSetProxy";
            this.btnSetProxy.Size = new System.Drawing.Size(95, 23);
            this.btnSetProxy.TabIndex = 5;
            this.btnSetProxy.Text = "Set Proxy";
            this.btnSetProxy.UseVisualStyleBackColor = true;
            this.btnSetProxy.Click += new System.EventHandler(this.btnSetProxy_Click);
            // 
            // btnClearProxy
            // 
            this.btnClearProxy.Location = new System.Drawing.Point(503, 92);
            this.btnClearProxy.Name = "btnClearProxy";
            this.btnClearProxy.Size = new System.Drawing.Size(95, 23);
            this.btnClearProxy.TabIndex = 6;
            this.btnClearProxy.Text = "Clear Proxy";
            this.btnClearProxy.UseVisualStyleBackColor = true;
            this.btnClearProxy.Click += new System.EventHandler(this.btnClearProxy_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 428);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.btnClearProxy);
            this.Controls.Add(this.btnSetProxy);
            this.Controls.Add(this.proxySelection);
            this.Controls.Add(this.source1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.countrySelection);
            this.Name = "Form1";
            this.Text = "wwProxy";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox countrySelection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.CheckBox source1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox proxySelection;
        private System.Windows.Forms.Button btnSetProxy;
        private System.Windows.Forms.Button btnClearProxy;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ToolStripStatusLabel proxyStatusLabel;
        private System.Windows.Forms.Splitter splitter1;
    }
}

