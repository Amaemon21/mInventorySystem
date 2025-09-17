using System.Collections.Generic;

namespace Inventory
{
    public class InventoryGridController
    {
        private readonly List<InventorySlotController> _slotControllers = new();
        
        public InventoryGridController(IReadOnlyInventoryGrid inventory, InventoryView view)
        {
             var size = inventory.Size;
             var slots = inventory.GetSlots();

             for (int i = 0; i < size.x; i++)
             {
                 for (int j = 0; j < size.y; j++)
                 {
                     var index = i * size.y + j;
                     var slotView = view.GetInventorySlotsViews(index);
                     var slot = slots[i, j];
                     _slotControllers.Add(new InventorySlotController(slot, slotView));
                 }
             }
             
             view.OwnerId = inventory.OwnerId;
        }
    }
}