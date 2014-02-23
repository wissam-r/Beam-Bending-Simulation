using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using forces;
namespace mainPorject
{
    public enum forceType
    {
        point,
        distributed
    }
    public partial class UserControl_Forces : UserControl
    {
        #region variables
        //variables 
        private forceType type_DONOTUSE;
        /// <summary>
        /// current force type
        /// </summary>
        public forceType Type
        {
            set
            {
                switch (value)
                {
                    case forceType.point:
                        this.panel1.Paint -= new PaintEventHandler(distriputedForce_paint);
                        this.panel1.Paint += new PaintEventHandler(PointForce_Paint);
                        break;
                    case forceType.distributed:
                        this.panel1.Paint -= new PaintEventHandler(PointForce_Paint);
                        this.panel1.Paint += new PaintEventHandler(distriputedForce_paint);
                        break;
                }
                type_DONOTUSE = value;
            }
            get
            {
                return type_DONOTUSE;
            }
        }

        private const int space = 10;
        //variables end
        #endregion

        public UserControl_Forces()
        {
            InitializeComponent();
        }

        #region paint
        //paint
        private void PointForce_Paint(object sender, PaintEventArgs e)
        {
            this.Width = 20;
            force_paint(sender, e, panel1.Width / 2, 9, Color.Red);
        }
        private void distriputedForce_paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < (panel1.Width + space - panel1.Width%space) / space; i++)
            {
                force_paint(sender, e, space / 2 + i*space, 3, Color.Red);
            }
        }
        private void force_paint(object sender, PaintEventArgs e, int x, int width, Color color)
        {
            Pen pen = new Pen(color);
            pen.Width = width;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            e.Graphics.DrawLine(pen, new Point(x, panel1.Height), new Point(x, 0));
        }
        //paint end
        #endregion

        #region send event on panel to form
        //send event on panel to form
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            this.OnMouseMove(e);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            this.OnMouseUp(e);
        }
        //send event on panel to form end
        #endregion
    }
}
