using Buildings.Storage;
using Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Buildings
{
    public class CrafterBuilding : BuildingBase
    {
        [SerializeField] private StoragePad _outputStorage;
        [SerializeField] private StoragePad[] _inputStorages;
        [SerializeField] private ItemType _prudctionItem;
        [SerializeField] private ItemType[] _consumtionItems;
    }
}
