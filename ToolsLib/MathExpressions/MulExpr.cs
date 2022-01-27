namespace ToolsLib.MathExpressions;

public class MulExpr : Expr
{
    private readonly Expr _A;
    private readonly Expr _B;

    public MulExpr(Expr a, Expr b)
    {
        _A = a;
        _B = b;
    }

    public override Expr Simplify()
    {
        if (_A is ValueExpr a)
        {
            if (a.Value == 0)
                return new ValueExpr(0);

            if(a.Value == 1)
                return _B.Simplify();
        }

        if (_B is ValueExpr b && b.Value == 1)
        {
            return _A.Simplify();
        }

        return this;
    }

    public override double Compute()
    {
        var a = _A.Compute();
        var b = _B.Compute();

        return a * b;
    }
    public override string ToString() => $"({_A} * {_B})";
}