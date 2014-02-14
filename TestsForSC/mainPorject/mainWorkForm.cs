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
        #endregion

        public mainWorkForm()
        {
            InitializeComponent();
            InitializSplitters();

            NewPointsFlag = false;
            NewPointPositionFlag = false;

            this.Visible = false;
            getNewBeam();
            this.Visible = true;
        }

        private void getNewBeam()
        {
            using (mainBeamSpec mbs = new mainBeamSpec())
            {
                DialogResult result = mbs.ShowDialog(this);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    this.beam = mbs.beamWrap;
                    NewPointsFlag = true;
                    updateMometPoints();
                    panelMomentom.Paint += new PaintEventHandler(panelMomentom_Paint);
                    updateShaerPoints();
                    panelShaer.Paint += new PaintEventHandler(panelShaer_Paint);
                    trackBar1_reset();

                }
            }

        }

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

        public BeamWrapper Beam
        {
            get { return beam; }
        }
        #endregion

        #region menu strip
        private void newBeamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getNewBeam();
        }
        #endregion

        #region Diagrames
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
            labelMaxMomentom.Text = maxMomentPoint["moment"].ToString();
            labelMaxMomentom.Left = (int)(maxMomentPoint["xPos"] - labelMaxMomentom.Width / 2);
            labelMaxMomentom.Top = (int)(maxMomentPoint["yPos"] + gap);
            panelMomentom.Invalidate();
        }
        private void panelMomentom_Paint(object sender, PaintEventArgs e)
        {
            Control panel = (sender as Panel);
            Graphics g = panel.CreateGraphics();
            g.DrawLine(Pens.Black, (int)gap, lineY_panelMomentom, panel.Width - (int)gap, lineY_panelMomentom);
            g.DrawLines(Pens.Plum, pointsMomentom);
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
                (minShaerPoint["yPos"] > panelShaer.Height - 2 * gap))
            {
                scaler = Math.Min( (labelMaxShaer.Height + label2.Top + label2.Height - 3 * gap) / maxShaerPoint["shaer"],
                    (panelShaer.Height - lineY_panelShaer - 2 * gap) / maxShaerPoint["shaer"]);
                for (int i = 0; i < poitsShear.Length; i++)
                {
                    poitsShear[i].Y = lineY_panelShaer - (int)((lineY_panelShaer - poitsShear[i].Y)*scaler) ;
                }
                maxShaerPoint.Remove("yPos");
                maxShaerPoint.Add("yPos", poitsShear[(int)maxShaerPoint["atIndex"]].Y);
                minShaerPoint.Remove("yPos");
                minShaerPoint.Add("yPos", poitsShear[(int)minShaerPoint["atIndex"]].Y);
            }
            labelMaxShaer.Text = maxShaerPoint["shaer"].ToString();
            labelMaxShaer.Left = (int)(maxShaerPoint["xPos"]);
            labelMaxShaer.Top = (int)(maxShaerPoint["yPos"] - gap - labelMaxShaer.Height);
            labelMinShaer.Text = minShaerPoint["shaer"].ToString();
            labelMinShaer.Left = (int)(minShaerPoint["xPos"] - labelMinShaer.Width);
            labelMinShaer.Top = (int)(minShaerPoint["yPos"] + gap);
            panelShaer.Invalidate();
        }
        void panelShaer_Paint(object sender, PaintEventArgs e)
        {
            Control panel = (sender as Panel);
            Graphics g = panel.CreateGraphics();
            g.DrawLine(Pens.Black, (int)gap, lineY_panelShaer, panel.Width - (int)gap, lineY_panelShaer);
            g.DrawLines(Pens.Olive, poitsShear);
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
            double scaler = (double)trackBar1.Value / trackBar1.Maximum;
            double position = scaler * Beam.Length;
            labelPos.Text = position.ToString();
            labelMoment.Text = "Momentom : " + Beam.getMomentomAt(position).ToString();
            labelShare.Text = "Shaer : " + Beam.getShaer(position).ToString();
            labelDef.Text = "Defliction : " + Beam.getDiflectionAt(position).ToString();
        }
        #endregion
    }
}


