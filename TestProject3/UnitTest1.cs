using Lab9;
using System.Text;

namespace TestProject3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShouldInitializeDeafaultValues()
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

        [TestMethod]
        public void ShouldInitializeDeafaultProperties()
        {
            // Arrange
            double speed = 52;
            double distance = 38;

            // Act
            Runner runner = new Runner(speed, distance);

            // Assert
            Assert.AreEqual(speed, runner.Speed);
            Assert.AreEqual(distance, runner.Distance);
        }

        [TestMethod]
        public void ShouldInitializeWithSameValues()
        {
            // Arrange
            Runner r1 = new Runner(52, 38);

            // Act
            Runner r2 = new Runner(r1);

            // Assert
            Assert.AreEqual(r1.Speed, r2.Speed);
            Assert.AreEqual(r2.Distance, r1.Distance);
        }

        [TestMethod]
        public void Speed_ShouldThrowArgumentException()
        {
            // Arrange
            Runner runner = new Runner();

            // Act & Assert
            var ex = Assert.ThrowsException<ArgumentException>(() => runner.Speed = -1);
            Assert.AreEqual("Скорость не может быть отрицательна", ex.Message);
        }

        [TestMethod]
        public void Distance_ShouldThrowArgumentException()
        {
            // Arrange
            Runner runner = new Runner();

            // Act & Assert
            var ex = Assert.ThrowsException<ArgumentException>(() => runner.Distance = -1);
            Assert.AreEqual("Расстояние не может быть отрицательным", ex.Message);
        }

        [TestMethod]
        public void CalculatingTime_ShouldReturnCorrectTime()
        {
            // Arrange
            Runner runner = new Runner(33, 44);

            // Act
            double time = runner.CalculatingTime();

            // Assert
            Assert.AreEqual(1.33, time);
        }

        [TestMethod]
        public void CalculatingTime_ShouldThrowInvalidOperationException()
        {
            // Arrange
            Runner runner = new Runner(0, 100);

            // Act & Assert
            var ex = Assert.ThrowsException<InvalidOperationException>(() => runner.CalculatingTime());
            Assert.AreEqual("Скорость не может быть равна нулю.", ex.Message);
        }

        [TestMethod]
        public void TimeStatic_ShouldReturnCorrectTime()
        {
            // Arrange
            double speed = 52;
            double distance = 38;

            // Act
            double time = Runner.TimeStatic(speed, distance);

            // Assert
            Assert.AreEqual(0.73, time);
        }

        [TestMethod]
        public void TimeStatic_ShouldThrowArgumentException()
        {
            // Arrange
            double speed = 0;
            double distance = 100;

            // Act & Assert
            var ex = Assert.ThrowsException<ArgumentException>(() => Runner.TimeStatic(speed, distance));
            Assert.AreEqual("Скорость не может быть равна нулю.", ex.Message);
        }

        [TestMethod]
        public void TimeStatic_ShouldThrowArgumentNullException()
        {
            // Arrange & Act & Assert
            var ex = Assert.ThrowsException<ArgumentNullException>(() => Runner.TimeStatic(null));
            Assert.AreEqual("Передан пустой объект (Parameter 'runner')", ex.Message);
        }

        [TestMethod]
        public void TimeStatic_ShouldThrowInvalidOperationException()
        {
            // Arrange
            Runner runner = new Runner(0, 100);

            // Act & Assert
            var ex = Assert.ThrowsException<InvalidOperationException>(() => Runner.TimeStatic(runner));
            Assert.AreEqual("Скорость не может быть равна нулю", ex.Message);
        }

        [TestMethod]
        public void ToString_ShouldReturnCorrectString()
        {
            // Arrange
            var runner = new Runner(52, 38);
            string expected = $"Расстояние: 38 км, Скорость: 52 км/ч,  Время: {runner.CalculatingTime()} ч.";

            // Act
            string result = runner.ToString();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IncrementOperation_ShouldIncreaseDistance()
        {
            // Arrange
            var runner = new Runner(52, 38);
            double initialDistance = runner.Distance;

            // Act
            runner++;

            // Assert
            Assert.AreEqual(initialDistance + 0.1, runner.Distance);
        }

        [TestMethod]
        public void DecrementOperation_ShouldDecreaseSpeed()
        {
            // Arrange
            var runner = new Runner(52, 38);
            double initialSpeed = runner.Speed;

            // Act
            runner--;

            // Assert
            Assert.AreEqual(initialSpeed - 0.05, runner.Speed);
        }

        [TestMethod]
        public void DecrementOperation_ShouldThrowArgumentException()
        {
            // Arrange
            var runner = new Runner(0.04, 100);

            // Act & Assert
            var ex = Assert.ThrowsException<ArgumentException>(() => runner--);
            Assert.AreEqual("Скорость не может быть меньше 0", ex.Message);
        }


        [TestMethod]
        public void ExplicitConversionToDouble_ShouldReturnCorrectValue()
        {
            // Arrange
            var runner = new Runner(10, 100);
            double expected = Math.Round((runner.Distance / (runner.CalculatingTime() * 0.95)) - runner.Speed, 2);

            // Act 
            double result = (double)runner;
            // Assert
            Assert.AreEqual(expected, result);
        }



    }
}