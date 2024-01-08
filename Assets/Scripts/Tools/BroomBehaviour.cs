using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroomBehaviour : Interactable
{
    public Acquireable acquireable;
    protected override void Interact()
    {
        acquireable.Acquire();
    }
}
