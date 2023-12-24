using NUnit.Framework;
using System;

namespace FootballTeam.Tests
{
    [TestFixture]
    public class Tests
    {
        private FootballPlayer player;
        private FootballTeam team;


        [SetUp]
        public void Setup()
        {
            this.player = new FootballPlayer("Ronaldo", 7, "Forward");
            this.team = new FootballTeam("Etar", 16);
        }

        [Test]
        public void PlayerConstructor_ShouldWorkCorrectly()
        {
            Assert.NotNull(this.player);
            Assert.AreEqual("Ronaldo", this.player.Name);
            Assert.AreEqual(7, this.player.PlayerNumber);
            Assert.AreEqual("Forward", this.player.Position);
        }

        [TestCase(null)]
        [TestCase("")]
        public void PlayerNameProperty_ShouldThrowAnExceptionWhenValueIsNullOrEmpty(string name)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new FootballPlayer(name, 5, "Forward"));

            Assert.AreEqual("Name cannot be null or empty!", exception.Message);
        }

        [TestCase(0)]
        [TestCase(22)]
        [TestCase(99)]
        public void PlayerNumberProperty_ShouldThrowAnExceptionWhenValueIsNotBetween1And21(int playerNumber)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new FootballPlayer("Son", playerNumber, "Forward"));

            Assert.AreEqual("Player number must be in range [1,21]", exception.Message);
        }

        [TestCase("GK")]
        [TestCase("CB")]
        [TestCase("ST")]
        public void PlayerPositionProperty_ShouldThrowAnExceptionWhenValueIsIncorrect(string position)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new FootballPlayer("Pesho", 8, position));

            Assert.AreEqual("Invalid Position", exception.Message);
        }

        [Test]
        public void TeamConstructor_ShouldWorkProperly()
        {
            Assert.NotNull(this.team);
            Assert.AreEqual("Etar", this.team.Name);
            Assert.AreEqual(16, this.team.Capacity);
            Assert.NotNull(this.team.Players);
        }

        [TestCase(null)]
        [TestCase("")]
        public void TeamNameProperty_ShouldThrowAnExceptionWhenValueIsNullOrEmpty(string name)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new FootballTeam(name, 20));

            Assert.AreEqual("Name cannot be null or empty!", exception.Message);
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(14)]
        public void TeamCapacityProperty_ShouldThrowAnExceptionWhenValueIsLessThan15(int capacity)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new FootballTeam("CSKA", capacity));

            Assert.AreEqual("Capacity min value = 15", exception.Message);
        }

        [Test]
        public void TeamAddNewPlayerMethod_ShouldWorkCorrectly()
        {
            string actualResult = this.team.AddNewPlayer(this.player);

            Assert.AreEqual(1, this.team.Players.Count);
            Assert.AreEqual("Added player Ronaldo in position Forward with number 7", actualResult);
        }

        [Test]
        public void TeamAddNewPlayerMethod_ShouldThrowAnExceptionWhenPlayersCountIsMoreThanCapacity()
        {
            this.team.AddNewPlayer(this.player);

            for (int i = 1; i < 16; i++)
            {
                this.team.AddNewPlayer(new FootballPlayer("Buffon", i, "Goalkeeper"));
            }

            string actualResult = this.team.AddNewPlayer(new FootballPlayer("Messi", 10, "Forward"));

            Assert.AreEqual("No more positions available!", actualResult);
        }

        [Test]
        public void TeamPickPlayerMethod_ShouldReturnAPlayerOrNull()
        {
            this.team.AddNewPlayer(this.player);

            Assert.AreEqual(null, this.team.PickPlayer(null));
            Assert.AreEqual(this.player, this.team.PickPlayer(this.player.Name));
        }

        [Test]
        public void TeamPlayerScore_ShouldWorkCorrectly()
        {
            this.team.AddNewPlayer(this.player);
            string expectedResult = "Ronaldo scored and now has 1 for this season!";

            Assert.AreEqual(expectedResult, this.team.PlayerScore(this.player.PlayerNumber));
            Assert.AreEqual(1, this.player.ScoredGoals);
        }
    }
}