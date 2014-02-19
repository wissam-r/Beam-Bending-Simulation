namespace mainPorject
{
    partial class UserContro_Forces
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(338, 182);
            this.panel1.TabIndex = 0;
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
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "distributed force";
            // 
            // buttonAddDistributedForce
            // 
            this.buttonAddDistributedForce.Enabled = false;
            this.buttonAddDistributedForce.Location = new System.Drawing.Point(6, 65);
            this.buttonAddDistributedForce.Name = "buttonAddDistributedForce";
            this.buttonAddDistributedForce.Size = new System.Drawing.Size(299, 23);
            this.buttonAddDistributedForce.TabIndex = 3;
            this.buttonAddDistributedForce.Text = "add";
            this.buttonAddDistributedForce.UseVisualStyleBackColor = true;
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
            this.label21.Size = new System.Drawing.Size(70, 13);
            this.label21.TabIndex = 4;
            this.label21.Text = "start location";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(16, 23);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(82, 13);
            this.label20.TabIndex = 3;
            this.label20.Text = "force in newten";
            // 
            // textBoxForceEnd
            // 
            this.textBoxForceEnd.Location = new System.Drawing.Point(220, 39);
            this.textBoxForceEnd.Name = "textBoxForceEnd";
            this.textBoxForceEnd.Size = new System.Drawing.Size(85, 20);
            this.textBoxForceEnd.TabIndex = 2;
            this.textBoxForceEnd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HandleEnterEntry_KeyDown);
            this.textBoxForceEnd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleNumberedEntry);
            // 
            // textBoxForceStart
            // 
            this.textBoxForceStart.Location = new System.Drawing.Point(113, 39);
            this.textBoxForceStart.Name = "textBoxForceStart";
            this.textBoxForceStart.Size = new System.Drawing.Size(85, 20);
            this.textBoxForceStart.TabIndex = 1;
            this.textBoxForceStart.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HandleEnterEntry_KeyDown);
            this.textBoxForceStart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleNumberedEntry);
            // 
            // textBoxDistributedForce
            // 
            this.textBoxDistributedForce.Location = new System.Drawing.Point(6, 39);
            this.textBoxDistributedForce.Name = "textBoxDistributedForce";
            this.textBoxDistributedForce.Size = new System.Drawing.Size(85, 20);
            this.textBoxDistributedForce.TabIndex = 0;
            this.textBoxDistributedForce.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HandleEnterEntry_KeyDown);
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
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "point force";
            // 
            // buttonAddPointForce
            // 
            this.buttonAddPointForce.Enabled = false;
            this.buttonAddPointForce.Location = new System.Drawing.Point(218, 30);
            this.buttonAddPointForce.Name = "buttonAddPointForce";
            this.buttonAddPointForce.Size = new System.Drawing.Size(87, 23);
            this.buttonAddPointForce.TabIndex = 2;
            this.buttonAddPointForce.Text = "add";
            this.buttonAddPointForce.UseVisualStyleBackColor = true;
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
            this.label18.Size = new System.Drawing.Size(82, 13);
            this.label18.TabIndex = 2;
            this.label18.Text = "force in newten";
            // 
            // textBoxForceLocation
            // 
            this.textBoxForceLocation.Location = new System.Drawing.Point(112, 33);
            this.textBoxForceLocation.Name = "textBoxForceLocation";
            this.textBoxForceLocation.Size = new System.Drawing.Size(100, 20);
            this.textBoxForceLocation.TabIndex = 1;
            this.textBoxForceLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HandleEnterEntry_KeyDown);
            this.textBoxForceLocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleNumberedEntry);
            // 
            // textBoxPointForce
            // 
            this.textBoxPointForce.Location = new System.Drawing.Point(6, 32);
            this.textBoxPointForce.Name = "textBoxPointForce";
            this.textBoxPointForce.Size = new System.Drawing.Size(100, 20);
            this.textBoxPointForce.TabIndex = 0;
            this.textBoxPointForce.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HandleEnterEntry_KeyDown);
            this.textBoxPointForce.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleNumberedEntry);
            // 
            // UserContro_Forces
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "UserContro_Forces";
            this.Size = new System.Drawing.Size(338, 182);
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
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
    }
}
