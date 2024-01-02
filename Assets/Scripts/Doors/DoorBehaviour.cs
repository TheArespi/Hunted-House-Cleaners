using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public DisableableComponents openCollision;
    public DisableableComponents closeCollision;
    public Animator animator;

    private bool _playerCanInteract = false;
    private bool _open = false;
    public void SetPlayerCanInteract(bool pPlayerCanInteract)
    {
        _playerCanInteract = pPlayerCanInteract;
        Debug.Log("Player " + (_playerCanInteract ? "can" : "cannot") + " interact with door");
    }
    private void Start()
    {
        DisableUpdated();
    }
    private void Update()
    {
        if (!_playerCanInteract)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _open = !_open;
            DisableUpdated();
            Debug.Log("Door is " + (_open ? "" : "not ") + "open");
        }
    }
    private void DisableUpdated()
    {
        openCollision.Disable = _open;
        closeCollision.Disable = !_open;
        animator.SetBool("open", _open);
    }
}
