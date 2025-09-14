
using System;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Inventory
{
    public class BaseItemState
    {
        public int Amount;
        public string Id;
    }

    public interface IITem
    {
        
    }
    public class BaseItemController<TState> : IITem where TState : BaseItemState
    {
        public string Id => _config.Id;
        public int Amount => _state.Amount;
        private BaseItemConfig _config;
        private TState _state;

        public void Init(BaseItemConfig config, TState state)
        {
            _config = config;
            _state = state;
        }

        public void Add(int amount)
        {
            _state.Amount += amount;
        }
    }

    public interface IInventory
    {
        public string Id { get; } 
        void Init(string id);
    }
    
    public class BaseInventoryController<TITem> : IInventory where TITem : IITem
    {
        public string Id { get; private set; }
        protected List<TITem> Items = new List<TITem>();

        public void Init(string id)
        {
            Id = id;
        }
        
       
    }
}