using System;

namespace GildedRose.Console
{
    public class AgedBrieItem : NamedItem
    {
        public AgedBrieItem(Item item)
            : base(item)
        {
        }

        public override void UpdateQuality()
        {
            Quality++;

            if (SellIn < 0)
            {
                Quality++;
            }

            Quality = Math.Min(Quality, 50);

            ReduceSellIn();
        }
    }
}