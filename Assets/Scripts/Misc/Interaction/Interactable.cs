using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Interactable : MonoBehaviour
{
    public static UnityEvent<Interactable, bool> CanInteractStatus = new UnityEvent<Interactable, bool>();

    [Header("Interactable")]
    public SpriteRenderer spriteRenderer;
    public KeyCode interactKey = KeyCode.Space;
    public string playerObjectName = "Player";

    private bool _canInteract = false;
    private void Start()
    {
        Interactor.targetSelect.AddListener(interactableSelect);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != playerObjectName)
            return;
        
        CanInteractStatus.Invoke(this, true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name != playerObjectName)
            return;

        CanInteractStatus.Invoke(this, false);
    }
    private void Update()
    {
        if (!_canInteract) return;

        if (Input.GetKeyDown(interactKey))
            Interact();
    }
    private void interactableSelect(Interactable pInteractable)
    {
        _canInteract = pInteractable && pInteractable.name == name;
        spriteRenderer.color = pInteractable && pInteractable.name == name ? Color.red : Color.white;
    }
    protected abstract void Interact();
}
