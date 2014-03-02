namespace RedPencilKata_XUnit_2014_03_01_22h07
{
    using System;

    public class Product
    {
        private float price;

        public bool IsPromotionActive { get; set; }

        public float PreviousPrice { get; set; }

        public DateTime PricePreviouslyLastChanged { get; set; }

        public float Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.PricePreviouslyLastChanged = this.PriceLastChanged;
                this.PreviousPrice = this.price;
                this.PriceLastChanged = Time.Now;
                this.price = value;
            }
        }

        public DateTime PriceLastChanged { get; set; }
    }
}