using System.ComponentModel;
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
                Control.TextAlignment = UITextAlignment.Center;
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == EditorNoUnderline.AlignmentProperty.PropertyName)
            {
                var editor = sender as EditorNoUnderline;
                if (editor.Alignment == 0)
                    Control.TextAlignment = UITextAlignment.Left;
                else if (editor.Alignment == 1)
                    Control.TextAlignment = UITextAlignment.Center;
                else
                    Control.TextAlignment = UITextAlignment.Right;
                Control.SetNeedsDisplay();
            }
        }
    }
}