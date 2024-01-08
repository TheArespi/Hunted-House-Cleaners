using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [Header("Interactable")]
    public SpriteRenderer spriteRenderer;
    public KeyCode interactKey = KeyCode.Space;
    public string playerObjectName = "Player";

    private bool _canInteract = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != playerObjectName)
            return;

        _canInteract = true;
        spriteRenderer.color = Color.red;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name != playerObjectName)
            return;

        _canInteract = false;
        spriteRenderer.color = Color.white;
    }
    private void Update()
    {
        if (!_canInteract) return;

        if (Input.GetKeyDown(interactKey))
            Interact();
    }
    protected abstract void Interact();
}
