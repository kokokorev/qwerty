using System;
using EmployeeBusinessLogic.Enums;

namespace EmployeeBusinessLogic.BindingModel
{
    public class EmployeeBindingModel
    {
        public int? Id { get; set; }

        public string Fio { get; set; }

        public DateTime? VacationStart { get; set; }
        
        public Position Position { get; set; }
    }
}