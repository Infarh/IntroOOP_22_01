namespace ToolsLib.MathExpressions;

public class DiffExpr : Expr
{
    private readonly Expr _A;
    private readonly Expr _B;

    public DiffExpr(Expr a, Expr b)
    {
        _A = a;
        _B = b;
    }

    public override double Compute()
    {
        var a = _A.Compute();
        var b = _B.Compute();

        return a - b;
    }

    public override Expr Simplify()
    {
        if (_B is ValueExpr b && b.Value == 0)
        {
            return _A.Simplify();
        }

        return this;
    }

    public override string ToString() => $"({_A} - {_B})";
}