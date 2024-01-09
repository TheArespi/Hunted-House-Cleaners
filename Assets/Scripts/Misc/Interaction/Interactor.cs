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
    private int _currentTargetIndex;

    private void Start()
    {
        Interactable.CanInteractStatus.AddListener(CanInteractStatusChanged);

        _currentTarget = null;
        _currentTargetIndex = 0;
    }
    private void Update()
    {
        //change this to mouse scroll
        if (Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            _currentTargetIndex++;
            if (_currentTargetIndex >= _interactableNames.Count)
                _currentTargetIndex = 0;
            _currentTarget = _interactables[_interactableNames[_currentTargetIndex]];
            targetSelect.Invoke(_currentTarget);
        } else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _currentTargetIndex--;
            if (_currentTargetIndex < 0)
                _currentTargetIndex = _interactableNames.Count - 1;
            _currentTarget = _interactables[_interactableNames[_currentTargetIndex]];
            targetSelect.Invoke(_currentTarget);
        }

    }
    private void CanInteractStatusChanged(Interactable pInteractable, bool pCanInteract)
    {
        if (pCanInteract)
        {
            if (!_interactableNames.Contains(pInteractable.name))
                _interactableNames.Add(pInteractable.name);

            _interactables[pInteractable.name] = pInteractable;

            int interactableIndex = _interactableNames.FindIndex(interactableName => interactableName.Equals(pInteractable.name));

            if (_currentTarget == null)
            {
                _currentTargetIndex = interactableIndex;
                _currentTarget = pInteractable;
                targetSelect.Invoke(pInteractable);
            }
        }
        else
        {
            if (_interactableNames.Contains(pInteractable.name))
                _interactableNames.Remove(pInteractable.name);

            int previousIndex = _interactableNames.FindIndex(interactableName => interactableName.Equals(pInteractable.name));

            _interactables.Remove(pInteractable.name);

            if (_currentTarget.name == pInteractable.name) 
            {
                if (_interactableNames.Count > 0)
                {
                    if (previousIndex > 0 && previousIndex < _interactableNames.Count)
                    {
                        _currentTarget = _interactables[_interactableNames[previousIndex]];
                        _currentTargetIndex = previousIndex;
                    }
                    else
                    {
                        _currentTarget = _interactables[_interactableNames[_interactableNames.Count - 1]];
                        _currentTargetIndex = _interactableNames.Count - 1;
                    }
                }
                else
                {
                    _currentTarget = null;
                    _currentTargetIndex = -1;
                }
                targetSelect.Invoke(_currentTarget);
            }
        }
    }
}
