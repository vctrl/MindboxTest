namespace ShapeAreaLib.Shapes
{
    using System;
    using System.Linq;

    /// <summary>
    /// The triangle shape
    /// </summary>
    public class Triangle : Shape
    {
        private const double _precision = 0.00001;

        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// </summary>
        /// <param name="side1"> The first side. </param>
        /// <param name="side2"> The second side. </param>
        /// <param name="side3"> The third side. </param>
        /// <param name="precision"> Precision of check if triangle is right. </param>
        public Triangle(double side1, double side2, double side3) : base(side1, side2, side3)
        {
            Sides = new double[] { side1, side2, side3 }.OrderBy(s => s).ToArray();
        }

        /// <summary>
        /// The side lenghts in ascending order.
        /// </summary>
        public double[] Sides { get; }

        /// <summary>
        /// Gets the value indicating whether a triangle is the right triangle.
        /// </summary>
        public virtual bool IsRight
        {
            get
            {
                return Math.Abs((Sides[0] * Sides[0]) + (Sides[1] * Sides[1]) - (Sides[2] * Sides[2])) < _precision;
            }
        }

        /// <summary>
        /// Calculate the area of the triangle.
        /// </summary>
        public override double Area
        {
            get
            {
                var p = Sides.Sum() / 2;
                return Math.Sqrt(p * (p - Sides[0]) * (p - Sides[1]) * (p - Sides[2]));
            }
        }

        public override string ToString()
        {
            return $"Triangle with sides {String.Join(',', Sides)}";
        }

        /// <summary>
        /// The sum of any 2 sides of a triangle must be greater than the measure of the third side.
        /// </summary>
        /// <param name="sides"> Side lengths. </param>
        protected override void AdditionalValidate(double[] sides)
        {
            if ((sides[0] + sides[1]) <= sides[2] || (sides[0] + sides[2]) <= sides[1] || (sides[1] + sides[2]) <= sides[0])
            {
                throw new ArgumentException("The sum of any 2 sides of a triangle must be greater than the measure of the third side");
            }
        }
    }
}
