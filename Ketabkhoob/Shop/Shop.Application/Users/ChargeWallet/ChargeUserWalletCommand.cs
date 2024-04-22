using Common.Application;
using Shop.Domain.UserAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users.ChargeWallet
{
    public class ChargeUserWalletCommand :IBaseCommand
    {
        public ChargeUserWalletCommand(long userId, int price,
            string description, bool isFinalized, WalletType type)
        {
            UserId = userId;
            Price = price;
            Description = description;
            IsFinalized = isFinalized;
            this.Type = type;
        }

        public long UserId { get; private set; }
        public int Price { get; private set; }
        public string Description { get; private set; }
        public bool IsFinalized { get; private set; }
        public WalletType Type { get; private set; }
    }
}
