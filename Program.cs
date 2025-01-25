// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");



public static class Program
{
    public static void Main(string[] args)
    {
        double x = 1.5;
        double d = -5;

        Console.WriteLine(MachineEpsilon);
        Console.WriteLine("f(" + x + ") = " + f(x) + ", f'(" + x + ") = " + deriv(f, x));


        //Start the simulated annealing algorithm test.
    }








    public static double SimAnn()
    {
    }








    public static double f(double x)
    {
        return x*x*x*x - 2*x*x + x;
    }


    public static double deriv(Func<double, double> f, double x, double h)
    {
        return (f(x + h) - f(x - h)) / (2 * h);
    }

    public static double deriv(Func<double, double> f, double x)
    {
        return deriv(f, x, ME_Sqrt * x);
    }


    public static readonly double ME_Sqrt = Math.Sqrt(MachineEpsilon);

    private static double? m_e = null;

    public static double MachineEpsilon
    {
        get
        {
            if (m_e.HasValue)
            {
                return m_e.Value;
            }


            m_e = 1;

            do
            {
                m_e /= 2;
            } while (1 + m_e/2 != 1);

            //m_e *= 2;
            return m_e.Value;
        }
    }
}
