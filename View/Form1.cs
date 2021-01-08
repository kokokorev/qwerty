using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            controlComboBox.ItemsList.Add("str1");
            controlComboBox.ItemsList.Add("str2");
            controlComboBox.ItemsList.Add("str3");
        }
    }
}
