using System;
using Xamarin.Forms;

namespace XWebService
{
	public class UserPage: ContentPage
	{
		public UserPage(user user)
		{
			var lblName = new Label
			{
				Text = user.name,
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions= LayoutOptions.CenterAndExpand,
				HorizontalTextAlignment= TextAlignment.Center
			};


			var stkUser = new StackLayout
			{
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Padding=20,
				Children =
				{
					new Image
					{
						Source="profile.png",
						Aspect= Aspect.AspectFit,
						HeightRequest= 50,
						WidthRequest=50
					},
					new Label
					{
						Text="Profilim"
					}
				}
			};
			var stkUserGesture = new TapGestureRecognizer();
			stkUserGesture.Tapped += (sender, e) =>
			{
				Navigation.PushAsync(new UserDetail(user));
			};
			stkUser.GestureRecognizers.Add(stkUserGesture);

			var stkPosts = new StackLayout
			{
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Padding=20,
				Children =
				{
					new Image
					{
						Source="post.png",
						Aspect= Aspect.AspectFit,
						HeightRequest= 50,
						WidthRequest=50
					},
					new Label
					{
						Text="Postlar"
					}
				}
			};
			var stkPostGesture = new TapGestureRecognizer();
			stkPostGesture.Tapped += (sender, args) =>
			{
				Navigation.PushAsync(new UserPosts(user.id, user.name));
			};
			stkPosts.GestureRecognizers.Add(stkPostGesture);

			var stkAlbums = new StackLayout
			{
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Padding = 20,
				Children =
				{
					new Image
					{
						Source="album.png",
						Aspect= Aspect.AspectFit,
						HeightRequest= 50,
						WidthRequest=50
					},
					new Label
					{
						Text="Albümler"
					}
				}
			};
			var stkToDo = new StackLayout
			{
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Padding= 20,
				Children =
				{
					new Image
					{
						Source="todo.png",
						Aspect= Aspect.AspectFit,
						HeightRequest= 50,
						WidthRequest=50
					},
					new Label
					{
						Text="Yapılacaklar"
					}
				}
			};

			var layout = new RelativeLayout();

			layout.Children.Add(lblName, Constraint.RelativeToParent((parent) => { return parent.Width / 4; }), 
			                    Constraint.Constant(25)
			                    );
			
			layout.Children.Add(stkUser, Constraint.Constant(0), Constraint.RelativeToView(lblName, (parent, sibling) =>
			{ return sibling.Y + sibling.Height + 20; }),
			                    Constraint.RelativeToParent((parent) => { return parent.Width / 2; }));

			layout.Children.Add(stkPosts, Constraint.RelativeToView(stkUser, (parent, sibling) =>
			{ return sibling.X + sibling.Width; }), Constraint.RelativeToView(stkUser, (parent, sibling) =>
			{ return sibling.Y; }),
			                   Constraint.RelativeToParent((parent) => { return parent.Width / 2; }));

			layout.Children.Add(stkAlbums, Constraint.Constant(0),
			                    Constraint.RelativeToView(stkUser, (parent, sibling) =>{return sibling.Y + sibling.Height;}),
			                   Constraint.RelativeToParent((parent) => { return parent.Width / 2; }));

			layout.Children.Add(stkToDo, Constraint.RelativeToView(stkAlbums, (parent, sibling) =>
			{ return sibling.X + sibling.Width; }), Constraint.RelativeToView(stkPosts, (parent, sibling) =>
			 { return sibling.Y + sibling.Height; }),
			                   Constraint.RelativeToParent((parent) => { return parent.Width / 2; }));

			Content = layout;

		}
	}
}
