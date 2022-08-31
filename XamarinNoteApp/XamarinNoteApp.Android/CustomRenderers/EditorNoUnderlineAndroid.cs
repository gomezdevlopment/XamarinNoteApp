using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinNoteApp.CustomRenderers;
using XamarinNoteApp.Droid.CustomRenderers;

[assembly: ExportRenderer(typeof(EditorNoUnderline), typeof(EditorNoUnderlineAndroid), new[] { typeof(VisualMarker.DefaultVisual) })]

namespace XamarinNoteApp.Droid.CustomRenderers
{
    public class EditorNoUnderlineAndroid : EditorRenderer
    {
        public EditorNoUnderlineAndroid(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Background = null;
                Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
            }
        }
    }
}