namespace ShapeAreaLibTests
{
    using System;
    using ShapeAreaLib.Shapes;
    using NUnit.Framework;

    public class CircleTests
    {
        [Test]
        public void TestNegativeOrZeroValues()
        {
            Assert.Throws<ArgumentException>(() => new Circle(-1));
            Assert.Throws<ArgumentException>(() => new Circle(0));
        }

        [Test]
        public void TestAreaCalculate()
        {
            var circle1 = new Circle(5);
            Assert.AreEqual(Math.Round(circle1.Area, 2), 78.54d);
            var circle2 = new Circle(10);
            Assert.AreEqual(Math.Round(circle2.Area, 2), 314.16d);
        }
    }
}
