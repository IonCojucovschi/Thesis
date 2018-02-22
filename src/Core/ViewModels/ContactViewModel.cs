using System;
using System.Collections.Generic;
using Core.Helpers;
using Core.Models.DAL.Contacts;
using Core.Resources.Colors;
using Core.Resources.Locales.Page;
using Core.ViewModels.Base;
using Int.Core.Application.Widget.Contract;
using Int.Core.Application.Widget.Contract.Table;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Core.Extensions;

namespace Core.ViewModels
{
    public class ContactViewModel : ProjectNavigationBaseViewModel
    {
        protected override string HeaderText => RAccount.ContactsHeaderText.ToUpperInvariant();

        protected override HeaderAreaActionType HeaderAreaAction => HeaderAreaActionType.RightSideMenu;

        private readonly string AdresSede = RContact.AdresSede;
        private readonly string Consultant = RContact.Consultant;
        private readonly string GreenNumber = RContact.GreenNumber;
        private readonly string Call = RContact.Call;


        [CrossView]
        public IText TitleAccountLabel { get; protected set; }

        [CrossView]
        public IListView ListViewYour { get; protected set; }

        [CrossView]
        public IImage ShadowImage { get; protected set; }


        public override void UpdateData()
        {
            base.UpdateData();

            ListViewYour?.UpdateDataSource(new List<IItemContact>
            {
                new ItemContact
                {
                    Label = "Report Bugs",///AdresSede,
                    Value = "Cojucovschi@gmail.com",
                    ContactActivity = "",
                    ContactType = ContactType.None
                },
                new ItemContact
                {
                    Label = Consultant,
                    Value = ConcreteCurrentUser.Name+" "+ConcreteCurrentUser.Surname,
                    ContactType = ContactType.None,
                    ContactActivity = ""
                },
                new ItemContact
                {
                    Label = GreenNumber,
                    Value = "079-227-743",
                    ContactActivity = Call,
                    ContactType = ContactType.Phone
                }
            });

            ListViewYour?.SetBackgroundColor(ColorConstants.WhiteColor, CornerRadiusBackground,
                ColorConstants.WhiteColor, 1.0f);

            if (TitleAccountLabel != null)
            {
                TitleAccountLabel.Text = HeaderText.ToUpperInvariant();
                TitleAccountLabel.SetTextColor(ColorConstants.BlueColor);
                TitleAccountLabel.SetFont(FontsConstant.MontserratSemiBold, FontsConstant.Size15);
            }
        }

        public class ContactCell : ICrossCellViewHolder<IItemContact>
        {
            private readonly ProjectNavigationBaseViewModel _baseViewModel;

            public ContactCell(ProjectNavigationBaseViewModel viewModel)
            {
                _baseViewModel = viewModel;
            }

            [CrossView]
            public IView CellContentRootView { get; set; }

            [CrossView]
            public IText Label { get; set; }

            [CrossView]
            public IText Value { get; set; }

            [CrossView]
            public IText ContactAction { get; set; }

            [CrossView]
            public IView DashView { get; set; }

            public void Bind(IItemContact model)
            {
                if (Label != null)
                    Label.Text = model.Label;

                if (Value != null)
                    Value.Text = model.Value;

                if (Label != null)
                {
                    Label.SetTextColor(ColorConstants.TextGreyColor);
                    Label.SetFont(FontsConstant.MontserratRegular, FontsConstant.Size15);
                }

                if (Value != null)
                {
                    Value.SetTextColor(ColorConstants.TextLightGreyColor);
                    Value.SetFont(FontsConstant.MontserratLight, FontsConstant.Size15);
                }

                DashView?.SetBackgroundColor(ColorConstants.ExtraLightGrey);

                if (model?.ContactType != ContactType.None && !ContactAction.IsNull())
                {
                    ContactAction.Text = model?.ContactActivity;
                    ContactAction.SetTextColor(ColorConstants.WhiteColor);
                    ContactAction.SetFont(FontsConstant.MontserratMedium, FontsConstant.Size15);
                    ContactAction.SetBackgroundColor(ColorConstants.BlueColor, type: RadiusType.Aspect);

                    ContactAction.Tag = model;
                    ContactAction.Click -= HandleEventHandler;
                    ContactAction.Click += HandleEventHandler;
                    DashView.SetBackgroundColor(ColorConstants.WhiteColor);
                }
            }

            public void OnCreate() { }

            private void HandleEventHandler(object sender, EventArgs e)
            {
                if (!((sender as IView)?.Tag is IItemContact model)) return;

                switch (model.ContactType)
                {
                    case ContactType.Phone:
                        _baseViewModel.CallNumber(model.Value);
                        break;
                }
            }
        }
    }
}