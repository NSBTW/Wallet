using System;
using System.Collections.Generic;
using Wallet.Database.Models.Commissions;

namespace Wallet.Database.Models
{
    public class CurrencyRecord
    {
        public  string Id { get; set; }

        public List<CommissionRecord> Commissions { get; set; }
        public string Name { get; set; }
        public double MaxTransfer { get; set; }
        public double MaxDeposit { get; set; }
        public double MaxWithdrawal { get; set; }
    }
}