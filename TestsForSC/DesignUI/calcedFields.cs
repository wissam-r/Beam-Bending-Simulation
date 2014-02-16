using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DesignUI
{
    public partial class calcedFields : UserControl
    {
        public calcedFields()
        {
            InitializeComponent();
        }

        private void txtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox a = (TextBox)sender;
            string s = "0123456789.";
            if ((!s.Contains(e.KeyChar)) && e.KeyChar.GetHashCode() != 524296)
                e.Handled = true;
            else if (a.Text.Contains('.') && e.KeyChar == '.')
                e.Handled = true;
            else
                e.Handled = false;
        }
    }
}
