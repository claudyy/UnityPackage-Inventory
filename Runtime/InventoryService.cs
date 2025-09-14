using System;
using UnityUtility;

namespace Inventory
{
    public class InventoryService : Singleton<InventoryService>
    {
        public IInventory CreateController<TInventory>(string id) where TInventory : IInventory
        {
            var baseInventoryController = Activator.CreateInstance<TInventory>();
            baseInventoryController.Init(id);
            return baseInventoryController;
        }
    }
}