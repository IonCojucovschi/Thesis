using System;
using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.Widget;
using Core.Models.DAL.Contacts;
using Core.ViewModels;
using Droid.Page.Base;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Factories.Adapter.RecyclerView;
using Int.Droid.Wrappers;

namespace Droid.Page
{
    [Activity(Label = "Contact",
        MainLauncher = false,
        ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        Theme = "@style/AppTheme")]
    public partial class Contact : NavigationBasePage<ContactViewModel>
    {
        protected override int LayoutContentResource => Resource.Layout.contact;

        protected override void InitViews()
        {
            base.InitViews();

            ListViewYour.SetAdapter(ComponentAdapterRecyclerFactory.CreateAdapter((inflater, parent) =>
                                                                    new ContactCellViewHolder(inflater,
                                                                                              parent,
                                                                                              new ContactViewModel.ContactCell(ModelView))));

        }
    }

    public class ContactCellViewHolder : ComponentViewHolder<IItemContact>
    {

        public ContactCellViewHolder(LayoutInflater inflator, ViewGroup parent,
                                     ICrossCellViewHolder<IItemContact> cellModel)
            : base(inflator.Inflate(Resource.Layout.item_list_contact, parent, false), cellModel) { }

        [CrossView(nameof(ContactViewModel.ContactCell.Label))]
        [InjectView(Resource.Id.label)]
        public TextView Label { get; set; }

        [CrossView(nameof(ContactViewModel.ContactCell.Value))]
        [InjectView(Resource.Id.value)]
        public TextView Value { get; set; }

        [CrossView(nameof(ContactViewModel.ContactCell.ContactAction))]
        [InjectView(Resource.Id.Contact_activity)]
        public TextView ContactAction { get; set; }

        [CrossView(nameof(ContactViewModel.ContactCell.DashView))]
        [InjectView(Resource.Id.dash)]
        public View DashView { get; set; }

        [CrossView(nameof(ContactViewModel.ContactCell.CellContentRootView))]
        [InjectView(Resource.Id.cell_content_root_view)]
        public View CellContentRootView { get; set; }
    }
}