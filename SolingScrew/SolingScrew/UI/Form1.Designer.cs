namespace SolingScrew
{
    partial class solingScrew
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
            if(disposing && (components != null))
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(solingScrew));
            this.sysSetBtn = new System.Windows.Forms.Button();
            this.posSetBtn = new System.Windows.Forms.Button();
            this.CPKBtn = new System.Windows.Forms.Button();
            this.datCleanBtn = new System.Windows.Forms.Button();
            this.quitSysBtn = new System.Windows.Forms.Button();
            this.productNameLb = new System.Windows.Forms.Label();
            this.productName = new System.Windows.Forms.Label();
            this.testNumLb = new System.Windows.Forms.Label();
            this.testNum = new System.Windows.Forms.Label();
            this.pcsUnitLb = new System.Windows.Forms.Label();
            this.straitRateLb = new System.Windows.Forms.Label();
            this.straitRate = new System.Windows.Forms.Label();
            this.testTimeLb = new System.Windows.Forms.Label();
            this.testTime = new System.Windows.Forms.Label();
            this.timeUnit = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.loginBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.tcpTimer = new System.Windows.Forms.Timer(this.components);
            this.xyChat1 = new SolingScrew.XYGraph.XYChat();
            this.listBox2 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            //
            // sysSetBtn
            //
            this.sysSetBtn.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sysSetBtn.Location = new System.Drawing.Point(221, 12);
            this.sysSetBtn.Name = "sysSetBtn";
            this.sysSetBtn.Size = new System.Drawing.Size(105, 50);
            this.sysSetBtn.TabIndex = 0;
            this.sysSetBtn.Text = "系统设置";
            this.sysSetBtn.UseVisualStyleBackColor = true;
            this.sysSetBtn.Click += new System.EventHandler(this.sysSetBtn_Click);
            //
            // posSetBtn
            //
            this.posSetBtn.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.posSetBtn.Location = new System.Drawing.Point(349, 12);
            this.posSetBtn.Name = "posSetBtn";
            this.posSetBtn.Size = new System.Drawing.Size(105, 50);
            this.posSetBtn.TabIndex = 0;
            this.posSetBtn.Text = "点位设置";
            this.posSetBtn.UseVisualStyleBackColor = true;
            this.posSetBtn.Click += new System.EventHandler(this.posSetBtn_Click);
            //
            // CPKBtn
            //
            this.CPKBtn.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CPKBtn.Location = new System.Drawing.Point(477, 12);
            this.CPKBtn.Name = "CPKBtn";
            this.CPKBtn.Size = new System.Drawing.Size(105, 50);
            this.CPKBtn.TabIndex = 0;
            this.CPKBtn.Text = "CPK";
            this.CPKBtn.UseVisualStyleBackColor = true;
            this.CPKBtn.Click += new System.EventHandler(this.CPKBtn_Click);
            //
            // datCleanBtn
            //
            this.datCleanBtn.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.datCleanBtn.Location = new System.Drawing.Point(605, 12);
            this.datCleanBtn.Name = "datCleanBtn";
            this.datCleanBtn.Size = new System.Drawing.Size(105, 50);
            this.datCleanBtn.TabIndex = 0;
            this.datCleanBtn.Text = "数据清零";
            this.datCleanBtn.UseVisualStyleBackColor = true;
            this.datCleanBtn.Click += new System.EventHandler(this.datCleanBtn_Click);
            //
            // quitSysBtn
            //
            this.quitSysBtn.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.quitSysBtn.Location = new System.Drawing.Point(733, 12);
            this.quitSysBtn.Name = "quitSysBtn";
            this.quitSysBtn.Size = new System.Drawing.Size(105, 50);
            this.quitSysBtn.TabIndex = 0;
            this.quitSysBtn.Text = "退出系统";
            this.quitSysBtn.UseVisualStyleBackColor = true;
            this.quitSysBtn.Click += new System.EventHandler(this.quitSysBtn_Click);
            //
            // productNameLb
            //
            this.productNameLb.AutoSize = true;
            this.productNameLb.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.productNameLb.Location = new System.Drawing.Point(13, 73);
            this.productNameLb.Name = "productNameLb";
            this.productNameLb.Size = new System.Drawing.Size(120, 21);
            this.productNameLb.TabIndex = 2;
            this.productNameLb.Text = "产品名称：";
            //
            // productName
            //
            this.productName.AutoSize = true;
            this.productName.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.productName.ForeColor = System.Drawing.Color.LimeGreen;
            this.productName.Location = new System.Drawing.Point(113, 73);
            this.productName.Name = "productName";
            this.productName.Size = new System.Drawing.Size(76, 21);
            this.productName.TabIndex = 2;
            this.productName.Text = "soling";
            //
            // testNumLb
            //
            this.testNumLb.AutoSize = true;
            this.testNumLb.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.testNumLb.Location = new System.Drawing.Point(243, 73);
            this.testNumLb.Name = "testNumLb";
            this.testNumLb.Size = new System.Drawing.Size(120, 21);
            this.testNumLb.TabIndex = 2;
            this.testNumLb.Text = "测试数量：";
            //
            // testNum
            //
            this.testNum.AutoSize = true;
            this.testNum.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.testNum.ForeColor = System.Drawing.Color.LimeGreen;
            this.testNum.Location = new System.Drawing.Point(347, 73);
            this.testNum.Name = "testNum";
            this.testNum.Size = new System.Drawing.Size(46, 21);
            this.testNum.TabIndex = 2;
            this.testNum.Text = "100";
            //
            // pcsUnitLb
            //
            this.pcsUnitLb.AutoSize = true;
            this.pcsUnitLb.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pcsUnitLb.Location = new System.Drawing.Point(408, 73);
            this.pcsUnitLb.Name = "pcsUnitLb";
            this.pcsUnitLb.Size = new System.Drawing.Size(46, 21);
            this.pcsUnitLb.TabIndex = 2;
            this.pcsUnitLb.Text = "PCS";
            //
            // straitRateLb
            //
            this.straitRateLb.AutoSize = true;
            this.straitRateLb.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.straitRateLb.Location = new System.Drawing.Point(523, 73);
            this.straitRateLb.Name = "straitRateLb";
            this.straitRateLb.Size = new System.Drawing.Size(98, 21);
            this.straitRateLb.TabIndex = 2;
            this.straitRateLb.Text = "直通率：";
            //
            // straitRate
            //
            this.straitRate.AutoSize = true;
            this.straitRate.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.straitRate.ForeColor = System.Drawing.Color.LimeGreen;
            this.straitRate.Location = new System.Drawing.Point(605, 73);
            this.straitRate.Name = "straitRate";
            this.straitRate.Size = new System.Drawing.Size(58, 21);
            this.straitRate.TabIndex = 2;
            this.straitRate.Text = "100%";
            //
            // testTimeLb
            //
            this.testTimeLb.AutoSize = true;
            this.testTimeLb.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.testTimeLb.Location = new System.Drawing.Point(704, 73);
            this.testTimeLb.Name = "testTimeLb";
            this.testTimeLb.Size = new System.Drawing.Size(120, 21);
            this.testTimeLb.TabIndex = 2;
            this.testTimeLb.Text = "测试时间：";
            //
            // testTime
            //
            this.testTime.AutoSize = true;
            this.testTime.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.testTime.ForeColor = System.Drawing.Color.LimeGreen;
            this.testTime.Location = new System.Drawing.Point(817, 73);
            this.testTime.Name = "testTime";
            this.testTime.Size = new System.Drawing.Size(22, 21);
            this.testTime.TabIndex = 2;
            this.testTime.Text = "0";
            //
            // timeUnit
            //
            this.timeUnit.AutoSize = true;
            this.timeUnit.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.timeUnit.Location = new System.Drawing.Point(858, 73);
            this.timeUnit.Name = "timeUnit";
            this.timeUnit.Size = new System.Drawing.Size(22, 21);
            this.timeUnit.TabIndex = 2;
            this.timeUnit.Text = "S";
            //
            // dataGridView1
            //
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 116);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(500, 602);
            this.dataGridView1.TabIndex = 3;
            //
            // chart1
            //
            chartArea1.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(523, 116);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(473, 300);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chart1";
            //
            // listBox1
            //
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(523, 434);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(473, 172);
            this.listBox1.TabIndex = 6;
            //
            // pictureBox1
            //
            this.pictureBox1.Image = global::SolingScrew.Properties.Resources.soling_logo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 57);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            //
            // loginBtn
            //
            this.loginBtn.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loginBtn.Location = new System.Drawing.Point(891, 12);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(105, 50);
            this.loginBtn.TabIndex = 7;
            this.loginBtn.Text = "登入";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Visible = false;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            //
            // clearBtn
            //
            this.clearBtn.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.clearBtn.Location = new System.Drawing.Point(891, 393);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(105, 34);
            this.clearBtn.TabIndex = 8;
            this.clearBtn.Text = "清空";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            //
            // tcpTimer
            //
            this.tcpTimer.Interval = 1000;
            this.tcpTimer.Tick += new System.EventHandler(this.tcpTimer_Tick);
            //
            // xyChat1
            //
            this.xyChat1.AxisColor = System.Drawing.Color.Black;
            this.xyChat1.AxisTextColor = System.Drawing.Color.Black;
            this.xyChat1.BgColor = System.Drawing.Color.Snow;
            this.xyChat1.BorderColor = System.Drawing.Color.Black;
            this.xyChat1.CurveColors = new System.Drawing.Color[]
            {
                System.Drawing.Color.Red,
                System.Drawing.Color.Blue
            };
            this.xyChat1.CurveSize = 2;
            this.xyChat1.FontSize = 9;
            this.xyChat1.Length = 0;
            this.xyChat1.Location = new System.Drawing.Point(523, 116);
            this.xyChat1.Name = "xyChat1";
            this.xyChat1.Size = new System.Drawing.Size(473, 300);
            this.xyChat1.SliceColor = System.Drawing.Color.Black;
            this.xyChat1.SliceTextColor = System.Drawing.Color.Black;
            this.xyChat1.TabIndex = 9;
            this.xyChat1.Tension = 0.5F;
            this.xyChat1.TextColor = System.Drawing.Color.Black;
            this.xyChat1.Title = "曲线图";
            this.xyChat1.Visible = false;
            this.xyChat1.XAxisText = "点位";
            this.xyChat1.XRotateAngle = 30F;
            this.xyChat1.XSlice = 41.44444F;
            this.xyChat1.XSpace = 50F;
            this.xyChat1.XYHeight = 300F;
            this.xyChat1.XYWidth = 473F;
            this.xyChat1.YAxisText = "扭力值(kgf.cm)";
            this.xyChat1.YRotateAngle = 0F;
            this.xyChat1.YSlice = 50F;
            this.xyChat1.YSliceBegin = 0F;
            this.xyChat1.YSliceValue = 20F;
            this.xyChat1.YSpace = 50F;
            //
            // listBox2
            //
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(523, 618);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(473, 100);
            this.listBox2.TabIndex = 10;
            //
            // solingScrew
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.productName);
            this.Controls.Add(this.timeUnit);
            this.Controls.Add(this.testTime);
            this.Controls.Add(this.testTimeLb);
            this.Controls.Add(this.straitRate);
            this.Controls.Add(this.straitRateLb);
            this.Controls.Add(this.pcsUnitLb);
            this.Controls.Add(this.testNum);
            this.Controls.Add(this.testNumLb);
            this.Controls.Add(this.productNameLb);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.quitSysBtn);
            this.Controls.Add(this.datCleanBtn);
            this.Controls.Add(this.CPKBtn);
            this.Controls.Add(this.posSetBtn);
            this.Controls.Add(this.sysSetBtn);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.xyChat1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "solingScrew";
            this.Text = "螺丝机操作平台";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.solingScrew_FormClosing);
            this.Load += new System.EventHandler(this.solingScrew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        
        #endregion
        
        private System.Windows.Forms.Button sysSetBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button posSetBtn;
        private System.Windows.Forms.Button CPKBtn;
        private System.Windows.Forms.Button datCleanBtn;
        private System.Windows.Forms.Button quitSysBtn;
        private System.Windows.Forms.Label productNameLb;
        private System.Windows.Forms.Label productName;
        private System.Windows.Forms.Label testNumLb;
        private System.Windows.Forms.Label testNum;
        private System.Windows.Forms.Label pcsUnitLb;
        private System.Windows.Forms.Label straitRateLb;
        private System.Windows.Forms.Label straitRate;
        private System.Windows.Forms.Label testTimeLb;
        private System.Windows.Forms.Label testTime;
        private System.Windows.Forms.Label timeUnit;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Button clearBtn;
        private XYGraph.XYChat xyChat1;
        private System.Windows.Forms.Timer tcpTimer;
        private System.Windows.Forms.ListBox listBox2;
    }
}

