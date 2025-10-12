using System;

namespace Inventory
{
    [Serializable]
    public class ItemAmount
    {
        public BaseItemConfig Item;
        public int Amount;

        public ItemAmount(BaseItemConfig item, int amount)
        {
            Item = item;
            Amount = amount;
        }
    }
}