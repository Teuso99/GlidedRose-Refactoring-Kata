using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        var itemsToUpdate = Items.Where(i => !i.Name.Contains("Sulfuras"));

        foreach (var item in itemsToUpdate)
        {
            item.SellIn--;

            switch (item.Name)
            {
                case string name when name.Contains("Aged Brie"):
                    item.Quality = GetAgedBrieQualityUpdated(item);
                    break;

                case string name when name.Contains("Backstage pass"):
                    item.Quality = GetBackstagePassQualityUpdated(item);
                    break;

                case string name when name.Contains("Conjured"):
                    item.Quality = GetConjuredItemQualityUpdated(item);
                    break;

                default:
                    
                    item.Quality = GetDefaultItemQualityUpdated(item);
                    break;
            }
        }
    }

    private int GetDefaultItemQualityUpdated(Item item)
    {
        if (item.Quality == 0)
        {
            return 0;
        }

        if (item.SellIn < 0)
        {
            return item.Quality >= 2 ? item.Quality - 2 : 0;
        }

        return item.Quality > 0 ? item.Quality - 1 : 0;
    }

    private int GetAgedBrieQualityUpdated(Item item)
    {
        if (item.Quality == 50)
        {
            return 50;
        }

        if (item.SellIn < 0)
        {
            return item.Quality <= 48 ? item.Quality + 2 : 50;
        }

        return item.Quality + 1;
    }

    private int GetBackstagePassQualityUpdated(Item item)
    {
        if (item.SellIn < 0)
        {
            return 0;
        }

        if (item.Quality == 50)
        {
            return 50;
        }

        switch (item.SellIn)
        {
            case int sellIn when sellIn < 5:

                return item.Quality <= 47 ? item.Quality + 3 : 50;

            case int sellIn when sellIn < 10:

                return item.Quality <= 48 ? item.Quality + 2 : 50;

            default:

                return item.Quality + 1;
        }
    }

    private int GetConjuredItemQualityUpdated(Item item)
    {
        if (item.Quality == 0)
        {
            return 0;
        }

        if (item.SellIn < 0)
        {
            return item.Quality >= 4 ? item.Quality - 4 : 0;
        }

        return item.Quality >= 2 ? item.Quality - 2 : 0;
    }
}