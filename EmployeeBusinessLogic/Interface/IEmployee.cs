using System.Collections.Generic;
using EmployeeBusinessLogic.BindingModel;
using EmployeeDatabase.Models;

namespace EmployeeBusinessLogic.Interface
{
    public interface IEmployee
    {
        void CreateOrUpdate(EmployeeBindingModel model);

        List<Employee> Read(EmployeeBindingModel filter);

        void Delete(EmployeeBindingModel model);
    }
}