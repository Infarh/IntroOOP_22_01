using System;
using System.ComponentModel.DataAnnotations;

namespace IntroOOP
{
    /// <summary>Класс главной программы</summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            var a = new Vector2D(5, 7);
            
            var a1 = a;
            a1.X = 100;


            var b = new Vector2D(-3, 5);

            var c = a.Add(b);
            var d = a.Sub(b);

            var e = c.Add(3.1415);

            var vectors_array = new Vector2D[20];
            var vectors_list = new List<Vector2D>();
            for (var i = 0; i < vectors_array.Length; i++)
            {
                vectors_array[i] = new Vector2D(i, -20 * i);
                vectors_list.Add(vectors_array[i]);
            }

            vectors_array[5].X = 1000;
            //vectors_list[5].X = 1000;

            var car2d = new Car2D(new Vector2D(5, 7));
            //car2d.Position.X = 5;
            car2d.Position = new Vector2D(5, car2d.Position.Y);


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
                car2d.Move(dt, new Vector2D(1.5, 0.7));

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