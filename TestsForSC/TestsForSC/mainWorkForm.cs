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
    public partial class mainWorkForm : Form
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
    }
}


