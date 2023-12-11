using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Tests
{
    public static class InventoryTest
    {
        [MenuItem("Tests/InventoryTest")]
        public static void Test()
        {
            int allPassed = 0;
            int allFailed = 0;

            AddItem(0, ref allPassed, ref allFailed);
            AddItem(1, ref allPassed, ref allFailed);
            AddItem(100, ref allPassed, ref allFailed);

            TryRemoveItem(0, 0, ref allPassed, ref allFailed);
            TryRemoveItem(1, 1, ref allPassed, ref allFailed);
            TryRemoveItem(100, 1, ref allPassed, ref allFailed);
            TryRemoveItem(0, 1, ref allPassed, ref allFailed);
            TryRemoveItem(1, 100, ref allPassed, ref allFailed);

            Debug.Log($"Inventory: \nPASSED : {allPassed}\nFAILED : {allFailed}");
        }

        private static void AddItem(int count, ref int PASSED, ref int FAILED)
        {
            IInventory inventory = new InventorySlotsData(99);
            var item = new TestItem();
            var id = item.ID;
            item.Count = count;
            inventory.AddItem(null, item);
            if (inventory.GetItemCount(id) != count)
            {
                FAILED++;
                Debug.Log($"TRY ADD {count} TEST_ITEMS!\n" +
                    $"{inventory} has items : {inventory.GetItemCount(id)}\n" +
                    $"--------------------------------------------------------");
            }
            else
            {
                PASSED++;
            }


            var item1 = new TestItem();
            item1.Count = count;
            inventory.AddItem(null, item1);
            if (inventory.GetItemCount(id) != count * 2)
            {
                FAILED++;
                Debug.Log($"AFTER ADDING ANOTHER {count}, IT SHOULD HAVE BEEN {count * 2}\n" +
                    $"{inventory} has items : {inventory.GetItemCount(id)}\n" +
                    $"--------------------------------------------------------");
            }
            else
            {
                PASSED++;
            }
        }

        private static void TryRemoveItem(int was, int taken, ref int PASSED, ref int FAILED)
        {
            IInventory inventory = new InventorySlotsData(99);
            var item = new TestItem();
            item.Count = was;
            var id = item.ID;
            inventory.AddItem(null, item);

            var code = inventory.TryRemove(null, id, taken);

            if (was < taken)
            {
                if (code)
                {
                    FAILED++;
                    Debug.Log($"TRY REMOVE {taken} TEST_ITEMS, WAS : {was}\n" +
                        $"WAS: {was} < TAKEN: {taken} !BUT! deletion passed!\n" +
                        $"--------------------------------------------------------");
                }
                else
                {
                    PASSED++;
                }
            }
            else
            {
                if (!code)
                {
                    FAILED++;
                    Debug.Log($"TRY REMOVE {taken} TEST_ITEMS, WAS : {was}\n" +
                        $"WAS: {was} > TAKEN: {taken} !BUT! deletion failed!\n" +
                        $"--------------------------------------------------------");
                }
                else
                {
                    PASSED++;
                }
            }
        }
    }
}