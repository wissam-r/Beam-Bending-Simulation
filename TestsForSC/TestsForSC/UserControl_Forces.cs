﻿using System;
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
        public UserControl_Forces()
        {
            InitializeComponent();
        }

        private forceType type_DONOTUSE;
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

        public new event MouseEventHandler MouseClick
        {
            add
            {
                base.MouseClick += value;
                panel1.MouseClick += value;
            }
            remove
            {
                base.MouseClick -= value;
                panel1.MouseClick -= value;
            }
        }
        public new event MouseEventHandler MouseDown
        {
            add
            {
                base.MouseDown += value;
                panel1.MouseDown += value;
            }
            remove
            {
                base.MouseDown -= value;
                panel1.MouseDown -= value;
            }
        }
        public new event MouseEventHandler MouseMove
        {
            add
            {
                base.MouseMove += value;
                panel1.MouseMove += value;
            }
            remove
            {
                base.MouseMove -= value;
                panel1.MouseMove -= value;
            }
        }
        public new event MouseEventHandler MouseUp
        {
            add
            {
                base.MouseUp += value;
                panel1.MouseUp += value;
            }
            remove
            {
                base.MouseUp -= value;
                panel1.MouseUp -= value;
            }
        }

    }
}
