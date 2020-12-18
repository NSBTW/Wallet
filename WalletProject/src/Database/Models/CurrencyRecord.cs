using System.Collections.Generic;
using Wallet.Database.Models.Commissions;

namespace Wallet.Database.Models
{
    public class CurrencyRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<CommissionRecord> Commissions { get; set; }
    }
}