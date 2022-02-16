using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public class Item : MonoBehaviour
    {
        public ItemType Type { get => _itemType; }

        [SerializeField] private ItemType _itemType;
    }
}
