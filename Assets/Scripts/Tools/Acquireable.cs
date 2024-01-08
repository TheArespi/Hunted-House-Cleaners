using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Acquireable : MonoBehaviour
{
    public static UnityEvent<string, Items.Item> playerPickedUp = new UnityEvent<string, Items.Item>();
    public static UnityEvent<string, bool> successfulPickUp = new UnityEvent<string, bool>();

    public Items.Item item;

    private bool _playerCanAcquire = false;
    private void Start()
    {
        successfulPickUp.AddListener(successfullyPickedUp);
    }
    public void Acquire() => playerPickedUp.Invoke(gameObject.name, item);
    private void successfullyPickedUp(string itemName, bool success)
    {
        if (itemName != gameObject.name)
            return;

        Debug.Log((success ? "successfully" : "failed to") + "pick up " + itemName);

        if (success)
            Destroy(gameObject);
    }
}
