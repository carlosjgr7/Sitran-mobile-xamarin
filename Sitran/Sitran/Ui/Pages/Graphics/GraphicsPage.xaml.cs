using Sitran.Model;
using Sitran.Ui.ViewModel;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Entry = Microcharts.ChartEntry;

namespace Sitran.Ui.Pages
{
    public partial class GraphicsPage : ContentPage
    {
        public bool controlviewmenu { get; set; } = false;

        private async void Show()
        {
            _ = TitleTxt.FadeTo(0);
            _ = MenuItemsView.FadeTo(1);
            await MainMenuView.RotateTo(0, 300, Easing.BounceOut);
        }

        private async void Hide()
        {
            _ = TitleTxt.FadeTo(1);
            _ = MenuItemsView.FadeTo(0);
            await MainMenuView.RotateTo(-90, 300, Easing.BounceOut);
        }

        private void ShowMenu(object sender, EventArgs e)
        {
            if (controlviewmenu)
            {
                Hide();
            }
            else
            {
                Show();

            }
            controlviewmenu = !controlviewmenu;

        }

        private async void MenuTapped(object sender, EventArgs e)
        {
            var text = ((sender as StackLayout).BindingContext as Menuu).Title;
            (this.BindingContext as GraphicsViewModel).Organizacion = text;

            if (text.Equals("Sitran"))
                (this.BindingContext as GraphicsViewModel).BackColorOrg = "#322463";

            if (text.Equals("1000Pagos"))
                (this.BindingContext as GraphicsViewModel).BackColorOrg = "#0E0C5E";

            if (text.Equals("CarroPago"))
                (this.BindingContext as GraphicsViewModel).BackColorOrg = "#DE5C37";

            if (text.Equals("LibrePago"))
                (this.BindingContext as GraphicsViewModel).BackColorOrg = "#3C88E4";

            Hide();
        }




        public GraphicsPage()
        {
            InitializeComponent();
            BindingContext = new GraphicsViewModel(Navigation);

        }


    }

}