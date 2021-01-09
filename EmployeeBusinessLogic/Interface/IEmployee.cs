using System.Collections.Generic;
using EmployeeBusinessLogic.BindingModel;
using EmployeeBusinessLogic.ViewModel;

namespace EmployeeBusinessLogic.Interface
{
    public interface IEmployee
    {
        void CreateOrUpdate(EmployeeBindingModel model);

        List<EmployeeViewModel> Read(EmployeeBindingModel filter);

        void Delete(EmployeeBindingModel model);
    }
}