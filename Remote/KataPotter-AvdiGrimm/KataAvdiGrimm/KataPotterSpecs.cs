// ReSharper disable InconsistentNaming
namespace KataAvdiGrimm
{
	using System.Collections.Generic;
	using System.Linq;
	using NUnit.Framework;

	[TestFixture]
	public class KataPotterSpecs
	{
		// Harry Potter Books Kata 
		// http://codingdojo.org/cgi-bin/wiki.pl?KataPotter

		[Test]
		public void OneBook_Costs800C()
		{
			List<string> cart = new List<string>();

			cart.Add("Harry1");
			var price = CalculateSetPrice(cart);

			Assert.That(price, Is.EqualTo(800));
		}



		[Test]
		public void TwoSameBooks_Costs1600C()
		{
			List<string> cart = new List<string>();

			cart.Add("Harry1");
			cart.Add("Harry1");

			double price = 0;

			price =
			cart.Aggregate(
				0,
				(total, title) => total + 800);


			Assert.That(price, Is.EqualTo(1600));
		}

		[Test]
		public void TwoDifferentBooks()
		{
			List<string> cart = new List<string>();
			cart.Add("1");
			cart.Add("2");

			int priceInCents = CalculateSetPrice(cart);

			Assert.That(priceInCents, Is.EqualTo(1520));
		}

		[Test]
		public void DifferentBooks()
		{
			List<string> cart = new List<string>();
			cart.Add("1");
			cart.Add("2");
			cart.Add("3");
			Assert.That(CalculateSetPrice(cart), Is.EqualTo(2160));

			cart.Add("4");
			Assert.That(CalculateSetPrice(cart), Is.EqualTo(2560));

			cart.Add("5");
			Assert.That(CalculateSetPrice(cart), Is.EqualTo(3000));
		}

	
		[Test]
		public void OneSetAnd_1Duplicate()
		{
			List<string> cart = new List<string>();
			cart.Add("1");
			cart.Add("2");
			cart.Add("2");

			var calculatePrice = CalculatePrice(cart);

			Assert.That(calculatePrice, Is.EqualTo(800 + 1520));
		}

		[Test]
		public void OneSetAnd_1Duplicate_DifferentOrder()
		{
			List<string> cart = new List<string>();
			cart.Add("2");
			cart.Add("1");
			cart.Add("2");

			var calculatePrice = CalculatePrice(cart);

			Assert.That(calculatePrice, Is.EqualTo(800 + 1520));
		}


		[Test]
		public void Force3Sets()
		{
			List<string> cart = new List<string>();
			cart.Add("1");
			cart.Add("1");
			cart.Add("1");
			
			var calculatePrice = CalculatePrice(cart);

			Assert.That(calculatePrice, Is.EqualTo(2400));
		}


		[Test]
		public void COMPLLICATSSS()
		{
			List<string> cart = new List<string>();
			cart.Add("1");
			cart.Add("1");
			cart.Add("1");
			cart.Add("2");
			cart.Add("2");
			
			var calculatePrice = CalculatePrice(cart);

			Assert.That(calculatePrice, Is.EqualTo(1520 + 1520 + 800));
		}

		private static int CalculatePrice(List<string> cart)
		{
			cart.Sort();

			List<List<string>> resultSet = new List<List<string>>();
		
			// TODO NEXT TIME
			// create permutations --> and calcPrice on those
			// find cheapest
			//  OR
			// calc price for each potential set? 


			while (cart.Count > 0)
			{
				List<string> currentSet = GetSetThatDoesntHaveTheBook(cart[0], resultSet);

				if (currentSet == null) 
				{
					currentSet = new List<string>();
					resultSet.Add(currentSet);
					
				}
				else
				{
					currentSet.Add(cart[0]);
					cart.RemoveAt(0);
				}
				
				
			}

			//Assert.That(resultSet.Count, Is.EqualTo(2));


			int calculatePrice =
				resultSet.Aggregate(
				0,
				(total, set) => total + CalculateSetPrice(set));
			
			//Assert.That(resultSet[0].Count, Is.EqualTo(2));
			//Assert.That(resultSet[1].Count, Is.EqualTo(1));

			//Assert.That(price1, Is.EqualTo(1520));
			//Assert.That(price2, Is.EqualTo(800));
			
			return calculatePrice;
		}

		private static List<string> GetSetThatDoesntHaveTheBook(string book, List<List<string>> resultSet)
		{
			var foundSet = resultSet.Find(set => !set.Contains(book));
			return foundSet;
		}



		private static int CalculateSetPrice(IEnumerable<string> cart)
		{
			var discounts = new Dictionary<int, int>
				                                 {
					                                 {1,0},
					                                 {2,5},
					                                 {3,10},
					                                 {4,20},
					                                 {5,25},
				                                 };

			int uniqueCount = cart.Distinct().Count();

			var discount = discounts[uniqueCount];


			int price =
				cart.Aggregate(
				0,
				(total, title) => total + 800);


			// apply discount
			price = (int)(price * (1 - (decimal)discount / 100));


			return price;
		}

	}
}










// ReSharper restore InconsistentNaming
