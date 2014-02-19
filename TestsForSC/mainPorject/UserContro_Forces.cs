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
    public partial class UserContro_Forces : UserControl
    {
        public UserContro_Forces()
        {
            InitializeComponent();
        }

        private void HandleNumberedEntry(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && textBox.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '0')
            {
                double nums, numa;
                if (double.TryParse(textBox.SelectedText, out nums) && double.TryParse(textBox.Text, out numa))
                {
                    if (numa == nums)
                    {
                        e.Handled = true;
                    }
                }
                else if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    e.Handled = true;
                }
            }
        }
        private void HandleEnterEntry_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (e.KeyCode == Keys.Enter)
            {
                //this.SelectNextControl(sender as Control,true,false,false,true);
                this.SelectNextControl(sender as Control, true, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        public Forces forces { get; private set; }
    }
}
