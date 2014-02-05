namespace RedPencilCodeKata
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	// ReSharper disable InconsistentNaming

	[TestClass]
	public class RedPencilPromotionSpec
	{
		/*
		 * http://stefanroock.wordpress.com/2011/03/04/red-pencil-code-kata/

		A red pencil promotion starts due to a price reduction. 
		The price has to be reduced by at least 5% but at most bei 30%
		and the previous price had to be stable for at least 30 days.

		A red pencil promotion lasts 30 days as the maximum length.
		 
		If the price is further reduced during the red pencil promotion the promotion will not be prolonged by that reduction.
		If the price is increased during the red pencil promotion the promotion will be ended immediately.
		If the price if reduced during the red pencil promotion so that the overall reduction is more than 30% with regard to the original price, the promotion is ended immediately.
		After a red pencil promotion is ended additional red pencil promotions may follow – as long as the start condition is valid: the price was stable for 30 days and these 30 days don’t intersect with a previous red pencil promotion.

OPEN QUESTIONS:
- Exact 30days?
- How often do you change the prices?
- Chaining of rules?
	  */

		[TestClass]
		public class PromotionActive
		{
			[TestMethod]
			public void PreviousPriceNeedsToBeStableMoreThan30Days_PromoActive()
			{
				Product p = new Product(100);
				p.Price = 80;
				Time.GoForwardInDays(40);
				Promoter.SetPromotion(p);

				Assert.IsTrue(p.IsRedPencilPromoted);
			}

			[TestMethod]
			public void PreviousPriceNeedsToBeStableMoreThan30Days_PromoNOTActive()
			{
				Product p = new Product(100);
				p.Price = 80;
				Time.GoForwardInDays(10);
				Promoter.SetPromotion(p);

				Assert.IsFalse(p.IsRedPencilPromoted);
			}

			[TestMethod]
			public void PriceLess30Percent_PromoActive()
			{
				Product p = new Product(100);
				p.Price = 80;
				Time.GoForwardInDays(40);
				Promoter.SetPromotion(p);

				Assert.IsTrue(p.IsRedPencilPromoted);
			}

			[TestMethod]
			public void PriceReducedMoreThan40Percent_PromoActive()
			{
				Product p = new Product(100);
				p.Price = 50;
				Time.GoForwardInDays(40);
				Promoter.SetPromotion(p);

				Assert.IsFalse(p.IsRedPencilPromoted);
			}

			[TestMethod]
			public void PriceReducedbyLess5Percent_PromoNotActive()
			{
				Product p = new Product(100);
				p.Price = 99;
				Time.GoForwardInDays(40);
				Promoter.SetPromotion(p);

				Assert.IsFalse(p.IsRedPencilPromoted);
			}



			[TestMethod]
			public void Aredpencilpromotionlasts30daysasthemaximumlength_PromotionActive50Days()
			{
				var p = GivenProductIsPromoted();
				Time.GoForwardInDays(50);
				Promoter.SetPromotion(p);
				Assert.IsFalse(p.IsRedPencilPromoted);

			}

			[TestMethod]
			public void Aredpencilpromotionlasts30daysasthemaximumlength_PromotionActive29Days()
			{
				var p = GivenProductIsPromoted();

				Time.GoForwardInDays(29);
				Promoter.SetPromotion(p);

				Assert.IsTrue(p.IsRedPencilPromoted);
			}


			[TestMethod]
			public void Ifthepriceisfurtherreducedduringtheredpencilpromotionthepromotionwillnotbeprolongedbythatreduction_PromotionActive()
			{
				//If the price is further reduced during the red pencil promotion the promotion will not be prolonged by that reduction.
				var p = GivenProductIsPromoted();
				
				Time.GoForwardInDays(1);
				Promoter.SetPromotion(p);
				
				p.Price = 70;
				Promoter.SetPromotion(p);

				Assert.IsTrue(p.IsRedPencilPromoted);
			}

			[TestMethod]
			public void Ifthepriceisincreasedduringtheredpencilpromotionthepromotionwillbeendedimmediately_()
			{
				// If the price is increased during the red pencil promotion the promotion will be ended immediately.	
				var p = GivenProductIsPromoted();

				Time.GoForwardInDays(1);
				p.Price = 10000;

				Promoter.SetPromotion(p);

				Assert.IsFalse(p.IsRedPencilPromoted);
			}

			[TestMethod]
			public void ActivePromotion_NoPriceChange()
			{
				// If the price is increased during the red pencil promotion the promotion will be ended immediately.	
				var p = GivenProductIsPromoted();

				Time.GoForwardInDays(1);
				p.Price = p.Price;

				Promoter.SetPromotion(p);

				Assert.IsTrue(p.IsRedPencilPromoted);
			}

			[TestMethod]
			public void Duringtheredpencilpromotionsothattheoverallreductionismorethan30Percent_STOPPromotion()
			{
				// If the price if reduced during the red pencil promotion so that the overall reduction is more than 30% with regard to the original price, the promotion is ended immediately.	
				var p = GivenProductIsPromoted();

				Time.GoForwardInDays(1);
				p.Price = 1;

				Promoter.SetPromotion(p);

				Assert.IsFalse(p.IsRedPencilPromoted);

			}

			[TestMethod]
			public void TwoPromotionsAfterAnother()
			{
				// After a red pencil promotion is ended additional red pencil promotions may follow 
				// – as long as the start condition is valid: the price was stable for 30 days 
				//       and these 30 days don’t intersect with a previous red pencil promotion.
				// --> EXAMPLE??

				Product p = new Product(100);
				p.Price = 80;
				Time.GoForwardInDays(40);
				Promoter.SetPromotion(p);
				Assert.IsTrue(p.IsRedPencilPromoted);

				Time.GoForwardInDays(31);
				Promoter.SetPromotion(p);
				Assert.IsFalse(p.IsRedPencilPromoted);


				p.Price = 70;
				Time.GoForwardInDays(31);
				Promoter.SetPromotion(p);
				Assert.IsTrue(p.IsRedPencilPromoted);


			}


			private static Product GivenProductIsPromoted()
			{
				Product p = new Product(100);
				p.Price = 80;
				Time.GoForwardInDays(40);
				Promoter.SetPromotion(p);

				// Should assertion be here??
				Assert.IsTrue(p.IsRedPencilPromoted);
				return p;
			}
			
		}
	}
}
// ReSharper restore InconsistentNaming