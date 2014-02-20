using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using forces;
namespace mainPorject
{
    public partial class TestForcesSpec : Form
    {
        public BeamForce F1 { private set; get; }
        public BeamForce F2 { private set; get; }
        private double beamlength_DONOTUSE;
        public double BeamLength
        {
            set
            {
                scaler = (panel1.Width - 2 * gap) / value;
                beamlength_DONOTUSE = value;
                setTextBox();
            }
            get { return beamlength_DONOTUSE; }
        }
        private double scaler;
        private const int beamY = 235;
        private const int gap = 5;
        private Point xy;
        private Size wh;

        private bool catchf1;
        private bool catchf2;
        public TestForcesSpec()
        {
            InitializeComponent();
            xy = new Point(gap, beamY);
            wh = new Size(panel1.Width - 2 * gap, 2 * gap);
        }

        private void setTextBox()
        {
            textBox_pos1.Text = (panel1.Width - 2 * gap)/3/scaler + "";
            textBox_pos2.Text = 2 * (panel1.Width - 2 * gap) / 3 / scaler + "";
        }

        private void TestForcesSpec_Paint(object sender, PaintEventArgs e)
        {
            beam_paint(sender, e, xy, wh, Brushes.White);
        }

        private void beam_paint(object sender, PaintEventArgs e, Point pos, Size size, Brush brush)
        {
            e.Graphics.FillRectangle(brush, pos.X, pos.Y - size.Height / 2, size.Width, size.Height);
        }

        private void textBox_pos1_TextChanged(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            double x;
            if (!double.TryParse(textbox.Text, out x))
            {
                return;
            }
            x *= scaler;
            userControl_Forces1.MouseMove -= userControl_Forces1_MouseMove;
            userControl_Forces1.Location = new Point((int)x + gap - userControl_Forces1.Width / 2, beamY - gap - userControl_Forces1.Height);
            userControl_Forces1.MouseMove += userControl_Forces1_MouseMove;
        }

        private void textBox_pos2_TextChanged(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            double x;
            if (!double.TryParse(textbox.Text, out x))
            {
                return;
            }
            x *= scaler;
            userControl_Forces2.MouseMove -= userControl_Forces2_MouseMove;
            userControl_Forces2.Location = new Point((int)x + gap - userControl_Forces2.Width / 2, beamY - gap - userControl_Forces1.Height);
            userControl_Forces2.MouseMove += userControl_Forces2_MouseMove;
        }

        private void userControl_Forces1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!catchf1)
                return;
            Control panel = (sender as Control);
            int newLeft = panel.Left + e.X - panel.Width / 2;
            if (newLeft >= gap - panel.Width / 2
                && newLeft <= panel1.Width - 2 * gap - panel.Width / 2)
            {
                textBox_pos1.Text = ((newLeft + panel.Width / 2 - gap) / scaler).ToString();
            }
        }

        private void userControl_Forces2_MouseMove(object sender, MouseEventArgs e)
        {
            if (!catchf2)
                return;
            Control panel = (sender as Control);
            int newLeft = panel.Left + e.X - panel.Width / 2;
            if (newLeft >= gap - panel.Width / 2
                && newLeft <= panel1.Width - 2 * gap - panel.Width / 2)
            {
                textBox_pos2.Text = ((newLeft + panel.Width / 2 - gap) / scaler).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x1, x2, p1, p2;
            if (!double.TryParse(textBox_pos1.Text, out x1) ||
                !double.TryParse(textBox_pos2.Text, out x2) ||
                !double.TryParse(textBoxPower1.Text, out p1) ||
                !double.TryParse(textBoxPower2.Text, out p2))
            {
                return;
            }
            if (p1 > 0) 
                F1 = new PointBaemForce(p1, x1 * 100, BeamLength * 100);
            if (p2 > 0) 
                F2 = new PointBaemForce(p2, x2 * 100, BeamLength * 100);
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void userControl_Forces1_MouseDown(object sender, MouseEventArgs e)
        {
            catchf1 = true;
        }

        private void userControl_Forces1_MouseUp(object sender, MouseEventArgs e)
        {
            catchf1 = false;
        }

        private void userControl_Forces2_MouseDown(object sender, MouseEventArgs e)
        {
            catchf2 = true;
        }

        private void userControl_Forces2_MouseUp(object sender, MouseEventArgs e)
        {
            catchf2 = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
