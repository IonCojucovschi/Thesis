using System;
using Int.Core.Application.Window.Contract;
using Int.Core.Data.MVVM.Contract;
using Int.Core.Extensions;
using RestSharp;

namespace Core.Extensions
{
    public static class Extensions
    {
        public static IRestRequest AddToken(this IRestRequest request, string token)
        {
            return request.AddHeader("Authorization", $"Bearer {token}");
        }

        public static void GoPage(this IBaseViewModel @this, string page)
        {
            if (!page.IsNullOrWhiteSpace())
                @this.GoPage(Type.GetType(App.Instance.NameSpacePage() + "." + page));
        }

        public static string SelectorTransparence(this string @this, string transparence)
        {
            return @this.Replace("#", "#" + transparence);
        }

        public static void GetWindow<TWindow, TViewModel>(this IBaseViewModel @this)
           where TWindow : IPopupWindow, new() where TViewModel : IBaseViewModel
        {
            @this.GetWindow<TWindow>(App.Instance.GetView(typeof(TViewModel)));
        }
    }
}