using System;
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
        int radioTag = 0;
        public BeamDesignForm()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            switch (radioTag)
            {
                case 0: PartialDesign b = new PartialDesign(double.Parse(this.txtBoxMu.Text), double.Parse(this.txtBoxb.Text), double.Parse(this.txtBoxd.Text), double.Parse(this.txtBoxfy.Text), double.Parse(this.txtBoxfc.Text));
                    this.txtBoxAs.Text = b.AreaS.ToString(); break;
                case 1: WithMinAs c = new WithMinAs(double.Parse(this.txtBoxMu.Text), double.Parse(this.txtBoxb.Text), double.Parse(this.txtBoxfy.Text), double.Parse(this.txtBoxfc.Text));
                    this.txtBoxAs.Text = c.AreaS.ToString();
                    this.txtBoxd.Text = c.D.ToString(); break;
                case 2: WithMaxAs d = new WithMaxAs(double.Parse(this.txtBoxMu.Text), double.Parse(this.txtBoxb.Text), double.Parse(this.txtBoxfy.Text), double.Parse(this.txtBoxfc.Text));
                    this.txtBoxAs.Text = d.AreaS.ToString();
                    this.txtBoxd.Text = d.D.ToString(); break;
            }
        }

        private void radioBtn_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton a = (RadioButton)sender;
            txtBoxd.ReadOnly = a.Tag.ToString() == "0" ? false : true;
            radioTag = int.Parse(a.Tag.ToString());
        }
    }
}
