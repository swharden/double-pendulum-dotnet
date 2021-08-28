using System;

namespace DPend.Model
{
    /// <summary>
    /// Double pendulum simulator
    /// </summary>
    public class Simulator
    {
        /// <summary>
        /// Gravity (m/2^2)
        /// </summary>
        public double G = 9.8;

        public readonly Pendulum Pendulum1 = new();
        public readonly Pendulum Pendulum2 = new();

        private double L1 => Pendulum1.Length;
        private double L2 => Pendulum2.Length;
        private double M1 => Pendulum1.Mass;
        private double M2 => Pendulum2.Mass;

        public int Iterations { get; private set; }
        public double Time { get; private set; }

        public override string ToString() => $"{Iterations}: {Pendulum1.Theta:F6} {Pendulum1.Omega:F6} {Pendulum1.Theta:F6} {Pendulum1.Omega:F6}";

        public Simulator()
        {

        }

        public Simulator(double theta1, double theta2)
        {
            Pendulum1.Theta = theta1;
            Pendulum2.Theta = theta2;
        }

        double[] Deriv(double[] yin)
        {
            double del = yin[2] - yin[0];
            double den1 = (M1 + M2) * L1 - M2 * L1 * Math.Cos(del) * Math.Cos(del);
            double den2 = (L2 / L1) * den1;

            double[] dydx = new double[4];
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

            return dydx;
        }

        /// <summary>
        /// Step the simulator forward in time
        /// </summary>
        /// <param name="dt">step size (seconds)</param>
        public void Step(double dt)
        {
            int N = 4;
            double[] yt = new double[N];
            double[] k1 = new double[N];
            double[] k2 = new double[N];
            double[] k3 = new double[N];
            double[] k4 = new double[N];
            double[] yin = { Pendulum1.Theta, Pendulum1.Omega, Pendulum2.Theta, Pendulum2.Omega };

            double[] d1 = Deriv(yin);
            for (int i = 0; i < N; i++)
            {
                k1[i] = dt * d1[i];
                yt[i] = yin[i] + 0.5 * k1[i];
            }

            double[] d2 = Deriv(yt);
            for (int i = 0; i < N; i++)
            {
                k2[i] = dt * d2[i];
                yt[i] = yin[i] + 0.5 * k2[i];
            }

            double[] d3 = Deriv(yt);
            for (int i = 0; i < N; i++)
            {
                k3[i] = dt * d3[i];
                yt[i] = yin[i] + k3[i];
            }

            double[] d4 = Deriv(yt);
            double[] yout = new double[4];
            for (int i = 0; i < N; i++)
            {
                k4[i] = dt * d4[i];
                yout[i] = yin[i] + k1[i] / 6 + k2[i] / 3 + k3[i] / 3 + k4[i] / 6;
            }

            Pendulum1.Theta = yout[0];
            Pendulum1.Omega = yout[1];
            Pendulum2.Theta = yout[2];
            Pendulum2.Omega = yout[3];
            Iterations += 1;
            Time += dt;
        }
    }
}

