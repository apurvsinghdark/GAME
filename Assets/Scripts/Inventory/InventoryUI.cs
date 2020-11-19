using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemParent;
    public GameObject inventoryUI;
    Inventory inventory;
    public InventorySlot[] slots;

    private void Start() {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;

        Cursor.visible = false;
        slots = itemParent.GetComponentsInChildren<InventorySlot>();
    }
    private void Update() {
        if(Input.GetButtonDown("Inventory")) 
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }

        if (inventoryUI.activeSelf)
        {
            Cursor.visible = true;
        }
        else{
            Cursor.visible = false;
        }
    }

    public void UpdateUI()
    { 
        for( int i = 0; i < slots.Length; i++ )
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }

        }
    }
}
