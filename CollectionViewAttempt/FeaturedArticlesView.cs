using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace CollectionViewAttempt
{
	public partial class FeaturedArticlesView : UICollectionViewController
	{
		static NSString cellId = new NSString ("FeaturedArticlesCell");
		List<FeaturedArticles> fa;
		FeaturedArticlesSingleton fas;

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public FeaturedArticlesView (IntPtr handle ) : base (handle)
		{
			fa = new List<FeaturedArticles> ();
			fas = FeaturedArticlesSingleton.Instance;
			fa = fas.getArticles ();
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
			articleCell.setTitle (fa [indexPath.Row].Title);
			articleCell.setDetails (fa [indexPath.Row].Description);

			return articleCell;
		}
	}
}

