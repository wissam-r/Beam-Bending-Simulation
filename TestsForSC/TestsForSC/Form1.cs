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
    public partial class Form1 : Form
    {
        beem.SinReinRecBeem bemo= new beem.SinReinRecBeem(30, 20, 200, 20, 210000, 10, 2, 5);
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = bemo.getCrossSectionalArea().ToString();
            textBox2.Text = bemo.getDistanceCenterGravity().ToString();
            textBox3.Text = bemo.getMomentInertiaNonCrackedSection().ToString();
            textBox4.Text = bemo.EMC.ToString();
            textBox5.Text = bemo.getRatioOfStandard().ToString();
            textBox6.Text = bemo.getSpaceTensileReinforcement().ToString();
            textBox7.Text = bemo.DNASE.ToString();
            textBox8.Text = bemo.CF.ToString();
            textBox9.Text = bemo.Mcr.ToString();
            textBox10.Text = bemo.Icr.ToString();
            //textBox11.Text = bemo.testIe(0.06, 0.09, 8.806 * Math.Pow(10, 5), 2.98 * Math.Pow(10, 5)).ToString();
            //textBox11.Text =  bemo.getIe(
           // textBox1.Text = bemo.EMC.ToString();
           // textBox2.Text = bemo.getCrossSectionalArea().ToString();
           // textBox3.Text = bemo.getDistanceCenterGravity().ToString();
           // //textBox4.Text = bemo.getIe().ToString();
           // textBox5.Text = bemo.Mcr.ToString();
           //// textBox6.Text = bemo.Icr.ToString();
           // textBox6.Text = bemo.getMomentInertiaNonCrackedSection().ToString();

           
        }
    }
}
