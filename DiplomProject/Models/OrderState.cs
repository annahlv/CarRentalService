using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomProject.Models
{
    [Table("OrderStates")]
    public class OrderState
    {
        [Key]
        public int Id { get; set; }
        public string State { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
