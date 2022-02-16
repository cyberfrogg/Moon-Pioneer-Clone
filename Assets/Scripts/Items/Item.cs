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

        [SerializeField] private ItemType _itemType;
        [SerializeField] private float _itemPositionLerp = 10f;

        private ItemsContainer _currentContainer;
        private Action<bool> _onMovementToStorageDone;

        public void GoToStoragePad(ItemsContainer container, Action<bool> onMovementDone)
        {
            _onMovementToStorageDone?.Invoke(false);
            _onMovementToStorageDone = null;

            _currentContainer = container;
            _onMovementToStorageDone += onMovementDone;
        }
        public void Disappear()
        {
            Debug.Log("TODO: Object need to be properly destroyed on scene and in Lists");
        }

        private void Update()
        {
            if (_currentContainer == null)
            {
                return;
            }

            transform.position = Vector3.Lerp(
                transform.position,
                _currentContainer.transform.position,
                _itemPositionLerp * Time.deltaTime
                );

            float distanceToTarget = Vector3.Distance(transform.position, _currentContainer.transform.position);
            if (distanceToTarget <= 0.1f)
            {
                _currentContainer = null;
                _onMovementToStorageDone?.Invoke(true);
            }
        }
    }
}
