using UnityEditor;

namespace Assets.Scripts.Tests
{
    public static class AllTests
    {
        [MenuItem("Tests/AllTests")]
        public static void Test()
        {
            InventoryTest.Test();
        }
    }
}