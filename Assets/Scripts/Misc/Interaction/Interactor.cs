using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactor : MonoBehaviour
{
    public static UnityEvent<Interactable> targetSelect = new UnityEvent<Interactable>();

    private Dictionary<string, Interactable> _interactables = new Dictionary<string, Interactable>();
    private List<string> _interactableNames = new List<string>();
    private Interactable _currentTarget;

    private void Start()
    {
        Interactable.CanInteractStatus.AddListener(CanInteractStatusChanged);

        _currentTarget = null;
    }
    private void CanInteractStatusChanged(Interactable pInteractable, bool pCanInteract)
    {
        if (pCanInteract)
        {
            if (!_interactableNames.Contains(pInteractable.gameObject.name))
                _interactableNames.Add(pInteractable.gameObject.name);

            _interactables[pInteractable.gameObject.name] = pInteractable;

            if (_currentTarget == null)
            {
                _currentTarget = pInteractable;
                targetSelect.Invoke(pInteractable);
            }
        }
        else
        {
            if (_interactableNames.Contains(pInteractable.gameObject.name))
                _interactableNames.Remove(pInteractable.gameObject.name);

            int previousIndex = _interactableNames.FindIndex(interactableName => interactableName.Equals(pInteractable.name));

            _interactables.Remove(pInteractable.gameObject.name);

            if (_currentTarget.name == pInteractable.name) 
            {
                if (_interactableNames.Count > 0)
                {
                    if (previousIndex < _interactableNames.Count)
                        _currentTarget = _interactables[_interactableNames[previousIndex]];
                    else
                        _currentTarget = _interactables[_interactableNames[_interactableNames.Count - 1]];
                }
                else
                {
                    _currentTarget = null;
                }
                targetSelect.Invoke(_currentTarget);
            }
        }
    }
}
