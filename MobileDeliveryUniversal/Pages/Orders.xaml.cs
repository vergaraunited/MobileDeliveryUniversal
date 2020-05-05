using MobileDeliveryGeneral.Data;
using MobileDeliveryGeneral.Interfaces.DataInterfaces;
using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileDeliveryUniversal.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Orders : ContentPage
	{
        #region locals
        StopData stop;
        public DateTime dteShipDate;
        #endregion

        public Orders(StopData sd)
        {
            InitializeComponent();
            stop = sd;
        }

        protected override void OnAppearing()
        {
            lblManId.Text = stop.ManifestId.ToString();
            lblStopNo.Text = stop.DisplaySeq.ToString();
            lblDlrName.Text = stop.DealerName.ToString();
            lblDlrNo.Text = stop.DealerNo.ToString();
            //lblLineCnt.Text = stop.DealerNo.ToString();

            lblShipDate.Text = dteShipDate.ToString("D", CultureInfo.CreateSpecificCulture("en-US"));

            base.OnAppearing();
        }
        public Orders ()
		{
			InitializeComponent ();
            stop = new StopData() { ManifestId = 0 };
		}
        private void OrderSelected(object sender, ItemTappedEventArgs e)
        {
            if (((ListView)sender).SelectedItem == null)
                return;
            var ordData = (OrderData)((ListView)sender).SelectedItem;
            var orderDetailsPage = new OrderDetails(ordData);
            ((ListView)sender).SelectedItem = null;
            Navigation.PushAsync(orderDetailsPage);
            NavigationPage.SetBackButtonTitle(orderDetailsPage, "Order Details for Order Number " + ordData.ORD_NO);
        }

        private void OnCompleteStop(object sender, EventArgs e)
        {
            var closeStopPage = new CloseStopPage();
            //closeStopPage.BindingContext = e.SelectedItem as Contact;
            Navigation.PushModalAsync(closeStopPage);
        }
    }
}