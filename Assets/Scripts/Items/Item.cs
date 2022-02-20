using Buildings.Storage;
using Items.Container;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public class Item : MonoBehaviour
    {
        public ItemType Type { get => _itemType; }
        public Action<Item> OnDisappear;

        [SerializeField] private ItemType _itemType;
        [SerializeField] private float _itemPositionLerp = 10f;

        private ContainerSlot _currentSlot;
        private Action<bool> _onMovementToStorageDone;

        public void GoToSlot(ItemsContainer container, Action<bool> onMovementDone)
        {
            _onMovementToStorageDone?.Invoke(false);
            _onMovementToStorageDone = null;

            _currentSlot = container.AttachItemToSlot(this);
            _onMovementToStorageDone += onMovementDone;
        }
        public void Disappear()
        {
            OnDisappear?.Invoke(this);
            Destroy(gameObject);
        }

        public void OnSlotAttach(ContainerSlot slot)
        {
            transform.SetParent(slot.transform);
        }
        public void OnSlotDetach(ContainerSlot slot)
        {
            _onMovementToStorageDone?.Invoke(false);
            _onMovementToStorageDone = null;
            _currentSlot = null;
            transform.SetParent(null);
        }

        private void Update()
        {
            if (_currentSlot == null)
            {
                return;
            }

            transform.position = Vector3.Lerp(
                transform.position,
                _currentSlot.transform.position,
                _itemPositionLerp * Time.deltaTime
                );

            float distanceToTarget = Vector3.Distance(transform.position, _currentSlot.transform.position);
            if (distanceToTarget <= 0.1f)
            {
                _currentSlot = null;
                _onMovementToStorageDone?.Invoke(true);
            }
        }
    }
}
