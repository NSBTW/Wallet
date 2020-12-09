using System.Linq;
using Wallet.Database.Models.Commissions;

namespace Wallet.Database.Models
{
    public class WalletRecord
    {
        public string Id { get; set; }
        public AccountRecord AccountRecord { get; set; }
        public CurrencyRecord CurrencyRecord { get; set; }
        
        public double Value { get; set; }

    }
}