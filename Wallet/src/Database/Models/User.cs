using System.Collections.Generic;

namespace Wallet
{
    public class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public UserType Type { get; set; }
        
        public List<Account> Accounts { get; set; }
        public List<PersonalCommission> PersonalCommissions { get; set; }
    }
}