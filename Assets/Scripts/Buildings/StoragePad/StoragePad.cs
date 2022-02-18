using Interactable;
using Items;
using Items.Container;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Buildings.Storage
{
    public class StoragePad : MonoBehaviour, IInteractable
    {
        public ItemsContainer ItemsContainer { get => _itemsContainer; }
        public StorageBuildingType Type { get => _storageType; }
        public float InteractionRadius { get => _interactionRadius; }

        [SerializeField] private StorageBuildingType _storageType;
        [SerializeField] private ItemsContainer _itemsContainer;
        [SerializeField] private float _interactionRadius = 1.5f;

        [Inject] private Interactables _interactables;

        public void Interact(Player.Player player)
        {
            if (ItemsContainer.Count == 0)
                return;

            if (!player.Backpack.ItemsContainer.CanAddItem())
                return;

            Item takenItem = null;
            if (!ItemsContainer.TakeItem(out takenItem))
                return;

            player.Backpack.ItemsContainer.AddItem(takenItem);
        }

        public void Register()
        {
            _interactables.Register(this);
        }
        public void Unregister()
        {
            _interactables.Unregister(this);
        }

        private void Awake()
        {
            Register();
        }
        private void OnDestroy()
        {
            Unregister();
        }
    }
}
