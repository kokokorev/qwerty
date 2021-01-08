using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace KoP_8var_CL
{
    public partial class ControlCheckedListBox : UserControl
    {
        private int _selectedIndex;

        private event EventHandler _checkedListBoxSelectedElementChange;

        public int SelectedIntex
        {
            get { return _selectedIndex; }
            set
            {
                if (value > -2 && value < checkedListBox.Items.Count)
                {
                    _selectedIndex = value; 
                    checkedListBox.SelectedIndex = _selectedIndex;
                }
            }
        }

        public string SelectedText
        {
            get { return checkedListBox.Text; }
            private set { if (_selectedIndex > 0) checkedListBox.Items[SelectedIntex] = value; }
        }

        public event EventHandler checkedListBoxSelectedElementChange
        {
            add { _checkedListBoxSelectedElementChange += value; }
            remove { _checkedListBoxSelectedElementChange -= value; }
        }

        public ControlCheckedListBox()
        {
            InitializeComponent();
            checkedListBox.SelectedIndexChanged += (sender, e) =>
            {
                _checkedListBoxSelectedElementChange?.Invoke(sender, e);
            };
        }

        public CheckedListBox.ObjectCollection List
        {
            get
            {
                return checkedListBox.Items;
            }
        }

        public void Clear()
        {
            checkedListBox.Items.Clear();
        }

        public void SetIndex(int ind)
        {
            if (ind >= checkedListBox.Items.Count)
            {
                MessageBox.Show("За границами диапазона");
                return;
            }
            if (SelectedIntex >= 0)
            {
                var temp = checkedListBox.Items[SelectedIntex];
                var state = checkedListBox.GetItemChecked(SelectedIntex);
                checkedListBox.Items.RemoveAt(SelectedIntex);
                checkedListBox.Items.Insert(ind, temp);
                checkedListBox.SetItemChecked(ind, state);
            }
        }

        private void checkedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIntex = checkedListBox.SelectedIndex;
        }
    }
}
