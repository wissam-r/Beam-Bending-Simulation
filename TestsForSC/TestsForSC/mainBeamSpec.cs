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
    public partial class mainBeamSpec : Form
    {
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
                    for (int i = 0; i < RenforcementCount; i++)
                    {
                        drawCircul(upperLeft.X + space / 2 + i * space, upperLeft.Y + size.Height - (int)RenforcementA - raduis, raduis, g);
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
            RenforcementA = a;
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    labelPanelHeight.Visible = true;
                    labelPanelLength.Visible = true;
                    labelpanelWidth.Visible = true;
                    p = new painting(paintLength);
                    p += paintHeightWidth;
                    this.Width = 670;
                    panel1.Invalidate();
                    break;
                case 1:
                    labelPanelHeight.Visible = false;
                    labelPanelLength.Visible = false;
                    labelpanelWidth.Visible = false;
                    p = new painting(paintRenforcement);                    
                    this.Width = 1000;
                    panel1.Invalidate();
                    if (RenforcementA > BeamHeight)
                    {
                        textBoxA.Text = (BeamHeight / 100).ToString();
                    }
                    if (Renforcement2Raduis > BeamHeight || Renforcement2Raduis > (BeamWidth - RenforcementA))
                        textBoxRadius.Text = (Math.Min(BeamWidth, BeamHeight - RenforcementA) / 2.0).ToString();
                    break;
                case 2:
                    labelPanelHeight.Visible = false;
                    labelPanelLength.Visible = false;
                    labelpanelWidth.Visible = false;
                    p -= paintLength;
                    p -= paintHeightWidth;
                    panel1.Invalidate();
                    break;
                default:
                    break;
            }
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
        

        

        

        
    }
}
