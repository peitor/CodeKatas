namespace RedPencilKata_XUnit_2014_03_01_22h07
{
    using Xunit;

    /*
     * During the red pencil promotion the old price is crossed out in red and the new reduced price is written next to it.
     */

    public class RedPencilPromotionSpecifications
    {
        public class PriceReducedInRange
        {
            // A red pencil promotion starts due to a price reduction. 
            // The price has to be reduced by at least 5% 
            //  but at most bei 30% and 
            // the previous price had to be stable for at least 30 days.   

            // TODO Data Driven Tests
            // TODO Check if price really changed

            [Fact]
            public void PriceReducedBy04Percent_PromotionNOTActive()
            {
                var product = new Product();
                product.Price = 100;
                Time.AdvanceDays(30);
                product.Price = 96;

                _SetPromotionAndAssertOn(product, false);
            }

            [Fact]
            public void PriceReducedBy05Percent_PromotionActive()
            {
                var product = new Product();
                product.Price = 100;
                Time.AdvanceDays(30);
                product.Price = 95;

                _SetPromotionAndAssertOn(product, true);
            }

            [Fact]
            public void PriceReducedBy30Percent_PromotionActive()
            {
                var product = new Product();
                product.Price = 100;
                Time.AdvanceDays(30);
                product.Price = 70;

                _SetPromotionAndAssertOn(product, true);
            }

            [Fact]
            public void PriceReducedBy31Percent_PromotionNOTActive()
            {
                var product = new Product();
                product.Price = 100;
                Time.AdvanceDays(30);
                product.Price = 69;

                _SetPromotionAndAssertOn(product, false);
            }




            [Fact]
            public void Hadtobestableforatleast30days_Wait1Day()
            {
                var product = new Product();
                product.Price = 100;
                Time.AdvanceDays(1);

                product.Price = 70;

                _SetPromotionAndAssertOn(product, false);
            }

            [Fact]
            public void Hadtobestableforatleast30days_Wait29Days()
            {
                var product = new Product();
                product.Price = 100;
                Time.AdvanceDays(29);

                product.Price = 70;

                _SetPromotionAndAssertOn(product, false);
            }

            [Fact]
            public void Hadtobestableforatleast30days_Wait30Days()
            {
                var product = new Product();
                product.Price = 100;
                Time.AdvanceDays(30);

                product.Price = 70;
                Time.AdvanceDays(30);

                _SetPromotionAndAssertOn(product, true);
            }



            [Fact]
            public void Aredpencilpromotionlasts30daysasthemaximumlength_29DaysLater()
            {
                var product = new Product();
                product.Price = 100;

                Time.AdvanceDays(30);
                product.Price = 70;

                _SetPromotionAndAssertOn(product, true);

                Time.AdvanceDays(29);

                _SetPromotionAndAssertOn(product, true);
            }

            [Fact]
            public void Aredpencilpromotionlasts30daysasthemaximumlength_31Later()
            {
                var product = new Product();
                product.Price = 100;

                Time.AdvanceDays(30);
                product.Price = 70;

                _SetPromotionAndAssertOn(product, true);

                Time.AdvanceDays(31);

                _SetPromotionAndAssertOn(product, false);
            }


            private static void _SetPromotionAndAssertOn(Product product, bool shouldPromotionBeActive)
            {
                PromotionCalculator.SetPromotionActive(product);
                if (shouldPromotionBeActive)
                {
                    Assert.True(product.IsPromotionActive);
                }
                else
                {
                    Assert.False(product.IsPromotionActive);
                }
            }
        }
    }
}