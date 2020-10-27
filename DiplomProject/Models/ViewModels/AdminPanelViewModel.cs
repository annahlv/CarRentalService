using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomProject.Models.ViewModels
{
    public class AdminPanelViewModel
    {
        public Order Order { get; set; }
        public string State { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
        public IEnumerable<Car> Cars { get; set; }
        public IEnumerable<Notification> Notifications { get; set; }
        public IEnumerable<OrderState> States { get; set; }

    }
}
