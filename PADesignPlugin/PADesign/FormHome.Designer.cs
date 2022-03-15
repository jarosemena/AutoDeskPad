using System.Windows.Forms;

namespace PADesign
{
    partial class FormHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHome));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.rtabhome = new System.Windows.Forms.RibbonTab();
            this.rpanelcommon = new System.Windows.Forms.RibbonPanel();
            this.rbutonnew = new System.Windows.Forms.RibbonButton();
            this.rbuttonsave = new System.Windows.Forms.RibbonButton();
            this.rbuttoncopy = new System.Windows.Forms.RibbonButton();
            this.rbuttonopen = new System.Windows.Forms.RibbonButton();
            this.rpaneldesign = new System.Windows.Forms.RibbonPanel();
            this.rbuttonwind = new System.Windows.Forms.RibbonButton();
            this.rtabview = new System.Windows.Forms.RibbonTab();
            this.rtabreport = new System.Windows.Forms.RibbonTab();
            this.rtabhelp = new System.Windows.Forms.RibbonTab();
            this.mtabversion = new System.Windows.Forms.RibbonPanel();
            this.mtablicense = new System.Windows.Forms.RibbonPanel();
            this.mtabmanual = new System.Windows.Forms.RibbonPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Heightz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kzt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ke = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tributary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Windward = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Leeward = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Leesard5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treeGroupDesign = new System.Windows.Forms.TreeView();
            this.txtmodelname = new System.Windows.Forms.TextBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.buttonadd = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkMaxHeight = new System.Windows.Forms.CheckBox();
            this.checkReportParapets = new System.Windows.Forms.CheckBox();
            this.checkWall = new System.Windows.Forms.CheckBox();
            this.checkRoof = new System.Windows.Forms.CheckBox();
            this.checkASD = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rdEnclose = new System.Windows.Forms.RadioButton();
            this.rdOpen = new System.Windows.Forms.RadioButton();
            this.rdPartEncolse = new System.Windows.Forms.RadioButton();
            this.rdPartOpen = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtMeanRoof = new System.Windows.Forms.TextBox();
            this.cmbRoofDegree = new System.Windows.Forms.ComboBox();
            this.checkparapet = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbRoofSlope = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtKe = new System.Windows.Forms.TextBox();
            this.txtKzt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtWindSpeed = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbKd = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCode = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonadd)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon1
            // 
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 447);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013;
            // 
            // 
            // 
            this.ribbon1.QuickAccessToolbar.Items.Add(this.ribbonButton1);
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ribbon1.Size = new System.Drawing.Size(820, 147);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.rtabhome);
            this.ribbon1.Tabs.Add(this.rtabview);
            this.ribbon1.Tabs.Add(this.rtabreport);
            this.ribbon1.Tabs.Add(this.rtabhelp);
            this.ribbon1.TabSpacing = 4;
            this.ribbon1.Text = "s";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Black;
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.Image")));
            this.ribbonButton1.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.LargeImage")));
            this.ribbonButton1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButton1.Name = "ribbonButton1";
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Text = "rbuttonexit";
            // 
            // rtabhome
            // 
            this.rtabhome.Name = "rtabhome";
            this.rtabhome.Panels.Add(this.rpanelcommon);
            this.rtabhome.Panels.Add(this.rpaneldesign);
            this.rtabhome.Text = "Home";
            // 
            // rpanelcommon
            // 
            this.rpanelcommon.Items.Add(this.rbutonnew);
            this.rpanelcommon.Items.Add(this.rbuttonsave);
            this.rpanelcommon.Items.Add(this.rbuttoncopy);
            this.rpanelcommon.Items.Add(this.rbuttonopen);
            this.rpanelcommon.Name = "rpanelcommon";
            this.rpanelcommon.Text = "Common Tasks";
            // 
            // rbutonnew
            // 
            this.rbutonnew.AltKey = "n";
            this.rbutonnew.Image = ((System.Drawing.Image)(resources.GetObject("rbutonnew.Image")));
            this.rbutonnew.LargeImage = ((System.Drawing.Image)(resources.GetObject("rbutonnew.LargeImage")));
            this.rbutonnew.Name = "rbutonnew";
            this.rbutonnew.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbutonnew.SmallImage")));
            this.rbutonnew.Text = "New";
            this.rbutonnew.ToolTip = "New";
            this.rbutonnew.ToolTipTitle = "New";
            // 
            // rbuttonsave
            // 
            this.rbuttonsave.AltKey = "s";
            this.rbuttonsave.Image = ((System.Drawing.Image)(resources.GetObject("rbuttonsave.Image")));
            this.rbuttonsave.LargeImage = ((System.Drawing.Image)(resources.GetObject("rbuttonsave.LargeImage")));
            this.rbuttonsave.Name = "rbuttonsave";
            this.rbuttonsave.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbuttonsave.SmallImage")));
            this.rbuttonsave.Text = "Save";
            this.rbuttonsave.ToolTip = "Save";
            this.rbuttonsave.ToolTipTitle = "Save";
            // 
            // rbuttoncopy
            // 
            this.rbuttoncopy.AltKey = "c";
            this.rbuttoncopy.Image = ((System.Drawing.Image)(resources.GetObject("rbuttoncopy.Image")));
            this.rbuttoncopy.LargeImage = ((System.Drawing.Image)(resources.GetObject("rbuttoncopy.LargeImage")));
            this.rbuttoncopy.Name = "rbuttoncopy";
            this.rbuttoncopy.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbuttoncopy.SmallImage")));
            this.rbuttoncopy.Text = "Copy";
            this.rbuttoncopy.ToolTip = "Copy";
            this.rbuttoncopy.ToolTipTitle = "Copy";
            // 
            // rbuttonopen
            // 
            this.rbuttonopen.AltKey = "o";
            this.rbuttonopen.Image = ((System.Drawing.Image)(resources.GetObject("rbuttonopen.Image")));
            this.rbuttonopen.LargeImage = ((System.Drawing.Image)(resources.GetObject("rbuttonopen.LargeImage")));
            this.rbuttonopen.Name = "rbuttonopen";
            this.rbuttonopen.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbuttonopen.SmallImage")));
            this.rbuttonopen.Text = "Open";
            this.rbuttonopen.ToolTip = "Open";
            this.rbuttonopen.ToolTipTitle = "Open";
            // 
            // rpaneldesign
            // 
            this.rpaneldesign.Items.Add(this.rbuttonwind);
            this.rpaneldesign.Name = "rpaneldesign";
            this.rpaneldesign.Text = "Design Tools";
            // 
            // rbuttonwind
            // 
            this.rbuttonwind.Image = ((System.Drawing.Image)(resources.GetObject("rbuttonwind.Image")));
            this.rbuttonwind.LargeImage = ((System.Drawing.Image)(resources.GetObject("rbuttonwind.LargeImage")));
            this.rbuttonwind.Name = "rbuttonwind";
            this.rbuttonwind.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbuttonwind.SmallImage")));
            this.rbuttonwind.Text = "WindModule";
            this.rbuttonwind.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center;
            // 
            // rtabview
            // 
            this.rtabview.Name = "rtabview";
            this.rtabview.Text = "Views";
            // 
            // rtabreport
            // 
            this.rtabreport.Name = "rtabreport";
            this.rtabreport.Text = "Reports";
            // 
            // rtabhelp
            // 
            this.rtabhelp.Name = "rtabhelp";
            this.rtabhelp.Panels.Add(this.mtabversion);
            this.rtabhelp.Panels.Add(this.mtablicense);
            this.rtabhelp.Panels.Add(this.mtabmanual);
            this.rtabhelp.Text = "Help";
            // 
            // mtabversion
            // 
            this.mtabversion.Name = "mtabversion";
            this.mtabversion.Text = "Version";
            // 
            // mtablicense
            // 
            this.mtablicense.Name = "mtablicense";
            this.mtablicense.Text = "License";
            // 
            // mtabmanual
            // 
            this.mtabmanual.Name = "mtabmanual";
            this.mtabmanual.Text = "Manuals";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Heightz,
            this.Kz,
            this.Kzt,
            this.Ke,
            this.qz,
            this.Tributary,
            this.Windward,
            this.Leeward,
            this.Leesard5});
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(166, 511);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Size = new System.Drawing.Size(641, 205);
            this.dataGridView1.TabIndex = 3;
            // 
            // Heightz
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.Heightz.DefaultCellStyle = dataGridViewCellStyle2;
            this.Heightz.HeaderText = "Height     z (ft)";
            this.Heightz.Name = "Heightz";
            this.Heightz.ReadOnly = true;
            this.Heightz.Width = 60;
            // 
            // Kz
            // 
            this.Kz.FillWeight = 40F;
            this.Kz.HeaderText = "Kz";
            this.Kz.Name = "Kz";
            this.Kz.ReadOnly = true;
            this.Kz.Width = 60;
            // 
            // Kzt
            // 
            this.Kzt.FillWeight = 40F;
            this.Kzt.HeaderText = "Kzt";
            this.Kzt.Name = "Kzt";
            this.Kzt.ReadOnly = true;
            this.Kzt.Width = 60;
            // 
            // Ke
            // 
            this.Ke.FillWeight = 40F;
            this.Ke.HeaderText = "Ke";
            this.Ke.Name = "Ke";
            this.Ke.ReadOnly = true;
            this.Ke.Width = 60;
            // 
            // qz
            // 
            this.qz.FillWeight = 40F;
            this.qz.HeaderText = "qz   (psf)";
            this.qz.Name = "qz";
            this.qz.ReadOnly = true;
            this.qz.Width = 60;
            // 
            // Tributary
            // 
            this.Tributary.FillWeight = 40F;
            this.Tributary.HeaderText = "Tributary Aarea (ft)";
            this.Tributary.Name = "Tributary";
            this.Tributary.Width = 65;
            // 
            // Windward
            // 
            this.Windward.FillWeight = 40F;
            this.Windward.HeaderText = "Windward (4,5)";
            this.Windward.Name = "Windward";
            this.Windward.ReadOnly = true;
            this.Windward.Width = 65;
            // 
            // Leeward
            // 
            this.Leeward.FillWeight = 40F;
            this.Leeward.HeaderText = "Leeward (4)";
            this.Leeward.Name = "Leeward";
            this.Leeward.ReadOnly = true;
            this.Leeward.Width = 60;
            // 
            // Leesard5
            // 
            this.Leesard5.FillWeight = 40F;
            this.Leesard5.HeaderText = "Leeward (5)";
            this.Leesard5.Name = "Leesard5";
            this.Leesard5.ReadOnly = true;
            this.Leesard5.Width = 60;
            // 
            // treeGroupDesign
            // 
            this.treeGroupDesign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeGroupDesign.Location = new System.Drawing.Point(3, 19);
            this.treeGroupDesign.Name = "treeGroupDesign";
            this.treeGroupDesign.Size = new System.Drawing.Size(153, 497);
            this.treeGroupDesign.TabIndex = 0;
            this.treeGroupDesign.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeGroupDesign_AfterSelect);
            // 
            // txtmodelname
            // 
            this.txtmodelname.Location = new System.Drawing.Point(13, 171);
            this.txtmodelname.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtmodelname.Name = "txtmodelname";
            this.txtmodelname.Size = new System.Drawing.Size(116, 23);
            this.txtmodelname.TabIndex = 0;
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(13, 153);
            this.lblModel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(76, 15);
            this.lblModel.TabIndex = 1;
            this.lblModel.Text = "Model Name";
            // 
            // buttonadd
            // 
            this.buttonadd.Image = ((System.Drawing.Image)(resources.GetObject("buttonadd.Image")));
            this.buttonadd.Location = new System.Drawing.Point(137, 171);
            this.buttonadd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonadd.Name = "buttonadd";
            this.buttonadd.Size = new System.Drawing.Size(22, 23);
            this.buttonadd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonadd.TabIndex = 2;
            this.buttonadd.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeGroupDesign);
            this.groupBox1.Location = new System.Drawing.Point(0, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(159, 519);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Design Group";
            this.groupBox1.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbCode);
            this.groupBox2.Location = new System.Drawing.Point(166, 153);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(642, 352);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "WindProperties";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.splitContainer1);
            this.groupBox6.Controls.Add(this.checkASD);
            this.groupBox6.Location = new System.Drawing.Point(310, 191);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(326, 161);
            this.groupBox6.TabIndex = 15;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Customize Report";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer1.Location = new System.Drawing.Point(0, 47);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.numericUpDown1);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox1);
            this.splitContainer1.Panel1.Controls.Add(this.checkMaxHeight);
            this.splitContainer1.Panel1.Controls.Add(this.checkReportParapets);
            this.splitContainer1.Panel1.Controls.Add(this.checkWall);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.checkRoof);
            this.splitContainer1.Size = new System.Drawing.Size(320, 108);
            this.splitContainer1.SplitterDistance = 159;
            this.splitContainer1.TabIndex = 1;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(116, 29);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(33, 23);
            this.numericUpDown1.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(2, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 15);
            this.label10.TabIndex = 4;
            this.label10.Text = "Trib. Area";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(60, 79);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(83, 23);
            this.comboBox1.TabIndex = 3;
            // 
            // checkMaxHeight
            // 
            this.checkMaxHeight.AutoSize = true;
            this.checkMaxHeight.Location = new System.Drawing.Point(5, 56);
            this.checkMaxHeight.Name = "checkMaxHeight";
            this.checkMaxHeight.Size = new System.Drawing.Size(115, 19);
            this.checkMaxHeight.TabIndex = 2;
            this.checkMaxHeight.Text = "Max Height Only";
            this.checkMaxHeight.UseVisualStyleBackColor = true;
            // 
            // checkReportParapets
            // 
            this.checkReportParapets.AutoSize = true;
            this.checkReportParapets.Location = new System.Drawing.Point(5, 30);
            this.checkReportParapets.Name = "checkReportParapets";
            this.checkReportParapets.Size = new System.Drawing.Size(113, 19);
            this.checkReportParapets.TabIndex = 1;
            this.checkReportParapets.Text = "Include Parapets";
            this.checkReportParapets.UseVisualStyleBackColor = true;
            // 
            // checkWall
            // 
            this.checkWall.AutoSize = true;
            this.checkWall.Location = new System.Drawing.Point(5, 5);
            this.checkWall.Name = "checkWall";
            this.checkWall.Size = new System.Drawing.Size(132, 19);
            this.checkWall.TabIndex = 0;
            this.checkWall.Text = "Show Wall Elements";
            this.checkWall.UseVisualStyleBackColor = true;
            // 
            // checkRoof
            // 
            this.checkRoof.AutoSize = true;
            this.checkRoof.Location = new System.Drawing.Point(7, 10);
            this.checkRoof.Name = "checkRoof";
            this.checkRoof.Size = new System.Drawing.Size(134, 19);
            this.checkRoof.TabIndex = 0;
            this.checkRoof.Text = "Show Roof Elements";
            this.checkRoof.UseVisualStyleBackColor = true;
            // 
            // checkASD
            // 
            this.checkASD.AutoSize = true;
            this.checkASD.Location = new System.Drawing.Point(5, 22);
            this.checkASD.Name = "checkASD";
            this.checkASD.Size = new System.Drawing.Size(107, 19);
            this.checkASD.TabIndex = 0;
            this.checkASD.Text = "Convert to ASD";
            this.checkASD.UseVisualStyleBackColor = true;
            this.checkASD.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rdEnclose);
            this.groupBox5.Controls.Add(this.rdOpen);
            this.groupBox5.Controls.Add(this.rdPartEncolse);
            this.groupBox5.Controls.Add(this.rdPartOpen);
            this.groupBox5.Location = new System.Drawing.Point(310, 66);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(326, 112);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Enclosure Classification";
            // 
            // rdEnclose
            // 
            this.rdEnclose.AutoSize = true;
            this.rdEnclose.Location = new System.Drawing.Point(29, 85);
            this.rdEnclose.Name = "rdEnclose";
            this.rdEnclose.Size = new System.Drawing.Size(124, 19);
            this.rdEnclose.TabIndex = 3;
            this.rdEnclose.TabStop = true;
            this.rdEnclose.Text = "Enclosed Buildings";
            this.rdEnclose.UseVisualStyleBackColor = true;
            // 
            // rdOpen
            // 
            this.rdOpen.AutoSize = true;
            this.rdOpen.Location = new System.Drawing.Point(29, 19);
            this.rdOpen.Name = "rdOpen";
            this.rdOpen.Size = new System.Drawing.Size(106, 19);
            this.rdOpen.TabIndex = 2;
            this.rdOpen.TabStop = true;
            this.rdOpen.Text = "Open Buildings";
            this.rdOpen.UseVisualStyleBackColor = true;
            // 
            // rdPartEncolse
            // 
            this.rdPartEncolse.AutoSize = true;
            this.rdPartEncolse.Location = new System.Drawing.Point(29, 63);
            this.rdPartEncolse.Name = "rdPartEncolse";
            this.rdPartEncolse.Size = new System.Drawing.Size(169, 19);
            this.rdPartEncolse.TabIndex = 1;
            this.rdPartEncolse.TabStop = true;
            this.rdPartEncolse.Text = "Partially Enclosed Buildings";
            this.rdPartEncolse.UseVisualStyleBackColor = true;
            // 
            // rdPartOpen
            // 
            this.rdPartOpen.AutoSize = true;
            this.rdPartOpen.Location = new System.Drawing.Point(29, 41);
            this.rdPartOpen.Name = "rdPartOpen";
            this.rdPartOpen.Size = new System.Drawing.Size(148, 19);
            this.rdPartOpen.TabIndex = 0;
            this.rdPartOpen.TabStop = true;
            this.rdPartOpen.Text = "Partialy Open Buildings";
            this.rdPartOpen.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox4.Controls.Add(this.txtMeanRoof);
            this.groupBox4.Controls.Add(this.cmbRoofDegree);
            this.groupBox4.Controls.Add(this.checkparapet);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.cmbRoofSlope);
            this.groupBox4.Location = new System.Drawing.Point(6, 253);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(298, 100);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Bulding Data";
            // 
            // txtMeanRoof
            // 
            this.txtMeanRoof.Location = new System.Drawing.Point(157, 51);
            this.txtMeanRoof.Name = "txtMeanRoof";
            this.txtMeanRoof.Size = new System.Drawing.Size(121, 23);
            this.txtMeanRoof.TabIndex = 14;
            this.txtMeanRoof.TextChanged += new System.EventHandler(this.TxtMeanRoof_TextChanged);
            // 
            // cmbRoofDegree
            // 
            this.cmbRoofDegree.FormattingEnabled = true;
            this.cmbRoofDegree.Location = new System.Drawing.Point(157, 22);
            this.cmbRoofDegree.Name = "cmbRoofDegree";
            this.cmbRoofDegree.Size = new System.Drawing.Size(121, 23);
            this.cmbRoofDegree.TabIndex = 5;
            // 
            // checkparapet
            // 
            this.checkparapet.AutoSize = true;
            this.checkparapet.Location = new System.Drawing.Point(263, 78);
            this.checkparapet.Name = "checkparapet";
            this.checkparapet.Size = new System.Drawing.Size(15, 14);
            this.checkparapet.TabIndex = 4;
            this.checkparapet.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(252, 15);
            this.label9.TabIndex = 3;
            this.label9.Text = "Parapet at least 3\' tall around perimeter of roof";
            this.label9.Click += new System.EventHandler(this.Label9_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "Mean Roof Height, h (ft)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "Roof Slope";
            // 
            // cmbRoofSlope
            // 
            this.cmbRoofSlope.FormattingEnabled = true;
            this.cmbRoofSlope.Location = new System.Drawing.Point(76, 22);
            this.cmbRoofSlope.Name = "cmbRoofSlope";
            this.cmbRoofSlope.Size = new System.Drawing.Size(57, 23);
            this.cmbRoofSlope.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtKe);
            this.groupBox3.Controls.Add(this.txtKzt);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtWindSpeed);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cmbCategory);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cmbKd);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(9, 66);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(295, 181);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Wind Data";
            // 
            // txtKe
            // 
            this.txtKe.Location = new System.Drawing.Point(161, 142);
            this.txtKe.Name = "txtKe";
            this.txtKe.Size = new System.Drawing.Size(122, 23);
            this.txtKe.TabIndex = 13;
            // 
            // txtKzt
            // 
            this.txtKzt.Location = new System.Drawing.Point(161, 82);
            this.txtKzt.Name = "txtKzt";
            this.txtKzt.Size = new System.Drawing.Size(122, 23);
            this.txtKzt.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Exposure Category";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Ground Elevation Factor, Ke";
            // 
            // txtWindSpeed
            // 
            this.txtWindSpeed.Location = new System.Drawing.Point(161, 22);
            this.txtWindSpeed.Name = "txtWindSpeed";
            this.txtWindSpeed.Size = new System.Drawing.Size(123, 23);
            this.txtWindSpeed.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "directionality Factor, Kd";
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(162, 52);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(121, 23);
            this.cmbCategory.TabIndex = 2;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.CmbCategory_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Topo Factor, Kzt (at base)";
            // 
            // cmbKd
            // 
            this.cmbKd.FormattingEnabled = true;
            this.cmbKd.Location = new System.Drawing.Point(162, 112);
            this.cmbKd.Name = "cmbKd";
            this.cmbKd.Size = new System.Drawing.Size(121, 23);
            this.cmbKd.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Basic Wind Speed, V (mph)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Code";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // cmbCode
            // 
            this.cmbCode.FormattingEnabled = true;
            this.cmbCode.Location = new System.Drawing.Point(60, 22);
            this.cmbCode.Name = "cmbCode";
            this.cmbCode.Size = new System.Drawing.Size(121, 23);
            this.cmbCode.TabIndex = 1;
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 723);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonadd);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.txtmodelname);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ribbon1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormHome";
            this.Text = "ForeFrontDesigner";
            this.Load += new System.EventHandler(this.FormHome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonadd)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab rtabhome;
        private System.Windows.Forms.RibbonTab rtabhelp;
        private System.Windows.Forms.RibbonPanel mtabversion;
        private System.Windows.Forms.RibbonPanel mtablicense;
        private System.Windows.Forms.RibbonPanel mtabmanual;
        private System.Windows.Forms.RibbonPanel mtabdesign;
        private System.Windows.Forms.RibbonPanel rpanelcommon;
        private System.Windows.Forms.RibbonPanel rpaneldesign;
        private System.Windows.Forms.RibbonTab rtabview;
        private System.Windows.Forms.RibbonTab rtabreport;
        private System.Windows.Forms.RibbonButton rbuttonsave;
        private System.Windows.Forms.RibbonButton rbutonnew;
        private System.Windows.Forms.RibbonButton rbuttoncopy;
        private System.Windows.Forms.RibbonButton rbuttonopen;
        private System.Windows.Forms.RibbonButton rbuttonwind;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Heightz;
        private DataGridViewTextBoxColumn Kz;
        private DataGridViewTextBoxColumn Kzt;
        private DataGridViewTextBoxColumn Ke;
        private DataGridViewTextBoxColumn qz;
        private DataGridViewTextBoxColumn Tributary;
        private DataGridViewTextBoxColumn Windward;
        private DataGridViewTextBoxColumn Leeward;
        private DataGridViewTextBoxColumn Leesard5;
        private TreeView treeGroupDesign;
        private TextBox txtmodelname;
        private Label lblModel;
        private PictureBox buttonadd;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private ComboBox cmbKd;
        private ComboBox cmbCategory;
        private ComboBox cmbCode;
        private TextBox txtWindSpeed;
        private GroupBox groupBox4;
        private Label label9;
        private Label label8;
        private Label label7;
        private ComboBox cmbRoofSlope;
        private GroupBox groupBox3;
        private Label label3;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label2;
        private GroupBox groupBox6;
        private CheckBox checkASD;
        private GroupBox groupBox5;
        private RadioButton rdEnclose;
        private RadioButton rdOpen;
        private RadioButton rdPartEncolse;
        private RadioButton rdPartOpen;
        private ComboBox cmbRoofDegree;
        private CheckBox checkparapet;
        private SplitContainer splitContainer1;
        private CheckBox checkWall;
        private CheckBox checkRoof;
        private NumericUpDown numericUpDown1;
        private Label label10;
        private ComboBox comboBox1;
        private CheckBox checkMaxHeight;
        private CheckBox checkReportParapets;
        private TextBox txtKzt;
        private TextBox txtKe;
        private TextBox txtMeanRoof;
    }
}