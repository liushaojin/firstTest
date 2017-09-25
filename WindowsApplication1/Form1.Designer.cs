namespace WindowsApplication1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clearRevBtn = new System.Windows.Forms.Button();
            this.Can1Cb = new System.Windows.Forms.CheckBox();
            this.RevListBox = new System.Windows.Forms.ListBox();
            this.Can0Cb = new System.Windows.Forms.CheckBox();
            this.can1GrpBox = new System.Windows.Forms.ComboBox();
            this.can1T1TextBox = new System.Windows.Forms.TextBox();
            this.can1T0TextBox = new System.Windows.Forms.TextBox();
            this.can0GrpBox = new System.Windows.Forms.ComboBox();
            this.can0T1TextBox = new System.Windows.Forms.TextBox();
            this.textBox_AccMask = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_Mode = new System.Windows.Forms.ComboBox();
            this.comboBox_Filter = new System.Windows.Forms.ComboBox();
            this.can0T0TextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_AccCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_devtype = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBox_CANIndex = new System.Windows.Forms.ComboBox();
            this.comboBox_DevIndex = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.listView = new System.Windows.Forms.ListView();
            this.timer_rec = new System.Windows.Forms.Timer(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.canMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.connectM = new System.Windows.Forms.ToolStripMenuItem();
            this.startM = new System.Windows.Forms.ToolStripMenuItem();
            this.resetM = new System.Windows.Forms.ToolStripMenuItem();
            this.upgradeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.bmsUp = new System.Windows.Forms.ToolStripMenuItem();
            this.canUp = new System.Windows.Forms.ToolStripMenuItem();
            this.sampleUp = new System.Windows.Forms.ToolStripMenuItem();
            this.deviceMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.canDeviceM = new System.Windows.Forms.ToolStripMenuItem();
            this.sampleDeviceM = new System.Windows.Forms.ToolStripMenuItem();
            this.insulatorDeviceM = new System.Windows.Forms.ToolStripMenuItem();
            this.signalMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.innerCanM = new System.Windows.Forms.ToolStripMenuItem();
            this.externalCanM = new System.Windows.Forms.ToolStripMenuItem();
            this.dataMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.importM = new System.Windows.Forms.ToolStripMenuItem();
            this.exportM = new System.Windows.Forms.ToolStripMenuItem();
            this.aboubMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.copyRightM = new System.Windows.Forms.ToolStripMenuItem();
            this.userManualM = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.sendListBox = new System.Windows.Forms.ListBox();
            this.clearSendBtn = new System.Windows.Forms.Button();
            this.comboBox_FrameFormat = new System.Windows.Forms.ComboBox();
            this.comboBox_FrameType = new System.Windows.Forms.ComboBox();
            this.button_Send = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox_SendType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_Data = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.errorlistV = new System.Windows.Forms.ListView();
            this.errorGrpBox = new System.Windows.Forms.GroupBox();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.errorGrpBox.SuspendLayout();
            this.SuspendLayout();
            //
            // groupBox1
            //
            this.groupBox1.BackColor = System.Drawing.Color.Gray;
            this.groupBox1.Controls.Add(this.clearRevBtn);
            this.groupBox1.Controls.Add(this.Can1Cb);
            this.groupBox1.Controls.Add(this.RevListBox);
            this.groupBox1.Controls.Add(this.Can0Cb);
            this.groupBox1.Controls.Add(this.can1GrpBox);
            this.groupBox1.Controls.Add(this.can1T1TextBox);
            this.groupBox1.Controls.Add(this.can1T0TextBox);
            this.groupBox1.Controls.Add(this.can0GrpBox);
            this.groupBox1.Controls.Add(this.can0T1TextBox);
            this.groupBox1.Controls.Add(this.textBox_AccMask);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboBox_Mode);
            this.groupBox1.Controls.Add(this.comboBox_Filter);
            this.groupBox1.Controls.Add(this.can0T0TextBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox_AccCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox_devtype);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.comboBox_CANIndex);
            this.groupBox1.Controls.Add(this.comboBox_DevIndex);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(0, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(530, 355);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设备参数";
            //
            // clearRevBtn
            //
            this.clearRevBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearRevBtn.Location = new System.Drawing.Point(446, 254);
            this.clearRevBtn.Name = "clearRevBtn";
            this.clearRevBtn.Size = new System.Drawing.Size(75, 23);
            this.clearRevBtn.TabIndex = 24;
            this.clearRevBtn.Text = "清空接收";
            this.clearRevBtn.UseVisualStyleBackColor = true;
            this.clearRevBtn.Click += new System.EventHandler(this.clearRevBtn_Click);
            //
            // Can1Cb
            //
            this.Can1Cb.AutoSize = true;
            this.Can1Cb.Location = new System.Drawing.Point(446, 309);
            this.Can1Cb.Name = "Can1Cb";
            this.Can1Cb.Size = new System.Drawing.Size(48, 16);
            this.Can1Cb.TabIndex = 23;
            this.Can1Cb.Text = "CAN1";
            this.Can1Cb.UseVisualStyleBackColor = true;
            this.Can1Cb.Visible = false;
            this.Can1Cb.CheckedChanged += new System.EventHandler(this.Can1Cb_CheckedChanged);
            //
            // RevListBox
            //
            this.RevListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RevListBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.RevListBox.FormattingEnabled = true;
            this.RevListBox.ItemHeight = 12;
            this.RevListBox.Location = new System.Drawing.Point(5, 20);
            this.RevListBox.Name = "RevListBox";
            this.RevListBox.Size = new System.Drawing.Size(520, 232);
            this.RevListBox.TabIndex = 0;
            //
            // Can0Cb
            //
            this.Can0Cb.AutoSize = true;
            this.Can0Cb.Location = new System.Drawing.Point(446, 282);
            this.Can0Cb.Name = "Can0Cb";
            this.Can0Cb.Size = new System.Drawing.Size(48, 16);
            this.Can0Cb.TabIndex = 22;
            this.Can0Cb.Text = "CAN0";
            this.Can0Cb.UseVisualStyleBackColor = true;
            this.Can0Cb.Visible = false;
            this.Can0Cb.CheckedChanged += new System.EventHandler(this.Can0Cb_CheckedChanged);
            //
            // can1GrpBox
            //
            this.can1GrpBox.BackColor = System.Drawing.Color.Gray;
            this.can1GrpBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.can1GrpBox.ForeColor = System.Drawing.Color.LawnGreen;
            this.can1GrpBox.FormattingEnabled = true;
            this.can1GrpBox.Location = new System.Drawing.Point(355, 307);
            this.can1GrpBox.Name = "can1GrpBox";
            this.can1GrpBox.Size = new System.Drawing.Size(81, 20);
            this.can1GrpBox.TabIndex = 21;
            this.can1GrpBox.SelectedIndexChanged += new System.EventHandler(this.can1GrpBox_SelectedIndexChanged);
            //
            // can1T1TextBox
            //
            this.can1T1TextBox.Location = new System.Drawing.Point(301, 307);
            this.can1T1TextBox.Name = "can1T1TextBox";
            this.can1T1TextBox.Size = new System.Drawing.Size(38, 21);
            this.can1T1TextBox.TabIndex = 19;
            //
            // can1T0TextBox
            //
            this.can1T0TextBox.Location = new System.Drawing.Point(253, 307);
            this.can1T0TextBox.Name = "can1T0TextBox";
            this.can1T0TextBox.Size = new System.Drawing.Size(38, 21);
            this.can1T0TextBox.TabIndex = 20;
            //
            // can0GrpBox
            //
            this.can0GrpBox.BackColor = System.Drawing.Color.Gray;
            this.can0GrpBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.can0GrpBox.ForeColor = System.Drawing.Color.LawnGreen;
            this.can0GrpBox.FormattingEnabled = true;
            this.can0GrpBox.Location = new System.Drawing.Point(355, 280);
            this.can0GrpBox.Name = "can0GrpBox";
            this.can0GrpBox.Size = new System.Drawing.Size(81, 20);
            this.can0GrpBox.TabIndex = 18;
            this.can0GrpBox.SelectedIndexChanged += new System.EventHandler(this.can0GrpBox_SelectedIndexChanged);
            //
            // can0T1TextBox
            //
            this.can0T1TextBox.Location = new System.Drawing.Point(301, 280);
            this.can0T1TextBox.Name = "can0T1TextBox";
            this.can0T1TextBox.Size = new System.Drawing.Size(38, 21);
            this.can0T1TextBox.TabIndex = 12;
            //
            // textBox_AccMask
            //
            this.textBox_AccMask.Location = new System.Drawing.Point(67, 307);
            this.textBox_AccMask.Name = "textBox_AccMask";
            this.textBox_AccMask.Size = new System.Drawing.Size(105, 21);
            this.textBox_AccMask.TabIndex = 13;
            //
            // label6
            //
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(178, 313);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "CAN1波特率:";
            //
            // comboBox_Mode
            //
            this.comboBox_Mode.BackColor = System.Drawing.Color.Gray;
            this.comboBox_Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Mode.ForeColor = System.Drawing.Color.LawnGreen;
            this.comboBox_Mode.FormattingEnabled = true;
            this.comboBox_Mode.Items.AddRange(new object[]
            {
                "正常",
                "只听"
            });
            this.comboBox_Mode.Location = new System.Drawing.Point(221, 334);
            this.comboBox_Mode.Name = "comboBox_Mode";
            this.comboBox_Mode.Size = new System.Drawing.Size(70, 20);
            this.comboBox_Mode.TabIndex = 14;
            this.comboBox_Mode.SelectedIndexChanged += new System.EventHandler(this.comboBox_Mode_SelectedIndexChanged);
            //
            // comboBox_Filter
            //
            this.comboBox_Filter.BackColor = System.Drawing.Color.Gray;
            this.comboBox_Filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Filter.ForeColor = System.Drawing.Color.LawnGreen;
            this.comboBox_Filter.FormattingEnabled = true;
            this.comboBox_Filter.Items.AddRange(new object[]
            {
                "双滤波",
                "单滤波"
            });
            this.comboBox_Filter.Location = new System.Drawing.Point(67, 334);
            this.comboBox_Filter.Name = "comboBox_Filter";
            this.comboBox_Filter.Size = new System.Drawing.Size(105, 20);
            this.comboBox_Filter.TabIndex = 15;
            this.comboBox_Filter.SelectedIndexChanged += new System.EventHandler(this.comboBox_Filter_SelectedIndexChanged);
            //
            // can0T0TextBox
            //
            this.can0T0TextBox.Location = new System.Drawing.Point(253, 280);
            this.can0T0TextBox.Name = "can0T0TextBox";
            this.can0T0TextBox.Size = new System.Drawing.Size(38, 21);
            this.can0T0TextBox.TabIndex = 16;
            //
            // label8
            //
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(178, 338);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "模式:";
            //
            // label7
            //
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 338);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "滤波方式:";
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 313);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "屏蔽码:0x";
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 286);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "CAN0波特率:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            //
            // textBox_AccCode
            //
            this.textBox_AccCode.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_AccCode.Location = new System.Drawing.Point(67, 280);
            this.textBox_AccCode.Name = "textBox_AccCode";
            this.textBox_AccCode.Size = new System.Drawing.Size(105, 21);
            this.textBox_AccCode.TabIndex = 17;
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "验收码:0x";
            //
            // comboBox_devtype
            //
            this.comboBox_devtype.BackColor = System.Drawing.Color.Gray;
            this.comboBox_devtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_devtype.ForeColor = System.Drawing.Color.LawnGreen;
            this.comboBox_devtype.FormattingEnabled = true;
            this.comboBox_devtype.Items.AddRange(new object[]
            {
                "3",
                "4",
                "5"
            });
            this.comboBox_devtype.Location = new System.Drawing.Point(67, 255);
            this.comboBox_devtype.MaxDropDownItems = 15;
            this.comboBox_devtype.Name = "comboBox_devtype";
            this.comboBox_devtype.Size = new System.Drawing.Size(105, 20);
            this.comboBox_devtype.TabIndex = 5;
            this.comboBox_devtype.SelectedIndexChanged += new System.EventHandler(this.comboBox_devtype_SelectedIndexChanged);
            //
            // label14
            //
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(4, 259);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 12);
            this.label14.TabIndex = 4;
            this.label14.Text = "设备类型:";
            //
            // comboBox_CANIndex
            //
            this.comboBox_CANIndex.BackColor = System.Drawing.Color.Gray;
            this.comboBox_CANIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_CANIndex.ForeColor = System.Drawing.Color.LawnGreen;
            this.comboBox_CANIndex.FormattingEnabled = true;
            this.comboBox_CANIndex.Items.AddRange(new object[]
            {
                "0",
                "1"
            });
            this.comboBox_CANIndex.Location = new System.Drawing.Point(355, 255);
            this.comboBox_CANIndex.Name = "comboBox_CANIndex";
            this.comboBox_CANIndex.Size = new System.Drawing.Size(81, 20);
            this.comboBox_CANIndex.TabIndex = 1;
            this.comboBox_CANIndex.SelectedIndexChanged += new System.EventHandler(this.comboBox_CANIndex_SelectedIndexChanged);
            //
            // comboBox_DevIndex
            //
            this.comboBox_DevIndex.BackColor = System.Drawing.Color.Gray;
            this.comboBox_DevIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DevIndex.ForeColor = System.Drawing.Color.LawnGreen;
            this.comboBox_DevIndex.FormattingEnabled = true;
            this.comboBox_DevIndex.Items.AddRange(new object[]
            {
                "0",
                "1",
                "2"
            });
            this.comboBox_DevIndex.Location = new System.Drawing.Point(228, 255);
            this.comboBox_DevIndex.Name = "comboBox_DevIndex";
            this.comboBox_DevIndex.Size = new System.Drawing.Size(63, 20);
            this.comboBox_DevIndex.TabIndex = 1;
            this.comboBox_DevIndex.SelectedIndexChanged += new System.EventHandler(this.comboBox_DevIndex_SelectedIndexChanged);
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "CAN索引:";
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "设备号:";
            //
            // dataGridView1
            //
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.dataGridView1.Location = new System.Drawing.Point(5, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(520, 232);
            this.dataGridView1.TabIndex = 11;
            //
            // listView
            //
            this.listView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.listView.Location = new System.Drawing.Point(5, 15);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(520, 176);
            this.listView.TabIndex = 13;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.Visible = false;
            //
            // timer_rec
            //
            this.timer_rec.Tick += new System.EventHandler(this.timer_rec_Tick);
            //
            // toolStrip
            //
            this.toolStrip.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip.Location = new System.Drawing.Point(0, 25);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1008, 25);
            this.toolStrip.TabIndex = 9;
            this.toolStrip.Text = "toolStrip1";
            //
            // tabControl
            //
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl.Location = new System.Drawing.Point(780, 50);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(228, 610);
            this.tabControl.TabIndex = 10;
            //
            // tabPage1
            //
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(220, 584);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "主机信息";
            //
            // tabPage2
            //
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(220, 584);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "单体信息";
            //
            // tabPage3
            //
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(220, 584);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "命令列表";
            //
            // menuStrip
            //
            this.menuStrip.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.canMenu,
                this.upgradeMenu,
                this.deviceMenu,
                this.signalMenu,
                this.dataMenu,
                this.aboubMenu
            });
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1008, 25);
            this.menuStrip.TabIndex = 12;
            this.menuStrip.Text = "menuStrip1";
            //
            // canMenu
            //
            this.canMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.connectM,
                this.startM,
                this.resetM
            });
            this.canMenu.Name = "canMenu";
            this.canMenu.Size = new System.Drawing.Size(68, 21);
            this.canMenu.Text = "Can口(&F)";
            //
            // connectM
            //
            this.connectM.Name = "connectM";
            this.connectM.Size = new System.Drawing.Size(116, 22);
            this.connectM.Text = "连接(&C)";
            this.connectM.Click += new System.EventHandler(this.connectM_Click);
            //
            // startM
            //
            this.startM.Name = "startM";
            this.startM.Size = new System.Drawing.Size(116, 22);
            this.startM.Text = "启动(&S)";
            this.startM.Click += new System.EventHandler(this.startM_Click);
            //
            // resetM
            //
            this.resetM.Name = "resetM";
            this.resetM.Size = new System.Drawing.Size(116, 22);
            this.resetM.Text = "复位(&R)";
            this.resetM.Click += new System.EventHandler(this.resetM_Click);
            //
            // upgradeMenu
            //
            this.upgradeMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.bmsUp,
                this.canUp,
                this.sampleUp
            });
            this.upgradeMenu.Name = "upgradeMenu";
            this.upgradeMenu.Size = new System.Drawing.Size(61, 21);
            this.upgradeMenu.Text = "升级(&U)";
            //
            // bmsUp
            //
            this.bmsUp.Name = "bmsUp";
            this.bmsUp.Size = new System.Drawing.Size(143, 22);
            this.bmsUp.Text = "BMS主机(&B)";
            //
            // canUp
            //
            this.canUp.Name = "canUp";
            this.canUp.Size = new System.Drawing.Size(143, 22);
            this.canUp.Text = "CAN盒(&C)";
            //
            // sampleUp
            //
            this.sampleUp.Name = "sampleUp";
            this.sampleUp.Size = new System.Drawing.Size(143, 22);
            this.sampleUp.Text = "采集模块(&S)";
            //
            // deviceMenu
            //
            this.deviceMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.canDeviceM,
                this.sampleDeviceM,
                this.insulatorDeviceM
            });
            this.deviceMenu.Name = "deviceMenu";
            this.deviceMenu.Size = new System.Drawing.Size(61, 21);
            this.deviceMenu.Text = "设备(&D)";
            //
            // canDeviceM
            //
            this.canDeviceM.Name = "canDeviceM";
            this.canDeviceM.Size = new System.Drawing.Size(154, 22);
            this.canDeviceM.Text = "充电CAN盒(&C)";
            //
            // sampleDeviceM
            //
            this.sampleDeviceM.Name = "sampleDeviceM";
            this.sampleDeviceM.Size = new System.Drawing.Size(154, 22);
            this.sampleDeviceM.Text = "采集模块(&S)";
            //
            // insulatorDeviceM
            //
            this.insulatorDeviceM.Name = "insulatorDeviceM";
            this.insulatorDeviceM.Size = new System.Drawing.Size(154, 22);
            this.insulatorDeviceM.Text = "绝缘模块(&I)";
            //
            // signalMenu
            //
            this.signalMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.innerCanM,
                this.externalCanM
            });
            this.signalMenu.Name = "signalMenu";
            this.signalMenu.Size = new System.Drawing.Size(64, 21);
            this.signalMenu.Text = "报文(&M)";
            //
            // innerCanM
            //
            this.innerCanM.Name = "innerCanM";
            this.innerCanM.Size = new System.Drawing.Size(153, 22);
            this.innerCanM.Text = "内CAN报文(&I)";
            //
            // externalCanM
            //
            this.externalCanM.Name = "externalCanM";
            this.externalCanM.Size = new System.Drawing.Size(153, 22);
            this.externalCanM.Text = "外CAN报文(&E)";
            //
            // dataMenu
            //
            this.dataMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.importM,
                this.exportM
            });
            this.dataMenu.Name = "dataMenu";
            this.dataMenu.Size = new System.Drawing.Size(61, 21);
            this.dataMenu.Text = "数据(&D)";
            //
            // importM
            //
            this.importM.Name = "importM";
            this.importM.Size = new System.Drawing.Size(115, 22);
            this.importM.Text = "导入(&I)";
            //
            // exportM
            //
            this.exportM.Name = "exportM";
            this.exportM.Size = new System.Drawing.Size(115, 22);
            this.exportM.Text = "导出(&E)";
            //
            // aboubMenu
            //
            this.aboubMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.copyRightM,
                this.userManualM
            });
            this.aboubMenu.Name = "aboubMenu";
            this.aboubMenu.Size = new System.Drawing.Size(60, 21);
            this.aboubMenu.Text = "关于(&A)";
            //
            // copyRightM
            //
            this.copyRightM.Name = "copyRightM";
            this.copyRightM.Size = new System.Drawing.Size(141, 22);
            this.copyRightM.Text = "版权(&C)";
            //
            // userManualM
            //
            this.userManualM.Name = "userManualM";
            this.userManualM.Size = new System.Drawing.Size(141, 22);
            this.userManualM.Text = "用户手册(&U)";
            //
            // groupBox3
            //
            this.groupBox3.BackColor = System.Drawing.Color.Gray;
            this.groupBox3.Controls.Add(this.sendListBox);
            this.groupBox3.Controls.Add(this.clearSendBtn);
            this.groupBox3.Controls.Add(this.listView);
            this.groupBox3.Controls.Add(this.comboBox_FrameFormat);
            this.groupBox3.Controls.Add(this.comboBox_FrameType);
            this.groupBox3.Controls.Add(this.button_Send);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.comboBox_SendType);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.textBox_Data);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.textBox_ID);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(0, 411);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(530, 249);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发送数据";
            //
            // sendListBox
            //
            this.sendListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sendListBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.sendListBox.FormattingEnabled = true;
            this.sendListBox.ItemHeight = 12;
            this.sendListBox.Location = new System.Drawing.Point(5, 15);
            this.sendListBox.Name = "sendListBox";
            this.sendListBox.Size = new System.Drawing.Size(520, 172);
            this.sendListBox.TabIndex = 15;
            //
            // clearSendBtn
            //
            this.clearSendBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearSendBtn.Location = new System.Drawing.Point(450, 221);
            this.clearSendBtn.Name = "clearSendBtn";
            this.clearSendBtn.Size = new System.Drawing.Size(71, 23);
            this.clearSendBtn.TabIndex = 14;
            this.clearSendBtn.Text = "清空发送";
            this.clearSendBtn.UseVisualStyleBackColor = true;
            this.clearSendBtn.Click += new System.EventHandler(this.clearSendBtn_Click);
            //
            // comboBox_FrameFormat
            //
            this.comboBox_FrameFormat.BackColor = System.Drawing.Color.Gray;
            this.comboBox_FrameFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_FrameFormat.ForeColor = System.Drawing.Color.LawnGreen;
            this.comboBox_FrameFormat.FormattingEnabled = true;
            this.comboBox_FrameFormat.Items.AddRange(new object[]
            {
                "数据帧",
                "远程帧"
            });
            this.comboBox_FrameFormat.Location = new System.Drawing.Point(324, 195);
            this.comboBox_FrameFormat.Name = "comboBox_FrameFormat";
            this.comboBox_FrameFormat.Size = new System.Drawing.Size(70, 20);
            this.comboBox_FrameFormat.TabIndex = 1;
            //
            // comboBox_FrameType
            //
            this.comboBox_FrameType.BackColor = System.Drawing.Color.Gray;
            this.comboBox_FrameType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_FrameType.ForeColor = System.Drawing.Color.LawnGreen;
            this.comboBox_FrameType.FormattingEnabled = true;
            this.comboBox_FrameType.Items.AddRange(new object[]
            {
                "标准帧",
                "扩展帧"
            });
            this.comboBox_FrameType.Location = new System.Drawing.Point(197, 196);
            this.comboBox_FrameType.Name = "comboBox_FrameType";
            this.comboBox_FrameType.Size = new System.Drawing.Size(70, 20);
            this.comboBox_FrameType.TabIndex = 1;
            //
            // button_Send
            //
            this.button_Send.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Send.Location = new System.Drawing.Point(320, 221);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(75, 23);
            this.button_Send.TabIndex = 5;
            this.button_Send.Text = "发送";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            //
            // label11
            //
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(275, 199);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "帧格式:";
            //
            // label10
            //
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(148, 200);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "帧类型:";
            //
            // comboBox_SendType
            //
            this.comboBox_SendType.BackColor = System.Drawing.Color.Gray;
            this.comboBox_SendType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_SendType.ForeColor = System.Drawing.Color.LawnGreen;
            this.comboBox_SendType.FormattingEnabled = true;
            this.comboBox_SendType.Items.AddRange(new object[]
            {
                "正常发送",
                "单次正常发送",
                "自发自收",
                "单次自发自收"
            });
            this.comboBox_SendType.Location = new System.Drawing.Point(71, 196);
            this.comboBox_SendType.Name = "comboBox_SendType";
            this.comboBox_SendType.Size = new System.Drawing.Size(70, 20);
            this.comboBox_SendType.TabIndex = 1;
            //
            // label9
            //
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 200);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "发送格式:";
            //
            // textBox_Data
            //
            this.textBox_Data.Location = new System.Drawing.Point(51, 222);
            this.textBox_Data.Name = "textBox_Data";
            this.textBox_Data.Size = new System.Drawing.Size(251, 21);
            this.textBox_Data.TabIndex = 1;
            //
            // label13
            //
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 228);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "数据:";
            //
            // textBox_ID
            //
            this.textBox_ID.Location = new System.Drawing.Point(450, 194);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.Size = new System.Drawing.Size(70, 21);
            this.textBox_ID.TabIndex = 1;
            //
            // label12
            //
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(400, 200);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "帧ID:0x";
            //
            // errorlistV
            //
            this.errorlistV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.errorlistV.ForeColor = System.Drawing.Color.Red;
            this.errorlistV.Location = new System.Drawing.Point(3, 20);
            this.errorlistV.Name = "errorlistV";
            this.errorlistV.Size = new System.Drawing.Size(238, 584);
            this.errorlistV.TabIndex = 14;
            this.errorlistV.UseCompatibleStateImageBehavior = false;
            //
            // errorGrpBox
            //
            this.errorGrpBox.Controls.Add(this.errorlistV);
            this.errorGrpBox.Location = new System.Drawing.Point(533, 50);
            this.errorGrpBox.Name = "errorGrpBox";
            this.errorGrpBox.Size = new System.Drawing.Size(245, 610);
            this.errorGrpBox.TabIndex = 15;
            this.errorGrpBox.TabStop = false;
            this.errorGrpBox.Text = "故障区";
            //
            // richTextBox
            //
            this.richTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.richTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.richTextBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.richTextBox.Location = new System.Drawing.Point(0, 660);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(1008, 70);
            this.richTextBox.TabIndex = 13;
            this.richTextBox.Text = "";
            //
            // Form1
            //
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.errorGrpBox);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.LawnGreen;
            this.Name = "Form1";
            this.Text = "CAN调试软件";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormDragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormDragEnter);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.errorGrpBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_CANIndex;
        private System.Windows.Forms.ComboBox comboBox_DevIndex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox RevListBox;
        private System.Windows.Forms.Timer timer_rec;
        private System.Windows.Forms.ComboBox comboBox_devtype;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem canMenu;
        private System.Windows.Forms.ToolStripMenuItem upgradeMenu;
        private System.Windows.Forms.ToolStripMenuItem deviceMenu;
        private System.Windows.Forms.ToolStripMenuItem signalMenu;
        private System.Windows.Forms.ToolStripMenuItem aboubMenu;
        private System.Windows.Forms.ToolStripMenuItem connectM;
        private System.Windows.Forms.ToolStripMenuItem startM;
        private System.Windows.Forms.ToolStripMenuItem resetM;
        private System.Windows.Forms.ToolStripMenuItem bmsUp;
        private System.Windows.Forms.ToolStripMenuItem canUp;
        private System.Windows.Forms.ToolStripMenuItem sampleUp;
        private System.Windows.Forms.ToolStripMenuItem canDeviceM;
        private System.Windows.Forms.ToolStripMenuItem sampleDeviceM;
        private System.Windows.Forms.ToolStripMenuItem insulatorDeviceM;
        private System.Windows.Forms.ToolStripMenuItem innerCanM;
        private System.Windows.Forms.ToolStripMenuItem externalCanM;
        private System.Windows.Forms.ToolStripMenuItem dataMenu;
        private System.Windows.Forms.ToolStripMenuItem importM;
        private System.Windows.Forms.ToolStripMenuItem exportM;
        private System.Windows.Forms.ToolStripMenuItem copyRightM;
        private System.Windows.Forms.ToolStripMenuItem userManualM;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.TextBox can0T1TextBox;
        private System.Windows.Forms.TextBox textBox_AccMask;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_Mode;
        private System.Windows.Forms.ComboBox comboBox_Filter;
        private System.Windows.Forms.TextBox can0T0TextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_AccCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBox_FrameFormat;
        private System.Windows.Forms.ComboBox comboBox_FrameType;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox_SendType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_Data;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox_ID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListView errorlistV;
        private System.Windows.Forms.GroupBox errorGrpBox;
        private System.Windows.Forms.ComboBox can0GrpBox;
        private System.Windows.Forms.ComboBox can1GrpBox;
        private System.Windows.Forms.TextBox can1T1TextBox;
        private System.Windows.Forms.TextBox can1T0TextBox;
        private System.Windows.Forms.CheckBox Can1Cb;
        private System.Windows.Forms.CheckBox Can0Cb;
        private System.Windows.Forms.Button clearRevBtn;
        private System.Windows.Forms.Button clearSendBtn;
        private System.Windows.Forms.ListBox sendListBox;
        private System.Windows.Forms.RichTextBox richTextBox;
    }
}

