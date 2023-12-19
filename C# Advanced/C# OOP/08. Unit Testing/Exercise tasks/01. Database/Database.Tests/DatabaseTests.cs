namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void SetUp()
        {
            this.database = new Database(1, 2, 3);
        }

        [Test]
        public void CreateDatabase_CountShouldBeCorrect()
        {
            int expectedResult = 3;
            int actualResult = this.database.Count;

            Assert.NotNull(this.database);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void DatabaseCount_ShouldWorkCorrectly()
        {
            int expectedResult = 3;
            int actualResult = this.database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void DatabaseAddMethod_ShouldAddItemsCorrectly(int[] data)
        {
            this.database = new Database(data);
            int[] actualResult = this.database.Fetch();

            Assert.AreEqual(data, actualResult);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 })]
        public void CreateDatabaseAddMethod_ShouldThrowAnExceptionWhenCountIsMoreThan16(int[] data)
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => this.database = new Database(data));

            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
        }

        [TestCase(-5)]
        [TestCase(8)]
        public void DatabaseAddMethod_ShouldIncreaseCount(int number)
        {
            int expectedResult = 4;
            this.database.Add(number);

            Assert.AreEqual(expectedResult, this.database.Count);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 })]
        public void DatabaseAddMethod_ShouldAddSeveralItemsCorrectly(int[] data)
        {
            this.database = new Database();

            foreach (int number in data)
            {
                this.database.Add(number);
            }

            Assert.AreEqual(data, this.database.Fetch());
        }

        [Test]
        public void DatabaseAddMethod_ShouldThrowAnExceptionWhenCountIsMoreThan16()
        {
            for (int i = 0; i < 13; i++)
            {
                this.database.Add(i);
            }

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => this.database.Add(121));
            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
        }

        [Test]
        public void DatabaseRemoveMethod_ShouldDecreaseTheCount()
        {
            int expectedResult = 2;
            this.database.Remove();

            Assert.AreEqual(expectedResult, this.database.Count);
        }

        [Test]
        public void DatabaseRemoveMethod_ShouldRemoveItemsCorrectly()
        {
            int[] expectedResult = Array.Empty<int>();

            this.database.Remove();
            this.database.Remove();
            this.database.Remove();

            Assert.AreEqual(expectedResult, this.database.Fetch());
        }

        [Test]
        public void DatabaseRemoveMethod_ShouldThrowAnExceptionWhenTheArrayIsEmpty()
        {
            this.database = new Database();

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => this.database.Remove());
            Assert.AreEqual("The collection is empty!", exception.Message);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void DatabaseFetchMethod_ShouldReturnItemsCorrectly(int[] data)
        {
            this.database = new Database(data);

            Assert.AreEqual(data, this.database.Fetch());
        }
    }
}