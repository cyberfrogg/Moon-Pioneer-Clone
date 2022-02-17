using System;
using UnityEngine;

namespace Interactable
{
    public interface IInteractable
    {
        public float InteractionRadius { get; }
        public void Interact();
        public void Register();
        public void Unregister();
    }
}
