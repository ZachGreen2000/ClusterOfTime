using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemsToPickup;

    public void PickupItem(int id)
    {
        bool result = inventoryManager.AddItem(itemsToPickup[id]);

        if(result == true)
        {
            Debug.Log("Item Added");
        }else
        {
            Debug.Log("Item Not Added");
        }
    }
    public void UseSelectedItem()
    {
        Item recievedItem = inventoryManager.GetSelectedItem(true);
    }
    public void DropItem()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Item recievedItem = inventoryManager.GetSelectedItem(true);
        }
    }
}
