namespace mainPorject
{
    partial class mainWorkForm
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newBeamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backToStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testForcesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.splitContainerMainLeft = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.splitContainerMainLeftRight = new System.Windows.Forms.SplitContainer();
            this.labelShare = new System.Windows.Forms.Label();
            this.labelPos = new System.Windows.Forms.Label();
            this.labelMoment = new System.Windows.Forms.Label();
            this.labelDef = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelSCM = new System.Windows.Forms.Label();
            this.labelSRM = new System.Windows.Forms.Label();
            this.panelShaer = new System.Windows.Forms.Panel();
            this.labelMinShaer = new System.Windows.Forms.Label();
            this.labelMaxShaer = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelMomentom = new System.Windows.Forms.Panel();
            this.labelMaxMomentom = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMainLeft)).BeginInit();
            this.splitContainerMainLeft.Panel1.SuspendLayout();
            this.splitContainerMainLeft.Panel2.SuspendLayout();
            this.splitContainerMainLeft.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMainLeftRight)).BeginInit();
            this.splitContainerMainLeftRight.Panel2.SuspendLayout();
            this.splitContainerMainLeftRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelShaer.SuspendLayout();
            this.panelMomentom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newBeamToolStripMenuItem,
            this.backToStartToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.fileToolStripMenuItem.ShowShortcutKeys = false;
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newBeamToolStripMenuItem
            // 
            this.newBeamToolStripMenuItem.Name = "newBeamToolStripMenuItem";
            this.newBeamToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newBeamToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.newBeamToolStripMenuItem.Text = "New beam";
            this.newBeamToolStripMenuItem.Click += new System.EventHandler(this.newBeamToolStripMenuItem_Click);
            // 
            // backToStartToolStripMenuItem
            // 
            this.backToStartToolStripMenuItem.Name = "backToStartToolStripMenuItem";
            this.backToStartToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.backToStartToolStripMenuItem.Text = "back to start";
            this.backToStartToolStripMenuItem.Click += new System.EventHandler(this.backToStartToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testForcesToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // testForcesToolStripMenuItem
            // 
            this.testForcesToolStripMenuItem.Name = "testForcesToolStripMenuItem";
            this.testForcesToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.testForcesToolStripMenuItem.Text = "Test Forces";
            this.testForcesToolStripMenuItem.Click += new System.EventHandler(this.testForcesToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 520);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.Location = new System.Drawing.Point(0, 24);
            this.MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.splitContainerMainLeft);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.panel1);
            this.MainSplitContainer.Panel2.Controls.Add(this.panelShaer);
            this.MainSplitContainer.Panel2.Controls.Add(this.panelMomentom);
            this.MainSplitContainer.Size = new System.Drawing.Size(784, 496);
            this.MainSplitContainer.SplitterDistance = 488;
            this.MainSplitContainer.TabIndex = 2;
            // 
            // splitContainerMainLeft
            // 
            this.splitContainerMainLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMainLeft.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMainLeft.Name = "splitContainerMainLeft";
            // 
            // splitContainerMainLeft.Panel1
            // 
            this.splitContainerMainLeft.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainerMainLeft.Panel2
            // 
            this.splitContainerMainLeft.Panel2.Controls.Add(this.splitContainerMainLeftRight);
            this.splitContainerMainLeft.Size = new System.Drawing.Size(488, 496);
            this.splitContainerMainLeft.SplitterDistance = 67;
            this.splitContainerMainLeft.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.button5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.trackBar2, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(67, 496);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 45);
            this.button1.TabIndex = 0;
            this.button1.Text = "start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(3, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(61, 45);
            this.button2.TabIndex = 1;
            this.button2.Text = "pause";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(3, 105);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(61, 45);
            this.button3.TabIndex = 2;
            this.button3.Text = "new test";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Location = new System.Drawing.Point(3, 156);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(61, 45);
            this.button4.TabIndex = 3;
            this.button4.Text = "clear";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.Location = new System.Drawing.Point(3, 207);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(61, 45);
            this.button5.TabIndex = 4;
            this.button5.Text = "stop";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // splitContainerMainLeftRight
            // 
            this.splitContainerMainLeftRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMainLeftRight.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMainLeftRight.Name = "splitContainerMainLeftRight";
            this.splitContainerMainLeftRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMainLeftRight.Panel2
            // 
            this.splitContainerMainLeftRight.Panel2.Controls.Add(this.label8);
            this.splitContainerMainLeftRight.Panel2.Controls.Add(this.label7);
            this.splitContainerMainLeftRight.Panel2.Controls.Add(this.labelShare);
            this.splitContainerMainLeftRight.Panel2.Controls.Add(this.labelPos);
            this.splitContainerMainLeftRight.Panel2.Controls.Add(this.labelMoment);
            this.splitContainerMainLeftRight.Panel2.Controls.Add(this.labelDef);
            this.splitContainerMainLeftRight.Panel2.Controls.Add(this.trackBar1);
            this.splitContainerMainLeftRight.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainerMainLeftRight_Panel2_Paint);
            this.splitContainerMainLeftRight.Size = new System.Drawing.Size(417, 496);
            this.splitContainerMainLeftRight.SplitterDistance = 246;
            this.splitContainerMainLeftRight.TabIndex = 0;
            // 
            // labelShare
            // 
            this.labelShare.AutoSize = true;
            this.labelShare.Location = new System.Drawing.Point(34, 121);
            this.labelShare.Name = "labelShare";
            this.labelShare.Size = new System.Drawing.Size(35, 13);
            this.labelShare.TabIndex = 3;
            this.labelShare.Text = "label1";
            // 
            // labelPos
            // 
            this.labelPos.AutoSize = true;
            this.labelPos.Location = new System.Drawing.Point(2, 230);
            this.labelPos.Name = "labelPos";
            this.labelPos.Size = new System.Drawing.Size(35, 13);
            this.labelPos.TabIndex = 4;
            this.labelPos.Text = "label1";
            // 
            // labelMoment
            // 
            this.labelMoment.AutoSize = true;
            this.labelMoment.Location = new System.Drawing.Point(34, 100);
            this.labelMoment.Name = "labelMoment";
            this.labelMoment.Size = new System.Drawing.Size(35, 13);
            this.labelMoment.TabIndex = 5;
            this.labelMoment.Text = "label1";
            // 
            // labelDef
            // 
            this.labelDef.AutoSize = true;
            this.labelDef.Location = new System.Drawing.Point(34, 142);
            this.labelDef.Name = "labelDef";
            this.labelDef.Size = new System.Drawing.Size(35, 13);
            this.labelDef.TabIndex = 6;
            this.labelDef.Text = "label1";
            // 
            // trackBar1
            // 
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trackBar1.Location = new System.Drawing.Point(0, 201);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(417, 45);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.labelSCM);
            this.panel1.Controls.Add(this.labelSRM);
            this.panel1.Location = new System.Drawing.Point(4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 118);
            this.panel1.TabIndex = 2;
            // 
            // labelSCM
            // 
            this.labelSCM.AutoSize = true;
            this.labelSCM.Location = new System.Drawing.Point(19, 40);
            this.labelSCM.Name = "labelSCM";
            this.labelSCM.Size = new System.Drawing.Size(121, 13);
            this.labelSCM.TabIndex = 0;
            this.labelSCM.Text = "Section crack moment : ";
            // 
            // labelSRM
            // 
            this.labelSRM.AutoSize = true;
            this.labelSRM.Location = new System.Drawing.Point(19, 13);
            this.labelSRM.Name = "labelSRM";
            this.labelSRM.Size = new System.Drawing.Size(145, 13);
            this.labelSRM.TabIndex = 0;
            this.labelSRM.Text = "Section resistance moment : ";
            // 
            // panelShaer
            // 
            this.panelShaer.Controls.Add(this.labelMinShaer);
            this.panelShaer.Controls.Add(this.labelMaxShaer);
            this.panelShaer.Controls.Add(this.label2);
            this.panelShaer.Location = new System.Drawing.Point(4, 127);
            this.panelShaer.Name = "panelShaer";
            this.panelShaer.Size = new System.Drawing.Size(276, 180);
            this.panelShaer.TabIndex = 1;
            // 
            // labelMinShaer
            // 
            this.labelMinShaer.AutoSize = true;
            this.labelMinShaer.Location = new System.Drawing.Point(84, 161);
            this.labelMinShaer.Name = "labelMinShaer";
            this.labelMinShaer.Size = new System.Drawing.Size(0, 13);
            this.labelMinShaer.TabIndex = 3;
            // 
            // labelMaxShaer
            // 
            this.labelMaxShaer.AutoSize = true;
            this.labelMaxShaer.Location = new System.Drawing.Point(37, 169);
            this.labelMaxShaer.Name = "labelMaxShaer";
            this.labelMaxShaer.Size = new System.Drawing.Size(0, 13);
            this.labelMaxShaer.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "shaer diagram";
            // 
            // panelMomentom
            // 
            this.panelMomentom.Controls.Add(this.labelMaxMomentom);
            this.panelMomentom.Controls.Add(this.label1);
            this.panelMomentom.Location = new System.Drawing.Point(4, 313);
            this.panelMomentom.Name = "panelMomentom";
            this.panelMomentom.Size = new System.Drawing.Size(276, 180);
            this.panelMomentom.TabIndex = 0;
            // 
            // labelMaxMomentom
            // 
            this.labelMaxMomentom.AutoSize = true;
            this.labelMaxMomentom.Location = new System.Drawing.Point(169, 13);
            this.labelMaxMomentom.Name = "labelMaxMomentom";
            this.labelMaxMomentom.Size = new System.Drawing.Size(0, 13);
            this.labelMaxMomentom.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "bending momentom diagram";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // trackBar2
            // 
            this.trackBar2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar2.Location = new System.Drawing.Point(3, 328);
            this.trackBar2.Minimum = 1;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar2.Size = new System.Drawing.Size(61, 111);
            this.trackBar2.TabIndex = 5;
            this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar2.Value = 1;
            this.trackBar2.ValueChanged += new System.EventHandler(this.trackBar2_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 39);
            this.label3.TabIndex = 6;
            this.label3.Text = "update speed per second";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Strength  Reduction Factor : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Maximum reinforcement :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "label7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(49, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "label8";
            // 
            // mainWorkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 542);
            this.Controls.Add(this.MainSplitContainer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainWorkForm";
            this.Text = "mainWorkForm";
            this.Load += new System.EventHandler(this.mainWorkForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.splitContainerMainLeft.Panel1.ResumeLayout(false);
            this.splitContainerMainLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMainLeft)).EndInit();
            this.splitContainerMainLeft.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainerMainLeftRight.Panel2.ResumeLayout(false);
            this.splitContainerMainLeftRight.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMainLeftRight)).EndInit();
            this.splitContainerMainLeftRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelShaer.ResumeLayout(false);
            this.panelShaer.PerformLayout();
            this.panelMomentom.ResumeLayout(false);
            this.panelMomentom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.SplitContainer splitContainerMainLeft;
        private System.Windows.Forms.SplitContainer splitContainerMainLeftRight;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newBeamToolStripMenuItem;
        private System.Windows.Forms.Panel panelMomentom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelShare;
        private System.Windows.Forms.Label labelPos;
        private System.Windows.Forms.Label labelMoment;
        private System.Windows.Forms.Label labelDef;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label labelMaxMomentom;
        private System.Windows.Forms.Panel panelShaer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelMaxShaer;
        private System.Windows.Forms.Label labelMinShaer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testForcesToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelSCM;
        private System.Windows.Forms.Label labelSRM;
        private System.Windows.Forms.ToolStripMenuItem backToStartToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}