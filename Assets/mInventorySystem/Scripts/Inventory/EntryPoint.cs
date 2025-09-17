using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Inventory
{
    public class EntryPoint : MonoBehaviour
    {
        private const string OWNER_1 = "MAIN";
        private const string OWNER_2 = "NPC";
        private readonly string[] _itemsIds = {"Apple", "Orange", "Banana", "Pineapple"};
        
        [SerializeField] private ScreenView _screenView;
        
        private InventoryService _inventoryService;
        private ScreenController _screenController;
        
        private string _cachedOwnerId;

        private void Awake()
        {
            var gameStateProvider = new GameStatePlayerPrefsProvider();
            
            gameStateProvider.Load();
            
            _inventoryService = new InventoryService(gameStateProvider);

            var gameState = gameStateProvider.GameState;

            foreach (var inventoryData in gameState.Inventories)
            {
                _inventoryService.RegisterInventory(inventoryData);
            }
            
            _screenController = new ScreenController(_inventoryService, _screenView);
            _screenController.OpenInventory(OWNER_1);
            _cachedOwnerId = OWNER_1;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _screenController.OpenInventory(OWNER_1);
                _cachedOwnerId = OWNER_1;
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _screenController.OpenInventory(OWNER_2);
                _cachedOwnerId = OWNER_2;
            }
            
            if (Input.GetKeyDown(KeyCode.A))
            {
                var rIndex = Random.Range(0, _itemsIds.Length);
                var rItemId = _itemsIds[rIndex];
                var rItemAmount = Random.Range(1, 50);
                
                var result = _inventoryService.AddItemsToInventory(_cachedOwnerId, rItemId, rItemAmount);
                Debug.Log($"Items added. id - {rItemId}, amount - {result.ItemsAddedAmount}");
            }
            
            if (Input.GetKeyDown(KeyCode.R))
            {
                var rIndex = Random.Range(0, _itemsIds.Length);
                var rItemId = _itemsIds[rIndex];
                var rItemAmount = Random.Range(1, 50);
                
                var result = _inventoryService.RemoveItemsToInventory(_cachedOwnerId, rItemId, rItemAmount);
                Debug.Log($"Items added. id - {rItemId}, Try to remove  - {result.Success}");
            }
        }
    }
}