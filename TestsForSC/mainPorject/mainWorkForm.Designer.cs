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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.splitContainerMainLeft = new System.Windows.Forms.SplitContainer();
            this.splitContainerMainLeftRight = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMainLeft)).BeginInit();
            this.splitContainerMainLeft.Panel2.SuspendLayout();
            this.splitContainerMainLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMainLeftRight)).BeginInit();
            this.splitContainerMainLeftRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(919, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 438);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(919, 22);
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
            this.MainSplitContainer.Size = new System.Drawing.Size(919, 414);
            this.MainSplitContainer.SplitterDistance = 678;
            this.MainSplitContainer.TabIndex = 2;
            // 
            // splitContainerMainLeft
            // 
            this.splitContainerMainLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMainLeft.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMainLeft.Name = "splitContainerMainLeft";
            // 
            // splitContainerMainLeft.Panel2
            // 
            this.splitContainerMainLeft.Panel2.Controls.Add(this.splitContainerMainLeftRight);
            this.splitContainerMainLeft.Size = new System.Drawing.Size(678, 414);
            this.splitContainerMainLeft.SplitterDistance = 46;
            this.splitContainerMainLeft.TabIndex = 0;
            // 
            // splitContainerMainLeftRight
            // 
            this.splitContainerMainLeftRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMainLeftRight.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMainLeftRight.Name = "splitContainerMainLeftRight";
            this.splitContainerMainLeftRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainerMainLeftRight.Size = new System.Drawing.Size(628, 414);
            this.splitContainerMainLeftRight.SplitterDistance = 345;
            this.splitContainerMainLeftRight.TabIndex = 0;
            // 
            // mainWorkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 460);
            this.Controls.Add(this.MainSplitContainer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainWorkForm";
            this.Text = "mainWorkForm";
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.splitContainerMainLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMainLeft)).EndInit();
            this.splitContainerMainLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMainLeftRight)).EndInit();
            this.splitContainerMainLeftRight.ResumeLayout(false);
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
    }
}