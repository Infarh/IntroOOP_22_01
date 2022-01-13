using System;
using System.ComponentModel.DataAnnotations;

namespace IntroOOP
{
    /// <summary>Класс главной программы</summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            var car = new Car("ВАЗ-2141", Position: 140, Speed: 0);
            //car.TresholdSpeed = double.NaN;

            car.Crash += () =>
            {
                //throw new Exception($"Автокатастрофа на скорости {car.Speed * 3.6} км/ч");
                Console.WriteLine("Опасная скорость! {0} км/ч", car.Speed * 3.6);
            };

            car.Crash += () =>
            {
                throw new Exception($"Автокатастрофа на скорости {car.Speed * 3.6} км/ч");
            };

            const double dt = 0.1;
            //var t = 0d;
            var t = 0d;
            while (car.Position < 5000)
            {
                car.Move(dt, 1.5);
                t += dt;

                //if (car.Speed > 180 / 3.6)
                //    throw new Exception($"Автокатастрофа на скорости {car.Speed * 3.6} км/ч");
            }

            Console.WriteLine("Время разгона составило {0} c, скорость составила {1} км/ч", 
                t, car.Speed * 3.6);
        }
    }

    //public class FastCar : Car
    //{
    //    public FastCar() : base("Fast", 0, 1000)
    //    {
    //        _Position = 50;
    //        _Speed = 10;
    //    }
    //}
}