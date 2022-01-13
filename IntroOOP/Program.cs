using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace IntroOOP
{
    /// <summary>Класс главной программы</summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            var car = new Car("ВАЗ-2141", Position: 140, Speed: 0);

            const double dt = 0.1;
            //var t = 0d;
            var t = 0d;
            while (car.Position < 5000)
            {
                car.Move(dt, 1.5);
                t += dt;
            }

            Console.WriteLine("Время разгона составило {0} c, скорость составила {1} км/ч", 
                t, car.Speed * 3.6);
        }
    }

    public class Car
    {
        private string _Name;

        protected double _Position;

        //public double _Speed;
        protected double _Speed;

        public double Speed
        {
            /*private */get { return _Speed; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Значение скорости не может быть меньше нуля!");

                _Speed = value;
                //Console.WriteLine("Новая скорость {0}", value);
            }
        }

        public double Position { get => _Position; set => _Position = value; }

        //public double get_Position()
        //{
        //    return _Position;
        //}

        //public void set_Position(double value)
        //{
        //    _Position = value;
        //}

        public double TestPosition { get; set; }

        public string Name => _Name;

        public Car(string Name, double Position, double Speed = 0)
        {
            //Console.WriteLine($"Значение {nameof(Name)} = {Name}");

            _Name = Name;
            _Position = Position;
            _Speed = Speed;

            var last_position_time = Position / Speed;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining /*| MethodImplOptions.Synchronized*/)]
        private static double Power2(double x) => x * x;

        public double Move(double dt, double Acceleration = 0)
        {
            //_Position = _Speed * dt + Acceleration * (dt * dt) / 2; //Math.Pow(dt, 2);
            _Position += _Speed * dt + Acceleration * Power2(dt) / 2;
            _Speed += Acceleration * dt;

            return _Position;
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