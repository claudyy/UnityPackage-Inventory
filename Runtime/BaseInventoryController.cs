using System.Collections.Generic;

namespace Inventory
{

    public interface IInventory
    {
        public string Id { get; } 
        void Init(string id);
    }

    public interface IInventoryOwner
    {
        IInventory GetInventory();
    }
    public abstract class BaseInventoryController<TITem> : IInventory where TITem : IITem
    {
        public string Id { get; private set; }
        protected List<TITem> Items = new List<TITem>();

        public void Init(string id)
        {
            Id = id;
        }
        
        public List<TITem> GetAll()
        {
            return new List<TITem>(Items);
        }

        protected TITem GetOrCreateController(BaseItemConfig config)
        {
            var index = Items.FindIndex(i => i.Id == config.Id);
            if (index == -1)
            {
                var itemController = CreateAndAddController(config);
                return itemController;
            }
            else
            {
                return Items[index];
            }
        }

        protected abstract TITem CreateAndAddController(BaseItemConfig config);
        public int Add(BaseItemConfig ammoType, int ammo)
        {
            var controller = GetOrCreateController(ammoType);
            return controller.Add(ammo);
        }

        public int RemoveAmount(BaseItemConfig ammoType, int neededAmmo)
        {
            var controller = GetOrCreateController(ammoType);
            return controller.Remove(neededAmmo);
        }
        
        public void Remove(BaseItemConfig item, int amount)
        {
            var controller = GetOrCreateController(item);
            controller.Remove(amount);
        }
    }
}