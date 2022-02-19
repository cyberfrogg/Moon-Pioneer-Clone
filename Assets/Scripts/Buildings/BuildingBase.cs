using Buildings.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Buildings
{
    public abstract class BuildingBase : MonoBehaviour
    {
        public IReadOnlyCollection<StoragePad> InputStoragePads
        {
            get
            {
                return _storagePads.Where(x => x.Type == StorageBuildingType.Input) as IReadOnlyCollection<StoragePad>;
            }
        }
        public StoragePad OutputStoragePad
        {
            get
            {
                return _storagePads.Where(x => x.Type == StorageBuildingType.Output).First();
            }
        }
        protected BuildingProductionTimer ProductionTimer { get => _productionTimer; }

        [SerializeField] private StoragePad[] _storagePads;
        [SerializeField] private BuildingProductionTimer _productionTimer;

        private void OnDestroy()
        {
            _productionTimer.Stop();
        }
    }
}