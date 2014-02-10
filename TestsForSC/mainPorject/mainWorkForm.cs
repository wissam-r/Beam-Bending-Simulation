using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mainPorject
{
    public partial class mainWorkForm : Form,XnaFormable
    {
        private SplitterPanel xnaPanel;
        private SplitterPanel quickOperation;
        private SplitterPanel extraInfo;
        private void InitializSplitters()
        {
            xnaPanel = splitContainerMainLeftRight.Panel1;
            quickOperation = splitContainerMainLeft.Panel1;
            extraInfo = MainSplitContainer.Panel2;
        }
        public mainWorkForm()
        {
            InitializeComponent();
            InitializSplitters();
        }

        public Control XnaContorl
        {
            get { return xnaPanel; }
        }

        public new Form Form
        {
            get { return this; }
        }

        public bool NewPointsFlag
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool NewPointPositionFlag
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Beam Beam
        {
            get { throw new NotImplementedException(); }
        }
    }
}


