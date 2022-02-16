using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Items.Container
{
    public class ItemsContainer : MonoBehaviour
    {
        public bool IsFull
        {
            get
            {
                return _items.Count >= _capacity;
            }
        }

        [SerializeField] private int _capacity = 10;

        private List<Item> _items = new List<Item>();

        public bool AddItem(Item item)
        {
            if (!CanAddItem())
            {
                return false;
            }

            _items.Add(item);
            item.GoToStoragePad(this, null);
            return true;
        }
        public bool TakeItem(out Item item)
        {
            if (!CanTakeItem())
            {
                item = null;
                return false;
            }

            item = _items[_items.Count - 1];
            _items.RemoveAt(_items.Count - 1);

            return true;
        }

        public bool CanAddItem()
        {
            return !IsFull;
        }
        public bool CanTakeItem()
        {
            return _items.Count > 0;
        }
    }
}
