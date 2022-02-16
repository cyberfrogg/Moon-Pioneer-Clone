﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Items.Container
{
    public class ContainerSlotsFactory : MonoBehaviour
    {
        [SerializeField] private ContainerSlot _slotPrefab;
        //[SerializeField] private float _slotSize = 0.25f;
        //[SerializeField] private float _slotGap = 0.1f;

        private readonly int _maxTotalMultipleSlots = 500;

        public ContainerSlot[] CreateSlots(Transform parent, int slotsCount, int sizeX = 3, int sizeZ = 2)
        {
            List<ContainerSlot> slots = new List<ContainerSlot>();

            int y = 0;
            while (true)
            {
                for (int x = 0, i = 0; x < sizeX; x++)
                {
                    for (int z = 0; z < sizeZ; z++)
                    {
                        if (slots.Count + 1 >= slotsCount)
                        {
                            return slots.ToArray();
                        }
                        if (i >= _maxTotalMultipleSlots)
                        {
                            throw new ArgumentOutOfRangeException($"Too many slots are instantiated. Max: {_maxTotalMultipleSlots}; Current: {_maxTotalMultipleSlots}; Slots count: {slotsCount}");
                        }

                        ContainerSlot slot = instantiateSlotPrefab(parent);

                        slot.transform.localPosition = new Vector3(x - (sizeX / 2), y, z - (sizeZ / 2));
                        slots.Add(slot);
                        i++;
                    }
                }
                y++;
            }
        }
        private ContainerSlot instantiateSlotPrefab(Transform parent)
        {
            ContainerSlot instance = Instantiate(_slotPrefab);

            instance.transform.SetParent(parent);
            instance.transform.localPosition = Vector3.zero;

            return instance;
        }
    }
}