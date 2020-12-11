using Wallet.Database.Models;

namespace Wallet.Models
{
    public class Wallet
    {
        private string Id { get; set; }
        public double Value { get; set; }
        
        public string CurrencyName { get; set; }

        public Wallet(string id, double value, string currencyName)
        {
            Id = id;
            Value = value;
            CurrencyName = currencyName;
        }

    }
}