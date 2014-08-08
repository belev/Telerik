using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ComputerBuildingSystem.Tests
{

    [TestClass]
    public class LaptopBatteryChargeTests
    {
        private LaptopBattery battery;
        [TestInitialize]
        public void InitializeBattery()
        {
            this.battery = new LaptopBattery();
        }

        [TestMethod]
        public void BatteryChargeWithMoreThan100Percents()
        {
            this.battery.ChargeBattery(200);

            var expectedBatteryPercentageAfterCharging = 100;
            Assert.AreEqual(expectedBatteryPercentageAfterCharging, this.battery.Percentage);
        }

        [TestMethod]
        public void BatteryChargeWithNegative200Percents()
        {
            this.battery.ChargeBattery(-200);

            var expectedBatteryPercentageAfterCharging = 0;
            Assert.AreEqual(expectedBatteryPercentageAfterCharging, this.battery.Percentage);
        }

        [TestMethod]
        public void BatteryChargeWithZeroPercent()
        {
            this.battery.ChargeBattery(0);

            var expectedBatteryPercentageAfterCharging = LaptopBattery.InitialBatteryPercentage;
            Assert.AreEqual(expectedBatteryPercentageAfterCharging, this.battery.Percentage);
        }

        [TestMethod]
        public void BatteryChargeWith10Percents()
        {
            this.battery.ChargeBattery(10);

            var expectedBatteryPercentageAfterCharging = LaptopBattery.InitialBatteryPercentage + 10;
            Assert.AreEqual(expectedBatteryPercentageAfterCharging, this.battery.Percentage);
        }

        [TestMethod]
        public void BatteryChargeWithNegative10Percents()
        {
            this.battery.ChargeBattery(-10);
            
            var expectedBatteryPercentageAfterCharging =LaptopBattery.InitialBatteryPercentage - 10;
            Assert.AreEqual(expectedBatteryPercentageAfterCharging, this.battery.Percentage);
        }
    }
}
