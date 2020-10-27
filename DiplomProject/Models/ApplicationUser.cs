using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина должна быть от 2 до 50 символов")]
        public string Name { get; set; }
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина должна быть от 2 до 50 символов")]
        public string Surname { get; set; }
        [Range(21, 70, ErrorMessage = "Недопустимый возраст")]
        public int Age { get; set; }
        [Phone(ErrorMessage = "Неправильно введен телефон")]
        public string Phone { get; set; }
        public string Address { get; set; }
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Длина должна быть от 2 до 30 символов")]
        public string City { get; set; }
        public string Photo { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
