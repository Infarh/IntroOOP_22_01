namespace IntroOOP;

public static class Program
{
    public static void Main(string[] args)
    {
        var a = new Vector2D(5, 7);
        var b = new Vector2D(-6, 10);

        var c = a + b;
        var d = a - b;

        var e = c * 5.3;
        var f = c / 5.3;

        var g = 5.3 * c;
        var h = 5.3 / c;

        double x = a;
        int int_var = (int)x;

        var i = (Vector2D)x;

        var a_str = a.ToString();
        a = Vector2D.Parse(a_str);
    }
}

