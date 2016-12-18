using System;
using Xamarin.Forms;

namespace XWebService
{
	public class MyTabbedPage: TabbedPage
	{
		public MyTabbedPage(user user)
		{
			Children.Add(new UserDetail( user));
			Children.Add(new UserPosts(user.id, user.name));
		}
	}
}
