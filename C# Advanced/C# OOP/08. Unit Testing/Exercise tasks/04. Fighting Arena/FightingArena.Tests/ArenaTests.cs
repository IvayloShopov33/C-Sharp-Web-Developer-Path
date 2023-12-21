namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            this.arena = new Arena();
        }

        [Test]
        public void ArenaConstructor_ShouldInitializedCollectionOfWarriors()
        {
            Assert.NotNull(this.arena);
            Assert.NotNull(this.arena.Warriors);
        }

        [Test]
        public void ArenaCountAndEnrollMethod_ShouldWorkCorrectly()
        {
            Warrior warrior = new Warrior("Batgirl", 50, 40);
            this.arena.Enroll(warrior);

            Assert.AreEqual(1, this.arena.Count);
            Assert.AreEqual(warrior, this.arena.Warriors.First());
        }

        [Test]
        public void ArenaEnrollMethod_ShouldThrowAnExceptionWhenAWarriorIsAlreadyEnrolled()
        {
            Warrior firstWarrior = new Warrior("Alan Scott", 65, 103);
            Warrior secondWarrior = new Warrior("Alan Scott", 39, 99);

            this.arena.Enroll(firstWarrior);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => this.arena.Enroll(secondWarrior));

            Assert.AreEqual("Warrior is already enrolled for the fights!", exception.Message);
        }

        [Test]
        public void ArenaFightMethod_ShouldWorkCorrectly()
        {
            Warrior attacker = new Warrior("Antiope", 78, 100);
            Warrior defender = new Warrior("Amanda Waller", 80, 150);

            this.arena.Enroll(attacker);
            this.arena.Enroll(defender);

            this.arena.Fight(attacker.Name, defender.Name);

            Assert.AreEqual(20, attacker.HP);
            Assert.AreEqual(72, defender.HP);
        }

        [Test]
        public void ArenaFightMethod_ShouldThrowAnExceptionWhenAttackerIsNotFound()
        {
            Warrior attacker = new Warrior("Alfred Pennyworth", 81, 225);
            Warrior defender = new Warrior("Amethyst", 100, 500);

            this.arena.Enroll(defender);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => this.arena.Fight(attacker.Name, defender.Name));

            Assert.AreEqual($"There is no fighter with name {attacker.Name} enrolled for the fights!",
                exception.Message);
        }

        [Test]
        public void ArenaFightMethod_ShouldThrowAnExceptionWhenDefenderIsNotFound()
        {
            Warrior attacker = new Warrior("Ares", 196, 289);
            Warrior defender = new Warrior("Bane", 324, 512);

            this.arena.Enroll(attacker);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => this.arena.Fight(attacker.Name, defender.Name));

            Assert.AreEqual($"There is no fighter with name {defender.Name} enrolled for the fights!",
                exception.Message);
        }
    }
}
