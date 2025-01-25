// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");



public static class Program
{
    public static void Main(string[] args)
    {
        double x = 

        Console.WriteLine("Hello, World!");
    }


    public static double f(double x)
    {
        return x*x*x*x - 2*x*x + x;
    }


    public static double deriv(Func<double, double> f, double x, double h)
    {
        return (f(x + h) - f(x - h)) / (2 * h);
    }
}
