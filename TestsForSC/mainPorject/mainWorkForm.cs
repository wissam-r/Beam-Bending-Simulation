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

namespace mainPorject
{
    public partial class mainWorkForm : Form,XnaFormable
    {
        #region variables
        //variables
        private BeamWrapper beam;
        private SplitterPanel xnaPanel;
        private SplitterPanel quickOperation;
        private SplitterPanel extraInfo;
        private void InitializSplitters()
        {
            xnaPanel = splitContainerMainLeftRight.Panel1;
            quickOperation = splitContainerMainLeft.Panel1;
            extraInfo = MainSplitContainer.Panel2;
        }
        private Forces stack;
        //private WindowsGameLibrary1.XnaBeam game;
        #endregion

        public mainWorkForm()
        {
            InitializeComponent();
            InitializSplitters();

            NewPointsFlag = false;
            NewPointPositionFlag = false;

            this.Visible = false;
            //game = new WindowsGameLibrary1.XnaBeam(this);
            //this.Disposed += new EventHandler(form_Disposed);
        }

        private void mainWorkForm_Load(object sender, EventArgs e)
        {
            if (StartGet())
            {
                setTestForce();
                this.Visible = true;
            }
            else
            {
                this.Close();
                return;
            }
            trackBar2.Value = 5;
            //game = new WindowsGameLibrary1.XnaBeam(this);
            //game.Run();
        }

