using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TestsForSC.force;

namespace TestsForSC
{
    public partial class mainBeamSpec : Form
    {
        #region variables
        //variables
        public double BeamHeight
        {
            private set;
            get;
        }

        public double BeamWidth
        {
            private set;
            get;
        }

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

        public double Renforcement2Raduis
        {
            private set;
            get;
        }

        public int RenforcementCount
        {
            private set;
            get;
        }

        public double RenforcementA
        {
            private set;
            get;
        }

        public Forces Forces
        {
            set;
            get;
        }
        public beem.SinReinRecBeem sbeam
        {
            private set;
            get;
        }
        public beem.DoubReinRecBeem dbeam
        {
            private set;
            get;
        }
        private List<Force> forces;
        #endregion

        public mainBeamSpec()
        {
            InitializeComponent();
            forces = new List<Force>();
            p += paintLength;
            p += paintHeightWidth;
        }

        private void mainBeamSpec_Load(object sender, EventArgs e)
        {
            BeamHeight = double.Parse(textBoxHieght.Text);
            BeamLength = double.Parse(textBoxLength.Text) * 100;
            BeamWidth = double.Parse(textBoxWidth.Text);
            RenforcementCount = (int)numericUpDownCount.Value;
            Renforcement2Raduis = double.Parse(textBoxRadius.Text);
            RenforcementA = double.Parse(textBoxA.Text);
            numericUpDownCount.Maximum = (int)(BeamWidth / Renforcement2Raduis);
            
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

        private void textBoxNoZero_Leave(object sender, EventArgs e)
        {
            double num;
            textChanged(sender as TextBox, null, out num, 1.0f);
            if (num == 0)
            {
                this.ActiveControl = sender as Control;
            }
        }

        private void textBoxNoZero_textChanged(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            double num;
            textChanged(sender as TextBox, null, out num, 1.0f);
            if (num == 0 && buttonOK.Enabled)
            {
                this.buttonOK.Enabled = false;
            }
            else if (!buttonOK.Enabled)
            {
                this.buttonOK.Enabled = true;
            }
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Text = "button1_Click";
            //MessageBox.Show(strb.ToString());
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = e.Location.ToString();
        }

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

        private void paintHeightWidth(Control control)
        {
            using (Graphics g = control.CreateGraphics())
            {
                float scaler = (float)(BeamHeight / BeamWidth);
                System.Drawing.Size size;
                {
                    int width = (int)BeamWidth;
                    if (width < 50)
                        width = 50;
                    else if (width > (int)(2.0 / 3.0 * control.Width))
                        width = (int)(2.0 / 3.0 * control.Width);
                    int height = (int)(width * scaler);
                    if (height > control.Height / 2)
                    {
                        height = control.Height / 2;
                        width = (int)(height / scaler);
                    }
                    width += 1;
                    height += 1;
                    size = new System.Drawing.Size(width, height);
                }
                Point upperLeft;
                {
                    int x = control.Width / 3 - size.Width / 2;
                    int y = control.Height / 2 - size.Height;
                    upperLeft = new Point(x, y);
                }
                g.FillRectangle(new SolidBrush(Color.Gray), new Rectangle(upperLeft, size));
                int gap = 5;
                labelpanelWidth.Location = new Point(upperLeft.X + size.Width / 2 - labelpanelWidth.Width / 2, upperLeft.Y + size.Height + gap);
                labelPanelHeight.Location = new Point(upperLeft.X + size.Width + gap, upperLeft.Y + size.Height / 2 - labelPanelHeight.Height / 2);
            }
        }

        private void paintLength(Control control)
        {
            using (Graphics g = control.CreateGraphics())
            {
                float scaler = (float)(BeamHeight / BeamLength);
                int gap = 5;
                System.Drawing.Size size;
                {
                    int length = (int)BeamLength;
                    if (length < 200)
                        length = 200;
                    else if (length > (int)(control.Width - 5))
                        length = (int)(control.Width - 5);
                    int height = (int)(length * scaler);
                    if (height > control.Height / 2)
                    {
                        height = control.Height / 2 - labelPanelLength.Size.Height - 2 * gap;
                        length = (int)(height / scaler);
                    }
                    length += 1;
                    height += 1;
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
                    int length = control.Width - 2*gap;
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

        private void paintRenforcement(Control control)
        {
            using (Graphics g = control.CreateGraphics())
            {
                float scaler = (float)(BeamHeight / BeamWidth);
                int gap = 5;
                System.Drawing.Size size;
                {
                    int width = (int)BeamWidth;
                    if (width < (control.Width - 150) / 2)
                        width = (control.Width - 150) / 2;
                    else if (width > (int)(control.Width - 150-2*gap))
                        width = (int)(control.Width - 150 - 2*gap);
                    int height = (int)(width * scaler);
                    if (height > control.Height-2*gap)
                    {
                        height = control.Height - 2 * gap;
                        width = (int)(height / scaler);
                    }
                    width += 1;
                    height += 1;
                    size = new System.Drawing.Size(width, height);
                }
                Point upperLeft;
                {
                    int x = 150 + (control.Width - 150)/2 - size.Width/2;
                    int y = control.Height / 2 - size.Height / 2;
                    upperLeft = new Point(x, y);
                }
                g.FillRectangle(Brushes.Gray, new Rectangle(upperLeft, size));
                if(RenforcementCount>0)
                {
                    scaler = (float)(Renforcement2Raduis/2 / BeamWidth);
                    int width = size.Width;
                    int raduis = (int) (width * scaler);
                    int space = width / RenforcementCount;
                    scaler = size.Height / (float)BeamHeight;
                    for (int i = 0; i < RenforcementCount; i++)
                    {
                        drawCircul(upperLeft.X + space / 2 + i * space, upperLeft.Y + size.Height - (int)(RenforcementA*scaler), raduis, g);
                    }
                }
                {
                    
                    int maxraduis2 = (int)BeamWidth;
                    scaler = (float)Renforcement2Raduis / maxraduis2;
                    int raduis = (int)(74 * scaler);
                    //if (raduis > 70) raduis = 70;
                    //else if (raduis < 30) raduis = 30;
                    int x = 75;
                    int y = control.Height / 2;
                    g.DrawEllipse(Pens.Blue, x - raduis, y - raduis, 2 * raduis, 2 * raduis);
                    g.DrawLine(Pens.LightBlue, x-raduis, y, x + raduis, y);
                }
            }
        }

        private void drawCircul(int x, int y, int r, Graphics g)
        {
            g.FillEllipse(Brushes.Black, x-r, y-r, 2*r, 2*r);
        }
        #endregion

        #region size and material tab
        //size and material tab
        private void textBoxHieght_TextChanged(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            double height;
            textChanged(textBoxHieght, panel1,out height, 1.0f);
            BeamHeight = height;
            labelPanelHeight.Text = height.ToString();
        }

        private void textBoxLength_TextChanged(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            double length;
            textChanged(textBoxLength, panel1, out length, 100.0f);
            BeamLength = length;
            labelPanelLength.Text = (BeamLength/100).ToString();
        }

        private void textBoxWidth_TextChanged(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            double width;
            textChanged(textBoxWidth, panel1, out width, 1.0f);
            BeamWidth = width;
            labelpanelWidth.Text = width.ToString();            
        }
        #endregion

        #region renforcement tab
        //renforcement tab
        private void textBoxRadius_TextChanged(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            double raduis2;
            textChanged(textBoxRadius, panel1, out raduis2, 1.0f);
            if (raduis2 <= BeamWidth && raduis2 <= (BeamHeight-RenforcementA))
            {
                Renforcement2Raduis = raduis2;
                if (raduis2 > 0)
                    numericUpDownCount.Maximum = (int)(BeamWidth / raduis2);
                else if (raduis2 == 0)
                    numericUpDownCount.Maximum = 0;
                else
                    throw new Exception();
            }
            else
                textBoxRadius.Text = Renforcement2Raduis.ToString();
            
        }

        private void numericUpDownCount_ValueChanged(object sender, EventArgs e)
        {
            if ((double)(numericUpDownCount.Value) * Renforcement2Raduis > BeamWidth)
                return;
            RenforcementCount = (int)numericUpDownCount.Value;
            panel1.Invalidate();
        }

        private void textBoxA_TextChanged(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            double a;
            textChanged(textBoxA, panel1, out a, 1.0f);
            if (a < BeamHeight)
                RenforcementA = a;
            else
                textBoxA.Text = RenforcementA.ToString();
        }
        #endregion

        #region tabs controller
        //tabs controller

        //this method use for painting in panel1
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage.Equals(tabPage1))
            {
                p = new painting(paintLength);
                p += paintHeightWidth;
                this.Width = 670;
                labelPanelHeight.Visible = true;
                labelPanelLength.Visible = true;
                labelpanelWidth.Visible = true;
                panel1.Invalidate();
            }
            else if (e.TabPage.Equals(tabPage2))
            {
                p = new painting(paintRenforcement);
                this.Width = 1000;
                panel1.Invalidate();
            }
            else if (e.TabPage.Equals(tabPage3))
            {
                this.Width = 670;
                pictureBoxDistributedForce.Visible = true;
                pictureBoxPointForce.Visible = true;
                p = new painting(paintForces);
                panel1.Invalidate();
                resetVariablesOfForcesTab();
                forces = new List<Force>();
                resetDistributedControls();
                resetPictureBox();
                resetPointForceControls();
            }
        }

        //this method is used for values in the text boxes
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage.Equals(tabPage1))
            {
                
            }
            else if (e.TabPage.Equals(tabPage2))
            {
                if (RenforcementA > BeamHeight)
                {
                    textBoxA.Text = (BeamHeight / 100).ToString();
                }
                if (Renforcement2Raduis > BeamWidth || Renforcement2Raduis > (BeamHeight - RenforcementA))
                    textBoxRadius.Text = (Math.Min(BeamWidth, BeamHeight - RenforcementA) / 2.0).ToString();
            }
            else if (e.TabPage.Equals(tabPage3))
            {
            }
        }

