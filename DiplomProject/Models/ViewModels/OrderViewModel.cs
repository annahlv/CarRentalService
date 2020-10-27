using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomProject.Models.ViewModels
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        public string State { get; set; } 
        public int StateId { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<OrderState> States { get; set; }
        public IEnumerable<Car> Cars { get; set; }
    }
}
