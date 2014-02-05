namespace RedPencilCodeKata
{
	using System;

	public class Product
	{
		private bool isRedPencilPromoted;

		private int price;

		public Product(int price)
		{
			this.Price = price;
		}

		public bool IsRedPencilPromoted
		{
			get
			{
				return this.isRedPencilPromoted;
			}
			set
			{
				this.isRedPencilPromoted = value;
				this.PromotionChangeDate = Time.Now;
			}
		}

		public int Price
		{
			get
			{
				return this.price;
			}
			set
			{
				if (this.price == value)
				{
					return;
				}

				this.PriceBefore = this.price;
				this.price = value;
				this.PriceChangeDate = Time.Now;
			}
		}

		public int PriceBefore { get; private set; }

		public DateTime PriceChangeDate { get; private set; }

		public DateTime PromotionChangeDate { get; private set; }
	}
}