using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class UpdateQualityTests
    {
        [TestCase("+5 Dexterity Vest")]
        [TestCase("Elixir of the Mongoose")]
        [TestCase("Conjured Mana Cake")]
        [TestCase("Aged Brie")]
        [TestCase("Backstage passes to a TAFKAL80ETC concert")]
        public void SellByDateReducesPerDay(string itemName)
        {
            var updated = UpdateQualityForItem(itemName, 2, 0);
            Assert.That(updated.SellIn, Is.EqualTo(1));
        }

        [TestCase("+5 Dexterity Vest")]
        [TestCase("Elixir of the Mongoose")]
        [TestCase("Conjured Mana Cake")]
        public void QualityReducesPerDay(string itemName)
        {
            var updated = UpdateQualityForItem(itemName, 2, 10);
            Assert.That(updated.Quality, Is.EqualTo(9));
        }

        [TestCase("+5 Dexterity Vest")]
        [TestCase("Elixir of the Mongoose")]
        [TestCase("Conjured Mana Cake")]
        public void ItemsPastSellByDateReduceQualityTwiceAsFast(string itemName)
        {
            var updated = UpdateQualityForItem(itemName, -2, 10);
            Assert.That(updated.Quality, Is.EqualTo(8));
        }

        [Test]
        public void AgedBriePastSellByDateIncreasesQualityTwiceAsFast()
        {
            var updated = UpdateQualityForItem("Aged Brie", -2, 10);
            Assert.That(updated.Quality, Is.EqualTo(12));
        }

        [TestCase("+5 Dexterity Vest")]
        [TestCase("Elixir of the Mongoose")]
        [TestCase("Conjured Mana Cake")]
        public void ZeroQualityItemDoesNotReduceQuality(string itemName)
        {
            var updated = UpdateQualityForItem(itemName, 2, 0);
            Assert.That(updated.Quality, Is.EqualTo(0));
        }

        [Test]
        public void AgedBrieQualityIncreasesPerDay()
        {
            var updated = UpdateQualityForItem("Aged Brie", 2, 10);
            Assert.That(updated.Quality, Is.EqualTo(11));
        }

        [TestCase("Aged Brie")]
        [TestCase("Backstage passes to a TAFKAL80ETC concert")]
        public void increasingQualityItemWith50QualityDoesNotIncreaseQuality(string itemName)
        {
            var updated = UpdateQualityForItem(itemName, 2, 50);
            Assert.That(updated.Quality, Is.EqualTo(50));
        }

        [Test]
        public void SulfurasQualityDoesNotChange()
        {
            var updated = UpdateQualityForItem("Sulfuras, Hand of Ragnaros", 2, 80);
            Assert.That(updated.Quality, Is.EqualTo(80));
        }

        [Test]
        public void SulfurasSellByDateDoesNotChange()
        {
            var updated = UpdateQualityForItem("Sulfuras, Hand of Ragnaros", 2, 15);
            Assert.That(updated.SellIn, Is.EqualTo(2));
        }

        [Test]
        public void BackstagePassQualityIncreasesWhenSellbyOver10Days()
        {
            var updated = UpdateQualityForItem("Backstage passes to a TAFKAL80ETC concert", 11, 15);
            Assert.That(updated.Quality, Is.EqualTo(16));
        }

        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        public void BackstagePassQualityIncreasesby2WhenSellby5To10Days(int days)
        {
            var updated = UpdateQualityForItem("Backstage passes to a TAFKAL80ETC concert", days, 15);
            Assert.That(updated.Quality, Is.EqualTo(17));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void BackstagePassQualityIncreasesby3WhenSellby1To5Days(int days)
        {
            var updated = UpdateQualityForItem("Backstage passes to a TAFKAL80ETC concert", days, 15);
            Assert.That(updated.Quality, Is.EqualTo(18));
        }

        [Test]
        public void BackstagePassQualityIs0WhenSellByDateReached()
        {
            var updated = UpdateQualityForItem("Backstage passes to a TAFKAL80ETC concert", 0, 15);
            Assert.That(updated.Quality, Is.EqualTo(0));
        }

        private static Item UpdateQualityForItem(string itemName, int sellIn, int quality)
        {
            var item = new Item { Name = itemName, SellIn = sellIn, Quality = quality };
            var items = new[] { item };
            new Program { Items = items }.UpdateQuality();
            return item;
        }
    }
}