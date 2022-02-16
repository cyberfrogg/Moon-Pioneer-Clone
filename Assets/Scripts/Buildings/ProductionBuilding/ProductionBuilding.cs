using Items;
using System;
using UnityEngine;

namespace Buildings
{
    public class ProductionBuilding : BuildingBase
    {
        public float PruductionRate { get => _productionRate; }
        public ItemType ProductionItemType { get => _productionItemType; }

        [SerializeField] private float _productionRate;
        [SerializeField] private ItemType _productionItemType;
    }
}
