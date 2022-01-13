namespace IntroOOP
{
    public struct Vector2D
    {
        //private double _X;  // поля класса
        //private double _Y;  // поля класса

        //public double X { get => _X; set => _X = value; }
        //public double Y { get => _Y; set => _Y = value; }

        public double X { get; set; }
        public double Y { get; set; }

        public double Length => Math.Sqrt(X * X + Y * Y);

        public double Angle => Math.Atan2(Y, X);

        //public Vector2D()  // не может быть у структуры
        //{                  // не может быть у структуры
                             // не может быть у структуры
        //}                  // не может быть у структуры

        public Vector2D(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public Vector2D Add(Vector2D Other)
        {
            var result = new Vector2D(X + Other.X, Y + Other.Y);
            return result;
        }

        public Vector2D Add(double A)
        {
            var result = new Vector2D(X + A, Y + A);
            return result;
        }

        public Vector2D Sub(Vector2D Other)
        {
            var result = new Vector2D(X - Other.X, Y - Other.Y);
            return result;
        }

        public Vector2D Sub(double A)
        {
            var result = new Vector2D(X - A, Y - A);
            return result;
        }

        public Vector2D Mul(double A)
        {
            var result = new Vector2D(X * A, Y * A);
            return result;
        }
    }
}
