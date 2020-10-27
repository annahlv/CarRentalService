using System.ComponentModel.DataAnnotations;
using DiplomProject.Models;

namespace DiplomProject.Models.ViewModels {

    public class LoginModel {

        [Required]
        public string Name { get; set; }

        [Required]
        [UIHint("password")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; } = "/";
    }
}
