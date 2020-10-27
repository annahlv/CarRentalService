using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiplomProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DiplomProject.Models.ViewModels
{
    public class CarListViewModel
    {
        public IEnumerable<Car> Cars { get; set; }
        public IEnumerable<string> Categories { get; set; }
        public IEnumerable<string> Bodytypes { get; set; }
        public IEnumerable<string> Brands { get; set; }
        public IEnumerable<string> GearBoxes { get; set; }
        public IEnumerable<string> Fuel { get; set; }
        public IEnumerable<int> Years { get; set; }
        public decimal Mileage { get; set; }
        public decimal PriceFrom { get; set; }
        public decimal PriceTo { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
    }
}
