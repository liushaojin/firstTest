namespace SolingScrew.UI
{
    partial class PointSetting
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.sysSetTitleLb = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.productCombo = new System.Windows.Forms.ComboBox();
            this.productNameLb = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pointCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.delBtn = new System.Windows.Forms.Button();
            this.newBtn = new System.Windows.Forms.Button();
            this.switchBtn = new System.Windows.Forms.Button();
            this.delPointBtn = new System.Windows.Forms.Button();
            this.cancelShieldBtn = new System.Windows.Forms.Button();
            this.shieldPointBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.changeProgramBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.z2Pos = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.yPos = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.z1Pos = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.x2Pos = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.x1Pos = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.readTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            //
            // sysSetTitleLb
            //
            this.sysSetTitleLb.AutoSize = true;
            this.sysSetTitleLb.BackColor = System.Drawing.Color.LightSeaGreen;
            this.sysSetTitleLb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sysSetTitleLb.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sysSetTitleLb.Location = new System.Drawing.Point(443, 12);
            this.sysSetTitleLb.Name = "sysSetTitleLb";
            this.sysSetTitleLb.Size = new System.Drawing.Size(98, 21);
            this.sysSetTitleLb.TabIndex = 2;
            this.sysSetTitleLb.Text = "点位设置";
            //
            // label1
            //
            this.label1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(985, 45);
            this.label1.TabIndex = 3;
            //
            // productCombo
            //
            this.productCombo.FormattingEnabled = true;
            this.productCombo.Location = new System.Drawing.Point(8, 50);
            this.productCombo.Name = "productCombo";
            this.productCombo.Size = new System.Drawing.Size(164, 20);
            this.productCombo.TabIndex = 4;
            this.productCombo.SelectedIndexChanged += new System.EventHandler(this.productCombo_SelectedIndexChanged);
            //
            // productNameLb
            //
            this.productNameLb.AutoSize = true;
            this.productNameLb.BackColor = System.Drawing.Color.LightSeaGreen;
            this.productNameLb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.productNameLb.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.productNameLb.Location = new System.Drawing.Point(8, 17);
            this.productNameLb.Name = "productNameLb";
            this.productNameLb.Size = new System.Drawing.Size(98, 21);
            this.productNameLb.TabIndex = 5;
            this.productNameLb.Text = "产品名称";
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(8, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "点位";
            //
            // pointCombo
            //
            this.pointCombo.FormattingEnabled = true;
            this.pointCombo.Location = new System.Drawing.Point(8, 120);
            this.pointCombo.Name = "pointCombo";
            this.pointCombo.Size = new System.Drawing.Size(164, 20);
            this.pointCombo.TabIndex = 6;
            this.pointCombo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(8, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "螺丝批程序编号";
            this.label3.Visible = false;
            //
            // comboBox2
            //
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(8, 188);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(164, 20);
            this.comboBox2.TabIndex = 8;
            this.comboBox2.Visible = false;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            //
            // delBtn
            //
            this.delBtn.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.delBtn.Location = new System.Drawing.Point(472, 20);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(105, 50);
            this.delBtn.TabIndex = 10;
            this.delBtn.Text = "删除产品";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            //
            // newBtn
            //
            this.newBtn.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.newBtn.Location = new System.Drawing.Point(348, 20);
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(105, 50);
            this.newBtn.TabIndex = 11;
            this.newBtn.Text = "新增产品";
            this.newBtn.UseVisualStyleBackColor = true;
            this.newBtn.Click += new System.EventHandler(this.newBtn_Click);
            //
            // switchBtn
            //
            this.switchBtn.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.switchBtn.Location = new System.Drawing.Point(224, 20);
            this.switchBtn.Name = "switchBtn";
            this.switchBtn.Size = new System.Drawing.Size(105, 50);
            this.switchBtn.TabIndex = 12;
            this.switchBtn.Text = "切换产品";
            this.switchBtn.UseVisualStyleBackColor = true;
            this.switchBtn.Click += new System.EventHandler(this.switchBtn_Click);
            //
            // delPointBtn
            //
            this.delPointBtn.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.delPointBtn.Location = new System.Drawing.Point(472, 90);
            this.delPointBtn.Name = "delPointBtn";
            this.delPointBtn.Size = new System.Drawing.Size(105, 50);
            this.delPointBtn.TabIndex = 13;
            this.delPointBtn.Text = "删除点位";
            this.delPointBtn.UseVisualStyleBackColor = true;
            this.delPointBtn.Click += new System.EventHandler(this.delPointBtn_Click);
            //
            // cancelShieldBtn
            //
            this.cancelShieldBtn.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cancelShieldBtn.Location = new System.Drawing.Point(348, 90);
            this.cancelShieldBtn.Name = "cancelShieldBtn";
            this.cancelShieldBtn.Size = new System.Drawing.Size(105, 50);
            this.cancelShieldBtn.TabIndex = 14;
            this.cancelShieldBtn.Text = "取消屏蔽";
            this.cancelShieldBtn.UseVisualStyleBackColor = true;
            this.cancelShieldBtn.Click += new System.EventHandler(this.cancelShieldBtn_Click);
            //
            // shieldPointBtn
            //
            this.shieldPointBtn.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.shieldPointBtn.Location = new System.Drawing.Point(224, 90);
            this.shieldPointBtn.Name = "shieldPointBtn";
            this.shieldPointBtn.Size = new System.Drawing.Size(105, 50);
            this.shieldPointBtn.TabIndex = 15;
            this.shieldPointBtn.Text = "屏蔽点位";
            this.shieldPointBtn.UseVisualStyleBackColor = true;
            this.shieldPointBtn.Click += new System.EventHandler(this.shieldPointBtn_Click);
            //
            // saveBtn
            //
            this.saveBtn.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.saveBtn.Location = new System.Drawing.Point(472, 158);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(105, 50);
            this.saveBtn.TabIndex = 16;
            this.saveBtn.Text = "保存";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            //
            // button5
            //
            this.button5.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button5.Location = new System.Drawing.Point(348, 158);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(105, 50);
            this.button5.TabIndex = 17;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            //
            // changeProgramBtn
            //
            this.changeProgramBtn.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.changeProgramBtn.Location = new System.Drawing.Point(224, 158);
            this.changeProgramBtn.Name = "changeProgramBtn";
            this.changeProgramBtn.Size = new System.Drawing.Size(105, 50);
            this.changeProgramBtn.TabIndex = 18;
            this.changeProgramBtn.Text = "更改程序";
            this.changeProgramBtn.UseVisualStyleBackColor = true;
            this.changeProgramBtn.Visible = false;
            this.changeProgramBtn.Click += new System.EventHandler(this.changeProgramBtn_Click);
            //
            // groupBox1
            //
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 265);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(960, 285);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "产品点位信息设置";
            //
            // dataGridView1
            //
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(6, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(948, 259);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            //
            // groupBox2
            //
            this.groupBox2.Controls.Add(this.z2Pos);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.yPos);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.z1Pos);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.x2Pos);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.x1Pos);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(610, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(362, 211);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "实时坐标";
            //
            // z2Pos
            //
            this.z2Pos.Location = new System.Drawing.Point(95, 188);
            this.z2Pos.Name = "z2Pos";
            this.z2Pos.Size = new System.Drawing.Size(98, 21);
            this.z2Pos.TabIndex = 25;
            //
            // label9
            //
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(199, 191);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 14);
            this.label9.TabIndex = 24;
            this.label9.Text = "mm";
            //
            // yPos
            //
            this.yPos.Location = new System.Drawing.Point(95, 110);
            this.yPos.Name = "yPos";
            this.yPos.Size = new System.Drawing.Size(98, 21);
            this.yPos.TabIndex = 25;
            //
            // label8
            //
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(199, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 14);
            this.label8.TabIndex = 24;
            this.label8.Text = "mm";
            //
            // z1Pos
            //
            this.z1Pos.Location = new System.Drawing.Point(95, 161);
            this.z1Pos.Name = "z1Pos";
            this.z1Pos.Size = new System.Drawing.Size(98, 21);
            this.z1Pos.TabIndex = 23;
            //
            // label13
            //
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(199, 164);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 14);
            this.label13.TabIndex = 22;
            this.label13.Text = "mm";
            //
            // x2Pos
            //
            this.x2Pos.Location = new System.Drawing.Point(95, 50);
            this.x2Pos.Name = "x2Pos";
            this.x2Pos.Size = new System.Drawing.Size(98, 21);
            this.x2Pos.TabIndex = 23;
            //
            // label11
            //
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(199, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 14);
            this.label11.TabIndex = 22;
            this.label11.Text = "mm";
            //
            // x1Pos
            //
            this.x1Pos.Location = new System.Drawing.Point(95, 23);
            this.x1Pos.Name = "x1Pos";
            this.x1Pos.Size = new System.Drawing.Size(98, 21);
            this.x1Pos.TabIndex = 23;
            //
            // label7
            //
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(199, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 14);
            this.label7.TabIndex = 22;
            this.label7.Text = "mm";
            //
            // label12
            //
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(6, 162);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 14);
            this.label12.TabIndex = 19;
            this.label12.Text = "Z1实时坐标";
            //
            // label6
            //
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(6, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 14);
            this.label6.TabIndex = 21;
            this.label6.Text = "Z2实时坐标";
            //
            // label10
            //
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(6, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 14);
            this.label10.TabIndex = 19;
            this.label10.Text = "X2实时坐标";
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(6, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 14);
            this.label5.TabIndex = 20;
            this.label5.Text = "Y实时坐标";
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(6, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 14);
            this.label4.TabIndex = 19;
            this.label4.Text = "X1实时坐标";
            //
            // groupBox3
            //
            this.groupBox3.Controls.Add(this.switchBtn);
            this.groupBox3.Controls.Add(this.productCombo);
            this.groupBox3.Controls.Add(this.saveBtn);
            this.groupBox3.Controls.Add(this.productNameLb);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.pointCombo);
            this.groupBox3.Controls.Add(this.changeProgramBtn);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.delPointBtn);
            this.groupBox3.Controls.Add(this.comboBox2);
            this.groupBox3.Controls.Add(this.cancelShieldBtn);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.shieldPointBtn);
            this.groupBox3.Controls.Add(this.newBtn);
            this.groupBox3.Controls.Add(this.delBtn);
            this.groupBox3.Location = new System.Drawing.Point(12, 48);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(592, 211);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "点位设置";
            //
            // readTimer
            //
            this.readTimer.Interval = 1;
            this.readTimer.Tick += new System.EventHandler(this.readTimer_Tick);
            //
            // PointSetting
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.sysSetTitleLb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Name = "PointSetting";
            this.Text = "PointSetting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PointSetting_FormClosing);
            this.Load += new System.EventHandler(this.PointSetting_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        
        #endregion
        
        private System.Windows.Forms.Label sysSetTitleLb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox productCombo;
        private System.Windows.Forms.Label productNameLb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox pointCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.Button newBtn;
        private System.Windows.Forms.Button switchBtn;
        private System.Windows.Forms.Button delPointBtn;
        private System.Windows.Forms.Button cancelShieldBtn;
        private System.Windows.Forms.Button shieldPointBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button changeProgramBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox x1Pos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox z2Pos;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox yPos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox z1Pos;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox x2Pos;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Timer readTimer;
    }
}