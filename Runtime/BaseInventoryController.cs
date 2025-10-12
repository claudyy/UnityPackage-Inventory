using System.Collections.Generic;

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
    public class BaseItemController<TState, TConfig> : IITem where TState : BaseItemState where TConfig : BaseItemConfig
    {
        public string Id => Config.Id;
        public int Amount => State.Amount;
        protected TConfig Config;
        protected TState State;

        public void Init(TConfig config, TState state)
        {
            Config = config;
            State = state;
        }

        public virtual void Add(int amount)
        {
            State.Amount += amount;
        }
        
        public virtual void Remove(int amount)
        {
            State.Amount -= amount;
        }
    }

    public interface IInventory
    {
        public string Id { get; } 
        void Init(string id);
    }

    public interface IInventoryOwner
    {
        IInventory GetInventory();
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