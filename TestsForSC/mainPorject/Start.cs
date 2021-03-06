﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DesignUI;

namespace mainPorject
{
    public partial class Start : Form
    {
        #region variables
        //variables
        public double width, height, As, Asl, fc, fs, a, al;
        public bool isSingel;
        //variables end
        #endregion

        public Start()
        {
            InitializeComponent();
        }

        private void Start_Load(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.None;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            using (BeamDesignForm mbs = new BeamDesignForm())
            {
                DialogResult result = mbs.ShowDialog(this);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    width = double.Parse(mbs.txtBoxb.Text);
                    fs = double.Parse(mbs.txtBoxfy.Text);
                    fc = double.Parse(mbs.txtBoxfc.Text);
                    if (mbs.tabControl1.SelectedTab == mbs.tabPgSR)
                    {
                        isSingel = true;
                        height = double.Parse(mbs.calcedFieldsSR.txtBoxh.Text);
                        a = double.Parse(mbs.calcedFieldsSR.txtBoxa.Text);
                        As = double.Parse(mbs.calcedFieldsSR.txtBoxAs.Text);
                    }
                    else
                    {
                        isSingel = false;
                        height = double.Parse(mbs.calcedFieldsDR.txtBoxh.Text) ;
                        a = double.Parse(mbs.calcedFieldsDR.txtBoxa.Text) ;
                        al = a;
                        As = double.Parse(mbs.calcedFieldsDR.txtBoxa.Text);
                        Asl = double.Parse(mbs.txtBoxAs_.Text);
                    }
                    DialogResult = System.Windows.Forms.DialogResult.Yes;
                    this.Close();
                }                
            }
        }

        private void Start_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(DialogResult == System.Windows.Forms.DialogResult.Cancel)
                DialogResult = System.Windows.Forms.DialogResult.Abort;
        } 
    }
}
