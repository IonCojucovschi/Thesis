using System.Collections.Generic;
using Core.Helpers;
using Core.Models.DAL;
using Core.Resources.Colors;
using Core.Resources.Drawables;
using Core.Resources.Locales.Page;
using Core.ViewModels.Base;
using Int.Core.Application.Widget.Contract;
using Int.Core.Application.Widget.Contract.Table;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Int.Core.Extensions;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using System.Threading;
using Core.Helpers.Manager;

namespace Core.ViewModels
{
    public class UserAddedBooksViewModel : ProjectNavigationBaseViewModel
    {
        protected override string HeaderText => RDetailItems.ComunicationHeaderText.ToUpperInvariant();
        protected override HeaderAreaActionType HeaderAreaAction => HeaderAreaActionType.RightSideMenu;

        private IList<IItemComunication> ListData { get; set; }

        [CrossView]
        public IListView ListView { get; protected set; }

        public virtual ICrossCellViewHolder<IItemComunication> CellModel { get; protected set; }

        public override void UpdateData()
        {
            base.UpdateData();

            CellModel = new ComunicationCell(this);
            LoadComunication();
        }

        private void LoadComunication()
        {
            Show();
            ThreadPool.QueueUserWorkItem(_ =>
                ContractManager.Instance.GetCommunicationList(
                    comunicatesList =>
                    {
                        ListData = comunicatesList;
                        OnPropertyChanged(nameof(ListData));
                        ListView?.UpdateDataSource(ListData);
                        Hide();
                    }, errorMessage => ShowError(errorMessage)));

        }

        #region CellBinding

        public class ComunicationCell : ICrossCellViewHolder<IItemComunication>
        {
            private readonly ProjectNavigationBaseViewModel _baseViewModel;

            public ComunicationCell(ProjectNavigationBaseViewModel viewModel)
            {
                _baseViewModel = viewModel;
            }

            [CrossView]
            public IView CellContentRootView { get; set; }

            [CrossView]
            public IText ComunicationText { get; set; }

            [CrossView]
            public IText ComunicationDate { get; set; }

            [CrossView]
            public IImage ShadowImage { get; set; }

            public void OnCreate() { }

            public void Bind(IItemComunication model)
            {
                InitViews();

                if (!ComunicationText.IsNull())
                {
                    ComunicationText.SetTextColor(ColorConstants.DarkColor);
                    ComunicationText.SetFont(FontsConstant.MontserratSemiBold, FontsConstant.Size15);
                    ComunicationText.Text = model.ComunicationText;
                }

                if (!ComunicationDate.IsNull())
                {
                    ComunicationDate.SetTextColor(ColorConstants.BlueColor);
                    ComunicationDate.SetFont(FontsConstant.MontserratLight, FontsConstant.Size15);
                    ComunicationDate.Text = model.ComunicationDate;
                }
            }

            private void InitViews()
            {
                CellContentRootView?.SetBackgroundColor(ColorConstants.WhiteColor, CornerRadiusBackground);
                ShadowImage?.SetImageFromResource(DrawableConstants.ShadowImage);
            }
        }

        #endregion
    }
}