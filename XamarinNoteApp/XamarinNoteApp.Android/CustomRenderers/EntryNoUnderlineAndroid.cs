using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinNoteApp.Droid.CustomRenderers;
using XamarinNoteApp.CustomRenderers;

[assembly: ExportRenderer(typeof(EntryNoUnderline), typeof(EntryNoUnderlineAndroid), new[] { typeof(VisualMarker.DefaultVisual) })]

namespace XamarinNoteApp.Droid.CustomRenderers
{
    public class EntryNoUnderlineAndroid : EntryRenderer
    {
        public EntryNoUnderlineAndroid(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
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