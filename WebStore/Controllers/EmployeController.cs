using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;
using WebStore.DomainNew.Models;

namespace WebStore.Controllers
{
    [Authorize]
    [Route("users")]
    public class EmployeController : Controller
    {

        private readonly IEmployeesData _employeesData;
        public EmployeController(IEmployeesData employeesData)
        {
            _employeesData = employeesData;
        }

        public IActionResult Index()
        {
            return View(_employeesData.GetAll());
        }

        [Route("{id}")]
        public IActionResult Details(int id)
        {
            var employee = _employeesData.GetById(id);
            if (ReferenceEquals(employee, null))
                return NotFound();
            return View(employee);
        }

        [Route("delete/{id}")]
        [Authorize(Roles = Constant.Roles.Admin)]
        public IActionResult DeLete(int id)
        {
            _employeesData.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [Route("edit/{id?}")]
        [Authorize(Roles = Constant.Roles.Admin)]
        public IActionResult Edit(int? id)
        {
            EmployeeView model;
            if (id.HasValue)
            {
                model = _employeesData.GetById(id.Value);
                if (ReferenceEquals(model, null))
                    return NotFound();
            }
            else
            {
                model = new EmployeeView();
            }
            return View(model);
        }

        [HttpPost]
        [Route("edit/{id?}")]
        [Authorize(Roles = Constant.Roles.Admin)]
        public IActionResult Edit(EmployeeView model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id > 0)
                {
                    var employe = _employeesData.GetById(model.Id);
                    if (ReferenceEquals(employe, null))
                        return NotFound();

                    employe.FirstName = model.FirstName;
                    employe.SurName = model.SurName;
                    employe.Age = model.Age;
                    employe.Patronymic = model.Patronymic;
                    employe.Birth = model.Birth;
                    employe.Departament = model.Departament;
                    employe.WorkingSince = model.WorkingSince;
                    employe.WorkRole = model.WorkRole;
                }
                else
                {
                    _employeesData.AddNew(model);
                }
                _employeesData.Edit();
                return RedirectToAction(nameof(Index));
            }
            else return View(model);
        }

    }

}
