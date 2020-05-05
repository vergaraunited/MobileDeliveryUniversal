using System;
using MobileDeliveryGeneral.Interfaces.DataInterfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileDeliveryGeneral.Data;
using System.Globalization;

namespace MobileDeliveryUniversal.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Stops : ContentPage
	{
        #region locals
        string TRK_CDE;
        public DateTime SHIP_DTE;
        TruckData truck;

        #endregion
        public Stops(TruckData td)
        {
            InitializeComponent();
            truck=td;
            SHIP_DTE = td.SHIP_DTE;
            lblShipDate.Text = td.SHIP_DTE.ToString("D",
                  CultureInfo.CreateSpecificCulture("en-US"));
        }
        public Stops()
		{
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            if(truck != null )
                lblManId.Text = truck.ManifestId.ToString();
            base.OnAppearing();

        }
        private void StopSelected(object sender, ItemTappedEventArgs e)
        {
            if (((ListView)sender).SelectedItem == null)
                return;
            var stpData = (StopData)((ListView)sender).SelectedItem;

            var ord = new Orders(stpData);
            ord.dteShipDate = SHIP_DTE;
            // var orderPage = new Orders(ord)
            ((ListView)sender).SelectedItem = null;
            Navigation.PushAsync(ord);

            NavigationPage.SetBackButtonTitle(ord, $"Orders for Stop {stpData.DisplaySeq} Truck Code: {stpData.TruckCode} ManifestId: {stpData.ManifestId}");
            //Post tappedPost = (Post)((ListView)sender).SelectedItem; Navigation.PushModalAsync(new MarketItemPage(tappedPost.Id, tappedPost.UserId));

        }
    }
}