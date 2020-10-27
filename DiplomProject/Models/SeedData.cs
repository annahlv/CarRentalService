using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DiplomProject.Models;
using System;

namespace DiplomProject.Models
{

    public static class SeedData
    {

        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            //if (!context.Cars.Any())
            //{
            //    context.Cars.AddRange(
            //        new Car
            //        {
            //            Brand = "Fiat",
            //            Model = "500",
            //            Description = "Описание",
            //            StartPrice = 250,
            //            MonthlyPrice = 100,
            //            BodyType = "Хэтчбек",
            //            Fuel = "",
            //            MaxPower = 50,
            //            MaxSpeed = 150,
            //            Acceleration = 50,
            //            LicensePlate = "MP1111",
            //            GearBox = "0",
            //            Consumption = 99,
            //            Mileage = 40000,
            //            Photo = "fiat500.png",
            //            TitlePhoto = "vwpolo.png"

            //        },
            //        new Car
            //        {
            //            Brand = "BMW",
            //            Model = "X5",
            //            Description = "Описание",
            //            StartPrice = 350,
            //            MonthlyPrice = 150,
            //            BodyType = "Седан",
            //            Fuel = "",
            //            MaxPower = 50,
            //            MaxSpeed = 150,
            //            Acceleration = 50,
            //            LicensePlate = "MP1111",
            //            GearBox = "0",
            //            Consumption = 99,
            //            Mileage = 40000,
            //            Photo = "bmwx5.png",
            //            TitlePhoto = "vwpolo.png"

            //        },
            //        new Car
            //        {
            //            Brand = "Toyota",
            //            Model = "Camry",
            //            Description = "Описание",
            //            StartPrice = 350,
            //            MonthlyPrice = 150,
            //            BodyType = "Седан",
            //            Fuel = "",
            //            MaxPower = 50,
            //            MaxSpeed = 150,
            //            Acceleration = 50,
            //            LicensePlate = "MP1111",
            //            GearBox = "0",
            //            Consumption = 99,
            //            Mileage = 40000,
            //            Photo = "toyotacamry.png",
            //            TitlePhoto = "vwpolo.png"

            //        },
            //        new Car
            //        {
            //            Brand = "Audi",
            //            Model = "A5",
            //            Description = "Описание",
            //            StartPrice = 400,
            //            MonthlyPrice = 200,
            //            BodyType = "Купе",
            //            Fuel = "",
            //            MaxPower = 50,
            //            MaxSpeed = 150,
            //            Acceleration = 50,
            //            LicensePlate = "MP1111",
            //            GearBox = "0",
            //            Consumption = 99,
            //            Mileage = 40000,
            //            Photo = "audia5.png",
            //            TitlePhoto = "vwpolo.png"

            //        },
            //        new Car
            //        {
            //            Brand = "Smart",
            //            Model = "Forfour",
            //            Description = "Описание",
            //            StartPrice = 300,
            //            MonthlyPrice = 100,
            //            BodyType = "Хэтчбек",
            //            Fuel = "",
            //            MaxPower = 50,
            //            MaxSpeed = 150,
            //            Acceleration = 50,
            //            LicensePlate = "MP1111",
            //            GearBox = "0",
            //            Consumption = 99,
            //            Mileage = 40000,
            //            Photo = "smartfor4.png",
            //            TitlePhoto = "vwpolo.png"

            //        },
            //        new Car
            //        {
            //            Brand = "Volkswagen",
            //            Model = "Polo",
            //            Description = "Описание",
            //            StartPrice = 550,
            //            MonthlyPrice = 110,
            //            BodyType = "Хэтчбек",
            //            Fuel = "",
            //            MaxPower = 50,
            //            MaxSpeed = 150,
            //            Acceleration = 50,
            //            LicensePlate = "MP1111",
            //            GearBox = "0",
            //            Consumption = 99,
            //            Mileage = 40000,
            //            Photo = "vwpolo.png",
            //            TitlePhoto = "vwpolo.png"
            //        }
            //        );

            //    context.SaveChanges();
            //}
            if (!context.States.Any())
            {
                context.States.AddRange(
                new OrderState
                {
                    State = "На рассмотрении"
                },
                new OrderState
                {
                    State = "Подтвержден"
                },
                new OrderState
                {
                    State = "Отклонен"
                },
                new OrderState
                {
                    State = "Активен"
                },
                new OrderState
                {
                    State = "Завершен"
                }
                );
                context.SaveChanges();
            }
            
        }
    }
}
