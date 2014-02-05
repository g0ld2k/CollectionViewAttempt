using System;
using RestSharp;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

namespace CollectionViewAttempt
{
	public class FeaturedArticlesSingleton
	{
		private static FeaturedArticlesSingleton _instance;
		private String _featuredArticlesJsonUrl = "http://www.vbgov.com/_assets/listdata.ashx?list=Home%20-%20Headlines&caml=%3CWhere%3E%3CEq%3E%3CFieldRef%20Name=%22RoutingEnabled%22%20/%3E%3CValue%20Type=%22Boolean%22%3E1%3C/Value%3E%3C/Eq%3E%3C/Where%3E";
//		private String _featuredArticlesJsonUrl = "http://localhost:8888/vbgov/featuredArticles.json";
		Dictionary<string, FeaturedArticles> _featuredArticles;

		public static FeaturedArticlesSingleton Instance
		{
			get {
				if (_instance == null ) {
					_instance = new FeaturedArticlesSingleton();
				}
				return _instance;
			}
		}

		public List<FeaturedArticles> getArticles() {
			return _featuredArticles.Select(fa => fa.Value).ToList ();
		}

		private FeaturedArticlesSingleton ()
		{
			fetchFeaturedArticles ();
		}

		private void fetchFeaturedArticles()
		{
			var client = new RestClient (_featuredArticlesJsonUrl);
			var request = new RestRequest (Method.GET);
			var response = client.Execute (request);

			_featuredArticles = JsonConvert.DeserializeObject<Dictionary<string, FeaturedArticles>>(response.Content);

			foreach (string key in _featuredArticles.Keys)
			{
				Console.WriteLine(_featuredArticles[key].Title);
			}

		}
	}
}

