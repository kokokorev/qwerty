using System;
using System.Windows.Forms;

namespace Components
{
    public partial class ControlListBox : UserControl
    {
        /// <summary>
        /// макетная строка
        /// </summary>
        private string _template = "";

        /// <summary>
        /// символ начала для имени свойства
        /// </summary>
        private char _startChar;

        /// <summary>
        /// символ конца для имени свойства
        /// </summary>
        private char _endChar;

        /// <summary>
        /// свойство для установки и получения индекса выбранной строки
        /// </summary>
        public int SelectedIndex
        {
            get => listBox.SelectedIndex;
            set => listBox.SelectedIndex = value;
        }

        public ControlListBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// метод заполнения макетной строки
        /// </summary>
        /// <param name="templateStr">макетная строка</param>
        /// <param name="start">символ начала для имени свойства</param>
        /// <param name="end">символ конца для имени свойства</param>
        public void FillTemplate(string templateStr, char start, char end)
        {
            _template = templateStr;
            _startChar = start;
            _endChar = end;
        }

        /// <summary>
        /// параметризованный метод для заполнения выбранной строки из объекта
        /// </summary>
        /// <param name="obj">объект какого то класса</param>
        /// <param name="fieldName">имя  поля, значение которого требуется подставить в строку</param>
        /// <param name="lineNumber">номер строки</param>
        /// <typeparam name="T">какой то тип</typeparam>
        public void FillLine<T>(T obj, string fieldName, int lineNumber)
        {
            if (string.IsNullOrEmpty(_template)) throw new Exception("Макетная строка пустая");
            
            while (listBox.Items.Count < lineNumber) listBox.Items.Add(_template);

            var objType = obj.GetType();
            var oldValue = _startChar + fieldName + _endChar;
            var newValue = objType.GetProperty(fieldName)?.GetValue(obj, null);
            listBox.Items[lineNumber] = listBox.Items[lineNumber].ToString().Replace(oldValue, newValue?.ToString());
        }

        /// <summary>
        /// параметризованный метод для получения объекта из выбранной строки
        /// </summary>
        /// <typeparam name="T">какой то тип</typeparam>
        /// <returns></returns>
        public T GetObjectFromLine<T>()
        {
            var startIndex = listBox.Items[SelectedIndex].ToString().IndexOf(_startChar);
            var endIndex = listBox.Items[SelectedIndex].ToString().IndexOf(_endChar);
            var valueFromLine = listBox.Items[SelectedIndex].ToString().Substring(startIndex, endIndex - startIndex);
            return (T)Activator.CreateInstance(typeof(T), valueFromLine );
        }
    }
}