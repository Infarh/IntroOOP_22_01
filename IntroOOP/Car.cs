using System.Runtime.CompilerServices;

namespace IntroOOP
{
    public class Car
    {
        //public event EventHandler Crash;
        public event Action Crash;

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

        public double TresholdSpeed { get; set; } = 180 / 3.6;

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

            if (TresholdSpeed > 0 && _Speed >= TresholdSpeed)
            {
                Crash?.Invoke();
            }

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