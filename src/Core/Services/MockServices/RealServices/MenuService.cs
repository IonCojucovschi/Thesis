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
                new MenuItem{Name=Library,ClickArgument=PageConstants.LibraryName},
                new MenuItem {Name = BibliotecaMea, ClickArgument = PageConstants.WantReadCon},
                new MenuItem {Name = Comunication, ClickArgument = PageConstants.UserAddedBooksCon},
                new MenuItem {Name = Account, ClickArgument = PageConstants.AccountName},
                new MenuItem {Name = Contacts, ClickArgument = PageConstants.ContactName}
            };
        }

        private string Dashboard => RMenu.Dashboard;
        private string Contacts => "Contacte";//RMenu.Contacts;
        private string BibliotecaMea => "Vreau sa citesc";///RMenu.Products;
        private string Comunication => "Am Adaugat";//RMenu.Comunication;
        private string Account => "Contul Meu";///RMenu.Account;


        private string Library = "Biblioteca";

        public IList<IItemMenu> Items { get; }
    }
}