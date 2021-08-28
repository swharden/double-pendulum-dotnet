using NUnit.Framework;

namespace DPend.Tests
{
    public class Tests
    {
        [TestCase(1, 0.010010, 1.570305, -0.098094, -0.174533, 0.000048)]
        [TestCase(2, 0.020020, 1.568833, -0.196163, -0.174531, 0.000385)]
        [TestCase(3, 0.030030, 1.566378, -0.294183, -0.174523, 0.001300)]
        [TestCase(50, 0.500501, 0.210694, -5.526093, 0.576804, 4.155592)]
        [TestCase(122, 1.221221, -0.533565, 2.738867, -1.355195, -4.533280)]
        [TestCase(542, 5.425425, 1.193991, 2.795244, -0.019194, -1.197950)]
        [TestCase(999, 10.000000, -0.154481, -1.916253, -1.954805, 1.785182)]
        public void Test_Simulator_ValuesMatch(int iterations, double time, double t1, double w1, double t2, double w2)
        {
            // values came from original C program http://www.physics.usyd.edu.au/~wheat/dpend_html/solve_dpend.c
            var sim2 = new Simulator(90, 0, -10, 0);
            double h = 10 / 999.0;
            for (int i = 0; i < iterations; i++)
                sim2.Step(h);

            double precision = 1e-5;
            Assert.AreEqual(time, sim2.Time, precision);
            Assert.AreEqual(t1, sim2.Theta1, precision);
            Assert.AreEqual(w1, sim2.Omega1, precision);
            Assert.AreEqual(t2, sim2.Theta2, precision);
            Assert.AreEqual(w2, sim2.Omega2, precision);
        }
    }
}