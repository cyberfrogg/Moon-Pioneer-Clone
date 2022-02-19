using Items;
using Items.Factory;
using System;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Buildings
{
    public class ProductionBuilding : BuildingBase
    {
        public float PruductionRate { get => _productionRate; }
        public ItemType ProductionItemType { get => _productionItemType; }

        [SerializeField] private float _productionRate;
        [SerializeField] private ItemType _productionItemType;
        [Space]
        [SerializeField] private Transform _outputPoint;

        [Inject] private ItemsFactory _itemsFactory;

        private void Start()
        {
            ProductionTimer.Ticked += produce;
            ProductionTimer.Start();
        }
        private void produce()
        {
            if (OutputStoragePad.ItemsContainer.CanAddItem() == false)
                return;

            Item newItem = _itemsFactory.CreateItem(_productionItemType);

            if (OutputStoragePad.ItemsContainer.AddItem(newItem) == false)
            {
                newItem.Disappear();
                return;
            }

            newItem.transform.position = _outputPoint.position;
        }
    }
}
