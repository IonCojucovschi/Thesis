using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models.DAL.Contracts;
using Core.Models.DAL.Contracts.Documents;
using Core.Models.DAL.Documents;
using Core.Services.MockServices.Interfaces;
using Int.Core.Network.Singleton;
using Splat;
using static Core.Models.DAL.Dashboard.ItemDashboard;
using Core.Models.DAL;
using Int.Core.Extensions;
using Core.Resources.Colors;
using Core.Resources.Locales.Page;
using I18NPortable;

namespace Core.Helpers.Manager
{
    public class ContractManager : Singleton<ContractManager>
    {
        private IList<IItemDocument> _loadedDocsItems;
        private IList<IItemProducts> _loadedProducts;
        
        private string SignatureDateLabel => @RDetailItems.ProductSignatureDateLabel;
        private string AgentLabel => @RDetailItems.ProductAgentLabel;
        private string TechnicValue => @RDetailItems.ProductTechnicValue;
        private string AdministrationLabel => @RDetailItems.ProductAdministration;
        private string AcceptenceLabel => @RDetailItems.ProductAcceptence;
        private string TechnicLabel => @RDetailItems.ProductTechnicaLabel;

        private string NewStatus => @RStatusProduct.NewStatus;
        private string SuspendedStatus => @RStatusProduct.SuspendedStatus;
        private string WorkingStatus => @RStatusProduct.WorkingStatus;
        private string CompletedStatus => @RStatusProduct.CompletedStatus;
        private string KoStatus => @RStatusProduct.KoStatus;
        private string ArchivedStatus => @RStatusProduct.ArchivedStatus;
        private string LegalStatus => @RStatusProduct.LegalStatus;
        private string LandscapingStatus => @RStatusProduct.LandscapingStatus;
        private string StandByStatus => @RStatusProduct.StandByStatus;
        private string NoDataStatus => @RStatusProduct.EmptyStatus;


        private static IContractService GetService =>
            Locator.Current.GetService<IContractService>(App.Instance.IsMock
                ? App.ServiceContractMock
                : App.ServiceContract);

        private static IDocumentService GetServiceDoc =>
            Locator.Current.GetService<IDocumentService>(App.Instance.IsMock
                ? App.ServiceContractMock
                : App.ServiceContract);

        private static IComunicationService GetServiceComunicates =>
            Locator.Current.GetService<IComunicationService>(App.Instance.IsMock
                ? App.ServiceContractMock
                : App.ServiceContract);


        public void GetProductsList(Action<IList<IItemProducts>> success, Action<string> error)
        {
            _loadedProducts = new List<IItemProducts>();

            GetContracts(
                contracts =>
                {
                    foreach (var item in contracts)
                    {
                        if (item.contract?.contract_product == null) continue;
                        var product = item.contract.contract_product?.FirstOrDefault();
                        var accetazioneSubModul = item.contract.contract_moduls?.ACCETTAZIONE?.sub_moduls?.FirstOrDefault();
                        var accetazioneTask = accetazioneSubModul?.tasks?.FirstOrDefault();
                        var amministrazioneSubModul = item.contract.contract_moduls.AMMINISTRAZIONE?.sub_moduls?.FirstOrDefault();
                        var amministrazioneTask = amministrazioneSubModul?.tasks?.FirstOrDefault();
                        var productDocuments = item.contract.contract_document?.FirstOrDefault();

                        string translatedAccetazioneStatus = null;
                        string translatedAmministrazioneStatus = null;

                        if (accetazioneTask != null)
                            translatedAccetazioneStatus = ProductStatus(accetazioneTask.status);

                        if (amministrazioneTask != null)
                            translatedAmministrazioneStatus = ProductStatus(amministrazioneTask.status);

                        _loadedProducts.Add(new ItemProducts
                        {
                            LabelProduct = product.product_name,
                            ValueProduct = product.product_code,
                            Products = new List<IProduct>
                            {   new Product
                                {
                                    LabelDescription = "NDA",
                                    ValueDescription = item?.contract?.contract_nda_number ?? NoDataStatus.UpperCaseWords(),
                                    StatusColor = StatusNullVerification(item?.contract?.contract_nda_number)
                                },
                                new Product
                                {
                                    LabelDescription = SignatureDateLabel,
                                    ValueDescription = item.contract.contract_signature_date.UnixTimeStampToDateTime().ToString("dd/MM/yyyy") ?? NoDataStatus.UpperCaseWords(),
                                    StatusColor = StatusNullVerification(item.contract.contract_signature_date)
                                },
                                new Product
                                {
                                    LabelDescription =  AgentLabel,
                                    ValueDescription = item.contract.contract_agent_name ?? "",
                                    StatusColor = StatusNullVerification(item.contract.contract_agent_name)
                                },
                                new Product
                                {
                                    LabelDescription = AcceptenceLabel,
                                    ValueDescription = translatedAccetazioneStatus ?? NoDataStatus.UpperCaseWords(),
                                    StatusColor = accetazioneTask?.status_color ?? ColorConstants.RedColor
                                },
                                new Product
                                {
                                    LabelDescription = TechnicLabel,
                                    ValueDescription = TechnicValue.UpperCaseWords(),
                                    StatusColor = item.contract.contract_moduls?.TECNICO?.status_color ?? ColorConstants.LightBlue
                                },
                                new Product
                                {
                                    LabelDescription = AdministrationLabel,
                                    ValueDescription = translatedAmministrazioneStatus ?? NoDataStatus.UpperCaseWords(),
                                    StatusColor = amministrazioneTask?.status_color ?? ColorConstants.RedColor
                                },
                                new Product
                                {
                                    FileName =  productDocuments?.document_type.UpperCaseWords() ?? NoDataStatus.UpperCaseWords(),
                                    FileStatus = productDocuments?.document_status ?? 3,
                                    FilePath = productDocuments?.document_path ?? ""
                                }
                            }
                        });
                    }
                    success?.Invoke(_loadedProducts);
                }, error);
        }

