using UnityEngine;

public class ExampleItem : InventoryItem
{
    [SerializeField] private Sprite sprite;

    public override bool IsEquipped { get; set; } = false;
    public override long ID => 1;
    public override int Count { get; set; }
    public override string Name { get; } = "Example Item";
    public override Sprite Sprite { get => sprite; set => Sprite = value; }
}

