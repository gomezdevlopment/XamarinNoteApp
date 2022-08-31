using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinNoteApp.CustomRenderers;
using XamarinNoteApp.iOS.CustomRenderers;

[assembly: ExportRenderer(typeof(EditorNoUnderline), typeof(EditorNoUnderlineIOS), new[] { typeof(VisualMarker.DefaultVisual) })]

namespace XamarinNoteApp.iOS.CustomRenderers
{
    public class EditorNoUnderlineIOS : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.BackgroundColor = UIColor.FromWhiteAlpha(1, 1);
                Control.Layer.BorderWidth = 0;
            }
        }
    }
}