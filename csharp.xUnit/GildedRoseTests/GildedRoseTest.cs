using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void UpdateQuality_AnyItem_DecreaseSellIn()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 } };
        GildedRose app = new GildedRose(Items);

        app.UpdateQuality();

        Assert.Equal(9, Items[0].SellIn);
    }

    [Fact]
    public void UpdateQuality_AnyItem_DecreaseQuality()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 } };
        GildedRose app = new GildedRose(Items);

        app.UpdateQuality();

        Assert.Equal(19, Items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_AnyItem_PastSellingDate_DecreaseQualityTwice()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 20 } };
        GildedRose app = new GildedRose(Items);

        app.UpdateQuality();

        Assert.Equal(18, Items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_AnyItem_ShouldNeverDecreaseQualityBelowZero()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 0 } };
        GildedRose app = new GildedRose(Items);

        app.UpdateQuality();

        Assert.Equal(0, Items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_AgedBrie_IncreaseQuality()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 } };
        GildedRose app = new GildedRose(Items);

        app.UpdateQuality();

        Assert.Equal(1, Items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_AnyItem_ShouldNeverIncreaseQualityPastFifty()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 50 } };
        GildedRose app = new GildedRose(Items);

        app.UpdateQuality();

        Assert.Equal(50, Items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_Sulfuras_ShouldNeverDecreaseQuality()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
        GildedRose app = new GildedRose(Items);

        app.UpdateQuality();

        Assert.Equal(80, Items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_Sulfuras_ShouldNeverDecreaseSellIn()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
        GildedRose app = new GildedRose(Items);

        app.UpdateQuality();

        Assert.Equal(0, Items[0].SellIn);
    }

    [Fact]
    public void UpdateQuality_BackstagePasses_IncreaseQuality()
    {
        IList<Item> Items = new List<Item> { new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 15,
                Quality = 20
            } };

        GildedRose app = new GildedRose(Items);

        app.UpdateQuality();

        Assert.Equal(21, Items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_BackstagePasses_TenDaysOrLessForSellInDate_IncreaseQualityTwice()
    {
        IList<Item> Items = new List<Item> { new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 10,
                Quality = 20
            } };

        GildedRose app = new GildedRose(Items);

        app.UpdateQuality();

        Assert.Equal(22, Items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_BackstagePasses_FiveDaysOrLessForSellInDate_IncreaseQualityThreeTimes()
    {
        IList<Item> Items = new List<Item> { new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 5,
                Quality = 20
            } };

        GildedRose app = new GildedRose(Items);

        app.UpdateQuality();

        Assert.Equal(23, Items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_BackstagePasses_PastSellInDate_DropsQualityToZero()
    {
        IList<Item> Items = new List<Item> { new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 0,
                Quality = 20
            } };

        GildedRose app = new GildedRose(Items);

        app.UpdateQuality();

        Assert.Equal(0, Items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_ConjuredItem_DecreaseQualityTwice()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 } };
        GildedRose app = new GildedRose(Items);

        app.UpdateQuality();

        Assert.Equal(4, Items[0].Quality);
    }
}