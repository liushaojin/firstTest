namespace SolingScrew
{
    partial class SysSetting
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
            this.spliterLb = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sysSetTitleLb = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.defaultBtn = new System.Windows.Forms.Button();
            this.torsionUpLimitLb = new System.Windows.Forms.Label();
            this.reScrewLb = new System.Windows.Forms.Label();
            this.torsionDownLimitLb = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.torsionDownLimit = new SolingScrew.UI.BaseForm.NumTextBox();
            this.torsion2UpLimit = new SolingScrew.UI.BaseForm.NumTextBox();
            this.torsion2DownLimit = new SolingScrew.UI.BaseForm.NumTextBox();
            this.torsionUpLimit = new SolingScrew.UI.BaseForm.NumTextBox();
            this.SuspendLayout();
            //
            // spliterLb
            //
            this.spliterLb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.spliterLb.Location = new System.Drawing.Point(2, 45);
            this.spliterLb.Name = "spliterLb";
            this.spliterLb.Size = new System.Drawing.Size(480, 4);
            this.spliterLb.TabIndex = 0;
            this.spliterLb.Text = "label1";
            //
            // label1
            //
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(2, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(480, 4);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            //
            // label2
            //
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(240, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(4, 200);
            this.label2.TabIndex = 0;
            this.label2.Text = "label1";
            //
            // sysSetTitleLb
            //
            this.sysSetTitleLb.AutoSize = true;
            this.sysSetTitleLb.BackColor = System.Drawing.Color.LightSeaGreen;
            this.sysSetTitleLb.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sysSetTitleLb.Location = new System.Drawing.Point(191, 12);
            this.sysSetTitleLb.Name = "sysSetTitleLb";
            this.sysSetTitleLb.Size = new System.Drawing.Size(98, 21);
            this.sysSetTitleLb.TabIndex = 1;
            this.sysSetTitleLb.Text = "系统设置";
            //
            // saveBtn
            //
            this.saveBtn.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.saveBtn.Location = new System.Drawing.Point(310, 259);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(105, 50);
            this.saveBtn.TabIndex = 2;
            this.saveBtn.Text = "保存";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            //
            // defaultBtn
            //
            this.defaultBtn.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.defaultBtn.Location = new System.Drawing.Point(72, 259);
            this.defaultBtn.Name = "defaultBtn";
            this.defaultBtn.Size = new System.Drawing.Size(105, 50);
            this.defaultBtn.TabIndex = 3;
            this.defaultBtn.Text = "默认值";
            this.defaultBtn.UseVisualStyleBackColor = true;
            this.defaultBtn.Click += new System.EventHandler(this.defaultBtn_Click);
            //
            // torsionUpLimitLb
            //
            this.torsionUpLimitLb.AutoSize = true;
            this.torsionUpLimitLb.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.torsionUpLimitLb.Location = new System.Drawing.Point(3, 70);
            this.torsionUpLimitLb.Name = "torsionUpLimitLb";
            this.torsionUpLimitLb.Size = new System.Drawing.Size(77, 14);
            this.torsionUpLimitLb.TabIndex = 1;
            this.torsionUpLimitLb.Text = "扭力上限1:";
            //
            // reScrewLb
            //
            this.reScrewLb.AutoSize = true;
            this.reScrewLb.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.reScrewLb.Location = new System.Drawing.Point(2, 162);
            this.reScrewLb.Name = "reScrewLb";
            this.reScrewLb.Size = new System.Drawing.Size(84, 14);
            this.reScrewLb.TabIndex = 1;
            this.reScrewLb.Text = "重新打螺丝:";
            //
            // torsionDownLimitLb
            //
            this.torsionDownLimitLb.AutoSize = true;
            this.torsionDownLimitLb.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.torsionDownLimitLb.Location = new System.Drawing.Point(4, 111);
            this.torsionDownLimitLb.Name = "torsionDownLimitLb";
            this.torsionDownLimitLb.Size = new System.Drawing.Size(77, 14);
            this.torsionDownLimitLb.TabIndex = 1;
            this.torsionDownLimitLb.Text = "扭力下限1:";
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(183, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "kgf.cm";
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(422, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 1;
            this.label4.Text = "kgf.cm";
            //
            // label5
            //
            this.label5.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(485, 45);
            this.label5.TabIndex = 5;
            //
            // label6
            //
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(243, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 6;
            this.label6.Text = "扭力下限2:";
            //
            // label7
            //
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(422, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 14);
            this.label7.TabIndex = 7;
            this.label7.Text = "kgf.cm";
            //
            // label8
            //
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(183, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 14);
            this.label8.TabIndex = 8;
            this.label8.Text = "kgf.cm";
            //
            // label9
            //
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(242, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 14);
            this.label9.TabIndex = 9;
            this.label9.Text = "扭力上限2:";
            //
            // checkBox1
            //
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(93, 162);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.UseVisualStyleBackColor = true;
            //
            // torsionDownLimit
            //
            this.torsionDownLimit.Location = new System.Drawing.Point(79, 108);
            this.torsionDownLimit.Name = "torsionDownLimit";
            this.torsionDownLimit.Size = new System.Drawing.Size(100, 21);
            this.torsionDownLimit.TabIndex = 16;
            //
            // torsion2UpLimit
            //
            this.torsion2UpLimit.Location = new System.Drawing.Point(318, 67);
            this.torsion2UpLimit.Name = "torsion2UpLimit";
            this.torsion2UpLimit.Size = new System.Drawing.Size(100, 21);
            this.torsion2UpLimit.TabIndex = 15;
            //
            // torsion2DownLimit
            //
            this.torsion2DownLimit.Location = new System.Drawing.Point(318, 108);
            this.torsion2DownLimit.Name = "torsion2DownLimit";
            this.torsion2DownLimit.Size = new System.Drawing.Size(100, 21);
            this.torsion2DownLimit.TabIndex = 14;
            //
            // torsionUpLimit
            //
            this.torsionUpLimit.Location = new System.Drawing.Point(79, 67);
            this.torsionUpLimit.Name = "torsionUpLimit";
            this.torsionUpLimit.Size = new System.Drawing.Size(100, 21);
            this.torsionUpLimit.TabIndex = 13;
            //
            // SysSetting
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 312);
            this.Controls.Add(this.torsionDownLimit);
            this.Controls.Add(this.torsion2UpLimit);
            this.Controls.Add(this.torsion2DownLimit);
            this.Controls.Add(this.torsionUpLimit);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.defaultBtn);
            this.Controls.Add(this.torsionDownLimitLb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.reScrewLb);
            this.Controls.Add(this.torsionUpLimitLb);
            this.Controls.Add(this.sysSetTitleLb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.spliterLb);
            this.Controls.Add(this.label5);
            this.Name = "SysSetting";
            this.Text = "SysSetting";
            this.Load += new System.EventHandler(this.SysSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        
        #endregion
        
        private System.Windows.Forms.Label spliterLb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label sysSetTitleLb;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button defaultBtn;
        private System.Windows.Forms.Label torsionUpLimitLb;
        private System.Windows.Forms.Label reScrewLb;
        private System.Windows.Forms.Label torsionDownLimitLb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBox1;
        private UI.BaseForm.NumTextBox torsionUpLimit;
        private UI.BaseForm.NumTextBox torsion2DownLimit;
        private UI.BaseForm.NumTextBox torsion2UpLimit;
        private UI.BaseForm.NumTextBox torsionDownLimit;
    }
}