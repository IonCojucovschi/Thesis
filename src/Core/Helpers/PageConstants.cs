#if __IOS__
using iOS.Storyboard;
#else
using Droid.Page;
using Droid.Page.Library;

#endif

namespace Core.Helpers
{
    public static class PageConstants
    {
        public static string LoginName => nameof(Login);
        public static string DashboardName => nameof(Dashboard);
        public static string AccountName => nameof(Account);
        public static string AccountDescriptionsName => nameof(AccountDescriptions);
        public static string ContactName => nameof(Contact);
        public static string ComunicationName =>"";///nameof(Comunication);
        public static string ProductName => nameof(Product);
        public static string LibraryName => nameof(Library);
    }
}