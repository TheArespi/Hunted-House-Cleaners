using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int inventorySize = 2;

    private List<Items.Item> content;
    private int _remainingSlots;

    private void Start()
    {
        //Add listener for item pickup
        Acquireable.playerPickedUp.AddListener(_playerPickedUp);

        //Initializing contents
        content = new List<Items.Item>();
        for (int i = 0; i < inventorySize; i++)
            content.Add(Items.Item.NONE);

        //Initializing _remainingSlots
        _remainingSlots = inventorySize;
    }
    public bool addToInventory(Items.Item item)
    {
        //If there are no more remaining slots
        if (_remainingSlots == 0)
            return false;

        for (int i = 0; i < inventorySize; i++)
        {
            if (content[i] == Items.Item.NONE)
            {
                content[i] = item;
                _remainingSlots--;

                Debug.Log(item + " Added to index " + i);
                return true;
            }
        }

        Debug.Log("Cannot add to inventory");

        return false;
    }
    public void dropOnHand()
    {
        if (content[0] == Items.Item.NONE)
            return;

        Instantiate(Items.itemsSingleton.GetPrefab(content[0]), new Vector3(transform.position.x, transform.position.y, 100), Quaternion.identity);
        content[0] = Items.Item.NONE;

        _remainingSlots++;
    }
    public void swapToHand(int inventoryIndex)
    {
        if (inventoryIndex >= inventorySize)
            return;

        //Switching index in parameter with on hand
        Items.Item tempItem = content[0];
        content[0] = content[inventoryIndex];
        content[inventoryIndex] = tempItem;
    }
    private void _playerPickedUp(string itemName, Items.Item item)
    {
        Debug.Log("Player is picking up " + itemName);
        Acquireable.successfulPickUp.Invoke(itemName, addToInventory(item));
    }
}
