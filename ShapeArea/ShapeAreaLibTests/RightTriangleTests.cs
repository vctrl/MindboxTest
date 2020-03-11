namespace ShapeAreaLibTests
{
    using System;
    using ShapeAreaLib.Shapes;
    using NUnit.Framework;

    public class RightTriangleTests
    {
        [Test]
        public void TestNegativeOrValues()
        {
            Assert.Throws<ArgumentException>(() => new RightTriangle(-1, 1));
            Assert.Throws<ArgumentException>(() => new RightTriangle(1, -1));

            Assert.Throws<ArgumentException>(() => new RightTriangle(0, 1));
            Assert.Throws<ArgumentException>(() => new RightTriangle(1, 0));
        }

        [Test]
        public void TestIsRight()
        {
            var rightTriangle1 = new RightTriangle(1, 2);
            Assert.IsTrue(rightTriangle1.IsRight);
            var rightTriangle2 = new RightTriangle(22, 45);
            Assert.IsTrue(rightTriangle2.IsRight);
        }

        [Test]
        public void TestAreaCalculate()
        {
            var triangle1 = new RightTriangle(3, 4);
            Assert.AreEqual(triangle1.Area, 6d);
            var triangle2 = new RightTriangle(20, 100);
            Assert.AreEqual(triangle2.Area, 1000d);
        }
    }
}
