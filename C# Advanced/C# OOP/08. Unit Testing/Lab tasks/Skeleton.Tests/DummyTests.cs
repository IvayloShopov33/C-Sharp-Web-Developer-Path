using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;

        [SetUp]
        public void CreateDummy()
        {
            dummy = new Dummy(100, 100);
        }

        [Test]
        public void DummyConstructor_InitializationShouldBeCorrect()
        {
            Assert.AreEqual(100, dummy.Health, "Dummy's health should be equal to the input.");
            Assert.AreEqual(100, dummy.Experience, "Dummy's experience should be equal to the input.");
        }

        [Test]
        public void TakeAttack_ShouldLoseHealth()
        {
            dummy.TakeAttack(20);
            dummy.TakeAttack(20);
            dummy.TakeAttack(10);

            Assert.AreEqual(50, dummy.Health, "Dummy doesn't lose");
        }

        [Test]
        public void TakeAttack_DeadDummyShouldThrowAnException()
        {
            dummy.TakeAttack(100);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(1), "Dummy is dead.");
        }

        [Test]
        public void GiveExperience_DeadDummyShouldGiveHisExperience()
        {
            try
            {
                dummy.TakeAttack(100);
                dummy.TakeAttack(1);
            }
            catch (InvalidOperationException)
            {

            }

            Assert.AreEqual(dummy.Experience, dummy.GiveExperience(), "Dead dummy should give his experience.");
        }

        [Test]
        public void GiveExperience_AliveDummyShouldNotGiveHisExperience()
        {
            dummy.TakeAttack(50);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(), "Alive dummy should not give his experience.");
        }

        [Test]
        public void IsDead_DummyShouldBeDead()
        {
            dummy.TakeAttack(100);

            Assert.True(dummy.IsDead(), "Dummy should be dead.");
        }
    }
}