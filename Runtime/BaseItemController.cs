using UnityEngine;

namespace Inventory
{
    public class BaseItemState
    {
        public int Amount;
        public string Id;
    }

    public interface IITem
    {
        string Id { get; }
        int Add(int amount);
        int Remove(int amount);

    }
    public abstract class BaseItemController<TState, TConfig> : IITem where TState : BaseItemState where TConfig : BaseItemConfig
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

        public virtual int Add(int amount)
        {
            amount = PossibleAddAmount(amount);
            if (State.Amount + amount > Max())
            {
                Debug.LogError("Max amount exceed");
                return 0;
            }
            State.Amount += amount;
            return amount;
        }
        
        public virtual int Remove(int amount)
        {
            amount = PossibleRemoveAmount(amount);
            if (State.Amount - amount < Min())
            {
                Debug.LogError("Min amount exceed");
                return 0;
            }
            
            State.Amount -= amount;
            return amount;
        }
        
        public virtual void Set(int value)
        {
            State.Amount = Mathf.Clamp(value, Min(), Max());
        }

        public bool IsMaxedOut()
        {
            return Amount >= Max();
        }
        
        public bool CanAdd(int amount)
        {
            return Amount + amount <= Max();
        }

        public int PossibleAddAmount(int amount)
        {
            var missingToReachMax = MissingToReachMax();
            return Mathf.Min(missingToReachMax, amount);
        }

        public int PossibleRemoveAmount(int amount)
        {
            var missingToReachMin = MissingToReachMin();
            return Mathf.Min(missingToReachMin, amount);
        }

        public int MissingToReachMax()
        {
            return Max() - Amount;
        }

        public int MissingToReachMin()
        {
            return Amount - Min();
        }

        public virtual int Max() => int.MaxValue;
        public virtual int Min() => 0;
    }
}