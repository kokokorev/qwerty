using System;
using System.ComponentModel;
using EmployeeBusinessLogic.Enums;

namespace EmployeeBusinessLogic.ViewModel
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [DisplayName("ФИО")] public string Fio { get; set; }

        [DisplayName("Начало отпуска")] public DateTime? VacationStart { get; set; }

        [DisplayName("Должность")] public Position Position { get; set; }
    }
}