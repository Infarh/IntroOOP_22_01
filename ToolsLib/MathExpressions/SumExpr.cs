namespace ToolsLib.MathExpressions;

public class SumExpr : Expr
{
    private readonly Expr _A;
    private readonly Expr _B;

    public SumExpr(Expr a, Expr b)
    {
        _A = a;
        _B = b;
    }

    public override double Compute()
    {
        var a = _A.Compute();
        var b = _B.Compute();

        return a + b;
    }

    public override Expr Simplify()
    {
        if (_A is ValueExpr a && a.Value == 0)
        {
            return _B.Simplify();
        }

        if (_B is ValueExpr b && b.Value == 0)
        {
            return _A.Simplify();
        }

        return this;
    }

    // A + B - инфиксная запись
    // (A,B)+ - постфиксная запись - "обратная польская запись"
    // +(A,B) - префиксная запись

    public override string ToString() => $"({_A} + {_B})";
}