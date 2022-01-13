using System;
using System.ComponentModel.DataAnnotations;

namespace IntroOOP
{
    /// <summary>Класс главной программы</summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            var car = new Car("ВАЗ-2141", 140, 200);

            //car._Speed = 50;
            //car._Position = 0;

            var speed = car.Speed;
            speed = 300;
            car.Speed += 50;
            car.Speed = 150;
            

            Console.WriteLine("213");
        }
    }

    public class Car
    {
        private string _Name;

        protected double _Position;

        //public double _Speed;
        private double _Speed;

        public double Speed
        {
            get
            {
                return _Speed;
                //return Random.Shared.Next(1, 200);
            }
            set
            {
                _Speed = value;
                //Console.WriteLine("Новая скорость {0}", value);
            }
        }

        public Car(string Name, double Position, double Speed = 0)
        {
            _Name = Name;
            _Position = Position;
            _Speed = Speed;

            var last_position_time = Position / Speed;
        }
    }
}