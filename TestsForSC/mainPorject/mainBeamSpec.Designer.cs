namespace mainPorject
{
    partial class mainBeamSpec
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonAddDistributedForce = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.textBoxForceEnd = new System.Windows.Forms.TextBox();
            this.textBoxForceStart = new System.Windows.Forms.TextBox();
            this.textBoxDistributedForce = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonAddPointForce = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.textBoxForceLocation = new System.Windows.Forms.TextBox();
            this.textBoxPointForce = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.drawPanelDistributedForce = new mainPorject.UserControl_Forces();
            this.drawPanelPointForce = new mainPorject.UserControl_Forces();
            this.labelPanelLength = new System.Windows.Forms.Label();
            this.labelpanelWidth = new System.Windows.Forms.Label();
            this.labelPanelHeight = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.contextMenuStripForce = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripTextBoxForce = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panelForces = new System.Windows.Forms.Panel();
            this.userControl_BasicSpec1 = new mainPorject.UserControl_BasicSpec();
            this.userControl_AdvancedSpec1 = new mainPorject.UserControl_AdvancedSpec();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStripForce.SuspendLayout();
            this.panelForces.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonAddDistributedForce);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.textBoxForceEnd);
            this.groupBox4.Controls.Add(this.textBoxForceStart);
            this.groupBox4.Controls.Add(this.textBoxDistributedForce);
            this.groupBox4.Location = new System.Drawing.Point(3, 76);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(327, 100);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "distributed force";
            // 
            // buttonAddDistributedForce
            // 
            this.buttonAddDistributedForce.Enabled = false;
            this.buttonAddDistributedForce.Location = new System.Drawing.Point(6, 65);
            this.buttonAddDistributedForce.Name = "buttonAddDistributedForce";
            this.buttonAddDistributedForce.Size = new System.Drawing.Size(299, 23);
            this.buttonAddDistributedForce.TabIndex = 6;
            this.buttonAddDistributedForce.Text = "add";
            this.buttonAddDistributedForce.UseVisualStyleBackColor = true;
            this.buttonAddDistributedForce.EnabledChanged += new System.EventHandler(this.buttonAddDistributedForce_EnabledChanged);
            this.buttonAddDistributedForce.Click += new System.EventHandler(this.button3_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(234, 23);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(59, 13);
            this.label22.TabIndex = 5;
            this.label22.Text = "end locatin";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(125, 23);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(67, 13);
            this.label21.TabIndex = 4;
            this.label21.Text = "start location";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(16, 23);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(77, 13);
            this.label20.TabIndex = 3;
            this.label20.Text = "foce in newten";
            // 
            // textBoxForceEnd
            // 
            this.textBoxForceEnd.Location = new System.Drawing.Point(220, 39);
            this.textBoxForceEnd.Name = "textBoxForceEnd";
            this.textBoxForceEnd.Size = new System.Drawing.Size(85, 20);
            this.textBoxForceEnd.TabIndex = 2;
            this.textBoxForceEnd.TextChanged += new System.EventHandler(this.textBoxForceEnd_textChanged);
            this.textBoxForceEnd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleNumberedEntry);
            // 
            // textBoxForceStart
            // 
            this.textBoxForceStart.Location = new System.Drawing.Point(113, 39);
            this.textBoxForceStart.Name = "textBoxForceStart";
            this.textBoxForceStart.Size = new System.Drawing.Size(85, 20);
            this.textBoxForceStart.TabIndex = 1;
            this.textBoxForceStart.TextChanged += new System.EventHandler(this.textBoxForceStart_textChanged);
            this.textBoxForceStart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleNumberedEntry);
            // 
            // textBoxDistributedForce
            // 
            this.textBoxDistributedForce.Location = new System.Drawing.Point(6, 39);
            this.textBoxDistributedForce.Name = "textBoxDistributedForce";
            this.textBoxDistributedForce.Size = new System.Drawing.Size(85, 20);
            this.textBoxDistributedForce.TabIndex = 0;
            this.textBoxDistributedForce.TextChanged += new System.EventHandler(this.AddDistributedForce_TextChanged);
            this.textBoxDistributedForce.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleNumberedEntry);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonAddPointForce);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.textBoxForceLocation);
            this.groupBox3.Controls.Add(this.textBoxPointForce);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(327, 67);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "point force";
            // 
            // buttonAddPointForce
            // 
            this.buttonAddPointForce.Enabled = false;
            this.buttonAddPointForce.Location = new System.Drawing.Point(218, 30);
            this.buttonAddPointForce.Name = "buttonAddPointForce";
            this.buttonAddPointForce.Size = new System.Drawing.Size(87, 23);
            this.buttonAddPointForce.TabIndex = 4;
            this.buttonAddPointForce.Text = "add";
            this.buttonAddPointForce.UseVisualStyleBackColor = true;
            this.buttonAddPointForce.EnabledChanged += new System.EventHandler(this.buttonAddPointForce_EnabledChanged);
            this.buttonAddPointForce.Click += new System.EventHandler(this.button4_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(128, 16);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(44, 13);
            this.label19.TabIndex = 3;
            this.label19.Text = "location";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(16, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 13);
            this.label18.TabIndex = 2;
            this.label18.Text = "foce in newten";
            // 
            // textBoxForceLocation
            // 
            this.textBoxForceLocation.Location = new System.Drawing.Point(112, 33);
            this.textBoxForceLocation.Name = "textBoxForceLocation";
            this.textBoxForceLocation.Size = new System.Drawing.Size(100, 20);
            this.textBoxForceLocation.TabIndex = 1;
            this.textBoxForceLocation.TextChanged += new System.EventHandler(this.textBoxForceLocation_textChanged);
            this.textBoxForceLocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleNumberedEntry);
            // 
            // textBoxPointForce
            // 
            this.textBoxPointForce.Location = new System.Drawing.Point(6, 32);
            this.textBoxPointForce.Name = "textBoxPointForce";
            this.textBoxPointForce.Size = new System.Drawing.Size(100, 20);
            this.textBoxPointForce.TabIndex = 0;
            this.textBoxPointForce.TextChanged += new System.EventHandler(this.AddPointForce_TextChanged);
            this.textBoxPointForce.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleNumberedEntry);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.drawPanelDistributedForce);
            this.panel1.Controls.Add(this.drawPanelPointForce);
            this.panel1.Controls.Add(this.labelPanelLength);
            this.panel1.Controls.Add(this.labelpanelWidth);
            this.panel1.Controls.Add(this.labelPanelHeight);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(254, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(530, 542);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // drawPanelDistributedForce
            // 
            this.drawPanelDistributedForce.Location = new System.Drawing.Point(345, 99);
            this.drawPanelDistributedForce.Name = "drawPanelDistributedForce";
            this.drawPanelDistributedForce.Size = new System.Drawing.Size(125, 40);
            this.drawPanelDistributedForce.TabIndex = 6;
            this.drawPanelDistributedForce.Type = mainPorject.forceType.distributed;
            this.drawPanelDistributedForce.Visible = false;
            this.drawPanelDistributedForce.MouseClick += new System.Windows.Forms.MouseEventHandler(this.drawPanelDistributedForce_MouseClick);
            this.drawPanelDistributedForce.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawPanelDistributedForce_MouseDown);
            this.drawPanelDistributedForce.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawPanelDistributedForce_MouseMove);
            this.drawPanelDistributedForce.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawPanelDistributedForce_MouseUp);
            // 
            // drawPanelPointForce
            // 
            this.drawPanelPointForce.Location = new System.Drawing.Point(319, 47);
            this.drawPanelPointForce.Name = "drawPanelPointForce";
            this.drawPanelPointForce.Size = new System.Drawing.Size(20, 92);
            this.drawPanelPointForce.TabIndex = 5;
            this.drawPanelPointForce.Type = mainPorject.forceType.point;
            this.drawPanelPointForce.Visible = false;
            this.drawPanelPointForce.MouseClick += new System.Windows.Forms.MouseEventHandler(this.drawPanelPointForce_MouseClick);
            this.drawPanelPointForce.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawPanelPointForce_MouseDown);
            this.drawPanelPointForce.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawPanelPointForce_MouseMove);
            this.drawPanelPointForce.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawPanelPointForce_MouseUp);
            // 
            // labelPanelLength
            // 
            this.labelPanelLength.AutoSize = true;
            this.labelPanelLength.Location = new System.Drawing.Point(134, 306);
            this.labelPanelLength.Name = "labelPanelLength";
            this.labelPanelLength.Size = new System.Drawing.Size(13, 13);
            this.labelPanelLength.TabIndex = 2;
            this.labelPanelLength.Text = "2";
            this.labelPanelLength.TextChanged += new System.EventHandler(this.labelPanel_TextChanged);
            // 
            // labelpanelWidth
            // 
            this.labelpanelWidth.AutoSize = true;
            this.labelpanelWidth.Location = new System.Drawing.Point(95, 169);
            this.labelpanelWidth.Name = "labelpanelWidth";
            this.labelpanelWidth.Size = new System.Drawing.Size(19, 13);
            this.labelpanelWidth.TabIndex = 1;
            this.labelpanelWidth.Text = "25";
            this.labelpanelWidth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelpanelWidth.TextChanged += new System.EventHandler(this.labelPanel_TextChanged);
            // 
            // labelPanelHeight
            // 
            this.labelPanelHeight.AutoSize = true;
            this.labelPanelHeight.Location = new System.Drawing.Point(137, 130);
            this.labelPanelHeight.Name = "labelPanelHeight";
            this.labelPanelHeight.Size = new System.Drawing.Size(19, 13);
            this.labelPanelHeight.TabIndex = 0;
            this.labelPanelHeight.Text = "55";
            this.labelPanelHeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelPanelHeight.TextChanged += new System.EventHandler(this.labelPanel_TextChanged);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.Location = new System.Drawing.Point(15, 492);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(97, 36);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Visible = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.Location = new System.Drawing.Point(138, 450);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(101, 36);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Visible = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // contextMenuStripForce
            // 
            this.contextMenuStripForce.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxForce,
            this.toolStripSeparator1,
            this.toolStripMenuItem1,
            this.cancelToolStripMenuItem});
            this.contextMenuStripForce.Name = "contextMenuStripForce";
            this.contextMenuStripForce.Size = new System.Drawing.Size(161, 79);
            this.contextMenuStripForce.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripForce_Opening);
            // 
            // toolStripTextBoxForce
            // 
            this.toolStripTextBoxForce.Name = "toolStripTextBoxForce";
            this.toolStripTextBoxForce.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxForce.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleNumberedEntry);
            this.toolStripTextBoxForce.TextChanged += new System.EventHandler(this.toolStripTextBoxForce_TextChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Enabled = false;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem1.Text = "Add";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.cancelToolStripMenuItem.Text = "Cancel";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 385);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 39);
            this.button1.TabIndex = 50;
            this.button1.Text = "Show Advanced";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 450);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 36);
            this.button2.TabIndex = 51;
            this.button2.Text = "Next";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(138, 492);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(101, 36);
            this.button3.TabIndex = 51;
            this.button3.Text = "Back";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // panelForces
            // 
            this.panelForces.Controls.Add(this.groupBox4);
            this.panelForces.Controls.Add(this.groupBox3);
            this.panelForces.Location = new System.Drawing.Point(12, 12);
            this.panelForces.Name = "panelForces";
            this.panelForces.Size = new System.Drawing.Size(335, 183);
            this.panelForces.TabIndex = 5;
            // 
            // userControl_BasicSpec1
            // 
            this.userControl_BasicSpec1.Location = new System.Drawing.Point(11, 12);
            this.userControl_BasicSpec1.Name = "userControl_BasicSpec1";
            this.userControl_BasicSpec1.Size = new System.Drawing.Size(228, 333);
            this.userControl_BasicSpec1.TabIndex = 52;
            this.userControl_BasicSpec1.HeightChanged += new mainPorject.UserControl_BasicSpec.NumberChangedHandler(this.Height_NumberChanged);
            this.userControl_BasicSpec1.WidthChanged += new mainPorject.UserControl_BasicSpec.NumberChangedHandler(this.Width_NumberChanged);
            this.userControl_BasicSpec1.LengthChanged += new mainPorject.UserControl_BasicSpec.NumberChangedHandler(this.Length_NumberChanged);
            this.userControl_BasicSpec1.DiameterChanged += new mainPorject.UserControl_BasicSpec.NumberChangedHandler(this.Diameter_NumberChanged);
            this.userControl_BasicSpec1.CountChanged += new mainPorject.UserControl_BasicSpec.NumberChangedHandler(this.Count_NumberChanged);
            this.userControl_BasicSpec1.Diameter2Changed += new mainPorject.UserControl_BasicSpec.NumberChangedHandler(this.userControl_BasicSpec1_Diameter2Changed);
            this.userControl_BasicSpec1.Count2Changed += new mainPorject.UserControl_BasicSpec.NumberChangedHandler(this.userControl_BasicSpec1_Count2Changed);
            this.userControl_BasicSpec1.DoubleCheckedChanged += new System.EventHandler(this.userControl_BasicSpec1_DoubleCheckedChanged);
            // 
            // userControl_AdvancedSpec1
            // 
            this.userControl_AdvancedSpec1.Basic = this.userControl_BasicSpec1;
            this.userControl_AdvancedSpec1.Location = new System.Drawing.Point(12, 12);
            this.userControl_AdvancedSpec1.Name = "userControl_AdvancedSpec1";
            this.userControl_AdvancedSpec1.Size = new System.Drawing.Size(221, 208);
            this.userControl_AdvancedSpec1.TabIndex = 5;
            this.userControl_AdvancedSpec1.AChanged += new mainPorject.UserControl_AdvancedSpec.NumberChangedHandler(this.userControl_AdvancedSpec1_AChanged);
            this.userControl_AdvancedSpec1.A2Changed += new mainPorject.UserControl_AdvancedSpec.NumberChangedHandler(this.userControl_AdvancedSpec1_A2Changed);
            // 
            // mainBeamSpec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::mainPorject.Properties.Resources._1600x900_modified;
            this.ClientSize = new System.Drawing.Size(784, 542);
            this.ControlBox = false;
            this.Controls.Add(this.userControl_BasicSpec1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.userControl_AdvancedSpec1);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelForces);
            this.Name = "mainBeamSpec";
            this.ShowIcon = false;
            this.Text = "mainBeamSpec";
            this.Load += new System.EventHandler(this.mainBeamSpec_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStripForce.ResumeLayout(false);
            this.contextMenuStripForce.PerformLayout();
            this.panelForces.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonAddDistributedForce;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBoxForceEnd;
        private System.Windows.Forms.TextBox textBoxForceStart;
        private System.Windows.Forms.TextBox textBoxDistributedForce;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonAddPointForce;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBoxForceLocation;
        private System.Windows.Forms.TextBox textBoxPointForce;
        private System.Windows.Forms.Label labelpanelWidth;
        private System.Windows.Forms.Label labelPanelHeight;
        private System.Windows.Forms.Label labelPanelLength;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripForce;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxForce;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private UserControl_BasicSpec userControl_BasicSpec1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panelForces;
        private UserControl_AdvancedSpec userControl_AdvancedSpec1;
        private UserControl_Forces drawPanelDistributedForce;
        private UserControl_Forces drawPanelPointForce;
    }
}