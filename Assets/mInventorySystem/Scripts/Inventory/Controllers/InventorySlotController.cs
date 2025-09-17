namespace Inventory
{
    public class InventorySlotController
    {
        private readonly InventorySlotView _view;

        public InventorySlotController(IReadOnlyInventorySlot slot, InventorySlotView view)
        {
            _view = view;

            slot.ItemIdChanged += SlotOnItemIdChanged;
            slot.ItemAmountChanged += SlotOnItemAmountChanged;

            _view.Title = slot.ItemId;
            _view.Amount = slot.Amount;
        }
        
        private void SlotOnItemIdChanged(string newItemId)
        {
            _view.Title = newItemId;
        }
        
        private void SlotOnItemAmountChanged(int newAmount)
        {
            _view.Amount = newAmount;
        }
    }
}