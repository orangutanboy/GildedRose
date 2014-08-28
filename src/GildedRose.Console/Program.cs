using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public const string AgedBrie = "Aged Brie";
        public const string DexterityVest = "+5 Dexterity Vest";
        public const string Elixir = "Elixir of the Mongoose";
        public const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        public const string BackstagePass = "Backstage passes to a TAFKAL80ETC concert";
        public const string ConjuredManaCake = "Conjured Mana Cake";

        internal IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
                          {
                              Items = new List<Item>
                                          {
                                              new Item { Name = DexterityVest, SellIn = 10, Quality = 20 },
                                              new Item { Name = AgedBrie, SellIn = 2, Quality = 0 },
                                              new Item { Name = Elixir, SellIn = 5, Quality = 7 },
                                              new Item { Name = Sulfuras, SellIn = 0, Quality = 80 },
                                              new Item { Name = BackstagePass, SellIn = 15, Quality = 20 },
                                              new Item { Name = ConjuredManaCake, SellIn = 3, Quality = 6 }
                                          }
                          };

            app.UpdateQuality();

            System.Console.ReadKey();

        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var namedItem = NamedItemFactory.Create(item);
                if (namedItem != null)
                {
                    namedItem.UpdateQuality();
                    item.SellIn = namedItem.SellIn;
                    item.Quality = namedItem.Quality;
                }
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}
