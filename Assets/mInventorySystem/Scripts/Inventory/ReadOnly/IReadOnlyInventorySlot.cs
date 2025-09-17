using System;

namespace Inventory
{
    public interface IReadOnlyInventorySlot
    {
        string ItemId { get; }
        int Amount { get; }
        bool IsEmpty { get; }
        
        public event Action<string> ItemIdChanged;
        public event Action<int> ItemAmountChanged;
    }
}