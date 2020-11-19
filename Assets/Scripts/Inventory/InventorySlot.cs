using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Item item;
    public Image icon;
    public Button removeButton;
    
    public void AddItem(Item _item)
    {
        item = _item;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void Remove()
    {
        Inventory.instance.RemoveItem(item);
    }
    
    public void Use()
    {
        if(item != null)
        {
            item.Use();
        }
    }
}
