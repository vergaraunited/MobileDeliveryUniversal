using MobileDeliveryGeneral.Data;
using MobileDeliveryGeneral.Interfaces.DataInterfaces;
using MobileDeliveryMVVM.ViewModel;
using System;
using System.Collections.Generic;
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
            lblStopNo.Text = stop.DisplaySeq.ToString();
            lblDlrName.Text = stop.DealerName.ToString();
            lblDlrNo.Text = stop.DealerNo.ToString();
            //lblLineCnt.Text = stop.DealerNo.ToString();
            lblManId.Text = stop.ManifestId.ToString();
            lblShipDate.Text = dteShipDate.ToString("dddd, MMMM dd, yyyy");

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

        private void OnCompleteOrder(object sender, EventArgs e)
        {
            var vm = this.BindingContext as OrderVM;
            var lstOD = new List<OrderData>(vm.CompletedOrders);
            var lstBOD = new List<OrderData>(vm.Orders);

            var closeStopPage = new CloseStopPage(stop, lstOD,lstBOD);

            Navigation.PushModalAsync(closeStopPage);

            Navigation.PopAsync(true);

            // NavigationPage.SetBackButtonTitle(closeStopPage, "Proof of Delivery Signature Form: " + vm.DlrName);

        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PopAsync(true);
            return true;
        }
    }
}