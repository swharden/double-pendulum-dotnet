using System;

namespace DPend
{
    public class Simulator
    {
        const double G = 9.8; // acc'n due to gravity, in m/s^2 
        const double L1 = 1.0; // length of pendulum 1 in m 
        const double L2 = 1.0; // length of pendulum 2 in m 
        const double M1 = 1.0; // mass of pendulum 1 in kg 
        const double M2 = 1.0; // mass of pendulum 2 in kg 

        public double Theta1 { get; private set; }
        public double Omega1 { get; private set; }
        public double Theta2 { get; private set; }
        public double Omega2 { get; private set; }
        public int Iterations { get; private set; }
        public double Time { get; private set; }

        public Simulator(double theta1, double omega1, double theta2, double omega2)
        {
            // degrees to radians
            Theta1 = theta1 * Math.PI / 180.0;
            Omega1 = omega1 * Math.PI / 180.0;
            Theta2 = theta2 * Math.PI / 180.0;
            Omega2 = omega2 * Math.PI / 180.0;
        }

        public void Step(double step = .01)
        {
            double[] yin = { Theta1, Omega1, Theta2, Omega2 };
            double[] yout = new double[4];
            RungeKutta(yin, yout, step);
            Theta1 = yout[0];
            Omega1 = yout[1];
            Theta2 = yout[2];
            Omega2 = yout[3];
            Iterations += 1;
            Time += step;
        }

        public string GetStatus() => $"{Iterations}: {Theta1:F6} {Omega1:F6} {Theta2:F6} {Omega2:F6}";

        static void Derivatives(double[] yin, double[] dydx)
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

        static void RungeKutta(double[] yin, double[] yout, double h)
        {
            int N = 4;
            double[] dydx = new double[N];
            double[] dydxt = new double[N];
            double[] yt = new double[N];
            double[] k1 = new double[N];
            double[] k2 = new double[N];
            double[] k3 = new double[N];
            double[] k4 = new double[N];

            Derivatives(yin, dydx);
            for (int i = 0; i < N; i++)
            {
                k1[i] = h * dydx[i];
                yt[i] = yin[i] + 0.5 * k1[i];
            }

            Derivatives(yt, dydxt);
            for (int i = 0; i < N; i++)
            {
                k2[i] = h * dydxt[i];
                yt[i] = yin[i] + 0.5 * k2[i];
            }

            Derivatives(yt, dydxt);
            for (int i = 0; i < N; i++)
            {
                k3[i] = h * dydxt[i];
                yt[i] = yin[i] + k3[i];
            }

            Derivatives(yt, dydxt);
            for (int i = 0; i < N; i++)
            {
                k4[i] = h * dydxt[i];
                yout[i] = yin[i] + k1[i] / 6 + k2[i] / 3 + k3[i] / 3 + k4[i] / 6;
            }
        }
    }
}

