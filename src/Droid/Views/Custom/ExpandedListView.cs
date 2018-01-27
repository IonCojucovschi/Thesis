using Android.Content;
using Android.Views;
using Android.Widget;

namespace Droid.Views.Custom
{
    public class ExpandedListView : ListView
    {
        public ExpandedListView(Context context) : base(context) { }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            var expandSpec = MeasureSpec.MakeMeasureSpec(int.MaxValue >> 2,
                    MeasureSpecMode.AtMost);
            base.OnMeasure(widthMeasureSpec, expandSpec);
        }
    }
}