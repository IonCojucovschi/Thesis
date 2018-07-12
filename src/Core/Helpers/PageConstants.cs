#if __IOS__
using iOS.Storyboard;
#else
using Droid.Page;

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


        public static string UserAddedBooksCon =>nameof(UserAddedBooks);
        public static string WantReadCon => nameof(WantRead);
        public static string LibraryName => nameof(Library_base);
        public static string BooksCategory => nameof(CategoryBoocks);
        public static string DetailBook => nameof(BoockDetails);
        public static string ReadContentBook => nameof(ReadBook);
        public static string DowloandedBooks => nameof(LocalBooks);
    }
}