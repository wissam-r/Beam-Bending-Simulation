﻿using System;
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
    public partial class Form1 : Form
    {
        SinReinRecBeem bemo= new SinReinRecBeem(30,420, 20, 200, 20, 210000, 10, 2, 5,1);
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Forces f = new Forces(12000, 6);
            f.Add(new PointBaemForce(30000, 2,6));
            //this.textBox16.Text = f.getMomentom(5).ToString();
            this.textBox15.Text = (f.getfMomentomd2x(3) / (300 * 1000 * 1000)).ToString();
            //force.Forces f = new force.Forces(0, 7);
            //f.Add(new force.PointBaemForce(30000, 2));
            //f.Add(new force.PointBaemForce(40000, 4.5));
            ////this.textBox16.Text = f.getMomentom(5).ToString();
            //this.textBox15.Text = (f.getfMomentomd2x(3.5, 7) / (200 * 1000 * 1000)).ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Text = bemo.EMC.ToString();
            textBox7.Text = bemo.EquivalentX.ToString();
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
