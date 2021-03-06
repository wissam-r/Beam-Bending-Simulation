﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BeamDesign;
namespace DesignUI
{
    public partial class BeamDesignForm : Form
    {
        public BeamDesignForm()
        {
            InitializeComponent();
        }
        int radioTag = 0;
        private void btnCalc_Click(object sender, EventArgs e)
        {
            btnCalc();
        }

        private void radioBtn_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton a = (RadioButton)sender;
            radioTag = int.Parse(a.Tag.ToString());
            this.calcedFieldsSR.txtBoxa.ReadOnly = radioTag == 0 ? false : true;
            this.calcedFieldsSR.txtBoxh.ReadOnly = radioTag == 0 ? false : true;
            this.calcedFieldsSR.txtBoxa.Text = "";
            this.calcedFieldsSR.txtBoxh.Text = "";

        }
        private void txtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox a = (TextBox)sender;
            string s = "0123456789.";
            if ((!s.Contains(e.KeyChar)) && e.KeyChar.GetHashCode() != 524296)
                e.Handled = true;
            else if (a.Text.Contains('.') && e.KeyChar == '.')
                e.Handled = true;
            else
                e.Handled = false;
        }
        private void BeamDesignForm_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
        
        void btnCalc()
        {
            if (tabControl1.SelectedIndex == 0)
            {
                try
                {
                    switch (radioTag)
                    {
                        case 0: SRBPartialDesign b = new SRBPartialDesign(double.Parse(this.txtBoxMu.Text), double.Parse(this.txtBoxb.Text), double.Parse(this.calcedFieldsSR.txtBoxh.Text), double.Parse(this.calcedFieldsSR.txtBoxa.Text), double.Parse(this.txtBoxfy.Text), double.Parse(this.txtBoxfc.Text));
                            this.calcedFieldsSR.txtBoxAs.Text = b.AreaS.ToString();
                            this.calcedFieldsSR.txtBoxd.Text = b.D.ToString(); break;
                        case 1: WithMinAs c = new WithMinAs(double.Parse(this.txtBoxMu.Text), double.Parse(this.txtBoxb.Text), double.Parse(this.txtBoxfy.Text), double.Parse(this.txtBoxfc.Text));
                            this.calcedFieldsSR.txtBoxAs.Text = c.AreaS.ToString();
                            this.calcedFieldsSR.txtBoxd.Text = c.D.ToString(); break;
                        case 2: WithMaxAs d = new WithMaxAs(double.Parse(this.txtBoxMu.Text), double.Parse(this.txtBoxb.Text), double.Parse(this.txtBoxfy.Text), double.Parse(this.txtBoxfc.Text));
                            this.calcedFieldsSR.txtBoxAs.Text = d.AreaS.ToString();
                            this.calcedFieldsSR.txtBoxd.Text = d.D.ToString(); break;
                    }
                    button1.Enabled = true;
                }
                catch (Exception ex)
                {
                    if (ex.Source == "BeamDesign")
                        MessageBox.Show(ex.Message, "Error");
                    else
                        MessageBox.Show("Please enter all fields values", "Error");
                }
            }
            else
            {
                try
                {
                    DRBPartialDesign b = new DRBPartialDesign(double.Parse(this.txtBoxMu.Text), double.Parse(this.txtBoxb.Text), double.Parse(this.calcedFieldsDR.txtBoxh.Text), double.Parse(this.calcedFieldsDR.txtBoxa.Text), double.Parse(this.txtBoxfy.Text), double.Parse(this.txtBoxfc.Text));
                    this.calcedFieldsDR.txtBoxAs.Text = b.AreaS.ToString();
                    this.calcedFieldsDR.txtBoxd.Text = b.D.ToString();
                    this.txtBoxAs_.Text = b.AreaS_.ToString();
                    button1.Enabled = true;
                }
                catch (Exception ex)
                {
                    if (ex.Source == "BeamDesign")
                        MessageBox.Show(ex.Message, "Error");
                    else
                        MessageBox.Show("Please enter all fields values", "Error");
                }
            }
        }

        private void BeamDesignForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnCalc();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