        public void GetDocumentsList(Action<IList<IItemDocument>> success, Action<string> error)
        {
            GetDocuments(
                docs =>
                {
                     _loadedDocsItems = docs.GroupBy(contract => contract.DocumentContractId).Select(group =>
                    {
                        var itemDocument = new ItemDocument
                        {
                            Label = "PDA",
                            Value = group.Key.ToString(),
                            Documents = new List<IDocument>()
                        };

                        foreach (var doc in group)
                        {
                            var docFile = new Document
                            {
                                Name = doc.DocumentPath.Split('/').LastOrDefault(),
                                Path = doc.DocumentPath
                            };
                            itemDocument.Documents.Add(docFile);
                        }

                        return itemDocument;
                    }).ToList<IItemDocument>();
                    success?.Invoke(_loadedDocsItems);
                }, error);
        }

        public void GetCommunicationList(Action<IList<IItemComunication>> success, Action<string> error)
        {
            GetComunicates(
                comunicates =>
                {
                    var loadedComunicatesItems = comunicates.Select(comunicate =>
                    new ItemComunication
                    {
                        ComunicationText = comunicate.ComunicationNote,
                        ComunicationDate = comunicate.ComunicationDate.UnixTimeStampToDateTime().ToString("dd/MM/yyyy")
                    }).ToList<IItemComunication>();
                    success?.Invoke(loadedComunicatesItems);
                }, error);
        }

        #region serivce

        private void GetContracts(Action<IList<Datum>> success, Action<string> error)
        {
            GetService.GetContracts(success, error);
        }

        private void GetDocuments(Action<IList<BeItemDocument>> success, Action<string> error)
        {
            GetServiceDoc.GetDocuments(success, error);
        }

        private void GetComunicates(Action<IList<BeComunicationModel>> success, Action<string> error)
        {
            GetServiceComunicates.GetCommunication(success, error);
        }

        private string ProductStatus(int statusId)
        {
            var translatedSrting = "";
            switch (statusId)
            {
                case 0:
                    translatedSrting = NewStatus.UpperCaseWords();
                    break;
                case 1:
                    translatedSrting = SuspendedStatus.UpperCaseWords();
                    break;
                case 2:
                    translatedSrting = WorkingStatus.UpperCaseWords();
                    break;
                case 3:
                    translatedSrting = CompletedStatus.UpperCaseWords();
                    break;
                case 4:
                    translatedSrting = KoStatus.UpperCaseWords();
                    break;
                case 5:
                    translatedSrting = ArchivedStatus.UpperCaseWords();
                    break;
                case 6:
                    translatedSrting = LegalStatus.UpperCaseWords();
                    break;
                case 7:
                    translatedSrting = LandscapingStatus.UpperCaseWords();
                    break;
                case 8:
                    translatedSrting = StandByStatus.UpperCaseWords();
                    break;
            }

            return translatedSrting;
        }

        private static string StatusNullVerification(object taskModule)
        {
            return taskModule != null ? ColorConstants.DarkColor : ColorConstants.RedColor;
        }
        #endregion
    }
}