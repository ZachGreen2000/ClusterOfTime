using Unity.VisualScripting;
using UnityEngine;

public class Selling : MonoBehaviour
{
    int npcBudget = 10000;
    int Item1Price = 100;
    int Item2Price = 150;
    int Item1QuantityOnMarket = 5;
    int Item2QuantityOnMarket = 10;
    int ItemQuantityBought = 1;
    int PlayerRevInMarket = 0;
    int Item1InInventory = 10;
    int Item2InInventory = 10;

    void BuyItem1()
    {
        if (npcBudget >= Item1Price && Item1QuantityOnMarket >= 1)
        {
            Item1QuantityOnMarket = Item1QuantityOnMarket - ItemQuantityBought;
            npcBudget = npcBudget - Item1Price;
            PlayerRevInMarket = PlayerRevInMarket + Item1Price;
        }
        else
        {
            Debug.Log("Cannot Purchase Item");
        }
    }
    void BuyItem2()
    {
        if (npcBudget >= Item2Price && Item2QuantityOnMarket >= 1)
        {
            Item2QuantityOnMarket = Item2QuantityOnMarket - ItemQuantityBought;
            npcBudget = npcBudget - Item2Price;
            PlayerRevInMarket = PlayerRevInMarket + Item2Price;
        }
        else
        {
            Debug.Log("Cannot Purchase Item");
        }
    }
    void AddItem1()
    {
        if (Item1InInventory >= 1)
        {
            Item1QuantityOnMarket++;
            Item1InInventory--;
        }
        else
        {
            Debug.Log("No Item in Inventory");
        }
    }
    void AddItem2()
    {
        if (Item2InInventory >= 1)
        {
            Item2QuantityOnMarket++;
            Item2InInventory--;
        }
        else
        {
            Debug.Log("No Item in Inventory");
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            BuyItem1();
            Debug.Log("NPC Budget = " + npcBudget);
            Debug.Log("Amount of Item 1 on Market: " + Item1QuantityOnMarket);
            Debug.Log("Amount of Item 2 on Market: " + Item2QuantityOnMarket);
            Debug.Log("Amount of Player Gold " + PlayerRevInMarket);
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            BuyItem2();
            Debug.Log("NPC Budget = " + npcBudget);
            Debug.Log("Amount of Item 1 on Market: " + Item1QuantityOnMarket);
            Debug.Log("Amount of Item 2 on Market: " + Item2QuantityOnMarket);
            Debug.Log("Amount of Player Gold " + PlayerRevInMarket);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            AddItem1();
            Debug.Log("Amount of Item 1 on Market: " + Item1QuantityOnMarket);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            AddItem2();
            Debug.Log("Amount of Item 2 on Market: " + Item2QuantityOnMarket);
        }
    }
}
