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
        int max_iterations = int.Parse(args[0]);
        double initial_temperature = double.Parse(args[1]);
        double best_x = SimAnn(x, max_iterations, initial_temperature, -2, 2, new Random(1));

        Console.WriteLine("f(" + best_x + ") = " + f(best_x) + ", f'(" + best_x + ") = " + deriv(f, best_x));
    }








    public static double SimAnn(double initial_x, int max_iterations, double starting_temp, double min, double max, Random random)
    {
        double current_guess = initial_x;
        for (int i = 0; i < max_iterations; ++i)
        {
            double temp = Temperature(starting_temp, 1.0 - (i + 1.0) / max_iterations);
            double neighbor = NextNeighbor(f, current_guess, min, max, random);

            double e_current = Enegery(f, current_guess, -5);
            double e_neighbor = Enegery(f, neighbor, -5);

            double allowance = random.NextDouble();

            if (AcceptanceProbability(e_current, e_neighbor, temp) >= allowance)
            {
                current_guess = neighbor;
            }

            //Console.WriteLine(temp);
        }

        return current_guess;
    }


    public static double Temperature(double max, double t)
    {
        return max * t;
    }

    public static double NextNeighbor(Func<double, double> f, double current, double min, double max, Random random)
    {
        //double rand = random.NextDouble();
        //return f((1 - rand) * min + rand * max);

        //double rand = random.NextDouble();
        //return (1 - rand) * min + rand * max;








        double rand = random.NextDouble() - .5;

        double possible_next = rand + current;
        if (possible_next < min)
        {
            possible_next = min;
        }
        else if (possible_next > max)
        {
            possible_next = max;
        }

        return possible_next;
    }

    public static double Enegery(Func<double, double> f, double current, double desired_output)
    {
        return Math.Abs(desired_output - f(current));
    }

    public static double AcceptanceProbability(double energy_current, double energy_new, double temp)
    {
        if (energy_new < energy_current)
        {
            return 1;
        }

        return Math.Exp(-(energy_new - energy_current) / temp);
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
