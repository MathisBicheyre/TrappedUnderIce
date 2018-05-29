using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public GameObject[] inventory = new GameObject[10];
    public Button[] inventoryButtons = new Button[10];

    public void AddItem(GameObject item)
    {
        bool itemAdded = false;
        
        //Find the 1st open slot in the inventory
        for(int i = 1; i < inventory.Length; i++)
        {
            if(inventory [i] == null)
            {
                inventory[i] = item;
                inventoryButtons[i].image.overrideSprite = item.GetComponent<SpriteRenderer>().sprite;
                Debug.Log(item.name + " was added");
                itemAdded = true;
                //do something with the object
                item.SendMessage("DoInteraction");
                break;
            }
        }

        //inventory full
        if(!itemAdded)
        {
            Debug.Log("Inventory is full, item not added");
        }
    }

    public bool FindItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == item)
            {
                return true;
            }
            
        }

        return false;
    }
    
   /* public GameObject FindItemByType(string itemType)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if(inventory[i] != null)
            {
                if(inventory[i].GetComponent<PickUp>().itemType == itemType)
                return inventory[i];
            }
        }
        return null;

    }

    public void RemoveItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == item)
            {
                //we found the item, remove it
                inventory[i] = null;
                Debug.Log(item.name + " was removed from inventory");
                //update UI
                inventoryButtons[i].image.overrideSprite = null;
                break;
            }
        }
    }
    */
}
