namespace Inventory
{
    public class ScreenController
    {
        private readonly InventoryService _inventoryService;
        private readonly ScreenView _view;

        private InventoryGridController _currentInventoryGridController;
        
        public ScreenController(InventoryService inventoryService, ScreenView view)
        {
            _inventoryService = inventoryService;
            _view = view;
        }

        public void OpenInventory(string ownerId)
        {
            var inventory = _inventoryService.GetInventory(ownerId);
            var inventoryView = _view.InventoryView;
            
            _currentInventoryGridController = new InventoryGridController(inventory, inventoryView);
        }
    }
}