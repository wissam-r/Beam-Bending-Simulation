using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using beam;
using forces;

namespace TestsForSC
{
    public partial class jasam : Form
    {
        public jasam()
        {
            InitializeComponent();
            NewPointsFlag = false;
            NewPointPositionFlag = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.myBeam = new SinReinRecBeem(
                double.Parse(textBoxFc.Text),
                double.Parse(textBoxFs.Text),
                double.Parse(textBoxHieght.Text),
                double.Parse(textBoxLength.Text),
                double.Parse(textBoxWidth.Text),
                double.Parse(textBoxEs.Text),
                double.Parse(textBoxRadius.Text),
                int.Parse(textBoxCount.Text),
                double.Parse(textBoxA.Text),
                1);
            this.myForces = new Forces(0, myBeam.L);
            MessageBox.Show("العزم المقاوم الاستثماري  : " + myBeam.ERM.ToString() + "\n"
                + " العزم المقاوم المثالي : " + myBeam.RM + "\n"
                + "عزم التشقق : " + myBeam.Mcr.ToString() + "\n"
                + "معامل تخفيض المقاومة : " + myBeam.Teta.ToString() + "\n"
                + "مساحة التسليح العظمى : " + myBeam.AsMax.ToString()
                
                );

            NewPointsFlag = true;
            MaxMomentom = myBeam.ERM;
  
            //MessageBox.Show(myBeam.Teta + "\n" +
            //    myBeam.CP + "\n" +
            //    myBeam.B + "\n" +
            //    myBeam.Y + "\n" +
            //    myBeam.D+ "\n" +
            //    myBeam.getSpaceTensileReinforcement() + "\n" +
            //    myBeam.IF + "\n" + 
            //    myBeam.ERM);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.myForces.Add(new PointBaemForce(
                double.Parse(textBoxPointForce.Text),
                double.Parse(textBoxForceLocation.Text),
                double.Parse(textBoxLength.Text)));
            NewPointPositionFlag = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.myForces.Add(new DistributedBeamForce(
                double.Parse(textBoxDistributedForce.Text),
                double.Parse(textBoxForceStart.Text),
                double.Parse(textBoxForceEnd.Text),
                double.Parse(textBoxLength.Text)));
            NewPointPositionFlag = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(myForces.getMomentom(double.Parse(textBoxLocation.Text)).ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show((myForces.getfMomentomd2x(double.Parse(textBoxLocation.Text))/(myBeam.getIe(myForces.getMomentom(double.Parse(textBoxLocation.Text))) * myBeam.EMC)).ToString());
        }

        private void textBoxFc_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show(myForces.getfMomentomd2x(double.Parse(textBoxLocation.Text)).ToString());
        }

        public Control XnaContorl{
            get{ return this.splitContainer1.Panel1; }
        }

        public bool NewPointsFlag
        {
            set;
            get;
        }

        public bool NewPointPositionFlag
        {
            set;
            get;
        }

        

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.label24.Text = trackBar1.Value.ToString();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show(MaxMomentom.ToString());
        }
    }
}
