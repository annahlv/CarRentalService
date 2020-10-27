using System;
using System.Collections.Generic;
using System.Text;
using DiplomProject.Models;

namespace DiplomProject.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Car> Cars { get; set; }
        public IEnumerable<Feedback> Feedbacks { get; set; }
        public Feedback Feedback { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }

    }
}
