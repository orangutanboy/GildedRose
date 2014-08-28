namespace GildedRose.Console
{
    public class NamedItem : Item
    {
        public NamedItem(Item item)
        {
            this.Name = item.Name;
            this.Quality = item.Quality;
            this.SellIn = item.SellIn;
        }

        public virtual void UpdateQuality()
        {
            if (Quality > 0)
            {
                Quality--;
            }

            if (SellIn < 0)
            {
                if (Quality > 0)
                {
                    Quality--;
                }
            }
            ReduceSellIn();
        }

        public void ReduceSellIn()
        {
            SellIn--;
        }
    }
}
