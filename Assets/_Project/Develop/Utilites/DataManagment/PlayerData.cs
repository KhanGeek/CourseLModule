using System.Collections.Generic;

namespace _Project.Develop
{
    public class PlayerData : ISaveData
    {
        public Dictionary<CurrencyTypes, int> WalletData;
    }
}