using System;

class SolveDPend
{
    const double PI = 3.14159265;
    const int N = 4; // number of equations to be solved 
    const double G = 9.8; // acc'n due to gravity, in m/s^2 
    const double L1 = 1.0; // length of pendulum 1 in m 
    const double L2 = 1.0; // length of pendulum 2 in m 
    const double M1 = 1.0; // mass of pendulum 1 in kg 
    const double M2 = 1.0; // mass of pendulum 2 in kg 

    static void Main(string[] args)
    {
        double TMIN = double.Parse(args[0]);
        double TMAX = double.Parse(args[1]);
        double TH10 = double.Parse(args[2]);
        double W10 = double.Parse(args[3]);
        double TH20 = double.Parse(args[4]);
        double W20 = double.Parse(args[5]);
        int NSTEP = int.Parse(args[6]);
        double h = (TMAX - TMIN) / (NSTEP - 1.0);

        double[] t = new double[NSTEP];
        double[] th1 = new double[NSTEP];
        double[] w1 = new double[NSTEP];
        double[] th2 = new double[NSTEP];
        double[] w2 = new double[NSTEP];

        /* Define array of t values */
        for (int i = 0; i < NSTEP; i++)
            t[i] = TMIN + h * i;

        /* initial values - convert all angles to radians */
        th1[0] = TH10 * PI / 180.0;
        w1[0] = W10 * PI / 180.0;
        th2[0] = TH20 * PI / 180.0;
        w2[0] = W20 * PI / 180.0;

        /* perform the integration */
        double[] yin = new double[N];
        double[] yout = new double[N];
        Console.WriteLine($"{t[0]:F6} {th1[0]:F6} {w1[0]:F6} {th2[0]:F6} {w2[0]:F6}");
        for (int i = 0; i < NSTEP - 1; i++)
        {
            yin[0] = th1[i];
            yin[1] = w1[i];
            yin[2] = th2[i];
            yin[3] = w2[i];
            runge_kutta(t[i], yin, yout, h);
            th1[i + 1] = yout[0];
            w1[i + 1] = yout[1];
            th2[i + 1] = yout[2];
            w2[i + 1] = yout[3];
            Console.WriteLine($"{t[i+1]:F6} {th1[i+1]:F6} {w1[i+1]:F6} {th2[i+1]:F6} {w2[i+1]:F6}");
        }
    }

    static void derivs(double xin, double[] yin, double[] dydx)
    {
        double del = yin[2] - yin[0];
        double den1 = (M1 + M2) * L1 - M2 * L1 * Math.Cos(del) * Math.Cos(del);
        double den2 = (L2 / L1) * den1;

        dydx[0] = yin[1];
        dydx[1] = (M2 * L1 * yin[1] * yin[1] * Math.Sin(del) * Math.Cos(del)
            + M2 * G * Math.Sin(yin[2]) * Math.Cos(del)
            + M2 * L2 * yin[3] * yin[3] * Math.Sin(del)
            - (M1 + M2) * G * Math.Sin(yin[0])) / den1;

        dydx[2] = yin[3];
        dydx[3] = (-M2 * L2 * yin[3] * yin[3] * Math.Sin(del) * Math.Cos(del)
            + (M1 + M2) * G * Math.Sin(yin[0]) * Math.Cos(del)
            - (M1 + M2) * L1 * yin[1] * yin[1] * Math.Sin(del)
            - (M1 + M2) * G * Math.Sin(yin[2])) / den2;
    }

    static void runge_kutta(double xin, double[] yin, double[] yout, double h)
    {
        double[] dydx = new double[N];
        double[] dydxt = new double[N];
        double[] yt = new double[N];
        double[] k1 = new double[N];
        double[] k2 = new double[N];
        double[] k3 = new double[N];
        double[] k4 = new double[N];

        double hh = 0.5 * h;
        double xh = xin + hh;

        derivs(xin, yin, dydx); /* first step */
        for (int i = 0; i < N; i++)
        {
            k1[i] = h * dydx[i];
            yt[i] = yin[i] + 0.5 * k1[i];
        }

        derivs(xh, yt, dydxt); /* second step */
        for (int i = 0; i < N; i++)
        {
            k2[i] = h * dydxt[i];
            yt[i] = yin[i] + 0.5 * k2[i];
        }

        derivs(xh, yt, dydxt); /* third step */
        for (int i = 0; i < N; i++)
        {
            k3[i] = h * dydxt[i];
            yt[i] = yin[i] + k3[i];
        }

        derivs(xin + h, yt, dydxt); /* fourth step */
        for (int i = 0; i < N; i++)
        {
            k4[i] = h * dydxt[i];
            yout[i] = yin[i] + k1[i] / 6 + k2[i] / 3 + k3[i] / 3 + k4[i] / 6;
        }
    }
}