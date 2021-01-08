using System;
using System.Windows.Forms;

namespace VisualComponents.Kokorev
{
    public partial class ControlComboBox : UserControl
    {
        /// <summary>
        /// событие, вызываемое при смене значения в ComboBox
        /// </summary>
        private event EventHandler change;

        public event EventHandler Change
        {
            add => change += value; 
            remove => change -= value; 
        }
        
        /// <summary>
        /// публичное свойство, для установки и получения выбранного значения
        /// </summary>
        public string SelectedValue
        {
            get => comboBox.Text;
            set => comboBox.Text = value;
        }
        
        /// <summary>
        /// публичное свойство, которое передает ссылку на свойство Items элемента ComboBox,
        /// через которое и идет заполнение
        /// </summary>
        public ComboBox.ObjectCollection ItemsList => comboBox.Items;
        
        public ControlComboBox()
        {
            InitializeComponent();
            comboBox.SelectedValueChanged += (sender, e) => change?.Invoke(sender, e);
        }

        /// <summary>
        /// публичный метод очистки списка
        /// </summary>
        public void ClearItems() => comboBox.Items.Clear();
        
    }
}
