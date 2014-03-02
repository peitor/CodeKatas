namespace RedPencilKata_XUnit_2014_03_01_22h07
{
    using System;

    public class PromotionCalculator
    {
        public static bool IsPromotionActive(
            float newPrice,
            float previousPrice,
            DateTime newPriceWasSet,
            DateTime oldPriceWasSet,
            DateTime now)
        {
            bool promotionIsActive = false;
            if (newPrice <= previousPrice * 0.95 && newPrice >= previousPrice * 0.7)
            {
                promotionIsActive = true;
            }

            // Price needs to be stable 30 days
            if (newPriceWasSet - oldPriceWasSet < TimeSpan.FromDays(30))
            {
                promotionIsActive = false;
            }

            // Promotion ends after 30 days
            if (now - newPriceWasSet > TimeSpan.FromDays(30))
            {
                promotionIsActive = false;
            }
            return promotionIsActive;
        }

        public static bool PromotionIsActive(float newPrice, float previousPrice)
        {
            return PromotionIsActive(newPrice, previousPrice, Time.Now.AddDays(32), Time.Now);
        }

        public static bool PromotionIsActive(float newPrice, float previousPrice, DateTime newPriceWasSet, DateTime now)
        {
            return IsPromotionActive(newPrice, previousPrice, newPriceWasSet, now, now);
        }

        public static void SetPromotionActive(Product p)
        {
            p.IsPromotionActive = IsPromotionActive(
                p.Price,
                p.PreviousPrice,
                p.PriceLastChanged,
                p.PricePreviouslyLastChanged,
                Time.Now);
        }
    }
}