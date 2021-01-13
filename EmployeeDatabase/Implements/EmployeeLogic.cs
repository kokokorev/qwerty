using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeBusinessLogic.BindingModel;
using EmployeeBusinessLogic.Interface;
using EmployeeBusinessLogic.ViewModel;
using EmployeeDatabase.Models;

namespace EmployeeDatabase.Implements
{
    public class EmployeeLogic : IEmployee
    {
        public void CreateOrUpdate(EmployeeBindingModel model)
        {
            Employee employee;
            using (var context = new Database())
            {
                if (model.Id.HasValue)
                {
                    employee = context.Employees.FirstOrDefault(rec => rec.Id == model.Id);
                    if (employee == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    employee = new Employee
                    {
                        Fio = model.Fio,
                        VacationStart = model.VacationStart,
                        Position = model.Position
                    };
                    context.Employees.Add(employee);
                    context.SaveChanges();
                    return;
                }

                employee.Fio = model.Fio;
                employee.VacationStart = model.VacationStart;
                employee.Position = model.Position;

                context.SaveChanges();
            }
        }

        public List<EmployeeViewModel> Read(EmployeeBindingModel filter)
        {
            using (var context = new Database())
            {
                return context.Employees
                    .Where(rec => filter == null || rec.Id == filter.Id)
                    .ToList()
                    .Select(rec => new EmployeeViewModel
                    {
                        Id = rec.Id,
                        Fio = rec.Fio,
                        Position = rec.Position,
                        VacationStart = rec.VacationStart
                    })
                    .ToList();
            }
        }

        public void Delete(EmployeeBindingModel model)
        {
            using (var context = new Database())
            {
                var employee = context.Employees.FirstOrDefault(rec => rec.Id == model.Id);
                if (employee != null)
                {
                    context.Employees.Remove(employee);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
    }
}