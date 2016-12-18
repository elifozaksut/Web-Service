using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XWebService
{
	public partial class UserPosts : ContentPage
	{
		public UserPosts(int id, string name)
		{
			this.Title = name+"/Postlar";
			InitializeComponent();
			BindData(id);
		}
		private async void  BindData(int id)
		{
			ServiceManager manager = new ServiceManager();
			lstPosts.BindingContext = await manager.GetUserPosts(id);
		}
		public void OnSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var lst = (ListView)sender;
			var selected = (Post)e.SelectedItem;
			if (lst.SelectedItem != null)
			{
				if (selected != null)
				{
					Navigation.PushAsync(new PostsPage(selected.id));
				}
				lst.SelectedItem = null;
			}
		}
	}
}
