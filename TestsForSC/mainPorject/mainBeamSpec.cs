using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using forces;
using beam;
using mainPorject.Properties;

namespace mainPorject
{
    public partial class mainBeamSpec : Form
    {
        #region variables
        //variables
        public BeamWrapper beamWrap;

        public double BeamHeight { private set; get; }
        public double BeamWidth { private set; get; }

        private double beamLength_DONOTUSE;
        public double BeamLength
        {
            private set
            {
                beamLength_DONOTUSE = value;
                calculateScaler();
            }
            get { return beamLength_DONOTUSE; }
        }

        public double RenforcementDiameter { private set; get; }
        public double RenforcementDiameter2 { private set; get; }

        public int RenforcementCount { private set; get; }
        public int RenforcementCount2 { private set; get; }

        public double RenforcementA { private set; get; }
        public double RenforcementA2 { private set; get; }

        public Forces Forces
        {
            set;
            get;
        }
        private List<Force> forces;

        int stage_DONOTUSE;
        private int stage
        {
            get { return stage_DONOTUSE; }
            set 
            {
                switch (stage_DONOTUSE)
                {
                    case (0):
                        desetStage0();
                        break;
                    case (1):
                        desetStage1();
                        break;
                    case (2):
                        desetStage2();
                        break;
                }
                stage_DONOTUSE= value;
                switch (stage_DONOTUSE)
                {
                    case(0):
                        setStage0();
                        break;
                    case(1):
                        setStage1();
                        break;
                    case(2):
                        setStage2();
                        break;
                }
            }
        }
        #endregion

        public mainBeamSpec()
        {
            InitializeComponent();
            stage = 0;
            forces = new List<Force>();
            p = new painting( paintLength_V2);
            p += new painting(paintHeightWidth_V2);
            p += new painting(paintRenforcement_V2);
        }

