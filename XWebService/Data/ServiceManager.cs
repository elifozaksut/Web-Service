using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace XWebService
{
	public class ServiceManager
	{
		private HttpClient GetClient()
		{
			HttpClient client = new HttpClient();
			return client;
		}

		public async Task<IEnumerable<user>> GetUsers()
		{
			var client = GetClient();

			var result = await client.GetAsync("http://jsonplaceholder.typicode.com/users");

			var obje = await result.Content.ReadAsStringAsync();

			var resultValue = JsonConvert.DeserializeObject<IEnumerable<user>>(obje);

			return resultValue;
		}

		public async Task<IEnumerable<Post>> GetUserPosts(int id)
		{
			var client = GetClient();
			var result = await client.GetAsync("http://jsonplaceholder.typicode.com/posts?userId="+id);
			var obje = await result.Content.ReadAsStringAsync();
			var resultValue = JsonConvert.DeserializeObject<IEnumerable<Post>>(obje);
			return resultValue;
		}

		public async Task<Post> GetPostInfo(int id)
		{
			var client = GetClient();
			var result = await client.GetAsync("https://jsonplaceholder.typicode.com/posts/" + id);
			var obje = await result.Content.ReadAsStringAsync();
			var resultValue = JsonConvert.DeserializeObject<Post>(obje);
			return resultValue;
		}
		public async Task<IEnumerable<Comment>> GetPostComments(int postId)
		{
			var client = GetClient();
			var result = await client.GetAsync("https://jsonplaceholder.typicode.com/comments?postId=" + postId);
			var obje = await result.Content.ReadAsStringAsync();
			var resultValue = JsonConvert.DeserializeObject<IEnumerable<Comment>>(obje);
			return resultValue;
		}
	}
}
