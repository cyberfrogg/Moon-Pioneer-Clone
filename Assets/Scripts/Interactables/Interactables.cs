using System;
using System.Collections.Generic;
using UnityEngine;

namespace Interactable
{
    public class Interactables : MonoBehaviour
    {
        private List<IInteractable> _interactables = new List<IInteractable>();

        public IReadOnlyCollection<IInteractable> GetAll()
        {
            return _interactables.AsReadOnly();
        }

        public bool Register(IInteractable interactable)
        {
            if (_interactables.Contains(interactable))
            {
                Debug.LogWarning("Interactable object already exists!");
                return false;
            }

            _interactables.Add(interactable);
            return true;
        }
        public bool Unregister(IInteractable interactable)
        {
            if (!_interactables.Contains(interactable))
            {
                Debug.LogWarning("Interactable object doesn't exists");
                return false;
            }

            return _interactables.Remove(interactable);
        }
    }
}
