using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeConstructor_InitializationShouldBeCorrect()
        {
            Axe axe = new Axe(10, 10);

            Assert.AreEqual(10, axe.AttackPoints);
            Assert.AreEqual(10, axe.DurabilityPoints);
        }

        [Test]
        public void Attack_AxeShouldLoseDurabilityAfterAttack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(100, 100);

            axe.Attack(dummy);

            Assert.AreEqual(9, axe.DurabilityPoints, "Axe Durability doesn't change after attack.");
        }

        [Test]
        public void Attack_AxeShouldNotAttackWithABrokenWeapon()
        {
            Axe axe = new Axe(10, 1);
            Dummy dummy = new Dummy(100, 100);

            axe.Attack(dummy);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy), "Axe is broken.");
        }
    }
}