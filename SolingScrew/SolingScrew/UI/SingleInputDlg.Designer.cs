namespace SolingScrew.UI
{
    partial class SingleInputDlg
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
            if(disposing && (components != null))
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
            this.productName = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.inputLb = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // productName
            //
            this.productName.Location = new System.Drawing.Point(224, 103);
            this.productName.Name = "productName";
            this.productName.Size = new System.Drawing.Size(98, 21);
            this.productName.TabIndex = 9;
            //
            // saveBtn
            //
            this.saveBtn.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.saveBtn.Location = new System.Drawing.Point(367, 200);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(105, 50);
            this.saveBtn.TabIndex = 8;
            this.saveBtn.Text = "保存";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            //
            // inputLb
            //
            this.inputLb.AutoSize = true;
            this.inputLb.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.inputLb.Location = new System.Drawing.Point(157, 106);
            this.inputLb.Name = "inputLb";
            this.inputLb.Size = new System.Drawing.Size(56, 14);
            this.inputLb.TabIndex = 6;
            this.inputLb.Text = "请输入:";
            //
            // label5
            //
            this.label5.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(485, 45);
            this.label5.TabIndex = 10;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // SingleInputDlg
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 262);
            this.Controls.Add(this.productName);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.inputLb);
            this.Controls.Add(this.label5);
            this.Name = "SingleInputDlg";
            this.Text = "SingleInputDlg";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        
        #endregion
        
        private System.Windows.Forms.TextBox productName;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label inputLb;
        private System.Windows.Forms.Label label5;
    }
}