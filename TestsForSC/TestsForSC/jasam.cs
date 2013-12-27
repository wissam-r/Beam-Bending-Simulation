using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestsForSC
{
    public partial class jasam : Form
    {
        public jasam()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.myBeam = new beem.SinReinRecBeem(
                double.Parse(textBoxFc.Text),
                double.Parse(textBoxFs.Text),
                double.Parse(textBoxHieght.Text),
                double.Parse(textBoxLength.Text),
                double.Parse(textBoxWidth.Text),
                double.Parse(textBoxEs.Text),
                double.Parse(textBoxRadius.Text),
                double.Parse(textBoxCount.Text),
                double.Parse(textBoxA.Text),
                0);
            this.myForces = new force.Forces(0, myBeam.L);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.myForces.Add(new force.PointBaemForce(
                double.Parse(textBoxPointForce.Text),
                double.Parse(textBoxForceLocation.Text)));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.myForces.Add(new force.DistributedBeamForce(
                double.Parse(textBoxDistributedForce.Text),
                double.Parse(textBoxForceStart.Text),
                double.Parse(textBoxForceEnd.Text)));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(myForces.getMomentom(double.Parse(textBoxLocation.Text)).ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show((myForces.getfMomentomd2x(double.Parse(textBoxLocation.Text), myBeam.L)/(myBeam.getIe(myForces.getMomentom(double.Parse(textBoxLocation.Text)) * myBeam.Es))).ToString());
        }
    }
}
