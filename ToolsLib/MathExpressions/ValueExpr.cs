namespace ToolsLib.MathExpressions;

public class ValueExpr : Expr
{
    private double _Value;

    public double Value { get => _Value; set => _Value = value; }

    public ValueExpr(double Value)
    {
        _Value = Value;
    }

    public override double Compute()
    {
        return _Value;
    }

    public override Expr Simplify() => this;

    public static implicit operator ValueExpr(double x) => new(x);

    public override string ToString() => _Value.ToString();
}