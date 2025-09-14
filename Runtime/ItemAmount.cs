using System;

namespace Inventory
{
    [Serializable]
    public class ItemAmount
    {
        public BaseItemConfig Item;
        public int Amount;
    }
}