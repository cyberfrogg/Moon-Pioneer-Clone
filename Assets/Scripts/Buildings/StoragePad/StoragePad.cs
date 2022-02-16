using Items;
using Items.Container;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Buildings.Storage
{
    public class StoragePad : MonoBehaviour
    {
        public ItemsContainer ItemsContainer
        {
            get
            {
                return _itemsContainer;
            }
        }
        public StorageBuildingType Type { get => _storageType; }

        [SerializeField] private StorageBuildingType _storageType;
        [SerializeField] private ItemsContainer _itemsContainer;
    }
}