        #region other form
        private bool StartGet()
        {
            using (Start mbs = new Start())
            {
                DialogResult result = mbs.ShowDialog(this);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    return getNewBeam();
                }
                else if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    return getNewBeam(mbs);                    
                }
                else if (result == System.Windows.Forms.DialogResult.Abort)
                {
                    return false;
                }
                return true;
            }
            
        }

        private bool getNewBeam()
        {
            using (mainBeamSpec mbs = new mainBeamSpec())
            {
                DialogResult result = mbs.ShowDialog(this);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    Clear();
                    this.beam = mbs.beamWrap;
                    NewPointsFlag = true;
                    updateMometPoints();
                    panelMomentom.Paint += new PaintEventHandler(panelMomentom_Paint);
                    updateShaerPoints();
                    panelShaer.Paint += new PaintEventHandler(panelShaer_Paint);
                    trackBar1_reset();
                    labelSRM.Text = "Section resistance moment : " + Math.Round(Beam.MaxMomentom,5);
                    labelSCM.Text = "Section crack moment : " + Math.Round(Beam.beam.Mcr * Math.Pow(10,6),5);
                    label5.Text = "Strength Reduction Factor : " + Math.Round(Beam.beam.Teta,5);
                    label6.Text = "Maximum reinforcement : " + Math.Round(Beam.beam.AsMax,5);
                    return true;
                }
                else if (result == System.Windows.Forms.DialogResult.Cancel && this.Beam == null)
                {
                    return false;
                }
                return true;
            }
        }
        private bool getNewBeam(Start str)
        {
            if (str.isSingel)
            {
                using (mainBeamSpec mbs = new mainBeamSpec(str.width,str.height,str.As,str.fc,str.fs,str.a))
                {
                    DialogResult result = mbs.ShowDialog(this);
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        Clear();
                        this.beam = mbs.beamWrap;
                        NewPointsFlag = true;
                        updateMometPoints();
                        panelMomentom.Paint += new PaintEventHandler(panelMomentom_Paint);
                        updateShaerPoints();
                        panelShaer.Paint += new PaintEventHandler(panelShaer_Paint);
                        trackBar1_reset();
                        labelSRM.Text = "Section resistance moment : " + Math.Round(Beam.MaxMomentom, 5);
                        labelSCM.Text = "Section crack moment : " + Math.Round(Beam.beam.Mcr * Math.Pow(10, 6), 5);
                        label5.Text = "Strength Reduction Factor : " + Math.Round(Beam.beam.Teta, 5);
                        label6.Text = "Maximum reinforcement : " + Math.Round(Beam.beam.AsMax, 5);
                        return true;
                    }
                    else if (result == System.Windows.Forms.DialogResult.Cancel && this.Beam == null)
                    {
                        return false;
                    }
                }
            }
            else
            {
                using (mainBeamSpec mbs = new mainBeamSpec(str.width,str.height,str.As,str.Asl,str.fc,str.fs,str.a,str.a))
                {
                    DialogResult result = mbs.ShowDialog(this);
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        Clear();
                        this.beam = mbs.beamWrap;
                        NewPointsFlag = true;
                        updateMometPoints();
                        panelMomentom.Paint += new PaintEventHandler(panelMomentom_Paint);
                        updateShaerPoints();
                        panelShaer.Paint += new PaintEventHandler(panelShaer_Paint);
                        trackBar1_reset();
                        labelSRM.Text = "Section resistance moment : " + Math.Round(Beam.MaxMomentom, 5);
                        labelSCM.Text = "Section crack moment : " + Math.Round(Beam.beam.Mcr * Math.Pow(10, 6), 5);
                        label5.Text = "Strength Reduction Factor : " + Math.Round(Beam.beam.Teta, 5);
                        label6.Text = "Maximum reinforcement : " + Math.Round(Beam.beam.AsMax, 5);
                        return true;
                    }
                    else if (result == System.Windows.Forms.DialogResult.Cancel && this.Beam == null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void setTestForce()
        {
            if (Beam == null)
                return;
            using (TestForcesSpec tfs = new TestForcesSpec())
            {
                tfs.BeamLength = Beam.Length / 100;
                DialogResult result = tfs.ShowDialog(this);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    Clear();
                    Beam.F1  = tfs.F1 as PointBaemForce;
                    Beam.F2  = tfs.F2 as PointBaemForce;
                    stack = new Forces(0, Beam.Length);
                    NewTestForces = true;
                }
            }
        }
        #endregion

        #region XnaFormable

        public Control XnaContorl
        {
            get { return xnaPanel; }
        }

        public Form Form
        {
            get { return this; }
        }

        public bool NewPointsFlag
        {
            get;
            set;
        }

        public bool NewPointPositionFlag
        {
            get;
            set;
        }
        public bool NewTestForces
        {
            get;
            set;
        }

        public BeamWrapper Beam
        {
            get { return beam; }
        }

        public void sendMassege(string str)
        {
            string[] words = str.Split('|');
            if (words[0].ToLower() == "break def")
            {
                timer1.Stop();
                double def = double.Parse(words[1]);
                double pos = double.Parse(words[2]);
                MessageBox.Show(" out of service by deflection \ndeflection = " + def + "\nat position = " + pos / 100+ "(m)", "out of servic", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (words[0].ToLower() == "break mom")
            {
                timer1.Stop();
                double mom = double.Parse(words[1]);
                double pos = double.Parse(words[2]);
                MessageBox.Show(" break of moment \nmoment = " + mom + "\nat position = " + pos / 100 + "(m)\n" + Beam.beam.getFailureWay(), "break", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        #endregion

        #region menu strip
        private void newBeamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            getNewBeam();
        }
        #endregion

        #region Diagrames
        private void beam_paint(object sender, PaintEventArgs e,Point pos,Size size,Brush brush)
        {
            e.Graphics.FillRectangle(brush,pos.X,pos.Y-size.Height/2,size.Width,size.Height);
        }
        private void beamSupport_paint(object sender, PaintEventArgs e, Point beamPos, Size beamSize,Size supportSize,bool white)
        {
            Image image = white ? Properties.Resources.LeftSupportWhite : Properties.Resources.LeftSupport;
            e.Graphics.DrawImage(image, new Rectangle(beamPos.X - supportSize.Width / 2, beamPos.Y , supportSize.Width, supportSize.Height));
            image = white ? Properties.Resources.RightSupportWhite : Properties.Resources.RightSupport;
            e.Graphics.DrawImage(image, new Rectangle(beamPos.X + beamSize.Width - supportSize.Width / 2, beamPos.Y, supportSize.Width, supportSize.Height));
        }

        private Point[] pointsMomentom;
        private Dictionary<string, double> maxMomentPoint = new Dictionary<string,double>(4);
        private const int lineY_panelMomentom = 40;
        private const int gap = 5;
        private void updateMometPoints()
        {
            pointsMomentom = new Point[panelMomentom.Width - 2 * gap];
            double scaler = (beam.Length) / (pointsMomentom.Length-1);
            maxMomentPoint.Clear();
            maxMomentPoint.Add("atIndex", 0);
            for (int i = 0; i < pointsMomentom.Length; i++)
            {
                int momentom = (int)beam.getMomentomAt(i*scaler);
                pointsMomentom[i] = new Point(i + gap,lineY_panelMomentom + momentom);
                if (pointsMomentom[(int)maxMomentPoint["atIndex"]].Y < pointsMomentom[i].Y)
                {
                    maxMomentPoint.Clear();
                    maxMomentPoint.Add("atIndex", i);
                    maxMomentPoint.Add("moment", momentom);
                    maxMomentPoint.Add("xPos", pointsMomentom[(int)maxMomentPoint["atIndex"]].X);
                    maxMomentPoint.Add("yPos", pointsMomentom[(int)maxMomentPoint["atIndex"]].Y);
                }
            }
            if (!maxMomentPoint.ContainsKey("moment"))
            {
                maxMomentPoint.Add("moment", (int)beam.getMomentomAt(maxMomentPoint["atIndex"] * scaler));
                maxMomentPoint.Add("xPos", pointsMomentom[(int)maxMomentPoint["atIndex"]].X);
                maxMomentPoint.Add("yPos", pointsMomentom[(int)maxMomentPoint["atIndex"]].Y);
            }
            if (maxMomentPoint["yPos"] > panelMomentom.Height - labelMaxMomentom.Height)
            {
                scaler = (panelMomentom.Height - labelMaxMomentom.Height - lineY_panelMomentom - 3 * gap) / maxMomentPoint["moment"];
                for (int i = 0; i < pointsMomentom.Length; i++)
                {
                    pointsMomentom[i].Y = (int)((pointsMomentom[i].Y - lineY_panelMomentom)*scaler) + lineY_panelMomentom;
                }
                maxMomentPoint.Remove("yPos");
                maxMomentPoint.Add("yPos", pointsMomentom[(int)maxMomentPoint["atIndex"]].Y);
            }
            labelMaxMomentom.Text = Math.Round( maxMomentPoint["moment"],5).ToString();
            labelMaxMomentom.Left = (int)(maxMomentPoint["xPos"] - labelMaxMomentom.Width / 2);
            labelMaxMomentom.Top = (int)(maxMomentPoint["yPos"] + gap);
            panelMomentom.Invalidate();
        }
        private void panelMomentom_Paint(object sender, PaintEventArgs e)
        {
            Control panel = (sender as Panel);
            Graphics g = panel.CreateGraphics();
            beam_paint(sender,e,new Point((int)gap,lineY_panelMomentom),new System.Drawing.Size(panel.Width-2*gap,3),Brushes.White);
            //g.DrawLine(Pens.Black, (int)gap, lineY_panelMomentom, panel.Width - (int)gap, lineY_panelMomentom);
            g.DrawLines(Pens.SkyBlue, pointsMomentom);
        }

        private Point[] poitsShear;
        private Dictionary<string, double> maxShaerPoint = new Dictionary<string, double>(4);
        private Dictionary<string, double> minShaerPoint = new Dictionary<string, double>(4);
        private int lineY_panelShaer { get { return (panelShaer.Height + 25) / 2; } }
        private void updateShaerPoints()
        {
            poitsShear = new Point[panelShaer.Width - 2 * gap];
            double scaler = (beam.Length) / (poitsShear.Length - 1);
            maxShaerPoint.Clear();
            maxShaerPoint.Add("atIndex", 0);
            minShaerPoint.Clear();
            minShaerPoint.Add("atIndex", 0);
            for (int i = 0; i < poitsShear.Length; i++)
            {
                int shaer = (int)beam.getShaer(i * scaler);
                poitsShear[i] = new Point(i + gap, lineY_panelShaer - shaer);
                if (poitsShear[(int)maxShaerPoint["atIndex"]].Y > poitsShear[i].Y)
                {
                    maxShaerPoint.Clear();
                    maxShaerPoint.Add("atIndex", i);
                    maxShaerPoint.Add("shear", shaer);
                    maxShaerPoint.Add("xPos", poitsShear[(int)maxShaerPoint["atIndex"]].X);
                    maxShaerPoint.Add("yPos", poitsShear[(int)maxShaerPoint["atIndex"]].Y);
                }
                if(poitsShear[(int)minShaerPoint["atIndex"]].Y <= poitsShear[i].Y)
                {
                    minShaerPoint.Clear();
                    minShaerPoint.Add("atIndex", i);
                    minShaerPoint.Add("shaer", shaer);
                    minShaerPoint.Add("xPos", poitsShear[(int)minShaerPoint["atIndex"]].X);
                    minShaerPoint.Add("yPos", poitsShear[(int)minShaerPoint["atIndex"]].Y);
                }
            }
            if (!maxShaerPoint.ContainsKey("shaer"))
            {
                maxShaerPoint.Add("shaer", (int)beam.getShaer(maxShaerPoint["atIndex"] * scaler));
                maxShaerPoint.Add("xPos", poitsShear[(int)maxShaerPoint["atIndex"]].X);
                maxShaerPoint.Add("yPos", poitsShear[(int)maxShaerPoint["atIndex"]].Y);
            }
            if (!minShaerPoint.ContainsKey("shaer"))
            {
                minShaerPoint.Add("shaer", (int)beam.getShaer(minShaerPoint["atIndex"] * scaler));
                minShaerPoint.Add("xPos", poitsShear[(int)minShaerPoint["atIndex"]].X);
                minShaerPoint.Add("yPos", poitsShear[(int)minShaerPoint["atIndex"]].Y);
            }
            if ((maxShaerPoint["yPos"] < labelMaxShaer.Height + label2.Top + label2.Height - 3 * gap)||
                (minShaerPoint["yPos"] > panelShaer.Height - labelMinShaer.Height - 2 * gap))
            {
                scaler = Math.Min( (labelMaxShaer.Height + label2.Top + label2.Height - 3 * gap) / Math.Abs(maxShaerPoint["shaer"]),
                    (panelShaer.Height - lineY_panelShaer - labelMinShaer.Height - 2 * gap) / Math.Abs(minShaerPoint["shaer"]));
                for (int i = 0; i < poitsShear.Length; i++)
                {
                    poitsShear[i].Y = lineY_panelShaer - (int)((lineY_panelShaer - poitsShear[i].Y)*scaler) ;
                }
                maxShaerPoint.Remove("yPos");
                maxShaerPoint.Add("yPos", poitsShear[(int)maxShaerPoint["atIndex"]].Y);
                minShaerPoint.Remove("yPos");
                minShaerPoint.Add("yPos", poitsShear[(int)minShaerPoint["atIndex"]].Y);
            }
            labelMaxShaer.Text = Math.Round( maxShaerPoint["shaer"],5).ToString();
            labelMaxShaer.Left = (int)(maxShaerPoint["xPos"]);
            labelMaxShaer.Top = (int)(maxShaerPoint["yPos"] - gap - labelMaxShaer.Height);
            labelMinShaer.Text = Math.Round( minShaerPoint["shaer"],5).ToString();
            labelMinShaer.Left = (int)(minShaerPoint["xPos"] - labelMinShaer.Width);
            labelMinShaer.Top = (int)(minShaerPoint["yPos"] + gap);
            panelShaer.Invalidate();
        }
        private void panelShaer_Paint(object sender, PaintEventArgs e)
        {
            Control panel = (sender as Panel);
            Graphics g = panel.CreateGraphics();
            beam_paint(sender, e, new Point(gap, lineY_panelShaer), new System.Drawing.Size(panel.Width - 2 * gap, 3), Brushes.White);
            //g.DrawLine(Pens.Black, (int)gap, lineY_panelShaer, panel.Width - (int)gap, lineY_panelShaer);
            g.DrawLines(Pens.SkyBlue, poitsShear);
        }
        #endregion

        #region track bar
        private void trackBar1_reset()
        {
            trackBar1.SetRange(0, (int)(Beam.Length * 100));
            trackBar1.Value = trackBar1.Maximum;
            trackBar1.Value = trackBar1.Minimum;
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            double scaler = (double)trackBar1.Value / trackBar1.Maximum;
            labelPos.Left = 13 + (int)(scaler * (trackBar1.Width - 26)) - labelPos.Width/2;
        }
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            updateData();
        }
        private void updateData()
        {
            double scaler = (double)trackBar1.Value / trackBar1.Maximum;
            double position = scaler * Beam.Length;
            labelPos.Text = position.ToString();
            labelMoment.Text = "(N.m) Momentom : " +Math.Round( Beam.getMomentomAt(position),5).ToString();
            labelShare.Text = "(N) Shaer : " + Math.Round( Beam.getShaer(position),5).ToString();
            labelDef.Text = "(cm) Defliction : " +Math.Round( Beam.getDiflectionAt(position),5).ToString();
            label7.Text = "(N) Test force 1 = ";
            label8.Text = "(N) Test force 2 = ";
            if (Beam.F1 != null && stack != null)
            {
                PointBaemForce temp = stack[Beam.F1.Position] as PointBaemForce;
                if(temp != null)
                    label7.Text += Math.Round(Math.Abs(temp.Power),5);
            }
            if (Beam.F2 != null && stack != null)
            {
                PointBaemForce temp = stack[Beam.F2.Position] as PointBaemForce;
                if (temp != null)
                    label8.Text += Math.Round(Math.Abs(temp.Power),5);
            }
        }

        private void splitContainerMainLeftRight_Panel2_Paint(object sender, PaintEventArgs e)
        {
            beam_paint(sender, e, new Point(trackBar1.Left + 10, trackBar1.Top - 30), new Size(trackBar1.Width - 20, 5), Brushes.White);
            beamSupport_paint(sender, e, new Point(trackBar1.Left + 10, trackBar1.Top - 30), new Size(trackBar1.Width - 20, 5), new Size(25, 25), true);
        }
        #endregion

        #region fast buttons
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool change = false;
            if (Beam.F1 != null)
            {
                Beam.forces.Add(new PointBaemForce(Beam.F1.Power,Beam.F1.Position,Beam.Length));
                stack.Add(new PointBaemForce(-Beam.F1.Power, Beam.F1.Position, Beam.Length));
                change = true;
            }
            if (Beam.F2 != null)
            {
                Beam.forces.Add(new PointBaemForce(Beam.F2.Power, Beam.F2.Position, Beam.Length));
                stack.Add(new PointBaemForce(-Beam.F2.Power, Beam.F2.Position, Beam.Length));
                change = true;
            }
            if (change)
            {
                updateMometPoints();
                updateShaerPoints();
                updateData();
                NewPointPositionFlag = true;
                if (maxMomentPoint["moment"] >= Beam.MaxMomentom)
                {
                    sendMassege("break mom|" + maxMomentPoint["moment"] + "|" + maxMomentPoint["xPos"]);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            setTestForce();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            Beam.forces.AddAll(stack);
            stack = new Forces(0, Beam.Length);
            updateAll();
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = trackBar2.Value * 100;
            label4.Text = 2000f / timer1.Interval + "";
        }

        private void Clear()
        {
            if (stack != null)
            {
                Beam.forces.AddAll(stack);
                stack = null;
                Beam.F1 = null;
                Beam.F2 = null;
                NewTestForces = true;
                updateAll();
            }
        }
        private void updateAll()
        {
            updateMometPoints();
            updateShaerPoints();
            updateData();
            NewPointPositionFlag = true;
        }
        #endregion

        #region menu
        private void testForcesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            setTestForce();
        }

        private void backToStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            if (StartGet())
                setTestForce();
            else
            {
                this.Close();
                return;
            }
            this.Visible = true;
        }
        #endregion
    }
}


