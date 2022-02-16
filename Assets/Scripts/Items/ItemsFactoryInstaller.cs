using System;
using UnityEngine;
using Zenject;

namespace Items.Factory.Installer
{
    public class ItemsFactoryInstaller : MonoInstaller
    {
        [SerializeField] private ItemsFactory _itemsFactory;

        public override void InstallBindings()
        {
            base.InstallBindings();

            Container.Bind<ItemsFactory>().FromInstance(_itemsFactory).AsSingle().NonLazy();
        }
    }
}
