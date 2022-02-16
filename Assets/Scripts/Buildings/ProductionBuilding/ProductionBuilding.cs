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
        private bool _isProductionWorking;

        private void Start()
        {
            runPruductionWork();
        }
        private void OnDestroy()
        {
            _isProductionWorking = false;
        }
        private async Task runPruductionWork()
        {
            _isProductionWorking = true;

            while (_isProductionWorking)
            {
                doProductionWork();
                await Task.Delay((int)(PruductionRate * 1000));
            }
        }
        private bool doProductionWork()
        {
            if (OutputStoragePad.ItemsContainer.CanAddItem() == false)
                return false;

            Item newItem = _itemsFactory.CreateItem(_productionItemType);

            if (OutputStoragePad.ItemsContainer.AddItem(newItem) == false)
            {
                newItem.Disappear();
                return false;
            }

            newItem.transform.position = _outputPoint.position;

            return true;
        }
    }
}
