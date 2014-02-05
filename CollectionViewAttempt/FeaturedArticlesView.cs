using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace CollectionViewAttempt
{
	public partial class FeaturedArticlesView : UICollectionViewController
	{
		static NSString cellId = new NSString ("ArticleCell");
		List<FeaturedArticles> fa;
		FeaturedArticlesSingleton fas;

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public FeaturedArticlesView ()
			: base (UserInterfaceIdiomIsPhone ? "FeaturedArticlesView_iPhone" : "FeaturedArticlesView_iPad", null)
		{
		}

		public FeaturedArticlesView (UICollectionViewLayout layout) : base (layout)
		{
			fa = new List<FeaturedArticles> ();
			fas = FeaturedArticlesSingleton.Instance;
			fa = fas.getArticles ();

			CollectionView.ContentInset = new UIEdgeInsets (10, 10, 10, 10);
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
			CollectionView.RegisterClassForCell (typeof(FeaturedArticlesCell), cellId);
		}

		public override int GetItemsCount (UICollectionView collectionView, int section)
		{
			return fa.Count;
		}

		public override UICollectionViewCell GetCell (UICollectionView collectionView, NSIndexPath indexPath)
		{
			var articleCell = (FeaturedArticlesCell)collectionView.DequeueReusableCell (cellId, indexPath);
			string articleImageUrl = fa [indexPath.Row].EncodedAbsoluteURL;

			articleCell.UpdateCell (new Uri (articleImageUrl));

			return articleCell;
		}
	}
}

