using UnityEngine;

namespace Assets.Scripts.Tests
{
    public class TestItem2 : InventoryItem
    {
        [SerializeField] private Sprite sprite;

        public override bool IsEquipped { get; set; } = false;
        public override long ID => 2;
        public override int Count { get; set; }
        public override string Name { get; } = "Test Item";
        public override Sprite Sprite { get => sprite; set => Sprite = value; }
    }
}