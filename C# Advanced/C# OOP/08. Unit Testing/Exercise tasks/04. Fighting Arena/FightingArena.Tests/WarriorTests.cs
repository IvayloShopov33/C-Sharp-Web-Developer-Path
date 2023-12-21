namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void SetUp()
        {
            this.warrior = new Warrior("Superman", 50, 60);
        }

        [Test]
        public void WarriorConstructor_ShouldWorkCorrectly()
        {
            Assert.NotNull(this.warrior);
            Assert.AreEqual("Superman", this.warrior.Name);
            Assert.AreEqual(50, this.warrior.Damage);
            Assert.AreEqual(60, this.warrior.HP);
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("        ")]
        public void WarriorName_ShouldThrowAnExceptionWhenValueIsNullOrWhitespace(string name)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => this.warrior = new Warrior(name, 40, 56));

            Assert.AreEqual("Name should not be empty or whitespace!", exception.Message);
        }

        [TestCase(0)]
        [TestCase(-8)]
        [TestCase(-17)]
        public void WarriorDamage_ShouldThrowAnExceptionWhenValueIsZeroOrNegative(int damage)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => this.warrior = new Warrior("Spiderman", damage, 43));

            Assert.AreEqual("Damage value should be positive!", exception.Message);
        }

        [TestCase(-5)]
        [TestCase(-100)]
        [TestCase(-1_000_000)]
        public void WarriorHP_ShouldThrowAnExceptionWhenValueIsNegative(int hp)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => this.warrior = new Warrior("Batman", 33, hp));

            Assert.AreEqual("HP should not be negative!", exception.Message);
        }

        [TestCase(0)]
        [TestCase(27)]
        [TestCase(30)]
        public void AttackMethod_ShouldThrowAnExceptionWhenHPIsLessOrEqualTo30(int hp)
        {
            Warrior attacker = new Warrior("Captain America", 32, hp);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => attacker.Attack(this.warrior));

            Assert.AreEqual("Your HP is too low in order to attack other warriors!", exception.Message);
        }

        [TestCase(8)]
        [TestCase(15)]
        [TestCase(30)]
        public void AttackMethod_ShouldThrowAnExceptionWhenEnemyHPIsLessOrEqualTo30(int hp)
        {
            this.warrior = new Warrior("The Flash", 10, hp);
            Warrior attacker = new Warrior("Cyborg", 47, 54);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => attacker.Attack(this.warrior));

            Assert.AreEqual("Enemy HP must be greater than 30 in order to attack him!", exception.Message);
        }

        [TestCase(31)]
        [TestCase(35)]
        [TestCase(49)]
        public void AttackMethod_ShouldThrowAnExceptionWhenHPIsLessThanEnemyDamage(int hp)
        {
            Warrior attacker = new Warrior("Aquaman", 40, hp);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => attacker.Attack(this.warrior));

            Assert.AreEqual("You are trying to attack too strong enemy", exception.Message);
        }

        [TestCase(61)]
        [TestCase(70)]
        [TestCase(100)]
        public void AttackMethod_ShouldWorkCorrectlyWhenDamageIsMoreThanEnemyHP(int damage)
        {
            Warrior attacker = new Warrior("Wonder Woman", damage, 55);

            attacker.Attack(this.warrior);

            Assert.AreEqual(5, attacker.HP);
            Assert.AreEqual(0, this.warrior.HP);
        }

        [TestCase(50)]
        [TestCase(55)]
        [TestCase(60)]
        public void AttackMethod_ShouldWorkCorrectlyWhenDamageIsLessOrEqualToEnemyHP(int damage)
        {
            Warrior attacker = new Warrior("Green Lantern", damage, 65);
            int enemyHP = this.warrior.HP;

            attacker.Attack(this.warrior);

            Assert.AreEqual(15, attacker.HP);
            Assert.AreEqual(enemyHP - damage, this.warrior.HP);
        }
    }
}