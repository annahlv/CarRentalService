using DiplomProject.Models;
using System.Collections.Generic;

namespace DiplomProject.Models.ViewModels {

    public class FavoriteIndexViewModel {
        public Favorite Favorite { get; set; }
        public IEnumerable<Car> Cars { get; set; }
        public string ReturnUrl { get; set; }
    }

}
