using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DiplomProject.Models
{

    [Table("Cars")]
    public partial class Car
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите наименование бренда")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Введите наименование модели")]
        public string Model { get; set; }

        [StringLength(40, ErrorMessage = "Не более 40 знаков")]
        [Required(ErrorMessage = "Введите краткое описание модели")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Введите год выпуска модели")]
        public int Year { get; set; }
        public bool IsAvailable { get; set; }

        [Required(ErrorMessage = "Введите положительное значение для цены")]
        public decimal StartPrice { get; set; }

        [Required(ErrorMessage = "Введите положительное значение для цены")]
        public decimal MonthlyPrice { get; set; }
        [Required(ErrorMessage = "Укажите тип кузова")]
        public string BodyType { get; set; }
        [Required(ErrorMessage = "Укажите тип топлива")]
        public string Fuel { get; set; }
        [Required(ErrorMessage = "Укажите объем топливного бака")]
        [Range(1, 100, ErrorMessage ="Введите корректное число")]
        public double? FuelVolume { get; set; }
        [Required(ErrorMessage = "Укажите максимальную мощность")]
        [Range(1, 10000, ErrorMessage = "Введите корректное число")]
        public double? MaxPower { get; set; }
        [Required(ErrorMessage = "Укажите максимальную скорость")]
        [Range(1, 500, ErrorMessage = "Введите корректное число")]
        public double? MaxSpeed { get; set; }
        [Required(ErrorMessage = "Укажите ускорение")]
        [Range(1, 100, ErrorMessage = "Введите корректное число")]
        public double? Acceleration { get; set; }
        [Required(ErrorMessage = "Укажите номерной знак")]
        public string LicensePlate { get; set; }
        [Required(ErrorMessage = "Укажите коробку передач")]
        public string GearBox { get; set; }
        [Required(ErrorMessage = "Укажите средний расход топлива")]
        [Range(1, 100, ErrorMessage = "Введите корректное число")]
        public double? Consumption { get; set; }

        [Required(ErrorMessage = "Укажите объем двигателя")]
        [Range(1, 20, ErrorMessage = "Введите корректное число")]
        public double? EngineSize { get; set; }

        [Required(ErrorMessage = "Укажите тип привода")]
        public string Drive { get; set; }
        [Required(ErrorMessage = "Укажите объем багажника")]
        [Range(1, 10000, ErrorMessage = "Введите корректное число")]
        public int BootVolume { get; set; }
        [Required(ErrorMessage = "Укажите количество дверей")]
        [Range(1, 7, ErrorMessage = "Введите корректное число")]
        public int Doors { get; set; }
        [Required(ErrorMessage = "Укажите количество мест")]
        [Range(1, 20, ErrorMessage = "Введите корректное число")]
        public int Seats { get; set; }
        [Required(ErrorMessage = "Укажите пробег автомобиля")]
        public int Mileage { get; set; }
        [Required(ErrorMessage = "Укажите цвет")]
        public string Color { get; set; }
        [Required(ErrorMessage = "Загрузите фотографию каталога")]
        public string Photo { get; set; }
        [Required(ErrorMessage = "Загрузите фотографию обложки")]
        public string TitlePhoto { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
