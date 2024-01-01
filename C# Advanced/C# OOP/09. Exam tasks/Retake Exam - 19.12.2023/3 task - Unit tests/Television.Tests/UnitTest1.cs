namespace Television.Tests
{
    using System;
    using NUnit.Framework;
    public class Tests
    {
        private TelevisionDevice device;

        [SetUp]
        public void Setup()
        {
            this.device = new TelevisionDevice("Sony", 500.5, 50, 40);
        }

        [Test]
        public void DeviceConstructor_ShouldWorkCorrectly()
        {
            Assert.NotNull(this.device);
            Assert.AreEqual("Sony", this.device.Brand);
            Assert.AreEqual(500.5, this.device.Price);
            Assert.AreEqual(50, this.device.ScreenWidth);
            Assert.AreEqual(40, this.device.ScreenHeigth);
            Assert.AreEqual(0, this.device.CurrentChannel);
            Assert.AreEqual(13, this.device.Volume);
            Assert.False(this.device.IsMuted);
        }

        [Test]
        public void DeviceSwitchOnMethod_ShouldWorkCorrectly()
        {
            string expectedResult = "Cahnnel 0 - Volume 13 - Sound On";

            Assert.AreEqual(expectedResult, this.device.SwitchOn());
        }

        [TestCase(-5)]
        [TestCase(-1)]
        public void DeviceChangeChannelMethod_ShouldThrowAnExceptionWhenParameterIsNegative(int channel)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => this.device.ChangeChannel(channel));

            Assert.AreEqual("Invalid key!", exception.Message);
        }

        [Test]
        public void DeviceChangeChannelMethod_ShouldWorkProperly()
        {
            int expectedResult = 5;
            int actualResult = this.device.ChangeChannel(5);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void DeviceVolumeChangeMethod_ShouldWorkProperlyWhenDirectionIsUp()
        {
            string expectedResult = "Volume: 39";
            string actualResult = this.device.VolumeChange("UP", 26);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void DeviceVolumeChangeMethod_ShouldWorkProperlyWhenDirectionIsUpAndVolumeExceeds100()
        {
            string expectedResult = "Volume: 100";
            string actualResult = this.device.VolumeChange("UP", 100);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void DeviceVolumeChangeMethod_ShouldWorkProperlyWhenDirectionIsDown()
        {
            string expectedResult = "Volume: 10";
            string actualResult = this.device.VolumeChange("DOWN", 3);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void DeviceVolumeChangeMethod_ShouldWorkProperlyWhenDirectionIsDownAndVolumeBecomesLessThan0()
        {
            string expectedResult = "Volume: 0";
            string actualResult = this.device.VolumeChange("DOWN", 15);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void DeviceVolumeChangeMethod_ShouldWorkProperlyWhenUnitsAreNegative()
        {
            this.device.VolumeChange("UP", -5);

            Assert.AreEqual("Volume: 10", this.device.VolumeChange("DOWN", -8));
        }

        [TestCase("up")]
        [TestCase("down")]
        [TestCase("left")]
        [TestCase("right")]
        public void DeviceVolumeChangeMethod_ShouldWorkCorrectlyWhenDirectionIsWrong(string direction)
        {
            Assert.AreEqual("Volume: 13", this.device.VolumeChange(direction, 15));
        }

        [Test]
        public void DeviceMuteMethod_ShouldWorkCorrectly()
        {
            Assert.True(this.device.MuteDevice());
            Assert.False(this.device.MuteDevice());
        }

        [Test]
        public void DeviceToStringMethod_ShouldWorkProperly()
        {
            string expectedResult = "TV Device: Sony, Screen Resolution: 50x40, Price 500.5$";
            string actualResult= this.device.ToString();

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}