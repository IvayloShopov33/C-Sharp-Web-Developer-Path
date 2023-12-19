namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;

        [SetUp]
        public void SetUp()
        {
            Person[] people =
            {
                new Person(1, "John"),
                new Person(2, "Mark"),
                new Person(3, "Steven"),
                new Person(4, "Donald"),
                new Person(5, "Joe"),
                new Person(6, "Jordan"),
                new Person(7, "Marcus"),
                new Person(8, "Elizabeth"),
                new Person(9, "Victoria"),
                new Person(10, "Margaret")
            };

            this.database = new Database(people);
        }

        [Test]
        public void CreateDatabaseCount_ShouldBeCorrect()
        {
            int expectedResult = 10;

            Assert.AreEqual(expectedResult, this.database.Count);
        }

        [Test]
        public void CreateDatabaseCount_ShouldThrowAnExceptionWhenCountIsMoreThan16()
        {
            Person[] people =
            {
                new Person(1, "John"),
                new Person(2, "Mark"),
                new Person(3, "Steven"),
                new Person(4, "Donald"),
                new Person(5, "Joe"),
                new Person(6, "Jordan"),
                new Person(7, "Marcus"),
                new Person(8, "Elizabeth"),
                new Person(9, "Victoria"),
                new Person(10, "Margaret"),
                new Person(11, "Maria"),
                new Person(12, "Ronny"),
                new Person(13, "Daniel"),
                new Person(14, "Jack"),
                new Person(15, "Roger"),
                new Person(16, "Simon"),
                new Person(17, "Alexander")
            };

            ArgumentException exception = Assert.Throws<ArgumentException>(() => this.database = new Database(people));
            Assert.AreEqual("Provided data length should be in range [0..16]!", exception.Message);
        }

        [Test]
        public void DatabaseAddMethod_ShouldIncreaseCount()
        {
            int expectedResult = 11;
            this.database.Add(new Person(11, "Mackenzie"));

            Assert.AreEqual(expectedResult, this.database.Count);
        }

        [Test]
        public void DatabaseAddMethod_ShouldThrowAnExceptionWhenCountIsMoreThan16()
        {
            this.database.Add(new Person(11, "Maria"));
            this.database.Add(new Person(12, "Ronny"));
            this.database.Add(new Person(13, "Daniel"));
            this.database.Add(new Person(14, "Jack"));
            this.database.Add(new Person(15, "Roger"));
            this.database.Add(new Person(16, "Simon"));

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => this.database.Add(new Person(17, "Alexander")));
            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
        }

        [Test]
        public void DatabaseAddMethod_ShouldThrowAnExceptionWhenAPersonWithSameUsernameIsAdded()
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => this.database.Add(new Person(11, "John")));
            Assert.AreEqual("There is already user with this username!", exception.Message);
        }

        [Test]
        public void DatabaseAddMethod_ShouldThrowAnExceptionWhenAPersonWithSameIdIsAdded()
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => this.database.Add(new Person(1, "Chris")));
            Assert.AreEqual("There is already user with this Id!", exception.Message);
        }

        [Test]
        public void DatabaseRemoveMethod_ShouldDecreaseCount()
        {
            int expectedResult = 9;
            this.database.Remove();

            Assert.AreEqual(expectedResult, this.database.Count);
        }

        [Test]
        public void DatabaseRemoveMethod_ShouldThrowAnExceptionWhenTheArrayIsEmpty()
        {
            this.database = new Database();

            Assert.Throws<InvalidOperationException>(() => this.database.Remove(), "The database is empty.");
        }

        [Test]
        public void DatabaseFindByUsername_ShouldWorkCorrectly()
        {
            string expectedResult = "Mark";

            Assert.AreEqual(expectedResult, this.database.FindByUsername(expectedResult).UserName);
        }

        [TestCase("Michel")]
        [TestCase("Rafael")]
        public void DatabaseFindByUsername_ShouldThrowAnExceptionWhenTheUsernameIsNotFound(string username)
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername(username));
            Assert.AreEqual("No user is present by this username!", exception.Message);
        }

        [TestCase(null)]
        [TestCase("")]
        public void DatabaseFindByUsername_ShouldThrowAnExceptionWhenTheUsernameIsNull(string username)
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(username));
            Assert.AreEqual("Username parameter is null!", exception.ParamName);
        }

        [Test]
        public void DatabaseFindByUsername_ShouldBeCaseSensitive()
        {
            string expectedResult = "joRDaN";

            Assert.AreNotEqual(expectedResult, this.database.FindByUsername("Jordan").UserName);
        }

        [Test]
        public void DatabaseFindById_ShouldWorkCorrectly()
        {
            long id = 3;
            string expectedResult = "Steven";

            Assert.AreEqual(expectedResult, this.database.FindById(id).UserName);
        }

        [TestCase(-1)]
        [TestCase(-1_000_000_000)]
        public void DatabaseFindById_ShouldThrowAnExceptionWhenTheIdIsANegativeNumber(long id)
        {
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindById(id));
            Assert.AreEqual("Id should be a positive number!", exception.ParamName);
        }

        [TestCase(11)]
        [TestCase(12)]
        [TestCase(100)]
        public void DatabaseFindById_ShouldThrowAnExceptionWhenTheIdIsNotFound(long id)
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => this.database.FindById(id));
            Assert.AreEqual("No user is present by this ID!", exception.Message);
        }
    }
}