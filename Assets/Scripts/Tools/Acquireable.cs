using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acquireable : MonoBehaviour
{
    public InventoryItem inventoryItem;
    private bool _playerCanAcquire = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "Player")
            return;

        _playerCanAcquire = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name != "Player")
            return;

        _playerCanAcquire = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(gameObject);
        }
    }
}
