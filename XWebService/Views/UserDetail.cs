using System;
using Xamarin.Forms;

namespace XWebService
{
	public class UserDetail: ContentPage
	{
		public UserDetail(user user)
		{
			this.Title = "Detay";
			var lblName = new Label { Text = user.name, FontAttributes = FontAttributes.Bold};
			var lblUserName = new Label { Text = user.username };
			var lblEmail = new Label { Text = user.email };
			StackLayout stk = new StackLayout()
			{
				Orientation =StackOrientation.Vertical,
				HorizontalOptions= LayoutOptions.CenterAndExpand
			};
			stk.Children.Add(lblName);
			stk.Children.Add(lblUserName);
			stk.Children.Add(lblEmail);

			Content = stk;


		}
	}
}
