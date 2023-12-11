using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Tests
{
    public class MTObject : MonoBehaviour
    {
        private IInventory inventory;

        private void Awake()
        {
            inventory = new InventorySlotsData(99);
        }

        private void LateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Add 1!");
                var item1 = new Item1();
                inventory.AddItem(this, item1);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("Add 2!");
                var item2 = new Item2();
                inventory.AddItem(this, item2);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("Remove 1!");
                inventory.TryRemove(this, 1, 1);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("Remove 2!");
                inventory.TryRemove(this, 2, 1);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("Display!");
                var items = inventory.GetAllItems();
                if (items.Length == 0) Debug.Log("Empty!");
                foreach (var item in items)
                {
                    Debug.Log("Name: " + item.Name + "; Count: " + item.Count);
                }
            }
        }
    }

    public class Item1 : InventoryItem
    {
        [SerializeField] private Sprite sprite;

        public override bool IsEquipped { get; set; } = false;
        public override long ID => 1;
        public override int Count { get; set; } = 1;
        public override string Name { get; } = "Item 1";
        public override Sprite Sprite { get => sprite; set => Sprite = value; }
    }

    public class Item2 : InventoryItem
    {
        [SerializeField] private Sprite sprite;

        public override bool IsEquipped { get; set; } = false;
        public override long ID => 2;
        public override int Count { get; set; } = 1;
        public override string Name { get; } = "Item 2";
        public override Sprite Sprite { get => sprite; set => Sprite = value; }
    }
}