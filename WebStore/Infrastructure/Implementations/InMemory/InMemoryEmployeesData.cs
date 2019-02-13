using System.Collections.Generic;
using System.Linq;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;

namespace WebStore.Infrastructure.Implementations
{
    public class InMemoryEmployeesData : IEmployeesData
    {
        private readonly List<EmployeeView> _employees;

        public EmployeeView NewEmploye(int id, string firstName, string surName, string partonymic, int age, string birth, string departament,
           string workRole, string workingSince)
        {
            var empl = new EmployeeView
            {
                Id = id,
                FirstName = firstName,
                SurName = surName,
                Patronymic = partonymic,
                Age = age,
                Birth = birth,
                Departament = departament,
                WorkRole = workRole,
                WorkingSince = workingSince
            };

            return empl;
        }

        public InMemoryEmployeesData()
        {
            _employees = new List<EmployeeView>
            {
                NewEmploye(1, "Иван", "Иванов", "Иванович", 22, "18.02.1996", "GameDev", "Unity Developer", "10.10.2016"),
                NewEmploye(2, "Владиславcкий", "Петр", "Иванович", 45, "18.02.1979", "Web", "Senior Developer", "10.10.2005"),
                NewEmploye(3, "Николай", "Николаев", "николаевич", 32, "18.02.1989", "Web", "FrontEnd developer", "10.10.2014"),
                NewEmploye(4, "Петр", "Петров", "Петрович", 35, "18.02.1986", "GameDev", "Senior Unity Developer", "10.10.2010")
            };

        }


        public IEnumerable<EmployeeView> GetAll()
        {
            return _employees;
        }
        public EmployeeView GetById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id.Equals(id));
        }
        public void Edit()
        {

        }
        public void AddNew(EmployeeView model)
        {
            model.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(model);
        }
        public void Delete(int id)
        {
            var employee = GetById(id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
        }
    }
}
