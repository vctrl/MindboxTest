namespace ShapeAreaLibTests
{
    using System;
    using ShapeAreaLib;
    using ShapeAreaLib.Shapes;
    using NUnit.Framework;

    public class Tests
    {
        [Test]
        public void AreaCalculatorWithDefaultsTest()
        {
            var areaCalculator = new AreaCalculator(true);
            var circleResult = areaCalculator.Calculate(3);
            Assert.AreEqual(Math.Round(circleResult, 2), 28.27d);
            var triangleResult = areaCalculator.Calculate(3, 4, 5);
            Assert.AreEqual(triangleResult, 6);
        }

        [Test]
        public void AreaCalculatorWithoutDefaultsTest()
        {
            var areaCalculator = new AreaCalculator(false);
            Assert.Throws<ArgumentException>(() => areaCalculator.Calculate(3));
            areaCalculator.AddShapeSidesCountConformity(1, typeof(Circle));
            Assert.AreEqual(Math.Round(areaCalculator.Calculate(3), 2), 28.27d);

            Assert.Throws<ArgumentException>(() => areaCalculator.Calculate(3, 4, 5));
            areaCalculator.AddShapeSidesCountConformity(3, typeof(Triangle));
            Assert.AreEqual(Math.Round(areaCalculator.Calculate(3, 4, 5), 2), 6);

            areaCalculator.RemoveShapeSidesCountConformity(1);
            Assert.Throws<ArgumentException>(() => areaCalculator.Calculate(3));
            areaCalculator.RemoveShapeSidesCountConformity(3);
            Assert.Throws<ArgumentException>(() => areaCalculator.Calculate(3, 4, 5));
        }
    }
}