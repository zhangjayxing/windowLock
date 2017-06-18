namespace windowLock
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
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.fbdSelect = new System.Windows.Forms.FolderBrowserDialog();
            this.ckrmvb = new System.Windows.Forms.CheckBox();
            this.ckavi = new System.Windows.Forms.CheckBox();
            this.ckmkv = new System.Windows.Forms.CheckBox();
            this.ckmp4 = new System.Windows.Forms.CheckBox();
            this.ckAll = new System.Windows.Forms.CheckBox();
            this.txtPWD = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnDispose = new System.Windows.Forms.Button();
            this.cbPath = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(53, 30);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(534, 25);
            this.txtFilePath.TabIndex = 0;
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Location = new System.Drawing.Point(603, 23);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(86, 34);
            this.btnSelectPath.TabIndex = 1;
            this.btnSelectPath.Text = "选择路径";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.button1_Click);
            // 
            // ckrmvb
            // 
            this.ckrmvb.AutoSize = true;
            this.ckrmvb.Location = new System.Drawing.Point(196, 78);
            this.ckrmvb.Name = "ckrmvb";
            this.ckrmvb.Size = new System.Drawing.Size(61, 19);
            this.ckrmvb.TabIndex = 2;
            this.ckrmvb.Text = "rmvb";
            this.ckrmvb.UseVisualStyleBackColor = true;
            // 
            // ckavi
            // 
            this.ckavi.AutoSize = true;
            this.ckavi.Location = new System.Drawing.Point(263, 78);
            this.ckavi.Name = "ckavi";
            this.ckavi.Size = new System.Drawing.Size(53, 19);
            this.ckavi.TabIndex = 3;
            this.ckavi.Text = "avi";
            this.ckavi.UseVisualStyleBackColor = true;
            // 
            // ckmkv
            // 
            this.ckmkv.AutoSize = true;
            this.ckmkv.Location = new System.Drawing.Point(322, 78);
            this.ckmkv.Name = "ckmkv";
            this.ckmkv.Size = new System.Drawing.Size(53, 19);
            this.ckmkv.TabIndex = 4;
            this.ckmkv.Text = "mkv";
            this.ckmkv.UseVisualStyleBackColor = true;
            // 
            // ckmp4
            // 
            this.ckmp4.AutoSize = true;
            this.ckmp4.Location = new System.Drawing.Point(381, 78);
            this.ckmp4.Name = "ckmp4";
            this.ckmp4.Size = new System.Drawing.Size(53, 19);
            this.ckmp4.TabIndex = 5;
            this.ckmp4.Text = "mp4";
            this.ckmp4.UseVisualStyleBackColor = true;
            // 
            // ckAll
            // 
            this.ckAll.AutoSize = true;
            this.ckAll.Location = new System.Drawing.Point(53, 78);
            this.ckAll.Name = "ckAll";
            this.ckAll.Size = new System.Drawing.Size(59, 19);
            this.ckAll.TabIndex = 6;
            this.ckAll.Text = "全选";
            this.ckAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckAll.UseVisualStyleBackColor = true;
            this.ckAll.CheckedChanged += new System.EventHandler(this.ckAll_CheckedChanged);
            // 
            // txtPWD
            // 
            this.txtPWD.Location = new System.Drawing.Point(95, 119);
            this.txtPWD.Name = "txtPWD";
            this.txtPWD.PasswordChar = '*';
            this.txtPWD.Size = new System.Drawing.Size(229, 25);
            this.txtPWD.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "pwd:";
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(701, 168);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(91, 26);
            this.btnRestore.TabIndex = 9;
            this.btnRestore.Text = "还原";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnDispose
            // 
            this.btnDispose.Location = new System.Drawing.Point(603, 74);
            this.btnDispose.Name = "btnDispose";
            this.btnDispose.Size = new System.Drawing.Size(86, 23);
            this.btnDispose.TabIndex = 11;
            this.btnDispose.Text = "处理";
            this.btnDispose.UseVisualStyleBackColor = true;
            this.btnDispose.Click += new System.EventHandler(this.btnDispose_Click);
            // 
            // cbPath
            // 
            this.cbPath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPath.FormattingEnabled = true;
            this.cbPath.Location = new System.Drawing.Point(53, 168);
            this.cbPath.Name = "cbPath";
            this.cbPath.Size = new System.Drawing.Size(636, 23);
            this.cbPath.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 424);
            this.Controls.Add(this.cbPath);
            this.Controls.Add(this.btnDispose);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPWD);
            this.Controls.Add(this.ckAll);
            this.Controls.Add(this.ckmp4);
            this.Controls.Add(this.ckmkv);
            this.Controls.Add(this.ckavi);
            this.Controls.Add(this.ckrmvb);
            this.Controls.Add(this.btnSelectPath);
            this.Controls.Add(this.txtFilePath);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.FolderBrowserDialog fbdSelect;
        private System.Windows.Forms.CheckBox ckrmvb;
        private System.Windows.Forms.CheckBox ckavi;
        private System.Windows.Forms.CheckBox ckmkv;
        private System.Windows.Forms.CheckBox ckmp4;
        private System.Windows.Forms.CheckBox ckAll;
        private System.Windows.Forms.TextBox txtPWD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnDispose;
        private System.Windows.Forms.ComboBox cbPath;
    }
}

