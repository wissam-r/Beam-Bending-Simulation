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

        public double BeamLength
        {
            private set;
            get;
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
        #endregion

        public mainBeamSpec()
        {
            InitializeComponent();
            p += paintLength;
            p += paintHeightWidth;
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

        //private void TextChangedNumberHandle(object sender, EventArgs e)
        //{
        //    double num;
        //    textChanged(sender as TextBox, null,out num, 1.0f);
        //    (sender as TextBox).Text
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

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

        System.Drawing.Size size_paintForces;
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

        private void textBoxHieght_TextChanged(object sender, EventArgs e)
        {
            double height;
            textChanged(textBoxHieght, panel1,out height, 1.0f);
            BeamHeight = height;
            labelPanelHeight.Text = height.ToString();
        }

        private void textBoxLength_TextChanged(object sender, EventArgs e)
        {
            double length;
            textChanged(textBoxLength, panel1, out length, 100.0f);
            BeamLength = length;
            labelPanelLength.Text = (BeamLength/100).ToString();
        }

        private void textBoxWidth_TextChanged(object sender, EventArgs e)
        {
            double width;
            textChanged(textBoxWidth, panel1, out width, 1.0f);
            BeamWidth = width;
            labelpanelWidth.Text = width.ToString();            
        }

        private void textBoxRadius_TextChanged(object sender, EventArgs e)
        {
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
            //else if (Renforcement2Raduis > BeamWidth || Renforcement2Raduis > BeamHeight)
            //{

            //}
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
            double a;
            textChanged(textBoxA, panel1, out a, 1.0f);
            if (a < BeamHeight)
                RenforcementA = a;
            else
                textBoxA.Text = RenforcementA.ToString();
        }

        private void mainBeamSpec_Load(object sender, EventArgs e)
        {
            BeamHeight = double.Parse(textBoxHieght.Text);
            BeamLength = double.Parse(textBoxLength.Text)*100;
            BeamWidth = double.Parse(textBoxWidth.Text);
            RenforcementCount = (int)numericUpDownCount.Value;
            Renforcement2Raduis = double.Parse(textBoxRadius.Text);
            RenforcementA = double.Parse(textBoxA.Text);
            numericUpDownCount.Maximum = (int)(BeamWidth / Renforcement2Raduis);
        }

        private void textChanged(TextBox textbox, Control paintable, out double number, float scalar)
        {
            if (textbox == null)
                throw new NullReferenceException();
            number = double.Parse(textbox.Text) * scalar;
            if(paintable != null)
                paintable.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Text = "button1_Click";
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = e.Location.ToString();
        }

        private void textBoxNoZero_Leave(object sender, EventArgs e)
        {
            double num;
            textChanged(sender as TextBox, null,out num, 1.0f);
            if (num == 0)
            {
                this.ActiveControl = sender as Control;
            }
        }

        private void textBoxNoZero_textChanged(object sender, EventArgs e)
        {
            double num;
            textChanged(sender as TextBox, null, out num, 1.0f);
            if (num == 0 && buttonOK.Enabled)
            {
                this.buttonOK.Enabled = false;
            }
            else if(!buttonOK.Enabled)
            {
                this.buttonOK.Enabled = true;
            }
        }

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
                pictureBoxDistributedForce.Visible = true;
                pictureBoxPointForce.Visible = true;
                p = new painting(paintForces);
                panel1.Invalidate();
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Forces.Add(new force.PointBaemForce(
                double.Parse(textBoxPointForce.Text),
                double.Parse(textBoxForceLocation.Text)));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Forces.Add(new force.DistributedBeamForce(
                double.Parse(textBoxDistributedForce.Text),
                double.Parse(textBoxForceStart.Text),
                double.Parse(textBoxForceEnd.Text)));
        }

        private void AddPointForce_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPointForce.Text != null
                && textBoxPointForce.Text != ""
                && textBoxForceLocation.Text != null
                && textBoxForceLocation.Text != ""
                && !buttonAddPointForce.Enabled)
            {
                this.buttonAddPointForce.Enabled = true;
            }
            else if (textBoxPointForce.Text == null
                || textBoxPointForce.Text == ""
                || textBoxForceLocation.Text == null
                || textBoxForceLocation.Text == "")
            {
                buttonAddPointForce.Enabled = false;
            }
       }

        private void AddDistributedForce_TextChanged(object sender, EventArgs e)
        {
            if (textBoxDistributedForce.Text != null
                && textBoxDistributedForce.Text != ""
                && textBoxForceStart.Text != null
                && textBoxForceStart.Text != ""
                && textBoxForceEnd.Text != null
                && textBoxForceEnd.Text != ""
                && !buttonAddPointForce.Enabled)
            {
                this.buttonAddPointForce.Enabled = true;
            }
            else if (textBoxDistributedForce.Text == null
                || textBoxDistributedForce.Text == ""
                || textBoxForceStart.Text == null
                || textBoxForceStart.Text == ""
                || textBoxForceEnd.Text == null
                || textBoxForceEnd.Text == "")
            {
                buttonAddPointForce.Enabled = false;
            }
        }

        private Type ForceSelcectd = null;

        private bool pictureBoxPointForce_RightClickable = false;
        private bool pictureBoxPointForce_LeftClickable = true;
        
        private void pictureBoxPointForce_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case System.Windows.Forms.MouseButtons.Right:
                    if(pictureBoxPointForce_RightClickable)
                        contextMenuStripForce.Show(pictureBoxPointForce, e.X, e.Y);
                    break;
                case System.Windows.Forms.MouseButtons.Left:
                    if (pictureBoxPointForce_LeftClickable)
                    {
                        ForceSelcectd = typeof(PointBaemForce);
                        pictureBoxPointForce.Location = new Point(upperLeft_paintForces.X - pictureBoxPointForce.Width / 2, upperLeft_paintForces.Y - pictureBoxPointForce.Height);
                        pictureBoxPointForce_RightClickable = true;
                        pictureBoxPointForce_LeftClickable = false;
                        pictureBoxDistributedForce_LeftClickable = false;
                        textBoxForceLocation.Text = "0";
                    }
                    break;
            }
        }

        private bool pictureBoxDistributedForce_RightClickable = false;
        private bool pictureBoxDistributedForce_LeftClickable = true;
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
                        ForceSelcectd = typeof(DistributedBeamForce);
                        pictureBoxDistributedForce.Location = new Point(upperLeft_paintForces.X, upperLeft_paintForces.Y - pictureBoxDistributedForce.Height);
                        pictureBoxDistributedForce_RightClickable = true;
                        pictureBoxPointForce_LeftClickable = false;
                        pictureBoxDistributedForce_LeftClickable = false;
                    }
                    break;
            }
        }  

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button4_Click(sender, e);
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBoxPointForce_LeftClickable = true;
            pictureBoxDistributedForce_LeftClickable = true;
            toolStripTextBoxForce.Text = "";
            pictureBoxPointForce.Location = new Point(281, 0);
            pictureBoxDistributedForce.Location = new Point(175, 0);
        }

        private bool pictureBoxPointForce_Catch = false;
        private Point oldXY;
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
            PictureBox pictureBox = (sender as PictureBox);
            if (pictureBoxPointForce_Catch)
            {
                int newLeft = pictureBox.Left + e.X - oldXY.X - pictureBox.Width / 2;
                if (newLeft >= upperLeft_paintForces.X - pictureBox.Width / 2
                    && newLeft <= upperLeft_paintForces.X + size_paintForces.Width - pictureBox.Width / 2)
                {
                    pictureBox.Left = newLeft;
                    float scaler = (float)(BeamLength / 100 / size_paintForces.Width);
                    textBoxForceLocation.Text = ((newLeft + pictureBox.Width / 2 - upperLeft_paintForces.X) * scaler).ToString();
                }
            }
            else if (pictureBoxPointForce_RightClickable)
            {
                pictureBox.Cursor = System.Windows.Forms.Cursors.SizeAll;
            }
        }

        private void pictureBoxPointForce_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = (sender as PictureBox);
            pictureBoxPointForce_Catch = false;
            pictureBox.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private bool pictureBoxDistributedForce_Catch = false;
        private int pictureBoxDistributedForce_CatchMood = none;
        private const int move = 0;
        private const int stretchLeft = 1;
        private const int stretchRight = 2;
        private const int none = -1;
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
                else
                {
                    pictureBoxDistributedForce_CatchMood = move;
                }
                
            }
        }

        private void pictureBoxDistributedForce_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = (sender as PictureBox);
            if (pictureBoxDistributedForce_Catch)
            {
                
                switch(pictureBoxDistributedForce_CatchMood){
                    case move:
                        int newLeft = pictureBox.Left + e.X - oldXY.X;
                        if (newLeft >= upperLeft_paintForces.X
                            && newLeft <= upperLeft_paintForces.X + size_paintForces.Width - pictureBox.Width)
                        {
                            pictureBox.Left = newLeft;
                        }
                    break;
                    case stretchRight:
                        int newWidth = pictureBox.Width + e.X - oldXY.X;
                        if (newWidth > 0
                            && newWidth + pictureBox.Left < upperLeft_paintForces.X + size_paintForces.Width)
                        {
                            pictureBox.Width = newWidth;
                        }
                        oldXY.X = e.X;
                    break;
                    case stretchLeft:
                        newWidth = pictureBox.Width -(e.X - oldXY.X);
                        newLeft = pictureBox.Left + e.X - oldXY.X;
                        if (newWidth > 0
                            && newLeft >= upperLeft_paintForces.X)
                        {
                            pictureBox.Left = newLeft;
                            pictureBox.Width = newWidth;
                            pictureBox.Invalidate();
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
                else
                {
                    pictureBox.Cursor = System.Windows.Forms.Cursors.SizeAll;
                }
            }
        }

        private void pictureBoxDistributedForce_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = (sender as PictureBox);
            pictureBoxDistributedForce_Catch = false;
            pictureBoxDistributedForce_CatchMood = none;
            pictureBox.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void toolStripTextBoxForce_TextChanged(object sender, EventArgs e)
        {
            if (ForceSelcectd == typeof(PointBaemForce))
            {
                textBoxPointForce.Text = (sender as ToolStripTextBox).Text;
            }
        }

              
    }
}
