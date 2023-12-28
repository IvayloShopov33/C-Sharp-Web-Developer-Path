using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        [Test]
        public void GymConstructor_ShouldWorkProperly()
        {
            Gym gym = new Gym("Mania", 100);

            Assert.NotNull(gym);
            Assert.AreEqual("Mania", gym.Name);
            Assert.AreEqual(100, gym.Capacity);
            Assert.AreEqual(0, gym.Count);
        }

        [TestCase("")]
        [TestCase(null)]
        public void GymName_ShouldThrowAnExceptionWhenValueIsNullOrEmpty(string name)
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(()
            => new Gym(name, 100));

            Assert.AreEqual("Invalid gym name. (Parameter 'value')", exception.Message);
            Assert.AreEqual("value", exception.ParamName);
        }

        [TestCase(-1)]
        [TestCase(-10)]
        public void GymCapacity_ShouldThrowAnExceptionWhenValueIsNegative(int capacity)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new Gym("Universe", capacity));

            Assert.AreEqual("Invalid gym capacity.", exception.Message);
        }

        [Test]
        public void GymAddAthleteMethod_ShouldThrowAnExceptionWhenGymIsFull()
        {
            Gym gym = new Gym("17", 1);
            gym.AddAthlete(new Athlete("Ivo"));

            Assert.AreEqual(1, gym.Count);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => gym.AddAthlete(new Athlete("Spas")));

            Assert.AreEqual("The gym is full.", exception.Message);
        }

        [Test]
        public void GymRemoveMethod_ShouldThrowAnExceptionWhenAthleteIsNotFound()
        {
            Gym gym = new Gym("Mania", 2);
            gym.AddAthlete(new Athlete("John"));
            gym.AddAthlete(new Athlete("Peter"));

            Assert.AreEqual(2, gym.Count);

            gym.RemoveAthlete("John");

            Assert.AreEqual(1, gym.Count);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => gym.RemoveAthlete("Mark"));

            Assert.AreEqual("The athlete Mark doesn't exist.", exception.Message);
        }

        [Test]
        public void GymInjureAthleteMethod_ShouldThrowAnExceptionWhenAthleteIsNotFound()
        {
            Gym gym = new Gym("Galaxy", 1);
            Athlete athlete = new Athlete("Mackenzie");
            gym.AddAthlete(athlete);

            Assert.AreEqual(gym.InjureAthlete("Mackenzie"), athlete);
            Assert.True(athlete.IsInjured);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => gym.InjureAthlete("Jordan"));

            Assert.AreEqual("The athlete Jordan doesn't exist.", exception.Message);
        }

        [Test]
        public void GymReportMethod_ShouldWorkProperly()
        {
            Gym gym = new Gym("Mania", 3);
            gym.AddAthlete(new Athlete("Mark"));
            gym.AddAthlete(new Athlete("John"));

            Assert.AreEqual("Active athletes at Mania: Mark, John", gym.Report());

            gym.InjureAthlete("Mark");

            Assert.AreEqual("Active athletes at Mania: John", gym.Report());

            gym.InjureAthlete("John");

            Assert.AreEqual("Active athletes at Mania: ", gym.Report());

            gym.AddAthlete(new Athlete("Lebron"));

            Assert.AreEqual("Active athletes at Mania: Lebron", gym.Report());
        }
    }
}
