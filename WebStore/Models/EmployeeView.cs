using System.ComponentModel.DataAnnotations;

namespace WebStore.Models
{
    public class EmployeeView
    {

        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Имя является обязательным")]
        [Display(Name = "Имя")]
        [StringLength(maximumLength: 200, MinimumLength = 2, ErrorMessage = "В имени должно быть неменее 2х и не более 200 символов")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Фамилия является обязательной")]
        [Display(Name = "Фамилия")]
        public string SurName { get; set; }
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Возраст является обязательным")]
        [Display(Name = "Возраст")]
        public int Age { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите дату рождения!")]
        [Display(Name = "Дата рождения")]
        public string Birth { get; set; }

        [Display(Name = "Департамент")]
        public string Departament { get; set; }

        [Display(Name = "Дата трудоустройства")]
        public string WorkingSince { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Должность является обязательной")]
        [Display(Name = "Должность")]
        public string WorkRole { get; set; }
    }
}
