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
        public StoragePad OutputStoragePads
        {
            get
            {
                return _storagePads.Where(x => x.Type == StorageBuildingType.Output).First();
            }
        }

        [SerializeField] private StoragePad[] _storagePads;
    }
}