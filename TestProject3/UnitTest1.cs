using Lab9;

namespace TestProject3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            int expectedSpeed = 1;
            int expectedDistance = 1;

            // Act
            Runner r = new Runner();

            // Assert
            Assert.AreEqual(expectedSpeed, r.Speed);
            Assert.AreEqual(expectedDistance, r.Distance);
        }
    }
}