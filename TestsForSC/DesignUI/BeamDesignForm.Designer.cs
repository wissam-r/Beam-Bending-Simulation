namespace DesignUI
{
    partial class BeamDesignForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtBoxMu = new System.Windows.Forms.TextBox();
            this.txtBoxb = new System.Windows.Forms.TextBox();
            this.txtBoxfy = new System.Windows.Forms.TextBox();
            this.txtBoxfc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.calcedFieldsSR = new DesignUI.calcedFields();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.radioBtnPartialDesign = new System.Windows.Forms.RadioButton();
            this.radioBtnSDWMaxAs = new System.Windows.Forms.RadioButton();
            this.radioBtnSDWMinAs = new System.Windows.Forms.RadioButton();
            this.btnCalc = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxAs_ = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.calcedFieldsDR = new DesignUI.calcedFields();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 344);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.txtBoxMu, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtBoxb, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtBoxfy, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtBoxfc, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label8, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.label9, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.label10, 2, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(194, 106);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // txtBoxMu
            // 
            this.txtBoxMu.Location = new System.Drawing.Point(30, 3);
            this.txtBoxMu.Name = "txtBoxMu";
            this.txtBoxMu.Size = new System.Drawing.Size(100, 20);
            this.txtBoxMu.TabIndex = 1;
            this.txtBoxMu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_KeyPress);
            // 
            // txtBoxb
            // 
            this.txtBoxb.Location = new System.Drawing.Point(30, 29);
            this.txtBoxb.Name = "txtBoxb";
            this.txtBoxb.Size = new System.Drawing.Size(100, 20);
            this.txtBoxb.TabIndex = 2;
            this.txtBoxb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_KeyPress);
            // 
            // txtBoxfy
            // 
            this.txtBoxfy.Location = new System.Drawing.Point(30, 55);
            this.txtBoxfy.Name = "txtBoxfy";
            this.txtBoxfy.Size = new System.Drawing.Size(100, 20);
            this.txtBoxfy.TabIndex = 3;
            this.txtBoxfy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_KeyPress);
            // 
            // txtBoxfc
            // 
            this.txtBoxfc.Location = new System.Drawing.Point(30, 81);
            this.txtBoxfc.Name = "txtBoxfc";
            this.txtBoxfc.Size = new System.Drawing.Size(100, 20);
            this.txtBoxfc.TabIndex = 4;
            this.txtBoxfc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 26);
            this.label7.TabIndex = 21;
            this.label7.Text = "Mu";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 26);
            this.label2.TabIndex = 22;
            this.label2.Text = "b";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 26);
            this.label3.TabIndex = 20;
            this.label3.Text = "fy";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 28);
            this.label4.TabIndex = 18;
            this.label4.Text = "f\'c";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(136, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 26);
            this.label1.TabIndex = 21;
            this.label1.Text = "kNm";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(136, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 26);
            this.label8.TabIndex = 23;
            this.label8.Text = "mm";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(136, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 26);
            this.label9.TabIndex = 24;
            this.label9.Text = "MPa";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(136, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 28);
            this.label10.TabIndex = 25;
            this.label10.Text = "MPa";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 115);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(194, 226);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.calcedFieldsSR);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btnCalc);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(186, 200);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "SR";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // calcedFieldsSR
            // 
            this.calcedFieldsSR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calcedFieldsSR.Location = new System.Drawing.Point(3, 91);
            this.calcedFieldsSR.Name = "calcedFieldsSR";
            this.calcedFieldsSR.Size = new System.Drawing.Size(180, 81);
            this.calcedFieldsSR.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 88);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Single Reinforcement Options";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.radioBtnPartialDesign, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.radioBtnSDWMaxAs, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.radioBtnSDWMinAs, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(174, 69);
            this.tableLayoutPanel4.TabIndex = 5;
            // 
            // radioBtnPartialDesign
            // 
            this.radioBtnPartialDesign.AutoSize = true;
            this.radioBtnPartialDesign.Checked = true;
            this.radioBtnPartialDesign.Location = new System.Drawing.Point(3, 3);
            this.radioBtnPartialDesign.Name = "radioBtnPartialDesign";
            this.radioBtnPartialDesign.Size = new System.Drawing.Size(90, 17);
            this.radioBtnPartialDesign.TabIndex = 6;
            this.radioBtnPartialDesign.TabStop = true;
            this.radioBtnPartialDesign.Tag = "0";
            this.radioBtnPartialDesign.Text = "Partial Design";
            this.radioBtnPartialDesign.UseVisualStyleBackColor = true;
            this.radioBtnPartialDesign.CheckedChanged += new System.EventHandler(this.radioBtn_CheckedChanged);
            // 
            // radioBtnSDWMaxAs
            // 
            this.radioBtnSDWMaxAs.AutoSize = true;
            this.radioBtnSDWMaxAs.Location = new System.Drawing.Point(3, 49);
            this.radioBtnSDWMaxAs.Name = "radioBtnSDWMaxAs";
            this.radioBtnSDWMaxAs.Size = new System.Drawing.Size(158, 17);
            this.radioBtnSDWMaxAs.TabIndex = 8;
            this.radioBtnSDWMaxAs.Tag = "2";
            this.radioBtnSDWMaxAs.Text = "Section Design With Max As";
            this.radioBtnSDWMaxAs.UseVisualStyleBackColor = true;
            this.radioBtnSDWMaxAs.CheckedChanged += new System.EventHandler(this.radioBtn_CheckedChanged);
            // 
            // radioBtnSDWMinAs
            // 
            this.radioBtnSDWMinAs.AutoSize = true;
            this.radioBtnSDWMinAs.Location = new System.Drawing.Point(3, 26);
            this.radioBtnSDWMinAs.Name = "radioBtnSDWMinAs";
            this.radioBtnSDWMinAs.Size = new System.Drawing.Size(154, 17);
            this.radioBtnSDWMinAs.TabIndex = 7;
            this.radioBtnSDWMinAs.Tag = "1";
            this.radioBtnSDWMinAs.Text = "Section Design With Min As";
            this.radioBtnSDWMinAs.UseVisualStyleBackColor = true;
            this.radioBtnSDWMinAs.CheckedChanged += new System.EventHandler(this.radioBtn_CheckedChanged);
            // 
            // btnCalc
            // 
            this.btnCalc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCalc.Location = new System.Drawing.Point(3, 172);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(180, 25);
            this.btnCalc.TabIndex = 10;
            this.btnCalc.Text = "Calc";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(186, 200);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DR";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.tableLayoutPanel3);
            this.groupBox2.Controls.Add(this.calcedFieldsDR);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(180, 194);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Double Reinforcement Partial Design";
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(3, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 25);
            this.button1.TabIndex = 8;
            this.button1.Text = "Calc";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtBoxAs_, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 99);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(174, 27);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 27);
            this.label5.TabIndex = 0;
            this.label5.Text = "As\'";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBoxAs_
            // 
            this.txtBoxAs_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxAs_.Location = new System.Drawing.Point(30, 3);
            this.txtBoxAs_.Name = "txtBoxAs_";
            this.txtBoxAs_.ReadOnly = true;
            this.txtBoxAs_.Size = new System.Drawing.Size(111, 20);
            this.txtBoxAs_.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(147, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 27);
            this.label6.TabIndex = 2;
            this.label6.Text = "mm²";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // calcedFieldsDR
            // 
            this.calcedFieldsDR.Dock = System.Windows.Forms.DockStyle.Top;
            this.calcedFieldsDR.Location = new System.Drawing.Point(3, 16);
            this.calcedFieldsDR.Name = "calcedFieldsDR";
            this.calcedFieldsDR.Size = new System.Drawing.Size(174, 83);
            this.calcedFieldsDR.TabIndex = 6;
            // 
            // BeamDesignForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 344);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "BeamDesignForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox txtBoxMu;
        private System.Windows.Forms.TextBox txtBoxb;
        private System.Windows.Forms.TextBox txtBoxfy;
        private System.Windows.Forms.TextBox txtBoxfc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.RadioButton radioBtnPartialDesign;
        private System.Windows.Forms.RadioButton radioBtnSDWMaxAs;
        private System.Windows.Forms.RadioButton radioBtnSDWMinAs;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private calcedFields calcedFieldsSR;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBoxAs_;
        private System.Windows.Forms.Label label6;
        private calcedFields calcedFieldsDR;

    }
}