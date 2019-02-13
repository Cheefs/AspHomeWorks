using System.Collections.Generic;
using WebStore.Models;

namespace WebStore.Infrastructure.Interfaces
{
    /// <summary>
    /// Интерфейс для работы с сотрудниками
    /// </summary>
    public interface IEmployeesData
    {
        IEnumerable<EmployeeView> GetAll();
        EmployeeView GetById(int id);
        void Edit();
        void AddNew(EmployeeView model);
        void Delete(int id);

    }
}
