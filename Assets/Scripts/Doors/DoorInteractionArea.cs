using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractionArea : Interactable
{
    public DoorBehaviour doorObj;

    protected override void Interact()
    {
        doorObj.InteractDoor();
    }
}
