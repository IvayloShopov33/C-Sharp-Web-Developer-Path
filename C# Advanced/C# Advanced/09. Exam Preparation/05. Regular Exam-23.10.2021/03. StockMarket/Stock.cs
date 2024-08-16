using System;

namespace StockMarket
{
    public class Stock
    {
        private string companyName;
        private string director;
        private decimal pricePerShare;
        private int totalNumberOfShares;
        private decimal marketCapitalization;

        public Stock(string companyName, string director, decimal pricePerShare, int totalNumberOfShares)
        {
            this.CompanyName = companyName;
            this.Director = director;
            this.PricePerShare = pricePerShare;
            this.TotalNumberOfShares = totalNumberOfShares;
            this.MarketCapitalization = this.pricePerShare * this.totalNumberOfShares;
        }

        public string CompanyName
        {
            get
            {
                return this.companyName;
            }
            private set
            {
                this.companyName = value;
            }
        }

        public string Director
        {
            get
            {
                return this.director;
            }
            private set
            {
                this.director = value;
            }
        }

        public decimal PricePerShare
        {
            get
            {
                return this.pricePerShare;
            }
            private set
            {
                this.pricePerShare = value;
            }
        }

        public int TotalNumberOfShares
        {
            get
            {
                return this.totalNumberOfShares;
            }
            private set
            {
                this.totalNumberOfShares = value;
            }
        }

        public decimal MarketCapitalization
        {
            get
            {
                return this.marketCapitalization;
            }
            private set
            {
                this.marketCapitalization = value;
            }
        }

        public override string ToString()
        {
            return $"Company: {this.CompanyName}{Environment.NewLine}Director: {this.Director}{Environment.NewLine}Price per share: ${this.PricePerShare:F2}{Environment.NewLine}Market capitalization: ${this.MarketCapitalization:F2}";
        }
    }
}
