namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        private Device device;

        [SetUp]
        public void Setup()
        {
            this.device = new Device(128);
        }

        [Test]
        public void DeviceConstructor_ShouldWorkCorrectly()
        {
            Assert.NotNull(this.device);
            Assert.AreEqual(128, this.device.MemoryCapacity);
            Assert.AreEqual(128, this.device.AvailableMemory);
            Assert.AreEqual(0, this.device.Photos);
            Assert.NotNull(this.device.Applications);
        }

        [TestCase(129)]
        [TestCase(150)]
        public void DeviceTakePhotoMethod_ShouldReturnFalseWhenPhotoSizeIsMoreThanMemory(int photoSize)
        {
            Assert.False(this.device.TakePhoto(photoSize));
        }

        [Test]
        public void DeviceTakePhotoMethod_ShouldWorkProperly()
        {
            Assert.True(this.device.TakePhoto(128));
            Assert.AreEqual(0, this.device.AvailableMemory);
            Assert.AreEqual(1, this.device.Photos);
        }

        [TestCase(129)]
        [TestCase(500)]
        public void DeviceInstallAppMethod_ShouldThrowAnExceptionWhenAppSizeIsBiggerThanMemory(int appSize)
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => this.device.InstallApp("Instagram", appSize));

            Assert.AreEqual("Not enough available memory to install the app.", exception.Message);
        }

        [Test]
        public void DeviceInstallAppMethod_ShouldWorkProperly()
        {
            string expectedResult = "Instagram is installed successfully. Run application?";
            string actualResult = this.device.InstallApp("Instagram", 128);

            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(0, this.device.AvailableMemory);
            Assert.AreEqual(1, this.device.Applications.Count);
            Assert.AreEqual("Instagram", this.device.Applications[0]);
        }

        [Test]
        public void DeviceFormatMethod_ShouldWorkCorrectly()
        {
            this.device.TakePhoto(50);
            this.device.InstallApp("Facebook", 50);

            this.device.FormatDevice();

            Assert.AreEqual(0, this.device.Photos);
            Assert.AreEqual(0, this.device.Applications.Count);
            Assert.AreEqual(128, this.device.AvailableMemory);
        }

        [Test]
        public void DeviceGetStatusMethod_ShouldWorkProperly()
        {
            this.device.TakePhoto(10);
            this.device.InstallApp("X", 45);
            this.device.InstallApp("Snapchat", 33);
            this.device.InstallApp("TikTok", 40);

            string expectedResult =
                $"Memory Capacity: 128 MB, Available Memory: 0 MB{Environment.NewLine}" +
                $"Photos Count: 1{Environment.NewLine}" +
                "Applications Installed: X, Snapchat, TikTok";

            string actualResult = this.device.GetDeviceStatus();

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}