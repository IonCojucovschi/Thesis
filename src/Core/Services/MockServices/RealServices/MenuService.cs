using System.Collections.Generic;
using Core.Helpers;
using Core.Models.DAL;
using Core.Resources.Locales.Page;
using Int.Core.Application.Menu.Contract;

namespace Core.Services.RealServices
{
    public class MenuService : IMenu<IItemMenu>
    {
        public MenuService()
        {
            Items = new List<IItemMenu>
            {
                new MenuItem {Name = Dashboard, ClickArgument = PageConstants.DashboardName},
                new MenuItem {Name = Account, ClickArgument = PageConstants.AccountName},
                new MenuItem{Name=Library,ClickArgument=PageConstants.LibraryName},
                new MenuItem {Name = Products, ClickArgument = PageConstants.ProductName},
                new MenuItem {Name = Comunication, ClickArgument = PageConstants.ComunicationName},
                new MenuItem {Name = Contacts, ClickArgument = PageConstants.ContactName}
            };
        }

        private string Dashboard => RMenu.Dashboard;
        private string Contacts => "Contacte";//RMenu.Contacts;
        private string Products => "Biblioteca";///RMenu.Products;
        private string Comunication => "Cartile mele";//RMenu.Comunication;
        private string Account => RMenu.Account;


        private string Library = "Library";

        public IList<IItemMenu> Items { get; }
    }
}