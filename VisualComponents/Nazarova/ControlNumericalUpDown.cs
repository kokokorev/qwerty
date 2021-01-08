using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace KoP_8var_CL
{
    public partial class ControlNumericalUpDown : UserControl
    {
        public decimal UpDownValue
        {
            get
            {
                if (From <= numericUpDown.Value && numericUpDown.Value <= To)
                {
                    return numericUpDown.Value;
                }
                else
                {
                    throw new Exception("Число не в диапазоне.");
                }
            }
            set { numericUpDown.Value = value; }
        }

        public decimal From
        {
            get { return numericUpDownFrom.Value; }
            set { numericUpDownFrom.Value = value; }
        }
        public decimal To
        {
            get { return numericUpDownTo.Value; }
            set { numericUpDownTo.Value = value; }
        }

        public ControlNumericalUpDown()
        {
            InitializeComponent();
            numericUpDownFrom.Value = From;
            numericUpDownTo.Value = To;
        }
    }
}