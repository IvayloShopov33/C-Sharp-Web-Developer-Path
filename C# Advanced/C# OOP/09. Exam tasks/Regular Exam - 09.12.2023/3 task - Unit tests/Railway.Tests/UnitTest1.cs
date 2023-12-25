namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Tests
    {
        private RailwayStation railwayStation;

        [SetUp]
        public void Setup()
        {
            this.railwayStation = new RailwayStation("Subway");
        }

        [Test]
        public void RailwayStationConstructor_ShouldWorkCorrectly()
        {
            Assert.NotNull(this.railwayStation);
            Assert.AreEqual("Subway", this.railwayStation.Name);
            Assert.NotNull(this.railwayStation.DepartureTrains);
            Assert.NotNull(this.railwayStation.ArrivalTrains);
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("        ")]
        public void RailwayStationName_ShouldThrowAnExceptionWhenValueIsNullOrWhitespace(string name)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new RailwayStation(name));

            Assert.AreEqual("Name cannot be null or empty!", exception.Message);
        }

        [Test]
        public void RailwayStationNewArrivalOnBoardMethod_ShouldWorkCorrectly()
        {
            this.railwayStation.NewArrivalOnBoard("Sofia-Varna");

            Assert.AreEqual(1, this.railwayStation.ArrivalTrains.Count);
            Assert.AreEqual("Sofia-Varna", this.railwayStation.ArrivalTrains.Peek());
        }

        [Test]
        public void RailwayStationTrainHasArrivedMethod_ShouldEnterFirstStatement()
        {
            this.railwayStation.NewArrivalOnBoard("Sofia-Plovdiv");
            this.railwayStation.NewArrivalOnBoard("Sofia-Burgas");

            string expectedResult = "There are other trains to arrive before Sofia-Burgas.";
            Assert.AreEqual(expectedResult, this.railwayStation.TrainHasArrived("Sofia-Burgas"));
        }

        [Test]
        public void RailwayStationTrainHasArrivedMethod_ShouldWorkCorrectly()
        {
            this.railwayStation.NewArrivalOnBoard("Sofia-Varna");
            this.railwayStation.NewArrivalOnBoard("Sofia-Ruse");

            string expectedResult = "Sofia-Varna is on the platform and will leave in 5 minutes.";
            Assert.AreEqual(expectedResult, this.railwayStation.TrainHasArrived("Sofia-Varna"));
            Assert.AreEqual(1, this.railwayStation.ArrivalTrains.Count);
            Assert.AreEqual(1, this.railwayStation.DepartureTrains.Count);
        }

        [Test]
        public void RailwayStationTrainHasLeftMethod_ShouldReturnTrue()
        {
            this.railwayStation.NewArrivalOnBoard("Sofia-Vidin");
            this.railwayStation.TrainHasArrived("Sofia-Vidin");

            Assert.IsTrue(this.railwayStation.TrainHasLeft("Sofia-Vidin"));
            Assert.AreEqual(0, this.railwayStation.DepartureTrains.Count);
        }

        [Test]
        public void RailwayStationTrainHasLeftMethod_ShouldReturnFalse()
        {
            this.railwayStation.NewArrivalOnBoard("Sofia-Pleven");
            this.railwayStation.NewArrivalOnBoard("Sofia-Shumen");

            this.railwayStation.TrainHasArrived("Sofia-Pleven");
            this.railwayStation.TrainHasArrived("Sofia-Shumen");

            Assert.IsFalse(this.railwayStation.TrainHasLeft("Sofia-Shumen"));
            Assert.AreEqual(0, this.railwayStation.ArrivalTrains.Count);
            Assert.AreEqual(2, this.railwayStation.DepartureTrains.Count);
        }
    }
}