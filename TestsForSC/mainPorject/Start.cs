using System;
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
        public Start()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        public double width, height, As, Asl, fc, fs, a, al;
        public bool isSingel;


        private void button1_Click(object sender, EventArgs e)
        {
            using (BeamDesignForm mbs = new BeamDesignForm())
            {
                DialogResult result = mbs.ShowDialog(this);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    width = double.Parse(mbs.txtBoxb.Text) / 10;
                    fs = double.Parse(mbs.txtBoxfy.Text);
                    fc = double.Parse(mbs.txtBoxfc.Text);
                    if (mbs.tabControl1.SelectedTab == mbs.tabPgSR)
                    {
                        isSingel = true;
                        height = double.Parse(mbs.calcedFieldsSR.txtBoxh.Text) / 10;
                        a = double.Parse(mbs.calcedFieldsSR.txtBoxa.Text) / 10;
                        As = double.Parse(mbs.calcedFieldsSR.txtBoxAs.Text) / 100;
                    }
                    else
                    {
                        isSingel = false;
                        height = double.Parse(mbs.calcedFieldsDR.txtBoxh.Text) / 10;
                        a = double.Parse(mbs.calcedFieldsDR.txtBoxa.Text) / 10;
                        al = a;
                        As = double.Parse(mbs.calcedFieldsDR.txtBoxa.Text) / 100;
                        Asl = double.Parse(mbs.txtBoxAs_.Text) / 100;
                    }
                    DialogResult = System.Windows.Forms.DialogResult.Yes;
                    this.Close();
                }                
            }
        }
    }
}
