using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.Dialog.Utilities;

namespace CollectionViewAttempt
{
	public partial class FeaturedArticlesCell : UICollectionViewCell, IImageUpdated
	{
		public static readonly NSString Key = new NSString ("FeaturedArticlesCell");

		public FeaturedArticlesCell() {}

		public FeaturedArticlesCell (IntPtr handle) : base (handle)
		{

		}

		public void UpdateCell (Uri uri)
		{
			this.imageView.Image = ImageLoader.DefaultRequestImage (uri, this);
		}

		public void UpdatedImage (Uri uri)
		{
			imageView.Image = ImageLoader.DefaultRequestImage (uri, this);
		}

		public void setTitle (String title)
		{
			titleLabel.Text = title;
		}

		public void setDetails (String details)
		{
			detailsTextView.Text = details;
		}
	}
}
