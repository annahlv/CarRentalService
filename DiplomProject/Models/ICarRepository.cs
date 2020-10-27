using System.Linq;

namespace DiplomProject.Models {

    public interface ICarRepository 
    {
        IQueryable<Car> Cars { get; }
        void SaveCar(Car car);
        Car DeleteCar(int carId);
    }
}
