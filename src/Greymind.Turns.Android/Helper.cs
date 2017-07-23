using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;

namespace Greymind.Turns.Android
{
    public static class Helper
    {
        public static void TintDrawable(Resources resources, Drawable drawable)
        {
            drawable?.Mutate();
            drawable?.SetColorFilter(resources.GetColor(Resource.Color.GreymindWhite), PorterDuff.Mode.SrcIn);
        }
    }
}