using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableableComponents : MonoBehaviour
{
    public List<Behaviour> componentsToDisable = new List<Behaviour>();
    public bool disable = false;

    private void Start()
    {
        if (!disable)
            return;

        foreach (Behaviour component in componentsToDisable)
        {
            component.enabled = false;
        }
    }
}
