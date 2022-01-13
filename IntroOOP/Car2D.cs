namespace IntroOOP
{
    public class Car2D
    {
        private Vector2D _Position;
        private Vector2D _Speed;

        public Vector2D Position { get => _Position; set => _Position = value; }
        public Vector2D Speed { get => _Speed; set => _Speed = value; }

        public Car2D(Vector2D Position, Vector2D Speed = default)
        {
            _Position = Position;
            _Speed = Speed;
        }

        private static double Power2(double x) => x * x;

        public Vector2D Move(double dt, Vector2D Acceleration = default)
        {
            var dx = _Speed.Mul(dt).Add(Acceleration.Mul(Power2(dt) / 2));
            _Position = _Position.Add(dx);

            var dV = Acceleration.Mul(dt);
            _Speed = _Speed.Add(dV);

            return _Position;
        }
    }
}
