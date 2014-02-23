using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mainPorject
{
    public partial class UserControl_AdvancedSpec : UserControl
    {
        public UserControl_AdvancedSpec()
        {
            InitializeComponent();
            //initializeHandling();
            //initializeValues();
        }
        public UserControl_AdvancedSpec(ref UserControl_BasicSpec basic)
        {
            
            InitializeComponent();
            this.Basic = basic;
            initializeHandling();
            //initializeValues();
        }

        #region handelling
        public delegate void NumberChangedHandler(Control sender, double number);
        public event NumberChangedHandler FcChanged;
        protected virtual void OnFcChanged(Control sender, double number)
        {
            if (FcChanged != null)
            {
                FcChanged(sender, number);
            }
        }
        public event NumberChangedHandler FsChanged;
        protected virtual void OnFsChanged(Control sender, double number)
        {
            if (FsChanged != null)
            {
                FsChanged(sender, number);
            }
        }
        public event NumberChangedHandler EsChanged;
        protected virtual void OnEsChanged(Control sender, double number)
        {
            if (EsChanged != null)
            {
                EsChanged(sender, number);
            }
        }
        public event NumberChangedHandler AChanged;
        protected virtual void OnAChanged(Control sender, double number)
        {
            if (AChanged != null)
            {
                AChanged(sender, number);
            }
        }
        public event NumberChangedHandler A2Changed;
        protected virtual void OnA2Changed(Control sender, double number)
        {
            if (A2Changed != null)
            {
                A2Changed(sender, number);
            }
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
        private void initializeHandling()
        {
            AChanged = new NumberChangedHandler(textBoxA_NumberChanged);
            A2Changed = new NumberChangedHandler(textBoxA2_NumberChanged);
            EsChanged = new NumberChangedHandler(textBoxEs_NumberChanged);
            FcChanged = new NumberChangedHandler(textBoxFc_NumberChanged);
            FsChanged = new NumberChangedHandler(textBoxFs_NumberChanged);
            Basic.DoubleCheckedChanged += new EventHandler(isDouble);
        }
        private void initializeValues()
        {
            textBoxA.Text = "50";
            textBoxA2.Text = "50";
            textBoxEs.Text = "210000";
            textBoxFc.Text = "40";
            textBoxFs.Text = "400";
        }

        #endregion

        #region variables
        private UserControl_BasicSpec basic_DONOTUSE;
        public UserControl_BasicSpec Basic
        {
            get { return basic_DONOTUSE; }
            set { basic_DONOTUSE = value; initializeHandling(); initializeValues(); }
        }
        #endregion

        #region getters
        public double Fc { get; private set; }
        public double Fs { get; private set; }
        public double Es { get; private set; }
        public double A { get; private set; }
        public double A2 { get; private set; }
        public byte Chose
        {
            get
            {
                if (Ring.Checked)
                {
                    return 0;
                }
                else if (spiral.Checked)
                {
                    return 1;
                }
                else
                    throw new Exception();
            }
        }
        public bool IsErrorFree()
        {
            if (errorProviderA.GetError(textBoxA) == "" &&
                errorProviderA2.GetError(textBoxA2) == "" &&
                errorProviderEs.GetError(textBoxEs) == "" &&
                errorProviderFc.GetError(textBoxFc) == "" &&
                errorProviderFs.GetError(textBoxFs) == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region setters
        public void setErrorA(string error)
        {
            setError(errorProviderA, textBoxA, error);
        }
        public void setErrorA2(string error)
        {
            setError(errorProviderA2, textBoxA2, error);
        }
        public void setErrorEs(string error)
        {
            setError(errorProviderEs, textBoxEs, error);
        }
        public void setErrorFc(string error)
        {
            setError(errorProviderFc, textBoxFc, error);
        }
        public void setErrorFs(string error)
        {
            setError(errorProviderFs, textBoxFs, error);
        }
        
        private void setError(ErrorProvider ep, Control control, string error)
        {
            if (error == null)
            {
                ep.Clear();
            }
            else
            {
                ep.SetError(control, error);
            }
        }

        public void setFcText(Double fc)
        {
            if (fc != null) { textBoxFc.Text = fc.ToString(); }
        }
        public void setFsText(Double fs)
        {
            if (fs != null) { textBoxFs.Text = fs.ToString(); }
        }
        public void setEsText(Double es)
        {
            if (es != null) { textBoxEs.Text = es.ToString(); }
        }
        public void setAText(Double a)
        {
            if (a != null) { textBoxA.Text = a.ToString(); }
        }
        public void setA2Text(Double a)
        {
            if (a != null) { textBoxA2.Text = a.ToString(); }
        }
        #endregion

        private void textBoxFc_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            double num;
            if (double.TryParse(textBox.Text, out num))
            {
                this.OnFcChanged(textBox, num);
            }
            else if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorProviderFc.SetError(textBox, "this field can not be empty");
            }
        }
        private void textBoxFc_NumberChanged(Control control, double num)
        {
            Fc = num;
            if (checkForZero(control, errorProviderFc, Fc))
            {
                errorProviderFc.Clear();
            }
        }

        private void textBoxFs_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            double num;
            if (double.TryParse(textBox.Text, out num))
            {
                this.OnFsChanged(textBox, num);
            }
            else if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorProviderFs.SetError(textBox, "this field can not be empty");
            }
        }
        private void textBoxFs_NumberChanged(Control control, double num)
        {
            Fs = num;
            if (checkForZero(control, errorProviderFs, Fs))
            {
                errorProviderFs.Clear();
            }
        }

        private void textBoxEs_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            double num;
            if (double.TryParse(textBox.Text, out num))
            {
                this.OnEsChanged(textBox, num);
            }
            else if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorProviderEs.SetError(textBox, "this field can not be empty");
            }
        }
        private void textBoxEs_NumberChanged(Control control, double num)
        {
            Es = num;
            if (checkForZero(control, errorProviderEs, Es))
            {
                errorProviderEs.Clear();
            }
        }

        private void textBoxA_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            double num;
            if (double.TryParse(textBox.Text, out num))
            {
                this.OnAChanged(textBox, num);
            }
            else if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorProviderA.SetError(textBox, "this field can not be empty");
            }
        }
        private void textBoxA_NumberChanged(Control control, double num)
        {
            A = num/10;
            if (checkForZero(control, errorProviderA, A))
            {
                errorProviderA.Clear();
            }
            if (checkA())
            {
                errorProviderA.Clear();
            }
        }

        private void textBoxA2_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            double num;
            if (double.TryParse(textBox.Text, out num))
            {
                this.OnA2Changed(textBox, num);
            }
            else if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorProviderA2.SetError(textBox, "this field can not be empty");
            }
        }
        private void textBoxA2_NumberChanged(Control control, double num)
        {
            A2 = num/10;
            if (checkForZero(control, errorProviderA2, A2))
            {
                errorProviderA2.Clear();
            }
            if (checkA2())
            {
                errorProviderA2.Clear();
            }
        }

        private void isDouble(object sender, EventArgs e)
        {
            if (!(sender is CheckBox))
                return;
            CheckBox checkbox = sender as CheckBox;
            if (checkbox.Checked)
            {
                textBoxA2.Enabled = true;
                checkA2();
            }
            else
            {
                textBoxA2.Enabled = false;
                errorProviderA2.Clear();
            }

        }

        private bool checkA()
        {
            if (A >= Basic.Height/2 - Basic.Diameter)
            {
                errorProviderA.SetError(textBoxA, "A must be less than " + (Basic.Height / 2 - Basic.Diameter));
                return false;
            }
            else if (A <= Basic.Diameter)
            {
                errorProviderA.SetError(textBoxA, "A must be more than " + (Basic.Diameter));
                return false;
            }
            return true;
        }
        private bool checkA2()
        {
            if (A2 >= Basic.Height / 2 - Basic.Diameter2)
            {
                errorProviderA2.SetError(textBoxA2, "A2 must be less than " + (Basic.Height / 2 - Basic.Diameter2));
                return false;
            }
            else if (A2 <= Basic.Diameter2)
            {
                errorProviderA2.SetError(textBoxA2, "A must be more than " + (Basic.Diameter2));
                return false;
            }
            return true;
        }
        private bool checkForZero(Control control, ErrorProvider ep, double num)
        {
            if (num == 0)
            {
                ep.SetError(control, "this field can not be zero");
                return false;
            }
            return true;
        }

        private void textBoxFocus_Enter(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.SelectAll();
        }
    }
}
