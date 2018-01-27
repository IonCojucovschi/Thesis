using Android.Content;
using Android.Util;
using Android.Views;
using Int.Droid.Factories.Adapter.RecyclerView;

namespace Droid.Views.Customm
{
    public class ExpandedListView : BaseRecyclerView
    {
        public ExpandedListView(Context context) : base(context)
        {
        }

        public ExpandedListView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            var expandSpec = MeasureSpec.MakeMeasureSpec(int.MaxValue >> 2,
                MeasureSpecMode.AtMost);
            base.OnMeasure(widthMeasureSpec, expandSpec);
        }
    }
}