﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinNoteApp.Views.NewNote.UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToolbarFontSizeItem : FlexLayout
    {
        public ToolbarFontSizeItem()
        {
            InitializeComponent();
        }
    }
}