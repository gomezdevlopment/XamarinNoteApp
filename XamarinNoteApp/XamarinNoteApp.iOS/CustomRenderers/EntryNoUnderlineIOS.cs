using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinNoteApp.CustomRenderers;
using XamarinNoteApp.iOS.CustomRenderers;

[assembly: ExportRenderer(typeof(EntryNoUnderline), typeof(EntryNoUnderlineIOS), new[] { typeof(VisualMarker.DefaultVisual) })]

namespace XamarinNoteApp.iOS.CustomRenderers
{
    public class EntryNoUnderlineIOS : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.BackgroundColor = UIColor.FromWhiteAlpha(1, 1);
                Control.Layer.BorderWidth = 0;
                Control.BorderStyle = UITextBorderStyle.None;
            }
        }
    }
}