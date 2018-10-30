namespace Garbage_Collection
{
    partial class Parent
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
            this.btnRefreshUsedMemory = new System.Windows.Forms.Button();
            this.lblUsedMemory = new System.Windows.Forms.Label();
            this.btnOpenChild = new System.Windows.Forms.Button();
            this.btnFlushMemory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRefreshUsedMemory
            // 
            this.btnRefreshUsedMemory.Location = new System.Drawing.Point(115, 262);
            this.btnRefreshUsedMemory.Name = "btnRefreshUsedMemory";
            this.btnRefreshUsedMemory.Size = new System.Drawing.Size(95, 54);
            this.btnRefreshUsedMemory.TabIndex = 0;
            this.btnRefreshUsedMemory.Text = "刷新已使用内存";
            this.btnRefreshUsedMemory.UseVisualStyleBackColor = true;
            this.btnRefreshUsedMemory.Click += new System.EventHandler(this.btnRefreshUsedMemory_Click);
            // 
            // lblUsedMemory
            // 
            this.lblUsedMemory.AutoSize = true;
            this.lblUsedMemory.Location = new System.Drawing.Point(112, 89);
            this.lblUsedMemory.Name = "lblUsedMemory";
            this.lblUsedMemory.Size = new System.Drawing.Size(82, 15);
            this.lblUsedMemory.TabIndex = 1;
            this.lblUsedMemory.Text = "已使用内存";
            // 
            // btnOpenChild
            // 
            this.btnOpenChild.Location = new System.Drawing.Point(297, 262);
            this.btnOpenChild.Name = "btnOpenChild";
            this.btnOpenChild.Size = new System.Drawing.Size(95, 54);
            this.btnOpenChild.TabIndex = 2;
            this.btnOpenChild.Text = "Open";
            this.btnOpenChild.UseVisualStyleBackColor = true;
            this.btnOpenChild.Click += new System.EventHandler(this.btnOpenChild_Click);
            // 
            // btnFlushMemory
            // 
            this.btnFlushMemory.Location = new System.Drawing.Point(506, 262);
            this.btnFlushMemory.Name = "btnFlushMemory";
            this.btnFlushMemory.Size = new System.Drawing.Size(130, 54);
            this.btnFlushMemory.TabIndex = 3;
            this.btnFlushMemory.Text = "FlushMemory";
            this.btnFlushMemory.UseVisualStyleBackColor = true;
            this.btnFlushMemory.Click += new System.EventHandler(this.btnFlushMemory_Click);
            // 
            // Parent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnFlushMemory);
            this.Controls.Add(this.btnOpenChild);
            this.Controls.Add(this.lblUsedMemory);
            this.Controls.Add(this.btnRefreshUsedMemory);
            this.Name = "Parent";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefreshUsedMemory;
        private System.Windows.Forms.Label lblUsedMemory;
        private System.Windows.Forms.Button btnOpenChild;
        private System.Windows.Forms.Button btnFlushMemory;
    }
}

