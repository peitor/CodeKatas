namespace RedPencilCodeKata
{
	public static class Promoter
	{
		public static void SetPromotion(Product product)
		{
			if (product.IsRedPencilPromoted)
			{
				if (PromotionIsTooOld(product))
				{
					product.IsRedPencilPromoted = false;
				}

				if (ProductWasModifiedSincePromotionStart(product))
				{
					ProductValidatePriceBefore(product);
				}
			}
			else if (CanProductBeRedPencilPromoted(product))
			{
				product.IsRedPencilPromoted = true;
			}
		}

		private static void ProductValidatePriceBefore(Product product)
		{
			if (product.Price > product.PriceBefore)
			{
				product.IsRedPencilPromoted = false;
			}
			if (CalcPriceReductionInPercent(product) > 30)
			{
				product.IsRedPencilPromoted = false;
			}
		}

		private static bool ProductWasModifiedSincePromotionStart(Product product)
		{
			return product.PriceChangeDate > product.PromotionChangeDate;
		}

		private static bool PromotionIsTooOld(Product product)
		{
			return (Time.Now - product.PromotionChangeDate).TotalDays > 30;
		}

		private static bool CanProductBeRedPencilPromoted(Product product)
		{
			var priceReductionInPercent = CalcPriceReductionInPercent(product);
			bool redPencilPromoted = priceReductionInPercent >= 5 && priceReductionInPercent <= 30;

			if ((Time.Now - product.PriceChangeDate).TotalDays < 30)
			{
				redPencilPromoted = false;
			}
			return redPencilPromoted;
		}

		private static double CalcPriceReductionInPercent(Product product)
		{
			double priceBefore = product.PriceBefore;
			var priceReduction = priceBefore - product.Price;
			var priceReductionInPercent = priceReduction / priceBefore * 100;
			return priceReductionInPercent;
		}
	}
}