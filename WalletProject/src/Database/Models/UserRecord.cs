using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Wallet.Database.Models.Commissions;

namespace Wallet.Database.Models
{
    public class UserRecord : IdentityUser
    {
        public List<AccountRecord> Accounts { get; set; }
        public List<CommissionRecord> PersonalCommissions { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}