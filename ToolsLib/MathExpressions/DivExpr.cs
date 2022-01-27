using System.Transactions;

namespace ToolsLib.MathExpressions;

public class DivExpr : Expr
{
    private readonly Expr _A;
    private readonly Expr _B;

    public DivExpr(Expr a, Expr b)
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
        }

        if (_B is ValueExpr b)
        {
            if (b.Value == 1)
                return _A.Simplify();

            if (b.Value == 0)
                return new ValueExpr(double.PositiveInfinity);
        }

        return this;
    }

    public override double Compute()
    {
        var a = _A.Compute();
        var b = _B.Compute();

        return a / b;
    }
    public override string ToString() => $"({_A} / {_B})";
}