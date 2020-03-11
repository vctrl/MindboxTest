namespace ShapeAreaLib.Shapes
{
    using System;

    /// <summary>
    /// The right triangle class.
    /// </summary>
    public class RightTriangle : Triangle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RightTriangle"/> class.
        /// </summary>
        /// <param name="c1"> First cathetus. </param>
        /// <param name="c2"> econd cathetus. </param>
        public RightTriangle(double c1, double c2) : base(c1, c2, Math.Sqrt(c1 * c1 + c2 * c2))
        {
        }

        /// <summary>
        /// Gets the value of the right triangle area.
        /// </summary>
        public override double Area => (Sides[0] * Sides[1]) / 2;

        /// <summary>
        /// This triangle is definitely right.
        /// </summary>
        public override bool IsRight => true;

        public override string ToString()
        {
            return $"Right triangle with cathetus {Sides[0]}, {Sides[1]} and hupotenuse {Sides[3]}";
        }
    }
}