        private void mainBeamSpec_Load(object sender, EventArgs e)
        {
            BeamHeight = userControl_BasicSpec1.Height;
            BeamLength = userControl_BasicSpec1.Length * 100;
            BeamWidth = userControl_BasicSpec1.Width;
            RenforcementCount = userControl_BasicSpec1.Count;
            RenforcementCount2 = userControl_BasicSpec1.Count2;
            RenforcementDiameter = userControl_BasicSpec1.Diameter;
            RenforcementDiameter2 = userControl_BasicSpec1.Diameter2;
            RenforcementA = userControl_AdvancedSpec1.A;
            RenforcementA2 = userControl_AdvancedSpec1.A2;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            beamWrap.forces = new Forces(userControl_BasicSpec1.Weight, BeamLength);
            foreach (BeamForce f in forces)
            {
                beamWrap.forces.Add(f);
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        #region text handlers
        //text handlers
        private bool isint(string str)
        {
            int n;
            return int.TryParse(str,out n);
        }
        private bool isdouble(string str)
        {
            double n;
            return double.TryParse(str,out n);
        }
        private void HandleNumberedEntry(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void textChanged(TextBox textbox, Control paintable, out double number, float scalar)
        {
            if (textbox == null)
                throw new NullReferenceException();
            number = double.Parse(textbox.Text) * scalar;
            if (paintable != null)
                paintable.Invalidate();
        }
        #endregion

        #region painting
        //painting
        delegate void painting(Control control);
        painting p;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = panel1.CreateGraphics())
            {
                g.Clear(SystemColors.Control);
            }
            if(p!=null)
            p(panel1);
        }

        private void labelPanel_TextChanged(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        private void userControl_BasicSpec1_DoubleCheckedChanged(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }
        
        private void paintHeightWidth_V2(Control control)
        {
            using (Graphics g = control.CreateGraphics())
            {
                double scaler = ((BeamHeight / BeamWidth) * 10);
                System.Drawing.Size size;
                {

                    int width, height;
                    if (scaler == 10)
                    {
                        width = height = 3;
                    }
                    else if (scaler > 20)
                    {
                        height = 2;
                        width = 4;
                    }
                    else if (/*20 >*/scaler > 10)
                    {
                        height = 2;
                        width = 3;
                    }
                    else if (scaler > 5)
                    {
                        height = 4;
                        width = 2;
                    }
                    else if (scaler > 0)
                    {
                        height = 3;
                        width = 2;
                    }
                    else
                    {
                        return;
                    }
                    height = (int)(control.Width / 1.2 / height);
                    width = (int)(control.Width / 1.2 / width);
                    size = new System.Drawing.Size(width, height);
                }
                Point upperLeft;
                {
                    //int x = control.Width / 3 - size.Width / 2;
                    //int y = control.Height / 2 - size.Height;
                    int x = 15;
                    int y = 15;
                    upperLeft = new Point(x, y);
                }
                g.FillRectangle(new SolidBrush(Color.Gray), new Rectangle(upperLeft, size));
                int gap = 5;
                labelpanelWidth.Location = new Point(upperLeft.X + size.Width / 2 - labelpanelWidth.Width / 2, upperLeft.Y + size.Height + gap);
                labelPanelHeight.Location = new Point(upperLeft.X + size.Width + gap, upperLeft.Y + size.Height / 2 - labelPanelHeight.Height / 2);
                //{
                //    List<Point> points = new List<Point>();
                //    points.Add(new Point(labelPanelHeight.Left, labelPanelHeight.Top - 1));
                //    points.Add(new Point(labelPanelHeight.Left + labelPanelHeight.Width, points.Last().Y));
                //    points.Add(new Point(points.Last().X, upperLeft.Y));
                //    points.Add(new Point(upperLeft.X + size.Width, points.Last().Y));
                //    points.Add(new Point(points.Last().X, upperLeft.Y + size.Height - 1));
                //    points.Add(new Point(points[1].X, points.Last().Y));
                //    points.Add(new Point(points.Last().X, labelPanelHeight.Top + labelPanelHeight.Height));
                //    points.Add(new Point(labelPanelHeight.Left, points.Last().Y));
                //    g.DrawLines(Pens.Blue, points.ToArray());
                //}
                drawPointerV(g, Pens.Blue, labelPanelHeight.Bounds, new Rectangle(upperLeft, size));
                drawPointerH(g, Pens.Blue, labelpanelWidth.Bounds, new Rectangle(upperLeft, size));
            }
        }

        private void drawPointerH(Graphics g, Pen p, Rectangle r/*inner*/, Rectangle b/*outer*/)
        {
            List<Point> points = new List<Point>();
            points.Add(new Point(r.Left - 1, r.Top));
            points.Add(new Point(points.Last().X, r.Bottom));
            points.Add(new Point(b.Left, points.Last().Y));
            points.Add(new Point(points.Last().X, b.Bottom));
            points.Add(new Point(b.Right - 1, points.Last().Y));
            points.Add(new Point(points.Last().X, points[1].Y));
            points.Add(new Point(r.Right, points.Last().Y));
            points.Add(new Point(points.Last().X, points[0].Y));
            g.DrawLines(p, points.ToArray());
        }
        private void drawPointerV(Graphics g, Pen p, Rectangle r/*inner*/, Rectangle b/*outer*/)
        {
            List<Point> points = new List<Point>();
            points.Add(new Point(r.Left, r.Top - 1));
            points.Add(new Point(r.Right, points.Last().Y));
            points.Add(new Point(points.Last().X, b.Top));
            points.Add(new Point(b.Right, points.Last().Y));
            points.Add(new Point(points.Last().X, b.Bottom - 1));
            points.Add(new Point(points[1].X, points.Last().Y));
            points.Add(new Point(points.Last().X, r.Bottom));
            points.Add(new Point(points[0].X, points.Last().Y));
            g.DrawLines(p, points.ToArray());
        }

        private void paintLength_V2(Control control)
        {
            using (Graphics g = control.CreateGraphics())
            {
                double scaler = (BeamHeight / BeamLength)*10;
                int gap = 5;
                System.Drawing.Size size;
                {
                    int length, height;
                    height = control.Height / 10;
                    //if (scaler > 10)
                    //{
                    //    length = 11;
                    //}
                    //else
                    //{
                    //    length = (int)scaler;//divid by zero
                    //}
                    length = (int)(control.Width / (scaler + 0.1) - 2 * gap);
                    size = new System.Drawing.Size(length, height);
                }
                Point upperLeft;
                {
                    int x = control.Width / 2 - size.Width / 2;
                    int y = control.Height - size.Height - labelPanelLength.Size.Height - 2 * gap;
                    upperLeft = new Point(x, y);
                }
                g.FillRectangle(new SolidBrush(Color.Gray), new Rectangle(upperLeft, size));
                labelPanelLength.Location = new Point(upperLeft.X + size.Width / 2 - labelpanelWidth.Width / 2, upperLeft.Y + size.Height + gap);
                drawPointerH(g, Pens.GreenYellow, labelPanelLength.Bounds, new Rectangle(upperLeft, size));
            }
        }

        private System.Drawing.Size size_paintForces_DONOTUSE;
        private System.Drawing.Size size_paintForces
        {
            get { return size_paintForces_DONOTUSE; }
            set
            {
                size_paintForces_DONOTUSE = value;
                calculateScaler();
            }
        }
        Point upperLeft_paintForces;

        private void paintForces(Control control)
        {
            using (Graphics g = control.CreateGraphics())
            {
                float scaler = (float)(BeamHeight / BeamLength);
                int gap = 5;
                {
                    int length = control.Width - 2 * gap;
                    int height = (int)(length * scaler);
                    if (height > control.Height / 2)
                    {
                        height = control.Height / 2 - 2 * gap;
                    }
                    size_paintForces = new System.Drawing.Size(length, height);
                }
                {
                    int x = control.Width / 2 - size_paintForces.Width / 2;
                    int y = control.Height - size_paintForces.Height - 2 * gap;
                    upperLeft_paintForces = new Point(x, y);
                }
                g.FillRectangle(new SolidBrush(Color.Gray), new Rectangle(upperLeft_paintForces, size_paintForces));
            }
        }

        private void paintRenforcement_V2(Control control)
        {
            using (Graphics g = control.CreateGraphics())
            {
                float scaler = (float)(BeamHeight / BeamWidth);
                int gap = 5;
                System.Drawing.Size size;
                {
                    int width = control.Width / 2 - 5 * gap;
                    int height = control.Height/2 + 5 * gap;
                    width += 1;
                    height += 1;
                    size = new System.Drawing.Size(width, height);
                }
                Point upperLeft;
                {
                    int x = control.Width / 2 + gap;
                    int y = 3*gap;
                    upperLeft = new Point(x, y);
                }
                g.FillRectangle(Brushes.Gray, new Rectangle(upperLeft, size));
                if (RenforcementCount > 0)
                {
                    scaler = (float)(RenforcementDiameter / 2 / BeamWidth);
                    int width = size.Width;
                    int raduis = (int)(width * scaler);
                    int space = width / RenforcementCount;
                    scaler = size.Height / (float)BeamHeight;
                    for (int i = 0; i < RenforcementCount; i++)
                    {
                        drawCircul(upperLeft.X + space / 2 + i * space, upperLeft.Y + size.Height - (int)(RenforcementA * scaler), raduis, g);
                    }
                }
                if (RenforcementCount2 > 0 && userControl_BasicSpec1.DoubleChecked)
                {
                    scaler = (float)(RenforcementDiameter2 / 2 / BeamWidth);
                    int width = size.Width;
                    int raduis = (int)(width * scaler);
                    int space = width / RenforcementCount2;
                    scaler = size.Height / (float)BeamHeight;
                    for (int i = 0; i < RenforcementCount2; i++)
                    {
                        drawCircul(upperLeft.X + space / 2 + i * space, upperLeft.Y +  (int)(RenforcementA2 * scaler), raduis, g);
                    }
                }
            }
        }

        private void drawCircul(int x, int y, int r, Graphics g)
        {
            g.FillEllipse(Brushes.Black, x-r, y-r, 2*r, 2*r);
        }
        #endregion

        #region Fields
        //Fields
        private void Height_NumberChanged(Control control, double num)
        {
            BeamHeight = num;
            labelPanelHeight.Text = BeamHeight.ToString();
        }

        private void Length_NumberChanged(Control control, double num)
        {
            BeamLength = num*100;
            labelPanelLength.Text = num.ToString();
        }

        private void Width_NumberChanged(Control control, double num)
        {
            BeamWidth = num;
            labelpanelWidth.Text = BeamWidth.ToString();
        }

        private void userControl_BasicSpec1_Count2Changed(Control sender, double number)
        {
            RenforcementCount2 = (int)number;
            panel1.Invalidate();
        }

        private void userControl_BasicSpec1_Diameter2Changed(Control sender, double number)
        {
            RenforcementDiameter2 = number;
            panel1.Invalidate();
        }

        private void Diameter_NumberChanged(Control control, double num)
        {
            RenforcementDiameter = num;
            panel1.Invalidate();
        }

        private void Count_NumberChanged(Control control, double num)
        {
            RenforcementCount = (int)num;
            panel1.Invalidate();
        }

        private void A_NumberChanged(Control control, double num)
        {
            RenforcementA = num;
            panel1.Invalidate();
        }

        private void userControl_AdvancedSpec1_A2Changed(Control sender, double number)
        {
            RenforcementA2 = number;
            panel1.Invalidate();
        }

        private void userControl_AdvancedSpec1_AChanged(Control sender, double number)
        {
            RenforcementA = number;
            panel1.Invalidate();
        }
        #endregion

        #region forces 
        //forces 
        string oldtextBoxForceLocation;
        private double oldStart;
        private double oldEnd;
        private void resetVariablesOfForcesTab()
        {
            oldtextBoxForceLocation = "";
            oldEnd = BeamLength/100;
            oldStart = 0;
            ForceSelcected = null;
        }
        private void disablePointForce_textBox()
        {
            textBoxPointForce.Enabled = false;
            textBoxForceLocation.Enabled = false;
        }
        private void enablePointForce_textBox()
        {
            textBoxPointForce.Enabled = true;
            textBoxForceLocation.Enabled = true;
        }
        private void disableDistributedForce_textBox()
        {
            textBoxDistributedForce.Enabled = false;
            textBoxForceStart.Enabled = false;
            textBoxForceEnd.Enabled = false;
        }
        private void enableDistributedForce_textBox()
        {
            textBoxDistributedForce.Enabled = true;
            textBoxForceStart.Enabled = true;
            textBoxForceEnd.Enabled = true;
        }
        float scaler_DONOTUSE = -1;
        float scaler{
            get {
                if (scaler_DONOTUSE == -1)
                    throw new DataException("scaler == -1");
                return scaler_DONOTUSE; }
            set { scaler_DONOTUSE = value; }
        }
        private void calculateScaler()
        {
            if (size_paintForces == null || size_paintForces.Width == 0)
                scaler = -1;
            scaler = (float)BeamLength / 100 / size_paintForces.Width;
        }

        private void resetPointForceControls()
        {
            textBoxForceLocation.Text = "";
            textBoxPointForce.Text = "";
            buttonAddPointForce.Enabled = false;
        }
        private void resetDistributedControls()
        {
            textBoxForceStart.Text = "";
            textBoxForceEnd.Text = "";
            textBoxDistributedForce.Text = "";
            buttonAddDistributedForce.Enabled = false;
        }

        private void tryEnable_ButtonAddDistributedForce()
        {
            if (textBoxDistributedForce.Text != null
                && textBoxDistributedForce.Text != ""
                && textBoxForceStart.Text != null
                && textBoxForceStart.Text != ""
                && textBoxForceEnd.Text != null
                && textBoxForceEnd.Text != ""
                && !buttonAddPointForce.Enabled)
            {
                buttonAddDistributedForce.Enabled = true;
            }
            else if (textBoxDistributedForce.Text == null
                || textBoxDistributedForce.Text == ""
                || textBoxForceStart.Text == null
                || textBoxForceStart.Text == ""
                || textBoxForceEnd.Text == null
                || textBoxForceEnd.Text == "")
            {
                buttonAddDistributedForce.Enabled = false;
            }
        }
        private void tryEnable_buttonAddPointForce()
        {
            if (textBoxPointForce.Text != null
                && textBoxPointForce.Text != ""
                && textBoxForceLocation.Text != null
                && textBoxForceLocation.Text != ""
                && !buttonAddPointForce.Enabled)
            {
                buttonAddPointForce.Enabled = true;
            }
            else if (textBoxPointForce.Text == null
                || textBoxPointForce.Text == ""
                || textBoxForceLocation.Text == null
                || textBoxForceLocation.Text == "")
            {
                buttonAddPointForce.Enabled = false;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.forces.Add(new PointBaemForce(
                double.Parse(textBoxPointForce.Text),
                double.Parse(textBoxForceLocation.Text)*100,
                BeamLength));
            resetPictureBox();
            resetPointForceControls();
            resetVariablesOfForcesTab();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.forces.Add(new DistributedBeamForce(
                double.Parse(textBoxDistributedForce.Text),
                double.Parse(textBoxForceStart.Text)*100,
                double.Parse(textBoxForceEnd.Text)*100,
                BeamLength));
            resetPictureBox();
            resetDistributedControls();
            resetVariablesOfForcesTab();
        }

        private void AddPointForce_TextChanged(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            if (textbox.Text == "")
            {
                tryEnable_buttonAddPointForce();
                tryNull_ForceSelcected();
            }
            else
            {
                if (ForceSelcected == null)
                    ForceSelcected = typeof(PointBaemForce);
                tryEnable_buttonAddPointForce();
            }            
       }

        private void AddDistributedForce_TextChanged(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            if (textbox.Text == "")
            {
                tryEnable_ButtonAddDistributedForce();
                tryNull_ForceSelcected();
            }
            else
            {
                if (ForceSelcected == null)
                    ForceSelcected = typeof(DistributedBeamForce);
                tryEnable_ButtonAddDistributedForce();
            }
        }

        private void textBoxForceLocation_textChanged(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            if (textbox.Text == "")
            {
                tryEnable_buttonAddPointForce();
                tryNull_ForceSelcected();
                return;
            }
            double num;
            textChanged(textbox, null, out num, 100.0f);
            if (num > BeamLength || num < 0)
            {
                textBoxForceLocation.Text = oldtextBoxForceLocation;
            }
            else
            {
                //strb.AppendLine(">>>text change: " + textbox.Text);
                oldtextBoxForceLocation = textBoxForceLocation.Text;
                movePictureBoxPointForce((int)(num / scaler)/100);
            }
            if (ForceSelcected == null)
                ForceSelcected = typeof(PointBaemForce); 
            tryEnable_buttonAddPointForce();
        }
        
        private void textBoxForceStart_textChanged(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            if (textbox.Text == "")
            {
                tryEnable_ButtonAddDistributedForce();
                tryNull_ForceSelcected();
                return;
            }
            double num;
            textChanged(textbox, null, out num, 1.0f);
            if (num > oldEnd || num < 0)
            {
                textbox.Text = oldStart.ToString();
            }
            else
            {
                oldStart = double.Parse(textbox.Text);
                //movePictureBoxDistributedForceStart((int)((decimal)num / scaler) );
                double end;
                if(!double.TryParse(textBoxForceEnd.Text,out end)){
                    end = BeamLength/100;
                }
                movePictureBoxDistributedForce((int)(num / scaler), (int)(end / scaler));
            }
            tryEnable_ButtonAddDistributedForce();
            if (ForceSelcected == null)
                ForceSelcected = typeof(DistributedBeamForce);
        }
        
        private void textBoxForceEnd_textChanged(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            if (textbox.Text == "")
            {
                tryEnable_ButtonAddDistributedForce();
                tryNull_ForceSelcected();
                return;
            }
            
            double num;
            textChanged(textbox, null, out num, 100.0f);
            if (num > BeamLength || num < oldStart)
            {
                textbox.Text = oldEnd.ToString();
            }
            else
            {
                oldEnd = double.Parse(textbox.Text);
                //movePictureBoxDistributedForceEnd((int)((decimal)num / scaler) / 100);
                double start;
                if (!double.TryParse(textBoxForceStart.Text, out start))
                {
                    start = 0;
                }
                movePictureBoxDistributedForce((int)(start / scaler), (int)(num/100 / scaler));
            }
            tryEnable_ButtonAddDistributedForce();
            if(ForceSelcected == null)
                ForceSelcected = typeof(DistributedBeamForce);
        }
        #endregion
        
        #region forces tab panel picture boxes
        //forces tab panel picture boxes
        private Point oldXY;
        private Type forceselectedDONOTUSETHIS;
        private Type ForceSelcected
        {
            get
            { return forceselectedDONOTUSETHIS; }
            set
            {
                forceselectedDONOTUSETHIS = value;
                if (forceselectedDONOTUSETHIS == typeof(PointBaemForce))
                {
                    disableDistributedForce_textBox();
                    enablePointForce_textBox();
                }
                else if (forceselectedDONOTUSETHIS == typeof(DistributedBeamForce))
                {
                    disablePointForce_textBox();
                    enableDistributedForce_textBox();
                }
                else
                {
                    enableDistributedForce_textBox();
                    enablePointForce_textBox();
                }
                
            }
        }
        private void tryNull_ForceSelcected()
        {
            if (ForceSelcected == null)
                return;
            else if (ForceSelcected == typeof(PointBaemForce)
                && textBoxForceLocation.Text == ""
                && textBoxPointForce.Text == "")
            {
                ForceSelcected = null;
            }
            else if (ForceSelcected == typeof(DistributedBeamForce)
                && textBoxForceStart.Text == ""
                && textBoxForceEnd.Text == ""
                && textBoxDistributedForce.Text == "")
            {
                ForceSelcected = null;
            }
        }
        //private bool PictureBoxPointForceMoving = false;

        private void resetPictureBox()
        {
            pictureBoxPointForce_LeftClickable = true;
            pictureBoxPointForce_RightClickable = false;
            pictureBoxDistributedForce_LeftClickable = true;
            pictureBoxDistributedForce_RightClickable = false;
            toolStripTextBoxForce.Text = "";
            pictureBoxPointForce.Location = new Point(281, 0);
            pictureBoxPointForce.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBoxDistributedForce.Location = new Point(175, 0);
            pictureBoxDistributedForce.Width = 100;
            pictureBoxDistributedForce.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void movePictureBoxPointForce(int x)
        {
            //strb.AppendLine(">>>move pic: " + x);
            //pictureBoxPointForce.Left = x;
            //pictureBoxPointForce.Top = upperLeft_paintForces.Y - pictureBoxPointForce.Height;
            //PictureBoxPointForceMoving = true;
            pictureBoxPointForce.Location = new Point(x + upperLeft_paintForces.X - pictureBoxPointForce.Width/2 ,upperLeft_paintForces.Y - pictureBoxPointForce.Height);
            if (pictureBoxPointForce_RightClickable == false)
            {
                pictureBoxPointForce_RightClickable = true;
                pictureBoxPointForce_LeftClickable = false;
                pictureBoxDistributedForce_LeftClickable = false;
            }
        }
        private void movePictureBoxDistributedForceStart(int x)
        {
            int oldend = pictureBoxDistributedForce.Left + pictureBoxDistributedForce.Width - upperLeft_paintForces.X;
            pictureBoxDistributedForce.Location = new Point(x + upperLeft_paintForces.X, upperLeft_paintForces.Y - pictureBoxDistributedForce.Height);
            movePictureBoxDistributedForceEnd(oldend);
            //if (pictureBoxDistributedForce_RightClickable == false)
            //{
            //    pictureBoxDistributedForce_RightClickable = true;
            //    pictureBoxDistributedForce_LeftClickable = false;
            //    pictureBoxPointForce_LeftClickable = false;
            //}
        }
        private void movePictureBoxDistributedForceEnd(int x)
        {
            pictureBoxDistributedForce.Width = x + upperLeft_paintForces.X - pictureBoxDistributedForce.Left;
            if (pictureBoxDistributedForce_RightClickable == false)
            {
                pictureBoxDistributedForce_RightClickable = true;
                pictureBoxDistributedForce_LeftClickable = false;
                pictureBoxPointForce_LeftClickable = false;
            }
        }
        private void movePictureBoxDistributedForce(int start, int end)
        {
            pictureBoxDistributedForce.Width = end - start;
            pictureBoxDistributedForce.Location = new Point(start + upperLeft_paintForces.X, upperLeft_paintForces.Y - pictureBoxDistributedForce.Height);
            if (pictureBoxDistributedForce_RightClickable == false)
            {
                pictureBoxDistributedForce_RightClickable = true;
                pictureBoxDistributedForce_LeftClickable = false;
                pictureBoxPointForce_LeftClickable = false;
            }
        }

        //pictureBoxPointForce
        private bool pictureBoxPointForce_RightClickable = false;
        private bool pictureBoxPointForce_LeftClickable = true;
        private bool pictureBoxPointForce_Catch = false;

        private void pictureBoxPointForce_MouseClick(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = (sender as PictureBox);
            switch (e.Button)
            {
                case System.Windows.Forms.MouseButtons.Right:
                    if(pictureBoxPointForce_RightClickable)
                        contextMenuStripForce.Show(pictureBoxPointForce, e.X, e.Y);
                    break;
                case System.Windows.Forms.MouseButtons.Left:
                    if (pictureBoxPointForce_LeftClickable)
                    {
                        ForceSelcected = typeof(PointBaemForce);
                        //movePictureBoxPointForce(upperLeft_paintForces.X - pictureBoxPointForce.Width / 2);
                        textBoxForceLocation.Text = "0";
                        pictureBox.Cursor = System.Windows.Forms.Cursors.SizeAll;
                    }
                    else if (pictureBoxDistributedForce_RightClickable)
                    {
                        resetPictureBox();
                        resetDistributedControls();
                        pictureBoxPointForce_MouseClick(pictureBoxDistributedForce, e);
                    }
                    break;
            }
        }
        
        private void pictureBoxPointForce_MouseDown(object sender, MouseEventArgs e)
        {
            if (pictureBoxPointForce_RightClickable)
            {
                pictureBoxPointForce_Catch = true;
                oldXY = e.Location;
            }
        }

        private void pictureBoxPointForce_MouseMove(object sender, MouseEventArgs e)
        {
            //if (PictureBoxPointForceMoving)
            //{
            //    PictureBoxPointForceMoving = false;
            //    return;
            //}
            PictureBox pictureBox = (sender as PictureBox);
            if (pictureBoxPointForce_Catch)
            {                
                //int newLeft = pictureBox.Left + e.X - oldXY.X - pictureBox.Width / 2;
                int newLeft = pictureBox.Left + e.X - pictureBox.Width / 2;
                //int newLeft = pictureBox.Left + e.X;
                if (newLeft >= upperLeft_paintForces.X - pictureBox.Width / 2
                    && newLeft <= upperLeft_paintForces.X + size_paintForces.Width - pictureBox.Width / 2)
                {
                    //pictureBox.Left = newLeft;
                    //movePictureBoxPointForce(newLeft);
                    //strb.AppendLine(">>>move: " + e.Location);
                    textBoxForceLocation.Text = ((newLeft + pictureBox.Width / 2 - upperLeft_paintForces.X) * scaler).ToString();
                    
                }
            }
            //else if (pictureBoxPointForce_RightClickable)
            //{
            //    pictureBox.Cursor = System.Windows.Forms.Cursors.SizeAll;
            //}
        }

        private void pictureBoxPointForce_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = (sender as PictureBox);
            if (pictureBoxPointForce_RightClickable)
            {
                pictureBoxPointForce_Catch = false;
                pictureBoxPointForce.Cursor = System.Windows.Forms.Cursors.SizeAll;
            }
            else
            {
            }
            //pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        //pictureBoxDistributedForce
        private bool pictureBoxDistributedForce_RightClickable = false;
        private bool pictureBoxDistributedForce_LeftClickable = true;
        private bool pictureBoxDistributedForce_Catch = false;
        private int pictureBoxDistributedForce_CatchMood = none;
        //private const int move = 0;
        private const int stretchLeft = 1;
        private const int stretchRight = 2;
        private const int none = -1;
        //private bool handelCursor = true;
        private Rectangle mouseClip = Cursor.Clip;

        private void pictureBoxDistributedForce_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case System.Windows.Forms.MouseButtons.Right:
                    if (pictureBoxDistributedForce_RightClickable)
                        contextMenuStripForce.Show(pictureBoxDistributedForce, e.X, e.Y);
                    break;
                case System.Windows.Forms.MouseButtons.Left:
                    if (pictureBoxDistributedForce_LeftClickable)
                    {
                        ForceSelcected = typeof(DistributedBeamForce);
                        //movePictureBoxDistributedForceStart(0);
                        textBoxForceStart.Text = "0";
                        textBoxForceEnd.Text = (pictureBoxDistributedForce.Width * scaler).ToString();
                    }
                    else if (pictureBoxPointForce_RightClickable)
                    {
                        resetPictureBox();
                        resetPointForceControls();
                        pictureBoxDistributedForce_MouseClick(pictureBoxPointForce, e);
                    }
                    break;
            }
        }  

        private void pictureBoxDistributedForce_MouseDown(object sender, MouseEventArgs e)
        {
            if (pictureBoxDistributedForce_RightClickable)
            {
                pictureBoxDistributedForce_Catch = true;
                oldXY = e.Location;
                PictureBox pictureBox = (sender as PictureBox);
                if (e.X < pictureBox.Width / 4)
                {
                    pictureBoxDistributedForce_CatchMood = stretchLeft;
                }
                else if (e.X > 3 * pictureBox.Width / 4)
                {
                    pictureBoxDistributedForce_CatchMood = stretchRight;
                }
                //else
                //{
                //    pictureBoxDistributedForce_CatchMood = move;
                //}
                
            }
        }

        private void pictureBoxDistributedForce_MouseMove(object sender, MouseEventArgs e)
        {
            //if (!handelCursor)
            //{
            //    handelCursor = true;
            //    return;
            //}
            PictureBox pictureBox = (sender as PictureBox);
            if (pictureBoxDistributedForce_Catch)
            {
                int newLeft;
                int newWidth;
                switch(pictureBoxDistributedForce_CatchMood){
                    //case move:
                    //    newLeft = pictureBox.Left + e.X - pictureBox.Width/2;
                    //    newWidth = pictureBox.Width;
                    //    if (newLeft >= upperLeft_paintForces.X
                    //        && newLeft <= upperLeft_paintForces.X + size_paintForces.Width - pictureBox.Width)
                    //    {
                    //        //pictureBox.Left = newLeft;
                    //        pictureBoxDistributedForce.MouseMove -= pictureBoxDistributedForce_MouseMove;
                    //        //textBoxForceStart.Text = ((newLeft - upperLeft_paintForces.X) * scaler).ToString();
                    //        //textBoxForceEnd.Text = ((newLeft - upperLeft_paintForces.X + pictureBox.Width) * scaler).ToString();
                    //        textBoxForceEnd.Text = ((newLeft - upperLeft_paintForces.X + newWidth) * scaler).ToString();
                    //        textBoxForceStart.Text = ((newLeft - upperLeft_paintForces.X) * scaler).ToString();
                    //        pictureBoxDistributedForce.MouseMove += pictureBoxDistributedForce_MouseMove;
                    //    }
                    //break;
                    case stretchRight:
                        newLeft = pictureBox.Left;
                        newWidth =  e.X;
                        if (newWidth > 0
                            && newWidth + newLeft <= upperLeft_paintForces.X + size_paintForces.Width)
                        {
                            Cursor.Clip = mouseClip;
                        }
                        else
                        {
                            newWidth = size_paintForces.Width - (int)(oldStart/scaler);
                            Cursor.Clip = new Rectangle(pictureBox.PointToScreen(new Point(0,0)),pictureBox.Size);
                            //handelCursor = false;
                            //Cursor.Position = pictureBoxDistributedForce.PointToScreen(new Point(pictureBoxDistributedForce.Width, e.Y));
                        }
                        //pictureBox.Width = newWidth;
                        textBoxForceEnd.Text = ((newLeft - upperLeft_paintForces.X + newWidth) * scaler).ToString();
                        oldXY.X = e.X;
                    break;
                    case stretchLeft:
                        newWidth = pictureBox.Width -(e.X - oldXY.X);
                        newLeft = pictureBox.Left + e.X;
                        if (newWidth > 0
                            && newLeft >= upperLeft_paintForces.X)
                        {
                            //pictureBox.Left = newLeft;
                            //pictureBox.Width = newWidth;
                            textBoxForceStart.Text = ((newLeft - upperLeft_paintForces.X) * scaler).ToString();
                        }
                    break;
                }
            }
            else if (pictureBoxDistributedForce_RightClickable)
            {
                if (e.X < pictureBox.Width / 4)
                {
                    pictureBox.Cursor = System.Windows.Forms.Cursors.SizeWE;
                }
                else if (e.X > 3 * pictureBox.Width / 4)
                {
                    pictureBox.Cursor = System.Windows.Forms.Cursors.SizeWE;
                }
            }
        }

        private void pictureBoxDistributedForce_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = (sender as PictureBox);
            pictureBoxDistributedForce_Catch = false;
            pictureBoxDistributedForce_CatchMood = none;
            pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            Cursor.Clip = mouseClip;
        }

        
        #endregion

        #region menu strip
        private void addToolStrip_SetEnable()
        {
            if (toolStripMenuItem1.Enabled)
            {
                if (!buttonAddPointForce.Enabled && !buttonAddDistributedForce.Enabled)
                {
                    toolStripMenuItem1.Enabled = false;
                }
            }
            else
            {
                if (buttonAddPointForce.Enabled || buttonAddDistributedForce.Enabled)
                {
                    toolStripMenuItem1.Enabled = true;
                }
            }
        }

        private void buttonAddPointForce_EnabledChanged(object sender, EventArgs e)
        {
            addToolStrip_SetEnable();
        }

        private void buttonAddDistributedForce_EnabledChanged(object sender, EventArgs e)
        {
            addToolStrip_SetEnable();
        }

        private void contextMenuStripForce_Opening(object sender, CancelEventArgs e)
        {
            if (ForceSelcected == typeof(PointBaemForce))
            {
                toolStripTextBoxForce.Text = textBoxPointForce.Text;
            }
            else if (ForceSelcected == typeof(DistributedBeamForce))
            {
                toolStripTextBoxForce.Text = textBoxDistributedForce.Text;
            }
        }

        private void toolStripTextBoxForce_TextChanged(object sender, EventArgs e)
        {
            if (ForceSelcected == typeof(PointBaemForce))
            {
                textBoxPointForce.Text = (sender as ToolStripTextBox).Text;
            }
            else if (ForceSelcected == typeof(DistributedBeamForce))
            {
                textBoxDistributedForce.Text = (sender as ToolStripTextBox).Text;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ForceSelcected == typeof(PointBaemForce))
            {
                button4_Click(sender, e);
            }
            else if (ForceSelcected == typeof(DistributedBeamForce))
            {
                button3_Click(sender, e);
            }
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetVariablesOfForcesTab();
            resetPictureBox();
            resetDistributedControls();
            resetPointForceControls();
        }
        #endregion
        
        #region stages
        private void setStage0()
        {
            userControl_AdvancedSpec1.Visible = false;
            userControl_BasicSpec1.Visible = true;
            panelForces.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = false;
            buttonOK.Visible = false;
            buttonCancel.Visible = true;

            p = new painting(paintLength_V2);
            p += paintHeightWidth_V2;
            p += paintRenforcement_V2;
            panel1.Width = 530;
            labelPanelHeight.Visible = true;
            labelPanelLength.Visible = true;
            labelpanelWidth.Visible = true;

            panel1.Invalidate();
        }
        private void setStage1()
        {
            userControl_AdvancedSpec1.Visible = true;
            userControl_BasicSpec1.Visible = false;
            panelForces.Visible = false;
            button1.Visible = false;
            button2.Visible = true;
            button3.Visible = true;
            buttonOK.Visible = false;
            buttonCancel.Visible = true;

            panel1.Width = 530;
            labelPanelHeight.Visible = true;
            labelPanelLength.Visible = true;
            labelpanelWidth.Visible = true;
        }
        private void setStage2()
        {
            panelForces.Visible = true;
            userControl_AdvancedSpec1.Visible = false;
            userControl_BasicSpec1.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = true;
            buttonOK.Visible = true;
            buttonCancel.Visible = true;

            pictureBoxDistributedForce.Visible = true;
            pictureBoxPointForce.Visible = true;
            panel1.Width = 435;
            p = new painting(paintForces);
            panel1.Invalidate();
            resetVariablesOfForcesTab();
            forces = new List<Force>();
            resetDistributedControls();
            resetPictureBox();
            resetPointForceControls();
        }
        
        private void desetStage0()
        {
            labelPanelHeight.Visible = false;
            labelPanelLength.Visible = false;
            labelpanelWidth.Visible = false;
        }
        private void desetStage1()
        {
            labelPanelHeight.Visible = false;
            labelPanelLength.Visible = false;
            labelpanelWidth.Visible = false;
        }
        private void desetStage2()
        {
            pictureBoxDistributedForce.Visible = false;
            pictureBoxPointForce.Visible = false;
            p = null;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            stage = stage - 2 + stage % 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!userControl_BasicSpec1.IsErrorFree())
            {
                MessageBox.Show("something wrong", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            stage = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (stage == 0)
            {
                if (!userControl_BasicSpec1.IsErrorFree())
                {
                    MessageBox.Show("something wrong", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!userControl_AdvancedSpec1.IsErrorFree())
                {
                    MessageBox.Show("something wrong", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    stage = 1;
                    return;
                }
                if (beamWrap == null) beamWrap = new BeamWrapper();
                if (userControl_BasicSpec1.DoubleChecked)
                {
                    beamWrap.beam = new DoubReinRecBeem(BeamHeight,
                                                        BeamLength,
                                                        BeamWidth,
                                                        userControl_BasicSpec1.Diameter,
                                                        userControl_BasicSpec1.Diameter2,
                                                        userControl_BasicSpec1.Count,
                                                        userControl_BasicSpec1.Count2);
                }
                else
                {
                    beamWrap.beam = new SinReinRecBeem(BeamHeight,
                                                       BeamLength,
                                                       BeamWidth,
                                                       userControl_BasicSpec1.Diameter,
                                                       userControl_BasicSpec1.Count);
                }
                stage = 2;
            }
            else if (stage == 1)
            {
                if (!userControl_AdvancedSpec1.IsErrorFree())
                {
                    MessageBox.Show("something wrong", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (beamWrap == null) beamWrap = new BeamWrapper();
                if (userControl_BasicSpec1.DoubleChecked)
                {
                    beamWrap.beam = new DoubReinRecBeem(userControl_AdvancedSpec1.Fc,
                                                        userControl_AdvancedSpec1.Fs,
                                                        BeamHeight,
                                                        BeamLength,
                                                        BeamWidth,
                                                        userControl_AdvancedSpec1.Es,
                                                        userControl_BasicSpec1.Diameter,
                                                        userControl_BasicSpec1.Diameter2,
                                                        userControl_BasicSpec1.Count,
                                                        userControl_BasicSpec1.Count2,
                                                        userControl_AdvancedSpec1.A,
                                                        userControl_AdvancedSpec1.A2,
                                                        userControl_AdvancedSpec1.Chose);
                }
                else
                {
                    beamWrap.beam = new SinReinRecBeem(userControl_AdvancedSpec1.Fc,
                                                        userControl_AdvancedSpec1.Fs,
                                                        BeamHeight,
                                                        BeamLength,
                                                        BeamWidth,
                                                        userControl_AdvancedSpec1.Es,
                                                        userControl_BasicSpec1.Diameter,
                                                        userControl_BasicSpec1.Count,
                                                        userControl_AdvancedSpec1.A,
                                                        userControl_AdvancedSpec1.Chose);
                }
                stage = 2;
            }
        }
        #endregion
    }
}
