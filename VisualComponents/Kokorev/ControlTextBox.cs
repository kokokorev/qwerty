using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace VisualComponents.Kokorev
{
    public partial class ControlTextBox : UserControl
    {
        /// <summary>
        /// шаблон
        /// </summary>
        private string _template = "";

        /// <summary>
        /// подсказка для заполнения поля
        /// </summary>
        private string _example = "";
        
        /// <summary>
        /// публичное свойство для заполнения шаблона
        /// </summary>
        public string Template { set => _template = value; }
        
        /// <summary>
        /// публичное свойство для установки и получения введенного значения
        /// </summary>
        /// <exception cref="Exception">Введенный номер не соответствует шаблону</exception>
        public string EnteredValue
        {
            get
            {
                if (Regex.IsMatch(textBox.Text, _template))
                {
                    return textBox.Text;
                }
                else
                {
                    throw new Exception("Введенный номер не соответствует шаблону.");
                }
            }
            set => textBox.Text = value;
            
        }

        public ControlTextBox()
        {
            InitializeComponent();
            toolTip.SetToolTip(textBox, _example);
        }
        
        /// <summary>
        /// публичный метод для заполнения примера
        /// </summary>
        /// <param name="str">Строка-подсказка для заполнения поля</param>
        public void FillExample(string str) => _example = str;
    }
}
