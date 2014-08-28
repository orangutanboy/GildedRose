namespace GildedRose.Console
{
    public static class NamedItemFactory
    {
        public static NamedItem Create(Item item)
        {
            switch (item.Name)
            {
                case Program.AgedBrie:
                    return new AgedBrieItem(item);
                case Program.BackstagePass:
                    return new BackstagePassItem(item);
                case Program.Sulfuras:
                    return new SulfurasItem(item);
                default:
                    return new NamedItem(item);
            }
        }
    }
}
