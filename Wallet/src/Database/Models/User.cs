using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;


namespace Wallet
{
    public class User : IdentityUser
    {
        public List<Account> Accounts { get; set; }
        public List<PersonalCommission> PersonalCommissions { get; set; }
    }
}