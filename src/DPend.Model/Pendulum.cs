using System;

namespace DPend.Model
{
    public class Pendulum
    {
        /// <summary>
        /// Angle (radians)
        /// </summary>
        public double Theta = 0;

        /// <summary>
        /// Angle (degrees)
        /// </summary>
        public double ThetaDegrees
        {
            get => Theta * 180 / Math.PI;
            set => Theta = value * Math.PI / 180.0;
        }

        /// <summary>
        /// Angle (radians)
        /// </summary>
        public double Omega = 0;

        /// <summary>
        /// Angle (degrees)
        /// </summary>
        public double OmegaDegrees
        {
            get => Omega * 180 / Math.PI;
            set => Omega = value * Math.PI / 180.0;
        }

        /// <summary>
        /// Mass (kg)
        /// </summary>
        public double Mass = 1.0;

        /// <summary>
        /// Length (m)
        /// </summary>
        public double Length = 1.0;

        /// <summary>
        /// X position of the tip of the pendulum relative to its base
        /// </summary>
        public double DeltaX => Length * Math.Cos(Theta + Math.PI / 2);

        /// <summary>
        /// Y position of the tip of the pendulum relative to its base
        /// </summary>
        public double DeltaY => Length * Math.Sin(Theta + Math.PI / 2);
    }
}
