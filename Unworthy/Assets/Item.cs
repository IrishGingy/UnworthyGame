using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    //public bool isDefaultItem = false;

    // "Virtual" derives different objects from the item and that way you can do different things to different items.
    public virtual void Use()
    {
        Debug.Log("Using" + name);
    }
}
