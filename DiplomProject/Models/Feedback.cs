using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace DiplomProject.Models
{

    [Table("Feedback")]
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
