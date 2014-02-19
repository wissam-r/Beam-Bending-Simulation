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
            this.panelShaer = new System.Windows.Forms.Panel();
            this.labelMinShaer = new System.Windows.Forms.Label();
            this.labelMaxShaer = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelMomentom = new System.Windows.Forms.Panel();
            this.labelMaxMomentom = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.panelShaer.SuspendLayout();
            this.panelMomentom.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newBeamToolStripMenuItem});
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
            this.splitContainerMainLeft.SplitterDistance = 33;
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
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(33, 496);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 93);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(3, 102);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(27, 93);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(3, 201);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(27, 93);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Location = new System.Drawing.Point(3, 300);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(27, 93);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.Location = new System.Drawing.Point(3, 399);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(27, 94);
            this.button5.TabIndex = 4;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
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
            this.splitContainerMainLeftRight.Panel2.Controls.Add(this.labelShare);
            this.splitContainerMainLeftRight.Panel2.Controls.Add(this.labelPos);
            this.splitContainerMainLeftRight.Panel2.Controls.Add(this.labelMoment);
            this.splitContainerMainLeftRight.Panel2.Controls.Add(this.labelDef);
            this.splitContainerMainLeftRight.Panel2.Controls.Add(this.trackBar1);
            this.splitContainerMainLeftRight.Size = new System.Drawing.Size(451, 496);
            this.splitContainerMainLeftRight.SplitterDistance = 355;
            this.splitContainerMainLeftRight.TabIndex = 0;
            // 
            // labelShare
            // 
            this.labelShare.AutoSize = true;
            this.labelShare.Location = new System.Drawing.Point(45, 31);
            this.labelShare.Name = "labelShare";
            this.labelShare.Size = new System.Drawing.Size(35, 13);
            this.labelShare.TabIndex = 3;
            this.labelShare.Text = "label1";
            // 
            // labelPos
            // 
            this.labelPos.AutoSize = true;
            this.labelPos.Location = new System.Drawing.Point(3, 96);
            this.labelPos.Name = "labelPos";
            this.labelPos.Size = new System.Drawing.Size(35, 13);
            this.labelPos.TabIndex = 4;
            this.labelPos.Text = "label1";
            // 
            // labelMoment
            // 
            this.labelMoment.AutoSize = true;
            this.labelMoment.Location = new System.Drawing.Point(45, 0);
            this.labelMoment.Name = "labelMoment";
            this.labelMoment.Size = new System.Drawing.Size(35, 13);
            this.labelMoment.TabIndex = 5;
            this.labelMoment.Text = "label1";
            // 
            // labelDef
            // 
            this.labelDef.AutoSize = true;
            this.labelDef.Location = new System.Drawing.Point(45, 62);
            this.labelDef.Name = "labelDef";
            this.labelDef.Size = new System.Drawing.Size(35, 13);
            this.labelDef.TabIndex = 6;
            this.labelDef.Text = "label1";
            // 
            // trackBar1
            // 
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trackBar1.Location = new System.Drawing.Point(0, 92);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(451, 45);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // panelShaer
            // 
            this.panelShaer.Controls.Add(this.labelMinShaer);
            this.panelShaer.Controls.Add(this.labelMaxShaer);
            this.panelShaer.Controls.Add(this.label2);
            this.panelShaer.Location = new System.Drawing.Point(4, 3);
            this.panelShaer.Name = "panelShaer";
            this.panelShaer.Size = new System.Drawing.Size(276, 222);
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
            this.splitContainerMainLeftRight.Panel2.ResumeLayout(false);
            this.splitContainerMainLeftRight.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMainLeftRight)).EndInit();
            this.splitContainerMainLeftRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panelShaer.ResumeLayout(false);
            this.panelShaer.PerformLayout();
            this.panelMomentom.ResumeLayout(false);
            this.panelMomentom.PerformLayout();
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
    }
}