using System;

namespace GildedRose.Console
{
    public class BackstagePassItem : NamedItem
    {
        public BackstagePassItem(Item item)
            : base(item)
        {
        }

        public override void UpdateQuality()
        {
            Quality++;

            if (SellIn <= 0)
            {
                Quality = 0;
            }
            else
            {
                if (SellIn <= 10)
                {
                    Quality++;
                }

                if (SellIn <= 5)
                {
                    Quality++;
                }
            }

            Quality = Math.Min(Quality, 50);

            ReduceSellIn();
        }
    }
}