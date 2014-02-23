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
    public partial class UserControl_BasicSpec : UserControl
    {
        public UserControl_BasicSpec()
        {
            InitializeComponent();
            initializeHandling();
            initializeValues();
        }

        #region handelling
        //handelling
        public delegate void NumberChangedHandler(Control sender, double number);
        public event NumberChangedHandler HeightChanged;
        protected virtual void OnHeightChanged(Control sender, double number)
        {
            if (HeightChanged != null)
            {
                HeightChanged(sender, number); 
            }
        }
        public event NumberChangedHandler WidthChanged;
        protected virtual void OnWidthChanged(Control sender, double number)
        {
            if (WidthChanged != null)
            {
                WidthChanged(sender, number);
            }
        }
        public event NumberChangedHandler LengthChanged;
        protected virtual void OnLengthChanged(Control sender, double number)
        {
            if (LengthChanged != null)
            {
                LengthChanged(sender, number);
            }
        }
        public event NumberChangedHandler DiameterChanged;
        protected virtual void OnDiameterChanged(Control sender, double number)
        {
            if (DiameterChanged != null)
            {
                DiameterChanged(sender, number);
            }
        }
        public event NumberChangedHandler CountChanged;
        protected virtual void OnCountChanged(Control sender, double number)
        {
            if (CountChanged != null)
            {
                CountChanged(sender, number);
            }
        }
        public event NumberChangedHandler Diameter2Changed;
        protected virtual void OnDiameter2Changed(Control sender, double number)
        {
            if (Diameter2Changed != null)
            {
                Diameter2Changed(sender, number);
            }
        }
        public event NumberChangedHandler Count2Changed;
        protected virtual void OnCount2Changed(Control sender, double number)
        {
            if (Count2Changed != null)
            {
                Count2Changed(sender, number);
            }
        }
        public event NumberChangedHandler WeightChanged;
        protected virtual void OnWeightChanged(Control sender, double number)
        {
            if (WeightChanged != null)
            {
                WeightChanged(sender, number);
            }
        }

        public event EventHandler DoubleCheckedChanged;

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
            else if (e.KeyChar == '0'){
                double nums,numa;
                if(double.TryParse(textBox.SelectedText, out nums) && double.TryParse(textBox.Text, out numa)){
                    if(numa == nums){
                        e.Handled = true;
                    }
                }
                else if(string.IsNullOrWhiteSpace(textBox.Text))
                {
                    e.Handled = true;
                }
            }
        }
        private void HandleEnterEntry_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (e.KeyCode == Keys.Enter){
                this.SelectNextControl(sender as Control, true, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void initializeHandling()
        {
            HeightChanged = new NumberChangedHandler(textBoxHieght_NumberChanged);
            LengthChanged = new NumberChangedHandler(textBoxLength_NumberChanged);
            WidthChanged = new NumberChangedHandler(textBoxWidth_NumberChanged);
            CountChanged = new NumberChangedHandler(numericUpDownCount_NumberChanged);
            DiameterChanged = new NumberChangedHandler(textBoxDiameter_NumberChanged);
            WeightChanged = new NumberChangedHandler(textBoxWeight_NumberChanged);
            Diameter2Changed = new NumberChangedHandler(textBoxDiameter2_NumberChanged);
            Count2Changed = new NumberChangedHandler(numericUpDownCount2_NumberChanged);
        }
        private void initializeValues()
        {
            textBoxDiameter.Text = "25";
            textBoxHieght.Text = "550";
            textBoxLength.Text = "2";
            textBoxWeight.Text = "1000";
            textBoxWidth.Text = "250";
            numericUpDownCount.Value = 3;
            textBoxDiameter2.Text = "25";
            numericUpDownCount2.Value = 3;
        }
        private void textBoxFocus_Enter(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.SelectAll();
        }
        //handelling end
        #endregion

        #region getters
        //getters
        public double Height { get; private set; }
        public double Length { get; private set; }
        public double Width { get; private set; }
        public double Diameter { get; private set; }
        public double Diameter2 { get; private set; }
        public double Weight { get; private set; }
        public int Count { get; private set; }
        public int Count2 { get; private set; }
        /// <summary>
        /// double renforcement is used or not
        /// </summary>
        public bool DoubleChecked { get { return checkBoxDouble.Checked; } }
        public bool IsErrorFree()
        {
            if (errorProviderWeight.GetError(textBoxWeight) == "" &&
                errorProviderWidth.GetError(textBoxWidth) == "" &&
                errorProviderHeight.GetError(textBoxHieght) == "" &&
                errorProviderLenght.GetError(textBoxLength) == "" &&
                errorProviderCount.GetError(numericUpDownCount) == "" &&
                errorProviderDiameter.GetError(textBoxDiameter) == "" &&
                errorProviderDiameter2.GetError(textBoxDiameter2) == "" &&
                errorProviderCount2.GetError(numericUpDownCount2) == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //getters end
        #endregion

        #region setters
        //setters
        public void setErrorWidth(string error)
        {
            setError(errorProviderWidth, textBoxWidth, error);
        }
        public void setErrorLength(string error)
        {
            setError(errorProviderLenght, textBoxLength, error);
        }
        public void setErrorHeight(string error)
        {
            setError(errorProviderHeight, textBoxHieght, error);
        }
        public void setErrorCount(string error)
        {
            setError(errorProviderCount, numericUpDownCount, error);
        }
        public void setErrorDiameter(string error)
        {
            setError(errorProviderDiameter, textBoxDiameter, error);
        }
        public void setErrorCount2(string error)
        {
            setError(errorProviderCount, numericUpDownCount, error);
        }
        public void setErrorDiameter2(string error)
        {
            setError(errorProviderDiameter, textBoxDiameter, error);
        }
        public void setErrorWeight(string error)
        {
            setError(errorProviderWeight, textBoxWeight, error);
        }

        private void setError(ErrorProvider ep,Control control, string error)
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

        public void setRecText(Double width, Double height, Double length)
        {
            if (width != null) { textBoxWidth.Text = width.ToString(); }
            if (height != null) { textBoxHieght.Text = height.ToString(); }
            if (length != null) { textBoxLength.Text = length.ToString(); }
        }
        public void setRenSText(Double diameter, Int32 count)
        {
            if (diameter != null) { textBoxDiameter.Text = diameter.ToString(); }
            if (count != null) { numericUpDownCount.Value = count; }
        }
        public void setRenDText(Double diameter, Int32 count)
        {
            if (diameter != null) { textBoxDiameter2.Text = diameter.ToString(); }
            if (count != null) { numericUpDownCount2.Value = count; }
        }
        public void setSingelOrDouble(bool sod)
        {
            checkBoxDouble.Checked = sod;
        }
        public void setWieghtText(Double wieght)
        {
            if (wieght != null) { textBoxWeight.Text = wieght.ToString(); }
        }
        //setters end
        #endregion

        #region changing handeling
        //changing handeling
        private void textBoxHieght_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            double num;
            if (double.TryParse(textBox.Text, out num))
            {
                this.OnHeightChanged(textBox, num);
            }
            else if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorProviderHeight.SetError(textBox, "this field can not be empty");
            }
        }
        private void textBoxHieght_NumberChanged(Control control, double num)
        {
            Height = num/10;
            if (checkForZero(control, errorProviderHeight, Height))
            {
                errorProviderHeight.Clear();
            }
        }

        private void textBoxLength_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            double num;
            if (double.TryParse(textBox.Text, out num))
            {
                this.OnLengthChanged(textBox, num);
            }
            else if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorProviderLenght.SetError(textBox, "this field can not be empty");
            }
        }
        private void textBoxLength_NumberChanged(Control control, double num)
        {
            Length = num;
            if (checkForZero(control,errorProviderLenght,Length))
            {
                errorProviderLenght.Clear();
            }
        }

        private void textBoxWidth_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            double num;
            if (double.TryParse(textBox.Text, out num))
            {
                this.OnWidthChanged(textBox, num);
            }
            else if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorProviderWidth.SetError(textBox, "this field can not be empty");
            }
        }
        private void textBoxWidth_NumberChanged(Control control, double num)
        {
            Width = num/10;
            if (checkWidthDiameterCount())
            {
                errorProviderWidth.Clear();
                errorProviderDiameter.Clear();
                errorProviderCount.Clear();
            }
            else if (!checkForZero(control, errorProviderLenght, Length))
            {
                errorProviderWidth.Clear();
            }
        }

        private void numericUpDownCount_ValueChanged(object sender, EventArgs e)
        {
            this.OnCountChanged(numericUpDownCount, (int)numericUpDownCount.Value);
        }
        private void numericUpDownCount_NumberChanged(Control control, double num)
        {
            Count = (int)num;
            if (checkWidthDiameterCount())
            {
                errorProviderWidth.Clear();
                errorProviderDiameter.Clear();
                errorProviderCount.Clear();
            }
            if (checkForZero(control, errorProviderCount, Count))
            {
                errorProviderCount.Clear();
            }
        }

        private void numericUpDownCount2_ValueChanged(object sender, EventArgs e)
        {
            this.OnCount2Changed(numericUpDownCount2, (int)numericUpDownCount2.Value);
        }
        private void numericUpDownCount2_NumberChanged(Control control, double num)
        {
            Count2 = (int)num;
            if (checkWidthDiameterCount2())
            {
                errorProviderWidth.Clear();
                errorProviderDiameter2.Clear();
                errorProviderCount2.Clear();
            }
            if (checkForZero(control, errorProviderCount2, Count2))
            {
                errorProviderCount2.Clear();
            }
        }

        private void textBoxDiameter_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            double num;
            if (double.TryParse(textBox.Text, out num))
            {
                this.OnDiameterChanged(textBox, num);
            }
            else if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorProviderDiameter.SetError(textBox, "this field can not be empty");
            }
        }
        private void textBoxDiameter_NumberChanged(Control control, double num)
        {
            Diameter = num/10;
            if (checkWidthDiameterCount())
            {
                errorProviderWidth.Clear();
                errorProviderDiameter.Clear();
                errorProviderCount.Clear();
            }
            if (checkForZero(control, errorProviderDiameter, Diameter))
            {
                errorProviderDiameter.Clear();
            }
        }

        private void textBoxDiameter2_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            double num;
            if (double.TryParse(textBox.Text, out num))
            {
                this.OnDiameter2Changed(textBox, num);
            }
            else if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorProviderDiameter2.SetError(textBox, "this field can not be empty");
            }
        }
        private void textBoxDiameter2_NumberChanged(Control control, double num)
        {
            Diameter2 = num/10;
            if (checkWidthDiameterCount2())
            {
                errorProviderWidth.Clear();
                errorProviderDiameter2.Clear();
                errorProviderCount2.Clear();
            }
            else if (checkForZero(control, errorProviderDiameter2, Diameter2))
            {
                errorProviderDiameter2.Clear();
            }
        }

        private void textBoxWeight_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            double num;
            if (double.TryParse(textBox.Text, out num))
            {
                this.OnWeightChanged(textBox, num);
            }
            else if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorProviderWeight.SetError(textBox, "this field can not be empty");
            }
        }
        private void textBoxWeight_NumberChanged(Control control, double num)
        {
            Weight = num;
            if (checkForZero(control, errorProviderLenght, Length))
            {
                errorProviderWeight.Clear();
            }
        }

        private void checkBoxDouble_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = sender as CheckBox;
            textBoxDiameter2.Enabled = checkbox.Checked;
            numericUpDownCount2.Enabled = checkbox.Checked;
            if(!checkbox.Checked)
            {
                errorProviderDiameter2.Clear();
                errorProviderCount2.Clear();
            }
            else
            {
                checkWidthDiameterCount2();
                checkForZero(textBoxDiameter2, errorProviderDiameter2, Diameter2);
                checkForZero(numericUpDownCount2, errorProviderCount2, Count2);
            }
            if (DoubleCheckedChanged != null)
                DoubleCheckedChanged(sender, e);
        }
        //changing handeling end
        #endregion

        #region checking
        //checking
        private bool checkWidthDiameterCount()
        {
            if (Diameter * Count > Width)
            {
                errorProviderWidth.SetError(textBoxWidth, "this width can not have that much of renforcement");
                errorProviderDiameter.SetError(textBoxDiameter, "this diameter is too big for this width");
                errorProviderCount.SetError(numericUpDownCount, "this count is too much for this width");
                return false;
            }
            return true;            
        }
        private bool checkWidthDiameterCount2()
        {
            if (Diameter2 * Count2 > Width)
            {
                errorProviderWidth.SetError(textBoxWidth, "this width can not have that much of renforcement");
                errorProviderDiameter2.SetError(textBoxDiameter2, "this diameter is too big for this width");
                errorProviderCount2.SetError(numericUpDownCount2, "this count is too much for this width");
                return false;
            }
            return true;
        }
        private bool checkForZero(Control control,ErrorProvider ep, double num)
        {
            if (num == 0)
            {
                ep.SetError(control, "this field can not be zero");
                return false;
            }
            return true;
        }
        //checking
        #endregion
        
    }
}
