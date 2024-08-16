using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private string fullName;
        private string emailAddress;
        private decimal moneyToInvest;
        private string brokerName;
        private Dictionary<string, Stock> portfolio;

        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            this.FullName = fullName;
            this.EmailAddress = emailAddress;
            this.MoneyToInvest = moneyToInvest;
            this.BrokerName = brokerName;
            this.portfolio = new Dictionary<string, Stock>();
        }

        public string FullName
        {
            get
            {
                return this.fullName;
            }
            private set
            {
                this.fullName = value;
            }
        }

        public string EmailAddress
        {
            get
            {
                return this.emailAddress;
            }
            private set
            {
                this.emailAddress = value;
            }
        }

        public decimal MoneyToInvest
        {
            get
            {
                return this.moneyToInvest;
            }
            private set
            {
                this.moneyToInvest = value;
            }
        }

        public string BrokerName
        {
            get
            {
                return this.brokerName;
            }
            private set
            {
                this.brokerName = value;
            }
        }

        public IReadOnlyDictionary<string, Stock> Portfolio => this.portfolio;

        public int Count => this.portfolio.Count;

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && this.MoneyToInvest >= stock.PricePerShare)
            {
                this.MoneyToInvest -= stock.PricePerShare;
                this.portfolio.Add(stock.CompanyName, stock);
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            if (!this.Portfolio.Any(x => x.Key == companyName))
            {
                return $"{companyName} does not exist.";
            }

            if (this.portfolio[companyName].PricePerShare > sellPrice)
            {
                return $"Cannot sell {companyName}.";
            }

            this.MoneyToInvest += sellPrice;
            this.portfolio.Remove(companyName);

            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName) => this.portfolio.FirstOrDefault(x => x.Key == companyName).Value;

        public Stock FindBiggestCompany() => this.portfolio.Select(x => x.Value).OrderByDescending(x => x.MarketCapitalization).FirstOrDefault();

        public string InvestorInformation()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"The investor {this.FullName} with a broker {this.BrokerName} has stocks:");
            output.AppendLine(string.Join(Environment.NewLine, this.portfolio.Values));

            return output.ToString().TrimEnd();
        }
    }
}
