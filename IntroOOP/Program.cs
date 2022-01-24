using ToolsLib.MathExpressions;

namespace IntroOOP;

public static class Program
{
    private static void OperatorsTests()
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

    public static void Main(string[] args)
    {
        var a = new ValueExpr(0);
        var b = new ValueExpr(7);
        var c = new ValueExpr(1);

        var d = a + b * c;

        var e = (a + 7) / Math.PI;

        var result = d.Compute();

        var simplified = d.Simplify();
    }
}

