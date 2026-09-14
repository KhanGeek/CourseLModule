using System;
using System.Collections.Generic;
using System.Linq;

namespace _Project.Develop
{
    public class WalletService
    {
        private Dictionary<CurrencyTypes, ReactiveVariable<int>> _currencies;

        public WalletService(Dictionary<CurrencyTypes, ReactiveVariable<int>> currencies)
        {
            _currencies = new Dictionary<CurrencyTypes, ReactiveVariable<int>>(currencies);
        }

        public List<CurrencyTypes> AvailableCurrencies => _currencies.Keys.ToList();

        public IReadOnlyReactiveVariable<int> GetCurrencies(CurrencyTypes type) => _currencies[type];

        public bool Enough(CurrencyTypes type, int amount)
        {
            if(amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));
            
            return _currencies[type].Value >= amount;
        }

        public void Add(CurrencyTypes type, int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));
            
            _currencies[type].Value += amount;
        }
        
        public void Spend(CurrencyTypes type, int amount)
        {
            if(Enough(type, amount)==false)
                throw new InvalidOperationException("Not enough: "+ type.ToString());
            
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));
            
            _currencies[type].Value -= amount;
        }
    }
}