namespace Aquariums.Tests
{
    using System;
    using NUnit.Framework;

    public class AquariumsTests
    {
        Aquarium aquarium;
        Fish fish;

       [SetUp]
        public void Setup()
        {
             aquarium = new Aquarium("Akva", 10);
            fish = new Fish("Nemo");
        }

        [Test]
        
        public void testAquariumNameIsNull()
        {
            Assert.That(() => new Aquarium("", 5), Throws.ArgumentNullException);
        }
        
        [Test]
        public void theNameIsCorect()
        {
            Assert.AreEqual(fish.Name, "Nemo");
        }

        [Test]
        public void capacityIsNegative()
        {
            Assert.That(() => new Aquarium("Aqua", -10), Throws.ArgumentException.With.Message.EqualTo("Invalid aquarium capacity!"));
        }

        [Test]
        public void CapacityIsCorrect()
        {
            Assert.AreEqual(aquarium.Capacity, 10);
        }

        [Test]
        public void AddFishWithoutCapacity()
        {
            Aquarium testAqua = new Aquarium("Akva", 1);
            testAqua.Add(fish);
            Assert.That(() => testAqua.Add(fish), Throws.InvalidOperationException.With.Message.EqualTo("Aquarium is full!"));
        }

        [Test]
        public void ifCapacityIsOk()
        {
            aquarium.Add(fish);
            Assert.AreEqual(1, aquarium.Count);

        }

        [Test]
        public void fishRemoveIsNull()
        {
            Assert.That(() => aquarium.RemoveFish("Gosho"), Throws.InvalidOperationException.With.Message.EqualTo("Fish with the name Gosho doesn't exist!"));

        }

        [Test]
        public void isFishIsRemoved()
        {
            aquarium.Add(fish);
            aquarium.RemoveFish("Nemo");
            Assert.AreEqual(0, aquarium.Count);

        }


        [Test]
        public void SellFishIsNull()
        {
            Assert.That(() => aquarium.SellFish("Gosho"), Throws.InvalidOperationException.With.Message.EqualTo("Fish with the name Gosho doesn't exist!"));

        }

        [Test]
        public void isFishIsSell()
        {
            aquarium.Add(fish);
            var result = aquarium.SellFish("Nemo");

            Assert.AreEqual(result, fish);

        }

        [Test]
        public void compareReport()
        {
            aquarium.Add(fish);
            var result = aquarium.Report();
            Assert.AreEqual("Fish available at Akva: Nemo", result);
        }
    }
}
