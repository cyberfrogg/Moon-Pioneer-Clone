using System;
using UnityEngine;

namespace Items.Container
{
    public class ContainerSlot : MonoBehaviour
    {
        public bool IsBusy
        {
            get
            {
                return _busyItem != null;
            }
        }
        public Item BusyItem { get => _busyItem; }

        private Item _busyItem;

        public void Attach(Item item)
        {
            _busyItem = item;
            item.OnSlotAttach(this);
        }
        public Item Detach()
        {
            Item nItem = _busyItem;
            _busyItem = null;

            nItem.OnSlotDetach(this);
            return nItem;
        }
    }
}
