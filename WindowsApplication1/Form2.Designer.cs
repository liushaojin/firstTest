namespace WindowsApplication1
{
    partial class SetForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.setTabControl = new System.Windows.Forms.TabControl();
            this.devPage = new System.Windows.Forms.TabPage();
            this.framePage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.userSetPage = new System.Windows.Forms.TabPage();
            this.setTabControl.SuspendLayout();
            this.framePage.SuspendLayout();
            this.SuspendLayout();
            // 
            // setTabControl
            // 
            this.setTabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.setTabControl.Controls.Add(this.devPage);
            this.setTabControl.Controls.Add(this.framePage);
            this.setTabControl.Controls.Add(this.userSetPage);
            this.setTabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.setTabControl.Location = new System.Drawing.Point(0, 0);
            this.setTabControl.Multiline = true;
            this.setTabControl.Name = "setTabControl";
            this.setTabControl.SelectedIndex = 0;
            this.setTabControl.Size = new System.Drawing.Size(580, 440);
            this.setTabControl.TabIndex = 0;
            // 
            // devPage
            // 
            this.devPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.devPage.Location = new System.Drawing.Point(22, 4);
            this.devPage.Name = "devPage";
            this.devPage.Padding = new System.Windows.Forms.Padding(3);
            this.devPage.Size = new System.Drawing.Size(554, 432);
            this.devPage.TabIndex = 0;
            this.devPage.Text = "设备区";
            // 
            // framePage
            // 
            this.framePage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.framePage.Controls.Add(this.groupBox1);
            this.framePage.Location = new System.Drawing.Point(22, 4);
            this.framePage.Name = "framePage";
            this.framePage.Padding = new System.Windows.Forms.Padding(3);
            this.framePage.Size = new System.Drawing.Size(554, 432);
            this.framePage.TabIndex = 1;
            this.framePage.Text = "报文区";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(545, 130);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // userSetPage
            // 
            this.userSetPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.userSetPage.Location = new System.Drawing.Point(22, 4);
            this.userSetPage.Name = "userSetPage";
            this.userSetPage.Size = new System.Drawing.Size(554, 432);
            this.userSetPage.TabIndex = 2;
            this.userSetPage.Text = "用户设置";
            // 
            // SetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(584, 442);
            this.Controls.Add(this.setTabControl);
            this.ForeColor = System.Drawing.Color.LawnGreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SetForm";
            this.Text = "设置";
            this.Load += new System.EventHandler(this.SetForm_Load);
            this.setTabControl.ResumeLayout(false);
            this.framePage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl setTabControl;
        private System.Windows.Forms.TabPage devPage;
        private System.Windows.Forms.TabPage framePage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage userSetPage;
    }
}