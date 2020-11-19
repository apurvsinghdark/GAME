using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : Interactable
{
    public Item item;
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    private void PickUp()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {       
            print("Interacted with " + item.name);
            bool wasPickedUp = Inventory.instance.AddItem(item);

            if(wasPickedUp)
                Destroy(gameObject);
        }
    }
}
