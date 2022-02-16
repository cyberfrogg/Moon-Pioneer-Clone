using Items;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Buildings
{
    public class StoragePad
    {
        public StorageBuildingType Type { get => _storageType; }

        [SerializeField] private StorageBuildingType _storageType;
        [SerializeField] private int _capacity = 10;

        private List<Item> _items = new List<Item>();

        public bool AddItem(Item item)
        {
            if (_items.Count >= _capacity)
            {
                return false;
            }

            return true;
        }
        public bool TakeItem(out Item item)
        {
            if (_items.Count == 0)
            {
                item = null;
                return false;
            }

            item = _items[_items.Count - 1];
            _items.RemoveAt(_items.Count - 1);

            return true;
        }
    }
}
