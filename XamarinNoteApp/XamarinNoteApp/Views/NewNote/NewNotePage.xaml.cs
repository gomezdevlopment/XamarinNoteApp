using Xamarin.Forms;
using XamarinNoteApp.CustomRenderers;
using XamarinNoteApp.ViewModels;

namespace XamarinNoteApp.Views.NewNote
{
    public partial class NewNotePage : ContentPage
    {
        public NewNoteViewModel _newNoteViewModel;

        public NewNotePage(NewNoteViewModel newNoteViewModel)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            _newNoteViewModel = newNoteViewModel;
            editor.SetBinding(EditorNoUnderline.AlignmentProperty, "TextAlignment");
        }
    }
}