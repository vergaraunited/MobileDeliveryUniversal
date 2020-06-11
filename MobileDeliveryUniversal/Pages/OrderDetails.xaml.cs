using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileDeliveryGeneral.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileDeliveryUniversal.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrderDetails : ContentPage
	{
        OrderData order;
        float OrdNo;
        public DateTime dteShipDate;
        public OrderDetails ()
		{
			InitializeComponent ();
		}
        public OrderDetails(OrderData od)
        {
            InitializeComponent();
            order = od;
            OrdNo = od.ORD_NO;
        }
        protected override void OnAppearing()
        {
            lblManId.Text = order.ManifestId.ToString();
            lblOrdNo.Text = order.ORD_NO.ToString();
            //lblStopNo.Text = order.DSP_SEQ.ToString();
            lblDlrNo.Text = order.DLR_NO.ToString();
            lblShipDate.Text = dteShipDate.ToString("dddd, MMMM dd, yyyy");

            base.OnAppearing();
        }

        private void OrderDetailSelected(object sender, ItemTappedEventArgs e)
        {
            //var ord = new Orders((IMDMMessage)((ListView)sender).SelectedItem);
            //Navigation.PushAsync(ord);

            //NavigationPage.SetBackButtonTitle(ord, $"Orders for Stop {ord.StopNumber} Truck Code: {ord.TruckCode}");
            //Post tappedPost = (Post)((ListView)sender).SelectedItem; Navigation.PushModalAsync(new MarketItemPage(tappedPost.Id, tappedPost.UserId));

        }
        protected override bool OnBackButtonPressed()
        {
            Navigation.PopAsync(true);
            return true;
        }
    }    
}