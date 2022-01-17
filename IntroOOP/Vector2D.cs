﻿namespace IntroOOP
{
    public readonly struct Vector2D : IEquatable<Vector2D>, IComparable<Vector2D>
    {
        //private double _X;  // поля класса
        //private double _Y;  // поля класса

        //public double X { get => _X; set => _X = value; }
        //public double Y { get => _Y; set => _Y = value; }

        public double X { get; init; }
        public double Y { get; init; }

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

        public override string ToString() => $"({X};{Y})";

        public override bool Equals(object? obj)
        {
            if (obj is Vector2D other_vector)
                return X == other_vector.X && Y == other_vector.Y;

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public bool Equals(Vector2D other)
        {
            return X.Equals(other.X) 
                && Y.Equals(other.Y);
        }

        public int CompareTo(Vector2D other)
        {
            var current_length = Length;
            var other_length = other.Length;

            //if (current_length > other_length)
            //    return +1;
            //if (current_length < other_length)
            //    return -1;
            //return 0;

            return current_length.CompareTo(other_length);
        }

        public static bool operator ==(Vector2D left, Vector2D right) { return left.Equals(right); }
        //public static bool operator !=(Vector2D left, Vector2D right) { return !left.Equals(right); }
        public static bool operator !=(Vector2D left, Vector2D right) { return !(left == right); }
    }
}