        //this method is used for painting in panel1 
        private void tabControl1_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage.Equals(tabPage1))
            {
                labelPanelHeight.Visible = false;
                labelPanelLength.Visible = false;
                labelpanelWidth.Visible = false;
                p = null;
            }
            else if (e.TabPage.Equals(tabPage2))
            {
                p = null;
            }
            else if (e.TabPage.Equals(tabPage3))
            {
                pictureBoxDistributedForce.Visible = false;
                pictureBoxPointForce.Visible = false;
                p = null;
            }
        }

        //this method is used for values in the text boxes
        private void tabControl1_Deselected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage.Equals(tabPage1))
            {
            }
            else if (e.TabPage.Equals(tabPage2))
            {
            }
            else if (e.TabPage.Equals(tabPage3))
            {
            }
        }
        #endregion

        #region forces tab
        //forces tab
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
            this.forces.Add(new force.PointBaemForce(
                double.Parse(textBoxPointForce.Text),
                double.Parse(textBoxForceLocation.Text)));
            resetPictureBox();
            resetPointForceControls();
            resetVariablesOfForcesTab();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.forces.Add(new force.DistributedBeamForce(
                double.Parse(textBoxDistributedForce.Text),
                double.Parse(textBoxForceStart.Text),
                double.Parse(textBoxForceEnd.Text)));
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


        //StringBuilder strb = new StringBuilder();
    }
}
