using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Shop shop;
        private int shopCapacity;
        private Smartphone smartphone;

        [SetUp]
        public void SetUp()
        {
            this.shopCapacity = 3;
            this.shop = new Shop(shopCapacity);
            this.smartphone = new Smartphone("Samsung", 100);           
        }

        [Test]
        public void SCreateSmartPhoneadgfdsgsg()
        {            
            smartphone.CurrentBateryCharge = 80;

            var exceptedName = smartphone.ModelName;
            var exceptedMaxBattery = smartphone.MaximumBatteryCharge;

            Assert.AreEqual(exceptedName, "Samsung");
            Assert.AreEqual(exceptedMaxBattery, 100);

        }

        [Test]
        public void TestCreateShopCapacity()
        {
            Assert.AreEqual(3, shop.Capacity);
        }

        [Test]
        public void TestWithInvalidCapacity()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.shop = new Shop(-1);
            });

        }

        [Test]
        public void TestAddSmartPhones()
        {
            shop.Add(smartphone);

            Assert.AreEqual(1, shop.Count);
        }

        [Test]
        public void TestAddIfPhoneExistsShouldThrowInvalidOperationException()
        {
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() =>
            {
                Smartphone sp2 = new Smartphone("Samsung", 100);
                shop.Add(sp2);
            });
        }

        [Test]
        public void TestIfCapacityIsFullShouldThrowInvalidOperationException()
        {
            this.shop = new Shop(1);
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                Smartphone sp2 = new Smartphone("Hitachi", 100);
                shop.Add(sp2);
            });
        }

        [Test]
        public void RemoveSmartphoneFromList()
        {
            this.shop.Add(smartphone);
            Smartphone sp2 = new Smartphone("Hitachi", 100);
            this.shop.Add(sp2);

            shop.Remove("Samsung");

            Assert.AreEqual(1, shop.Count); 

        }

        [Test]
        public void TryToRemoveUnexistingPhone()
        {
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove("Motorola");
            });
        }

        [Test]
        public void TestPhoneDownBatteryPercentage()
        {
            this.smartphone.CurrentBateryCharge = 50;
            shop.Add(smartphone);
            shop.TestPhone("Samsung", 20);

            Assert.AreEqual(30, smartphone.CurrentBateryCharge);
        }

        [Test]
        public void TryTestNotExistingPhoneShouldThrowInvalidOperationException()
        {
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("Alcatel", 20);
            });
        }

        [Test]
        public void TestPhoneWithLowBateryShouldThrowInvalidOperationException()
        {
            this.smartphone.CurrentBateryCharge = 50;
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("Samsung", 70);
            });
        }

        [Test]
        public void TestToChargeUnexistingPhone()
        {
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone("Iphone");
            });
        }

        [Test]
        public void ChargePhone()
        {
            shop.Add(smartphone);
            shop.ChargePhone("Samsung");

            Assert.AreEqual(smartphone.MaximumBatteryCharge, smartphone.CurrentBateryCharge);
        }

        [Test]
        public void TestConstructorOfSmartphone()
        {
            this.smartphone.ModelName = "Samsung";
            this.smartphone.CurrentBateryCharge = 20;

            Assert.AreEqual("Samsung", smartphone.ModelName);
            Assert.AreEqual(20, smartphone.CurrentBateryCharge);
            Assert.AreEqual(100, smartphone.MaximumBatteryCharge);

        }

    }

}