namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;

        [SetUp]
        public void SetUp()
        {
            this.car = new Car("Bugatti", "Veyron", 15.7, 100.5);
        }

        [Test]
        public void CreateCar_ShouldWorkCorrectly()
        {
            Assert.NotNull(this.car);
            
            Assert.AreEqual("Bugatti", this.car.Make);
            Assert.AreEqual("Veyron", this.car.Model);
            Assert.AreEqual(15.7, this.car.FuelConsumption);
            Assert.AreEqual(100.5, this.car.FuelCapacity);
            Assert.AreEqual(0, this.car.FuelAmount);
        }

        [Test]
        public void CarFuelAmount_ShouldBeSetTo0()
        {
            Assert.AreEqual(0, this.car.FuelAmount);
        }

        [TestCase(null)]
        [TestCase("")]
        public void CarMake_ShouldThrowAnExceptionWhenValueIsNullOrEmpty(string make)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => this.car = new Car(make, "123", 10, 50));

            Assert.AreEqual("Make cannot be null or empty!", exception.Message);
        }

        [TestCase(null)]
        [TestCase("")]
        public void CarModel_ShouldThrowAnExceptionWhenValueIsNullOrEmpty(string model)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => this.car = new Car("Bugatti", model, 10, 50));

            Assert.AreEqual("Model cannot be null or empty!", exception.Message);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10.5)]
        public void CarFuelConsumption_ShouldThrowAnExceptionWhenValueIsZeroOrNegative(double fuelConsumption)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => this.car = new Car("Bugatti", "Chiron", fuelConsumption, 50));

            Assert.AreEqual("Fuel consumption cannot be zero or negative!", exception.Message);
        }

        [TestCase(0)]
        [TestCase(-8)]
        [TestCase(-60.9)]
        public void CarFuelCapacity_ShouldThrowAnExceptionWhenValueIsZeroOrNegative(double fuelCapacity)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => this.car = new Car("Opel", "Corsa", 9.5, fuelCapacity));

            Assert.AreEqual("Fuel capacity cannot be zero or negative!", exception.Message);
        }

        [TestCase(0)]
        [TestCase(-2)]
        [TestCase(-5.5)]
        public void CarRefuelMethod_ShouldThrowAnExceptionWhenFuelIsNegativeOrZero(double fuelToRefuel)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => this.car.Refuel(fuelToRefuel));

            Assert.AreEqual("Fuel amount cannot be zero or negative!", exception.Message);
        }

        [Test]
        public void CarRefuelMethod_ShouldIncreaseFuelAmount()
        {
            this.car.Refuel(10.5);
            Assert.AreEqual(10.5, this.car.FuelAmount);

            this.car.Refuel(90);

            Assert.AreEqual(100.5, this.car.FuelAmount);
            Assert.AreEqual(this.car.FuelCapacity, this.car.FuelAmount);
        }

        [Test]
        public void CarRefuelMethod_FuelAmountShouldNotBeMoreThanFuelCapacity()
        {
            this.car.Refuel(110);

            Assert.AreEqual(100.5, this.car.FuelAmount);
        }

        [TestCase(100)]
        [TestCase(200)]
        [TestCase(300)]
        public void CarDriveMethod_ShouldDecreaseFuelAmount(double distance)
        {
            this.car.Refuel(100);
            double expectedResult = this.car.FuelAmount - ((distance / 100) * this.car.FuelConsumption);
            this.car.Drive(distance);

            Assert.AreEqual(expectedResult, this.car.FuelAmount);
        }

        [TestCase(90)]
        [TestCase(100)]
        [TestCase(270)]
        public void CarDriveMethod_ShouldThrowAnExceptionWhenValueIsLowerThanDistance(double distance)
        {
            this.car.Refuel(10);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => this.car.Drive(distance));

            Assert.AreEqual("You don't have enough fuel to drive!", exception.Message);
        }
    }
}
