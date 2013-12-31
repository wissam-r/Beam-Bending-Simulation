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
                1);
            this.myForces = new force.Forces(0, myBeam.L);
            MessageBox.Show("العزم المقاوم الاستثماري  : " + myBeam.MomentumInvestment.ToString() + "\n"
                + " العزم المقاوم المثالي : " + myBeam.MomentumRegulars + "\n"
                + "عزم التشقق : " + myBeam.Mcr.ToString() + "\n"
                + "معامل تخفيض المقاومة : " + myBeam.Teta.ToString() + "\n"
                + "مساحة التسليح العظمى : " + myBeam.AsMax.ToString()
                
                );
  
            //MessageBox.Show(myBeam.Teta + "\n" +
            //    myBeam.CP + "\n" +
            //    myBeam.B + "\n" +
            //    myBeam.Y + "\n" +
            //    myBeam.D+ "\n" +
            //    myBeam.getSpaceTensileReinforcement() + "\n" +
            //    myBeam.IF + "\n" + 
            //    myBeam.MomentumInvestment);
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
            MessageBox.Show((myForces.getfMomentomd2x(double.Parse(textBoxLocation.Text), myBeam.L)/(myBeam.getIe(myForces.getMomentom(double.Parse(textBoxLocation.Text)) * myBeam.EMC))).ToString());
        }

        private void textBoxFc_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show(myForces.getfMomentomd2x(double.Parse(textBoxLocation.Text), myBeam.L).ToString());
        }
    }
}
