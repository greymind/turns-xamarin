using Android.Content;
using Android.Support.V7.Widget;

namespace Greymind.Turns.Android
{
    public class NoScrollLinearLayoutManager : LinearLayoutManager
    {
        public NoScrollLinearLayoutManager(Context context)
            : base(context)
        {
        }

        public override bool CanScrollVertically()
        {
            return false;
        }
    }
}