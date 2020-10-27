using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomProject.Models.ViewModels
{
    public class CarViewModel
    {
        public Car Car { get; set; }
        public IFormFile Photo { get; set; }
        public IFormFile TitlePhoto { get; set; }
        public string CurrentPhoto { get; set; }
        public string CurrentTitlePhoto { get; set; }
        public string PhotoPath { get; set; }
        public string TitlePhotoPath { get; set; }
    }
}
