using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsControlLibrary.Models;
using EmployeeBusinessLogic.Interface;
using Unity;
using EmployeeDatabase;
using NonVisualComponents;
using System.Linq;

namespace EmployeeView
{
    public partial class MainForm : Form
    {
        [Dependency] public new IUnityContainer Container { get; set; }

        private readonly IEmployee employeeService;

        public MainForm(IEmployee employeeService)
        {
            InitializeComponent();
            this.employeeService = employeeService;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void backupSaveButton_Click(object sender, EventArgs e)
        {
            var employees = employeeService.Read(null);
            componentBackupXml.CreateXmlBackup(employees.ToArray(), "D:/dev");
        }

        private void createEmployeeButton_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<CreateEmployeeForm>();
            form.ShowDialog();
            LoadData();
        }

        private void LoadData()
        {
            var employees = employeeService.Read(null);
            var treeInfo = new DataTreeNodeConfig();
            var nodeNames = new Queue<string>();
            nodeNames.Enqueue("Position");
            nodeNames.Enqueue("Fio");
            treeInfo.NodeNames = nodeNames;

            controlDataTreeTable.LoadTreeInfo(treeInfo);
            controlDataTreeTable.AddTable(employees);
        }

        /// <summary>
        /// создание таблицы со всеми сотрудниками и их должностями
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonWordPosition_Click(object sender, EventArgs e)
        {
            var employees = employeeService.Read(null);
            try
            {
                ComponentWord comp = new ComponentWord();
                using (var context = new Database())
                {
                    using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
                    {
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            comp.Save(dialog.FileName, employees, new List<string> { "Fio", "Position" });
                            MessageBox.Show("Сохранение прошло успешно");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось сохранить отчет " + ex.Message);
            }
        }

        /// <summary>
        /// создание гистограммы с количеством отпусков в каждом месяце
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonWordVacation_Click(object sender, EventArgs e)
        {
            try
            {
                ComponentWordHistogram comp = new ComponentWordHistogram();
                using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
                {
                    using (var context = new Database())
                    {
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            List<DiagramModel> list = new List<DiagramModel>();
                            var employees = context.Employees
                                .GroupBy(p => p.VacationStart.Value.Month)
                                .Select(p => new { p.Key, Count = p.Count() })
                                .ToDictionary(p => p.Key, p => p.Count);

                            foreach (var employee in employees)
                            {
                                list.Add(new DiagramModel
                                {
                                    Count = employee.Key,
                                    Month = employee.Value
                                });
                            }

                            comp.CreateDiagram(list, "Employees", dialog.FileName);
                            MessageBox.Show("Сохранение прошло успешно");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось сохранить диаграмму " + ex.Message);
            }
        }
    }
}