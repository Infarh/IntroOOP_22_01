namespace ToolsLib.MathExpressions;

public abstract class Expr
{
    public static Expr operator +(Expr a, Expr b) => new SumExpr(a, b);
    public static Expr operator -(Expr a, Expr b) => new DiffExpr(a, b);
    public static Expr operator *(Expr a, Expr b) => new MulExpr(a, b);
    public static Expr operator /(Expr a, Expr b) => new DivExpr(a, b);

    public static Expr operator +(Expr a, double b) => new SumExpr(a, (ValueExpr)b);
    public static Expr operator -(Expr a, double b) => new DiffExpr(a, (ValueExpr)b);
    public static Expr operator *(Expr a, double b) => new MulExpr(a, (ValueExpr)b);
    public static Expr operator /(Expr a, double b) => new DivExpr(a, (ValueExpr)b);

    public abstract double Compute();

    public abstract Expr Simplify();
}