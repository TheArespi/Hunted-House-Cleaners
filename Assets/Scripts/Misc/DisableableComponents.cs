using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableableComponents : MonoBehaviour
{
    public List<Behaviour> componentsToDisable = new List<Behaviour>();
    public bool Disable
    {
        get => _disable;
        set
        {
            _disable = value;
            _SetDisable(value);
        }
    }
    private bool _disable = false;

    private void Start()
    {
        _SetDisable(_disable);
    }
    private void _SetDisable(bool pDisable)
    {
        foreach (Behaviour component in componentsToDisable)
        {
            component.enabled = pDisable;
        }
    }
}
