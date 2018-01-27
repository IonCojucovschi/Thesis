using System;
using System.Collections.Generic;
using Int.Core.Application.Menu;
using Int.Core.Application.Menu.Contract;
using Splat;

namespace Core.Helpers.Manager
{
    public class MenuManager : BaseMenuManager
    {
        private static readonly Lazy<MenuManager> Service = new Lazy<MenuManager>(() => new MenuManager());

        private IList<IItemMenu> _menuList;

        private MenuManager()
        {
            Update();
        }

        public static MenuManager Instance => Service.Value;

        private static IMenu<IItemMenu> GetService =>
            Locator.Current.GetService<IMenu<IItemMenu>>(App.Instance.IsMock
                ? App.ServiceContractMock
                : App.ServiceContract);

        public override IList<IItemMenu> GetAll()
        {
            return _menuList;
        }

        public sealed override void Update()
        {
            _menuList = GetService?.Items;
        }
    }
}