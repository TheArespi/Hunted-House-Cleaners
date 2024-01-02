using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractionArea : MonoBehaviour
{
    public DoorBehaviour doorObj;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "Player")
            return;

        doorObj.SetPlayerCanInteract(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name != "Player")
            return;

        doorObj.SetPlayerCanInteract(false);
    }
}
