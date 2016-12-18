using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XWebService
{
	public partial class PostsPage : ContentPage
	{
		public PostsPage(int id)
		{
			InitializeComponent();
			BindData(id);
			BindComment(id);
		}
		private async void BindData(int id)
		{
			ServiceManager manager = new ServiceManager();
			var post = await manager.GetPostInfo(id);
			lblBody.BindingContext = post;
			lblTitle.BindingContext = post;
		}
		private async void BindComment(int id)
		{
			ServiceManager manager = new ServiceManager();
			var comments = await manager.GetPostComments(id);
			lstComments.BindingContext = comments;
		}
	}
}
