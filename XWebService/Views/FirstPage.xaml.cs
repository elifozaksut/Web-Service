using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XWebService
{
	public partial class FirstPage : ContentPage
	{
		public FirstPage()
		{
			InitializeComponent();

			BindData();
		}

		private async void BindData()
		{
			ServiceManager manager = new ServiceManager();
			lstItems.BindingContext = await manager.GetUsers();
		}

		public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var lst = (ListView)sender;
			if (lst.SelectedItem == null)
				return;
			var selected = (user)e.SelectedItem;
			//Navigation.PushAsync(new UserPosts(selected.id, selected.name));
			//Navigation.PushAsync(new UserDetail(selected));
			//Navigation.PushAsync(new MyTabbedPage(selected));
			Navigation.PushAsync(new UserPage(selected));
			lst.SelectedItem = null;


		}
	}
}
