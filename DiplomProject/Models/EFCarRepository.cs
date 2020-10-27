using System.Collections.Generic;
using System.Linq;

namespace DiplomProject.Models {

    public class EFCarRepository : ICarRepository {
        private ApplicationDbContext context;

        public EFCarRepository(ApplicationDbContext ctx) {
            context = ctx;
        }

        public IQueryable<Car> Cars => context.Cars;
        public void SaveCar(Car car)
        {
            if (car.Id == 0)
            {
                context.Cars.Add(car);
            }
            else
            {
                Car dbEntry = context.Cars
                    .FirstOrDefault(p => p.Id == car.Id);
                if (dbEntry != null)
                {
                    dbEntry.Brand = car.Brand;
                    dbEntry.Model = car.Model;
                    dbEntry.Description = car.Description;
                    dbEntry.IsAvailable = car.IsAvailable;
                    dbEntry.StartPrice = car.StartPrice;
                    dbEntry.MonthlyPrice = car.MonthlyPrice;
                    dbEntry.BodyType = car.BodyType;
                    dbEntry.Fuel = car.Fuel;
                    dbEntry.MaxPower = car.MaxPower;
                    dbEntry.MaxSpeed = car.MaxSpeed;
                    dbEntry.GearBox = car.GearBox;
                    dbEntry.EngineSize = car.EngineSize;
                    dbEntry.Drive = car.Drive;
                    dbEntry.BootVolume = car.BootVolume;
                    dbEntry.Doors = car.Doors;
                    dbEntry.Seats = car.Seats;
                    dbEntry.Color = car.Color;
                    dbEntry.Acceleration = car.Acceleration;
                    dbEntry.Consumption = car.Consumption;
                    dbEntry.Year = car.Year;
                    dbEntry.FuelVolume = car.FuelVolume;
                    dbEntry.Mileage = car.Mileage;
                    dbEntry.Photo = car.Photo;
                    dbEntry.TitlePhoto = car.TitlePhoto;
                }

            }
            context.SaveChanges();
        }

        public Car DeleteCar(int carId)
        {
            Car dbEntry = context.Cars
                .FirstOrDefault(p => p.Id == carId);
            if (dbEntry != null)
            {
                context.Cars.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
