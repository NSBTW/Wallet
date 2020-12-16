using Wallet.Database.Models;

namespace Wallet.Models
{
    public class Wallet
    {
        private string Id { get; }
        public double Value { get;  }
        
        public string CurrencyName { get;  }

        public Wallet(string id, double value, string currencyName)
        {
            Id = id;
            Value = value;
            CurrencyName = currencyName;
        }

    }
}