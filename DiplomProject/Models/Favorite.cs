using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomProject.Models
{
    public class Favorite : Car
    {
        private List<FavoriteItem> collection = new List<FavoriteItem>();

        public virtual void AddItem(Car Car)
        {
            FavoriteItem items = collection
                .Where(p => p.Car.Id == Car.Id)
                .FirstOrDefault();
                collection.Add(new FavoriteItem
                {
                    Car = Car,
                });

        }

        public virtual void RemoveItem(Car Car) =>
            collection.RemoveAll(l => l.Car.Id == Car.Id);


        public virtual void Clear() => collection.Clear();

        public virtual IEnumerable<FavoriteItem> Items => collection;
    }

    public class FavoriteItem
    {
        public int FavoriteID { get; set; }
        public Car Car { get; set; }

    }
}
